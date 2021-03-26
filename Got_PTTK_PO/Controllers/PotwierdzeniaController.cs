using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Got_PTTK_PO.Data;
using Got_PTTK_PO.Models;
using Got_PTTK_PO.Views;
using Got_PTTK_PO.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Got_PTTK_PO.Controllers
{
    public class PotwierdzeniaController : Controller
    {
        
        private readonly IRepository repository;
        public PotwierdzeniaController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View("PrzodownikPotwierdzanie");
        }

        public IActionResult DoPotwierdzenia(string which = "all")
        {
            string userId = repository.Users.FirstOrDefault(us => us.UserName == User.Identity.Name).Id;
            var ekspert = repository.EksperciGorski.FirstOrDefault(us => us.IdUz == userId);
            if (repository.Legitymacje.FirstOrDefault(l => l.NumerL == ekspert.NumerL).DataWaznosci < DateTime.Now)
            {
                ViewBag.Komunikat = "Brak ważnej legitymacji! Brak dostępu!";

                return PartialView("DoPotwierdzenia"); //WIdok bez legitymacji
            }

            ViewBag.Paczka = GetFragmenty(which);
            ViewBag.Potwierdzono = TempData["Potwierdzono"]?.ToString();
            ViewBag.Odrzucono = TempData["Odrzucono"]?.ToString();
            ViewBag.Brak = TempData["Brak"]?.ToString();
            return PartialView("DoPotwierdzenia");
        }

        public IEnumerable<IGrouping<Turysta, FragmentWycieczki>> GetFragmenty(string which = "all")
        {
            string userId = repository.Users.FirstOrDefault(us => us.UserName == User.Identity.Name).Id;
            var fragments = (from f in repository.FragmentWycieczki.ToList().Where(f => FiltrujFragmenty(which,f,userId))
                             .Where(f => (!f.CzyZaliczony && f.DoZaliczenia))
                             join w in repository.Wycieczka.ToList() on f.IdW equals w.IdW
                             join k in repository.Ksiazeczka.ToList() on w.NumerK equals k.NumerK
                             join t in repository.Turysta.ToList() on k.IdUz equals t.IdUz
                             group f by t into grupka
                             select grupka);

            return fragments;
        }

        public bool FiltrujFragmenty (string mode,FragmentWycieczki f, string IdUz)
            {
                switch (mode)
                {
                    case "all": return f.IdUz == null || f.IdUz == IdUz;
                    case "anybodys": return f.IdUz == null;
                    case "my": return f.IdUz == IdUz;
                    default: return f.IdUz == null || f.IdUz == IdUz;
                }
            }
        public IActionResult PrzodownikPotwierdzanie()
        {
            return View();
        }

        public async Task<IActionResult> Potwierdz(List<string> fragmenty_id) // "IdW_NumerFW"
        {
            if (fragmenty_id.Count == 0)
            {
                TempData["Brak"] = 1;
                return RedirectToAction("DoPotwierdzenia");
            }
            var fragmenty = new List<FragmentWycieczki>();
            var idWycieczek = new List<int>();
            foreach (var fragment in fragmenty_id)
            {
                var values = fragment.Split("_");
                idWycieczek.Add(Convert.ToInt32(values[0]));
                fragmenty.Add(repository.FragmentWycieczki.FirstOrDefault(f => f.IdW == Convert.ToInt32(values[0]) && f.NumerFW == Convert.ToInt32(values[1])));
            }

            foreach (var fragment in fragmenty)
            {
                fragment.CzyZaliczony = true;
                fragment.DoZaliczenia = false;
                fragment.PowodOdrzucenia = null;
                repository.SaveChangesAsync();
            }
            foreach (var wycieczka in idWycieczek)
            {
                if (repository.FragmentWycieczki.Where(f => f.IdW == wycieczka).ToList().All(f => f.CzyZaliczony))
                {
                    repository.Wycieczka.FirstOrDefault(w => w.IdW == wycieczka).CzyZaliczona = true;
                    repository.SaveChangesAsync();

                }
                
            }
            
            TempData["Potwierdzono"] = 1;
            return RedirectToAction("DoPotwierdzenia");
        }
        public void SetCookie(string key, string value, int? numberOfSeconds = null)
        {
            CookieOptions option = new CookieOptions();
            if (numberOfSeconds.HasValue)
                option.Expires = DateTime.Now.AddSeconds(numberOfSeconds.Value);
            Response.Cookies.Append(key, value, option);
        }

        public async Task<IActionResult> Odrzuc(List<string> fragmenty_id, string powod) // "IdW_NumerFW"
        {
            if (fragmenty_id.Count == 0)
            {
                TempData["Brak"] = 1;
                return RedirectToAction("DoPotwierdzenia");
            }
            var fragmenty = new List<FragmentWycieczki>();
            foreach (var fragment in fragmenty_id)
            {
                var values = fragment.Split("_");
                fragmenty.Add(repository.FragmentWycieczki.FirstOrDefault(f => f.IdW == Convert.ToInt32(values[0]) && f.NumerFW == Convert.ToInt32(values[1])));
            }

            foreach (var fragment in fragmenty)
            {
                fragment.DoZaliczenia = false;
                fragment.PowodOdrzucenia = powod;
                repository.SaveChangesAsync();
            }
            TempData["Odrzucono"] = 1;
            return RedirectToAction("DoPotwierdzenia");
            
        }

    }
}

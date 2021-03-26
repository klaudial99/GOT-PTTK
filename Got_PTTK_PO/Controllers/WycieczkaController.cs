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
    public class WycieczkaController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRepository repository;
        public WycieczkaController(IRepository context, IHostingEnvironment hostingEnvironment)
        {
            repository = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Wycieczka
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Turysta"))
            {
                string userId = repository.Users.FirstOrDefault(us => us.UserName == User.Identity.Name).Id;
                ViewBag.Ksiazeczka = repository.Ksiazeczka.FirstOrDefault(ks => ks.IdUz.Equals(userId)).NumerK;

            }
            //ViewBag.RowsList = MultiAddRow.Fragmenty;
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            ViewData["NazwaT"] = new SelectList(repository.Trasa, "NazwaT", "NazwaT");
            return View();
        }

        // GET: Wycieczka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await repository.Wycieczka
                .FirstOrDefaultAsync(m => m.IdW == id);
            ViewData["Trasy"] = repository.FragmentWycieczki
                .Where(p => p.IdW == id).Join(repository.Trasa, cs => new { cs.NazwaT, cs.NazwaPP, cs.NazwaPK}, c => new { c.NazwaT, c.NazwaPP, c.NazwaPK }, (cs, c) => c).ToList();
            if (wycieczka == null)
            {
                return NotFound();
            }

            return View(wycieczka);
        }

        // GET: Wycieczka/Create
        public IActionResult Create()
        {

            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            return View();
        }

        public async Task<IActionResult> OtworzOknoWyslania(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await repository.Wycieczka
                .FirstOrDefaultAsync(m => m.IdW == id);
            if (wycieczka.CzyZaliczona)
            {
                ViewBag.Zaliczona = true;
                return PartialView("_PartialWyslij");
            }
            ViewData["Przodownicy"] = repository.EksperciGorski.Select(e => new SelectListItem() { Text = e.Imie + " " + e.Nazwisko, Value = e.IdUz.ToString() })
                .ToList();
            ViewBag.Zaliczona = false;
            ViewBag.IdW = id;
            return PartialView("_PartialWyslij");
        }
        [HttpPost]
        public async Task<IActionResult> Wyslij(int idW, string idP)
        {
            List<string> uprawnienia = new List<string>();
            var ekspert = repository.EksperciGorski.FirstOrDefault(e => e.IdUz == idP);
            if (ekspert!=null)
            {
                uprawnienia = repository.Legitymacja_ObszarGorski.Where(l => l.NumerL == ekspert.NumerL).Select(l => l.NazwaOG).ToList();

            }
            var fragmenty = repository.FragmentWycieczki.Where(f => f.IdW == idW).ToList();
            Dictionary<string, string> regiony = new Dictionary<string, string>();
            foreach (var fragment in fragmenty)
            {
                var region = repository.Punkt_RegionGorski.Where(r => r.NazwaP == fragment.NazwaPP || r.NazwaP == fragment.NazwaPK)
                                            .GroupBy(d => d.IdRG)
                                            .Select(group => new {
                                                Id = group.Key,
                                                Count = group.Count()
                                            }).FirstOrDefault(g => g.Count == 2).Id;
                //regiony[fragment.NazwaT + fragment.NazwaPP + fragment.NazwaPK] = region;
                var obszar = repository.RegionGorski.FirstOrDefault(r => r.IdRG == region).NazwaOG;
                fragment.DoZaliczenia = true;
                if (idP == "DOWOLNY" || !uprawnienia.Contains(obszar))
                    fragment.IdUz = null;
                else
                    fragment.IdUz = idP;
                repository.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DodajDowod(IFormFile new_image, string fragment_id)
        {
            var split_id = fragment_id.Split("_");
            var fragment = repository.FragmentWycieczki.FirstOrDefault(f => f.IdW == Convert.ToInt32(split_id[0]) && f.NumerFW == Convert.ToInt32(split_id[1]));
            string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "evidence");
            if (new_image != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(new_image.FileName);
                string extension = Path.GetExtension(new_image.FileName);
                fragment.ZdjecieDowod = fileName = DateTime.Now.ToString("yyMMddhhmmssfff") + extension;
                string path = Path.Combine(uploadFolder, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await new_image.CopyToAsync(fileStream);
                    repository.SaveChangesAsync();
                }
                repository.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SzczegolyWycieczki(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await repository.Wycieczka
                .FirstOrDefaultAsync(m => m.IdW == id);
            ViewData["Trasy"] = repository.FragmentWycieczki
                .Where(p => p.IdW == id).Join(repository.Trasa, cs => new { cs.NazwaT, cs.NazwaPP, cs.NazwaPK }, c => new { c.NazwaT, c.NazwaPP, c.NazwaPK }, (cs, c) => c).ToList();
            ViewData["Fragmenty"] = repository.FragmentWycieczki
                .Where(p => p.IdW == id).ToList();
            if (wycieczka == null)
            {
                return NotFound();
            }

            return PartialView("_PartialSzczegolyWycieczki", wycieczka);
        }
        public IActionResult ListaWycieczek( bool turysta = false)
        {
            List<Wycieczka> wycieczki;
            wycieczki = repository.Wycieczka.ToList();
            string userId = repository.Users.FirstOrDefault(us => us.UserName == User.Identity.Name).Id;
            if (turysta || User.IsInRole("Turysta"))
            {
                int ksiazeczka = repository.Ksiazeczka.FirstOrDefault(ks => ks.IdUz.Equals(userId)).NumerK;
                wycieczki = repository.Wycieczka.Where(w => w.NumerK == ksiazeczka).ToList();
            }
            var fragmenty_baza = repository.FragmentWycieczki.ToList();
            Dictionary<int, int> punkty = new Dictionary<int, int>();
            foreach (var wycieczka in wycieczki)
            {
                var suma_w = 0;
                foreach (var fragment in fragmenty_baza.Where(f => f.IdW == wycieczka.IdW))
                {
                    suma_w += repository.Trasa.FirstOrDefault(t => t.NazwaT == fragment.NazwaT && t.NazwaPP == fragment.NazwaPP && t.NazwaPK == fragment.NazwaPK).LiczbaPkt;
                }
                punkty[wycieczka.IdW] = suma_w;
            }
            ViewBag.Usunieto = TempData["Usunieto"]?.ToString();
            ViewBag.SumaPunktow = punkty.Values.Sum(); 
            ViewBag.Punkty = punkty;
            return PartialView("ListaWycieczek", wycieczki.OrderByDescending(f => f.DataRozp).ToList());
        }
        public IActionResult DodajFragment(string dataR, string pocz, string kon, string trasa, bool other = false)
        {
            

            
            List<string> messages = new List<string>();
            if (trasa == null)
            {
                trasa = "";
            }
            FragmentyTworzonejWycieczkiVM fragmenty;
            byte[] arr;
            if (HttpContext.Session.TryGetValue("fragmenty", out arr))
            {
                fragmenty = JsonConvert.DeserializeObject<FragmentyTworzonejWycieczkiVM>(HttpContext.Session.GetString("fragmenty"));
            }
            else
            {
                fragmenty = new FragmentyTworzonejWycieczkiVM();
            }
            if (!other)
            {
                    //System.Console.WriteLine($"{dataR}{pocz}{kon}{trasa}");
                    if (dataR != null && pocz != null && kon != null && trasa != null)
                {
                    DateTime data = DateTime.Parse(dataR);
                    var what = repository.WylaczenieTrasy.Any(w => w.NazwaT == trasa && w.NazwaPP == pocz && w.NazwaPK == kon && w.DataPocz <= DateTime.Parse(dataR) && (w.DataKonc == null || w.DataKonc >= DateTime.Parse(dataR)));
                    if (what)
                    {
                        ViewBag.Wylaczona = true;
                        //Trasa wyłączona
                        //return PartialView("_PartialFragments", new TrasaWycieczkaVM());
                    }
                    else
                    {
                        if (fragmenty.Fragmenty.Count > 0 && DateTime.Parse(dataR) < fragmenty.Fragmenty[fragmenty.Fragmenty.Count-1].Data)
                            messages.Add("Data nie może być wcześniejsza od daty ostatniego fragmentu!");
                        else
                        {
                            FragmentWycieczki fragment = new FragmentWycieczki
                            {
                                NumerFW = fragmenty.Fragmenty.Count + 1,
                                NazwaPP = pocz,
                                NazwaPK = kon,
                                NazwaT = trasa,
                                Data = DateTime.Parse(dataR)
                            };
                            fragmenty.Fragmenty.Add(fragment);
                        }
                    
                    }
                
                }
                else
                {
                    if (dataR == null)
                        messages.Add("Data nie może być pusta!");
                    if (pocz == null)
                        messages.Add("Brak punktu początkowego!");
                    if (kon == null)
                        messages.Add("Brak punktu końcowego!");
                }
            }
            var suma = 0;
            Dictionary<FragmentWycieczki, int> punkty = new Dictionary<FragmentWycieczki, int>();
            foreach (var frag in fragmenty.Fragmenty)
            {
                punkty[frag] = repository.Trasa.FirstOrDefault(t => t.NazwaT == frag.NazwaT && t.NazwaPP == frag.NazwaPP && t.NazwaPK == frag.NazwaPK).LiczbaPkt;
                suma += punkty[frag];
            }
            ViewBag.Suma = suma;
            HttpContext.Session.SetString("fragmenty", JsonConvert.SerializeObject(fragmenty));
            ViewData["NazwaPP"] = new SelectList(repository.Punkt.Where(p => repository.Trasa.Select(t => t.NazwaPP).Contains(p.NazwaP)), "NazwaP", "NazwaP");
            ViewData["NazwaT"] = new SelectList(repository.Trasa, "NazwaT", "NazwaT");
            ViewBag.Fragmenty = fragmenty.Fragmenty;
            ViewBag.Punkty = punkty;
            ViewBag.Wiadomosci = messages;
            return PartialView("_PartialFragments", new TrasaWycieczkaVM());
        }

        public IActionResult FiltrujWycieczki(string data_od, string data_do, int pkt_od, int pkt_do, bool zatwierdzona, bool niezatwierdzona)
        {
            
            List<Wycieczka> wycieczki = repository.Wycieczka.ToList();
            string userId = repository.Users.FirstOrDefault(us => us.UserName == User.Identity.Name).Id;
            if (User.IsInRole("Turysta"))
            {
                int ksiazeczka = repository.Ksiazeczka.FirstOrDefault(ks => ks.IdUz.Equals(userId)).NumerK;
                wycieczki = repository.Wycieczka.Where(w => w.NumerK == ksiazeczka).ToList();
            }
            if (data_od != null && data_od != "")
                wycieczki = wycieczki.Where(f => f.DataRozp >= DateTime.Parse(data_od)).ToList();
            if (data_do != null && data_do != "")
                wycieczki = wycieczki.Where(f => f.DataZak <= DateTime.Parse(data_do)).ToList();
            List<Wycieczka> filtrowane_wycieczki = new List<Wycieczka>();
            if (niezatwierdzona)
                filtrowane_wycieczki.AddRange(wycieczki.Where(p => !p.CzyZaliczona));
            if (zatwierdzona)
                filtrowane_wycieczki.AddRange(wycieczki.Where(p => p.CzyZaliczona));

            var fragmenty_baza = repository.FragmentWycieczki.ToList();
            Dictionary<int, int> punkty = new Dictionary<int, int>();
            foreach (var wycieczka in filtrowane_wycieczki)
            {
                var suma_w = 0;
                foreach (var fragment in fragmenty_baza.Where(f => f.IdW == wycieczka.IdW))
                {
                    suma_w += repository.Trasa.FirstOrDefault(t => t.NazwaT == fragment.NazwaT && t.NazwaPP == fragment.NazwaPP && t.NazwaPK == fragment.NazwaPK).LiczbaPkt;
                }
                punkty[wycieczka.IdW] = suma_w;
            }
            if (pkt_od != null && pkt_od != 0)
                filtrowane_wycieczki = filtrowane_wycieczki.Where(p => punkty[p.IdW] > pkt_od).ToList();

            if (pkt_do != null && pkt_do != 0)
                filtrowane_wycieczki = filtrowane_wycieczki.Where(p => punkty[p.IdW] < pkt_do).ToList();

            ViewBag.Usunieto = TempData["Usunieto"]?.ToString();
            ViewBag.SumaPunktow = punkty.Values.Sum();
            ViewBag.Punkty = punkty;
            return PartialView("ListaWycieczek", filtrowane_wycieczki.OrderByDescending(f => f.DataRozp));
        }
        
        
        [Authorize(Roles = "Turysta")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DodajWycieczke(TrasaWycieczkaVM wycieczka)
        {
            FragmentyTworzonejWycieczkiVM fragmenty;
            byte[] arr;
            if (HttpContext.Session.TryGetValue("fragmenty", out arr))
            {
                fragmenty = JsonConvert.DeserializeObject<FragmentyTworzonejWycieczkiVM>(HttpContext.Session.GetString("fragmenty"));
            }
            else
            {

                return RedirectToAction(nameof(Index));
            }
            if (!fragmenty.Fragmenty.Any())
                return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {
                var nowa_wycieczka = new Wycieczka
                {
                    IdW = wycieczka.IdW,
                    DataRozp = fragmenty.Fragmenty[0].Data,
                    DataZak = fragmenty.Fragmenty[fragmenty.Fragmenty.Count-1].Data,
                    NumerK = wycieczka.NumerK,
                    CzyZaliczona = wycieczka.CzyZaliczona
                };
                repository.Add(nowa_wycieczka);
                int number = 1;
                foreach (var fragment in fragmenty.Fragmenty)
                {
                    fragment.NumerFW = number;
                    fragment.IdW = nowa_wycieczka.IdW;
                    repository.Add(fragment);
                    number += 1;
                }
                fragmenty.Fragmenty.Clear();
                HttpContext.Session.SetString("fragmenty", JsonConvert.SerializeObject(fragmenty));
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RowsList = fragmenty.Fragmenty;
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            ViewData["NazwaT"] = new SelectList(repository.Trasa, "NazwaT", "NazwaT");
            return View("Index", wycieczka);
        }


        // POST: Wycieczka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdW,NumerK,DataRozp,DataZak,CzyZaliczona,Validate")] Wycieczka wycieczka)
        {
            if (ModelState.IsValid)
            {
                repository.Add(wycieczka);
                return RedirectToAction(nameof(Index));
            }
            return View(wycieczka);
        }

        // GET: Wycieczka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycieczka = await repository.Wycieczka
                .FirstOrDefaultAsync(m => m.IdW == id);
            if (wycieczka == null)
            {
                return NotFound();
            }
            if (wycieczka.CzyZaliczona==true)
            {
                return NotFound();
            }

            return View(wycieczka);
        }

        public async Task<IActionResult> UsunWycieczke(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var wycieczka = await repository.Wycieczka
                   .FirstOrDefaultAsync(m => m.IdW == id);
            if (wycieczka == null)
            {
                return NotFound();
            }
            if (wycieczka.CzyZaliczona == true)
            {
                TempData["Usunieto"] = 0;

                return RedirectToAction(nameof(ListaWycieczek));
            }
            repository.RemoveWycieczka(id);
            TempData["Usunieto"] = 1;
            return RedirectToAction(nameof(ListaWycieczek));
        }

        public IActionResult RemoveOstatni()
        {
            FragmentyTworzonejWycieczkiVM fragmenty;
            byte[] arr;
            if (HttpContext.Session.TryGetValue("fragmenty", out arr))
            {
                fragmenty = JsonConvert.DeserializeObject<FragmentyTworzonejWycieczkiVM>(HttpContext.Session.GetString("fragmenty"));
            }
            else
            {
                fragmenty = new FragmentyTworzonejWycieczkiVM();
            }
            fragmenty.RemoveLastFragment();
            HttpContext.Session.SetString("fragmenty",JsonConvert.SerializeObject(fragmenty));
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            ViewData["NazwaT"] = new SelectList(repository.Trasa, "NazwaT", "NazwaT");
            ViewBag.Fragmenty = fragmenty.Fragmenty;
            return RedirectToAction("DodajFragment");
        }

        private bool WycieczkaExists(int id)
        {
            return repository.Wycieczka.Any(e => e.IdW == id);
        }

        //Do JS
        public JsonResult GetPoints(string NazwaPP)
        {
            var punkty = repository.Trasa
              .Where(m => m.NazwaPP.Equals(NazwaPP)).Select(p => p.NazwaPK).ToList();

            List<Punkt> Punkty = repository.Punkt.Where(x => punkty.Contains(x.NazwaP)).ToList();
            return Json(new SelectList(Punkty, "NazwaP", "NazwaP"));

        }

        public JsonResult GetTrasasPK(string NazwaPK)
        {

            List<Trasa> Trasy = repository.Trasa.Where(x => x.NazwaPK == NazwaPK).ToList();
            return Json(new SelectList(Trasy, "NazwaT", "NazwaT"));

        }

        public JsonResult GetTrasas(string NazwaPP, string NazwaPK)
        {

            List<Trasa> Trasy = repository.Trasa.Where(x => x.NazwaPP == NazwaPP && x.NazwaPK==NazwaPK).ToList();
            return Json(new SelectList(Trasy, "NazwaT", "NazwaT"));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Got_PTTK_PO.Data;
using Got_PTTK_PO.Models;
using Got_PTTK_PO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Got_PTTK_PO.Controllers
{
    public class PunktsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PunktsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Punkts
        public async Task<IActionResult> Index()
        {
            Dictionary<string, List<TerenGorski>> tereny = new Dictionary<string, List<TerenGorski>>();
            Dictionary<string, List<RegionGorski>> regiony = new Dictionary<string, List<RegionGorski>>();
            foreach (var punkt in _context.Punkt.ToList())
            {
                regiony[punkt.NazwaP] = _context.Punkt_RegionGorski.Where(p => p.NazwaP == punkt.NazwaP).Join(_context.RegionGorski, cs => cs.IdRG, c => c.IdRG, (cs, c) => c).ToList();
                tereny[punkt.NazwaP] = _context.Punkt_TerenGorski.Where(p => p.NazwaP == punkt.NazwaP).Join(_context.TerenGorski, cs => cs.NazwaTG, c => c.NazwaTG, (cs, c) => c).ToList();
                
            }
            ViewBag.Punkty = await _context.Punkt.ToListAsync();
            ViewData["Tereny"] = tereny;

            ViewData["Regiony"] = regiony;

            ViewData["NazwaTG"] = new SelectList(_context.TerenGorski, "NazwaTG", "NazwaTG");
            ViewData["IdRG"] = new SelectList(_context.RegionGorski, "IdRG", "IdRG");
            
            ViewBag.Dodano = Request.Cookies["Dodano"];
            ViewBag.Wiadomosc = ViewBag.Dodano == "1" ? "Pomyślnie dodano nowy punkt!" : "Nie udało się dodać punktu! Podaj unikalną nazwę!";
            SetCookie("Dodano", "0", 3600);
            return View(new DodajPunktViewModel());
        }
       
        public IActionResult Filter(string nazwa, string rodzaj, int wys_od, int wys_do, string[] ter, string[] reg)
        {
            var regiony = _context.RegionGorski.Select(r => r.IdRG).ToList();
            var tereny = _context.TerenGorski.Select(r => r.NazwaTG).ToList();
            var ters = ter;
            var regs = reg;

            var punkty = _context.Punkt.ToList();
            if (nazwa != null && nazwa != "")
                punkty = punkty.Where(p => p.NazwaP.Contains(nazwa)).ToList();
            if (rodzaj != null && rodzaj != "---")
                punkty = punkty.Where(p => p.Rodzaj.ToString() == rodzaj).ToList();
            if (wys_od != null && wys_od != 0)
                punkty = punkty.Where(p => p.WysNpm >= wys_od).ToList();
            if (wys_do != null && wys_do != 0)
                punkty = punkty.Where(p => p.WysNpm <= wys_do).ToList();
            if (ter != null && ter.Length != 0 && ter[0]!= null )
                punkty = punkty.Intersect(_context.Punkt_TerenGorski
                    .Where(p => ters.Contains(p.NazwaTG))
                    .Join(_context.Punkt, cs => cs.NazwaP, c => c.NazwaP, (cs, c) => c)).ToList();
            if (reg != null && reg.Length != 0 && reg[0] != null )
                punkty = punkty.Intersect(_context.Punkt_RegionGorski
                    .Where(p => regs.Contains(p.IdRG))
                    .Join(_context.Punkt, cs => cs.NazwaP, c => c.NazwaP, (cs, c) => c))
                    .ToList();
         
            Dictionary<string, List<TerenGorski>> terenys = new Dictionary<string, List<TerenGorski>>();
            Dictionary<string, List<RegionGorski>> regionys = new Dictionary<string, List<RegionGorski>>();
            foreach (var punkt in punkty)
            {
                regionys[punkt.NazwaP] = _context.Punkt_RegionGorski.Where(p => p.NazwaP == punkt.NazwaP).Join(_context.RegionGorski, cs => cs.IdRG, c => c.IdRG, (cs, c) => c).ToList();
                terenys[punkt.NazwaP] = _context.Punkt_TerenGorski.Where(p => p.NazwaP == punkt.NazwaP).Join(_context.TerenGorski, cs => cs.NazwaTG, c => c.NazwaTG, (cs, c) => c).ToList();

            }
            ViewBag.Punkty = punkty;
            ViewData["Tereny"] = terenys;

            ViewData["Regiony"] = regionys;

            ViewData["NazwaTG"] = new SelectList(_context.TerenGorski, "NazwaTG", "NazwaTG");
            ViewData["IdRG"] = new SelectList(_context.RegionGorski, "IdRG", "IdRG");
            return View("Index", new DodajPunktViewModel());
        }
            // GET: Punkts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punkt = await _context.Punkt
                .FirstOrDefaultAsync(m => m.NazwaP == id);
            if (punkt == null)
            {
                return NotFound();
            }
            ViewData["Tereny"] = _context.Punkt_TerenGorski
               .Where(p => p.NazwaP == id).Join(_context.TerenGorski, cs => cs.NazwaTG, c => c.NazwaTG, (cs, c) => c).ToList();

            ViewData["Regiony"] = _context.Punkt_RegionGorski
                .Where(p => p.NazwaP == id).Join(_context.RegionGorski, cs => cs.IdRG, c => c.IdRG, (cs, c) => c).ToList();
            return View(punkt);
        }
        [Authorize(Roles = "Admin")]
      

        // POST: Punkts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken] // NA DodajPunkt
        public async Task<IActionResult> DodajPunkt( DodajPunktViewModel punkt)
        {

            if (ModelState.IsValid)
            {
                if (PunktExists(punkt.NazwaP))
                {

                    SetCookie("Dodano", "-1", 3600);
                    return RedirectToAction(nameof(Index));
                    //return RedirectToAction(nameof(Index));
                }
                    _context.Add(new Punkt
                    {
                        NazwaP = punkt.NazwaP,
                        SzerGeo = punkt.SzerGeo,
                        DlGeo = punkt.DlGeo,
                        Rodzaj = punkt.Rodzaj,
                        WysNpm = punkt.WysNpm,
                    });
                    await _context.SaveChangesAsync();
                

                var regiony = ViewData.ModelState["RegionyGorskie"].RawValue;
                if (regiony != "" && regiony!= "---")
                {
                    if (regiony is string[])
                        foreach (var region in (string[])regiony)
                        {
                            _context.Add(new Punkt_RegionGorski
                            {
                                NazwaP = punkt.NazwaP,
                                IdRG = region
                            });
                            await _context.SaveChangesAsync();
                        }
                    else
                    {
                        _context.Add(new Punkt_RegionGorski
                        {
                            NazwaP = punkt.NazwaP,
                            IdRG = (string)regiony
                        });
                        await _context.SaveChangesAsync();
                    }
                }
                var tereny = ViewData.ModelState["TerenyGorskie"].RawValue;
                if (tereny != "" && tereny != "---")
                {
                    if (tereny is string[])
                        foreach (var terenGorski in (string[])tereny)
                        {
                            _context.Add(new Punkt_TerenGorski
                            {
                                NazwaP = punkt.NazwaP,
                                NazwaTG = terenGorski
                            });
                            await _context.SaveChangesAsync();
                        }
                    else
                    {
                        _context.Add(new Punkt_TerenGorski
                        {
                            NazwaP = punkt.NazwaP,
                            NazwaTG = (string)tereny
                        });
                        await _context.SaveChangesAsync();
                    }
                }

                SetCookie("Dodano", "1", 3600);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Punkts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punkt = await _context.Punkt.FindAsync(id);
            if (punkt == null)
            {
                return NotFound();
            }
            return View("Index",punkt);
        }

        // POST: Punkts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DodajPunktViewModel punkt)
        {
            if (ModelState.IsValid)
            {
                Punkt edytowany_punkt = _context.Punkt.FirstOrDefault(p => p.NazwaP == id);
                if (edytowany_punkt != null)
                {
                    edytowany_punkt.NazwaP = punkt.NazwaP;
                    edytowany_punkt.SzerGeo = punkt.SzerGeo;
                    edytowany_punkt.DlGeo = punkt.DlGeo;
                    edytowany_punkt.Rodzaj = punkt.Rodzaj;
                    edytowany_punkt.WysNpm = punkt.WysNpm;
                }
                _context.Update(edytowany_punkt);
                await _context.SaveChangesAsync();

                var region_punkt = _context.Punkt_RegionGorski.Where(c => c.NazwaP == edytowany_punkt.NazwaP).ToList();
                string[] regiony;
                if (ViewData.ModelState["RegionyGorskie"].RawValue != "" && ViewData.ModelState["RegionyGorskie"].RawValue != "---")
                {
                    if (ViewData.ModelState["RegionyGorskie"].RawValue is string[])
                        regiony = (string[]) ViewData.ModelState["RegionyGorskie"].RawValue;
                    else
                        regiony = new string[] { (string)ViewData.ModelState["RegionyGorskie"].RawValue };
                    
                    foreach (var region_punktu in region_punkt)
                    {
                        if (Array.IndexOf(regiony,region_punktu.IdRG) <= -1)
                        {
                            _context.Remove(region_punktu);
                            await _context.SaveChangesAsync();
                        }
                    }

                    foreach (var region in regiony)
                    {
                        if (Array.IndexOf(region_punkt.Select(r => r.IdRG).ToArray(), region) <= -1)
                        {
                            _context.Add(new Punkt_RegionGorski
                            {
                                NazwaP = punkt.NazwaP,
                                IdRG = region
                            });
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                var teren_punkt = _context.Punkt_TerenGorski.Where(c => c.NazwaP == edytowany_punkt.NazwaP).ToList();
                string[] tereny;
                if (ViewData.ModelState["TerenyGorskie"]!= null && ViewData.ModelState["TerenyGorskie"].RawValue != "" && ViewData.ModelState["TerenyGorskie"].RawValue != "---")
                {
                    if (ViewData.ModelState["TerenyGorskie"].RawValue is string[])
                        tereny = (string[]) ViewData.ModelState["TerenyGorskie"].RawValue;
                    else
                        tereny = new string[] { (string)ViewData.ModelState["TerenyGorskie"].RawValue };
                    
                    foreach (var teren_punktu in teren_punkt)
                    {
                        if (Array.IndexOf(tereny, teren_punktu.NazwaTG) <= -1)
                        {
                            _context.Remove(teren_punktu);
                            await _context.SaveChangesAsync();
                        }
                    }

                    foreach (var teren in tereny)
                    {
                        if (Array.IndexOf(teren_punkt.Select(r => r.NazwaTG).ToArray(), teren) <= -1)
                        {
                            _context.Add(new Punkt_TerenGorski
                            {
                                NazwaP = punkt.NazwaP,
                                NazwaTG = teren
                            });
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else if (ViewData.ModelState["TerenyGorskie"] == null)
                {
                    foreach (var teren_punktu in teren_punkt)
                    {
                            _context.Remove(teren_punktu);
                            await _context.SaveChangesAsync();
                    }
                }


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


          
            return RedirectToAction(nameof(Index));
        }

        // GET: Punkts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punkt = await _context.Punkt
                .FirstOrDefaultAsync(m => m.NazwaP == id);
            if (punkt == null)
            {
                return NotFound();
            }

            return View(punkt);
        }

        // POST: Punkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var punkt = await _context.Punkt.FindAsync(id);
                _context.Punkt.Remove(punkt);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ViewBag.Tabela = "Punkt";
                ViewBag.Wiadomosc = "Nie można usunąć, ponieważ punkt należy do trasy!";
                return View("BladBazyDanych");
            }
            
            return RedirectToAction(nameof(Index));
        }
        public void SetCookie(string key, string value, int? numberOfSeconds = null)
        {
            CookieOptions option = new CookieOptions();
            if (numberOfSeconds.HasValue)
                option.Expires = DateTime.Now.AddSeconds(numberOfSeconds.Value);
            Response.Cookies.Append(key, value, option);
        }
        private bool PunktExists(string id)
        {
            return _context.Punkt.Any(e => e.NazwaP == id);
        }
    }
}

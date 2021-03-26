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

namespace Got_PTTK_PO.Controllers
{
    public class TrasasController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IRepository repository;

        //public TrasasController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public TrasasController(IRepository repo)
        {
            repository = repo;
        }
        public async Task<IActionResult> Index()
        {

            Dictionary<string, string> regiony = new Dictionary<string, string>();
            foreach (var trasa in repository.Trasa.ToList())
            {
                var region = repository.Punkt_RegionGorski.Where(r => r.NazwaP == trasa.NazwaPP || r.NazwaP == trasa.NazwaPK)
                                            .GroupBy(d => d.IdRG)
                                            .Select(group => new { Id = group.Key,
                                                Count = group.Count()
                                            }).FirstOrDefault(g => g.Count == 2).Id;
                regiony[trasa.NazwaT + trasa.NazwaPP + trasa.NazwaPK] = region;
            }
            ViewBag.Regiony = regiony; 
            var trasy = repository.Trasa.Include(t => t.PunktKonc).Include(t => t.PunktPocz);

            ViewData["NazwaPK"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            ViewBag.Trasy = await trasy.ToListAsync();
            return View(new TworzenieTrasyVM());
        }
        public IActionResult Filter(string nazwa, bool aktywna, int pkt_od, int pkt_do, string[] pkt_pocz, string[] pkt_kon)
        {

            var trasy = repository.Trasa.ToList();
            if (nazwa != null && nazwa != "")
                trasy = trasy.Where(p => p.NazwaT.Contains(nazwa)).ToList();
            if (aktywna != null )
                trasy = trasy.Where(p => p.CzyAktywna == aktywna).ToList();
            if (pkt_od != null && pkt_od != 0)
                trasy = trasy.Where(p => p.LiczbaPkt >= pkt_od).ToList();
            if (pkt_do != null && pkt_do != 0)
                trasy = trasy.Where(p => p.LiczbaPkt <= pkt_do).ToList();
            if (pkt_pocz != null && pkt_pocz.Length != 0 && pkt_pocz[0] != null)
                trasy = trasy.Where(p => pkt_pocz.Contains(p.NazwaPP)).ToList();
            if (pkt_kon != null && pkt_kon.Length != 0 && pkt_kon[0] != null)
                trasy = trasy.Where(p => pkt_kon.Contains(p.NazwaPK)).ToList();

            Dictionary<string, string> regiony = new Dictionary<string, string>();
            foreach (var trasa in trasy)
            {
                var region = repository.Punkt_RegionGorski.Where(r => r.NazwaP == trasa.NazwaPP || r.NazwaP == trasa.NazwaPK)
                                            .GroupBy(d => d.IdRG)
                                            .Select(group => new {
                                                Id = group.Key,
                                                Count = group.Count()
                                            }).FirstOrDefault(g => g.Count == 2).Id;
                regiony[trasa.NazwaT + trasa.NazwaPP + trasa.NazwaPK] = region;
            }
            ViewBag.Regiony = regiony;
            ViewBag.Trasy = trasy;
            ViewData["NazwaPK"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            return View("Index", new TworzenieTrasyVM());
        }
        
        // GET: Trasas/Create
        public IActionResult Create()
        {
            ViewData["NazwaPK"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP");
            return View();
        }

        // POST: Trasas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NazwaT,NazwaPP,NazwaPK,LiczbaPkt,CzyAktywna")] Trasa trasa)
        {
            if (trasa.NazwaT == null)
                trasa.NazwaT = "";
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Add(trasa);
                    repository.SaveChangesAsync();
                    //await _context.SaveChangesAsync();
                    var wylaczenia_trasy = repository.WylaczenieTrasy.ToList().Where(w => w.NazwaT == trasa.NazwaT && w.NazwaT == trasa.NazwaT && w.NazwaT == trasa.NazwaT).ToList();

                    if (!trasa.CzyAktywna)
                    {
                        var wylaczenie = new WylaczenieTrasy() { DataPocz = DateTime.Now, NazwaT = trasa.NazwaT, NazwaPP = trasa.NazwaPP, NazwaPK = trasa.NazwaPK, DataKonc = null };
                        repository.Add(wylaczenie);
                        //await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateException)
                {
                    if (TrasaExists(trasa.NazwaT, trasa.NazwaPP, trasa.NazwaPK))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NazwaPK"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP", trasa.NazwaPK);
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP", trasa.NazwaPP);
            ViewBag.Trasy = await repository.Trasa.Include(t => t.PunktKonc).Include(t => t.PunktPocz).ToListAsync();
            return View(new TworzenieTrasyVM());
        }

        // GET: Trasas/Edit/5
        public async Task<IActionResult> Edit(string NazwaT, string NazwaPP, string NazwaPK)
        {
            if (NazwaT == null)
            {
                return NotFound();
            }
            
            var trasa = await repository.Trasa.FirstOrDefaultAsync(m => m.NazwaT == NazwaT && m.NazwaPP == NazwaPP && m.NazwaPK == NazwaPK);
            if (trasa == null)
            {
                return NotFound();
            }
            ViewData["NazwaPK"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP", trasa.NazwaPK);
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP", trasa.NazwaPP);
            return View(trasa);
        }

        // POST: Trasas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string NazwaT, string NazwaPP, string NazwaPK, [Bind("NazwaT,NazwaPP,NazwaPK,LiczbaPkt,CzyAktywna")] Trasa trasa)
        {
            if (NazwaT != trasa.NazwaT)
            {
                return NotFound();
            }
            if (trasa.NazwaT == null)
            {
                trasa.NazwaT = "";
            }
            var trasaedytowana = repository.Trasa.FirstOrDefault(w => w.NazwaT == trasa.NazwaT && w.NazwaPP == trasa.NazwaPP && w.NazwaPK == trasa.NazwaPK);
            trasaedytowana.CzyAktywna = trasa.CzyAktywna;
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(trasaedytowana);
                    //repository.SaveChangesAsync();
                    var wylaczenia_trasy = repository.WylaczenieTrasy.Where(w => w.NazwaT == trasa.NazwaT && w.NazwaT == trasa.NazwaT && w.NazwaT == trasa.NazwaT).ToList();
                    if (trasa.CzyAktywna && wylaczenia_trasy.Any(w => w.DataKonc == null))
                    {
                        var wyl = wylaczenia_trasy.FirstOrDefault(w => w.DataKonc == null);
                        wyl.DataKonc = DateTime.Now;
                        repository.SaveChangesAsync();
                    }
                    else if (!trasa.CzyAktywna && !wylaczenia_trasy.Any(w => w.DataKonc == null))
                    {
                        var wylaczenie = new WylaczenieTrasy() { DataPocz = DateTime.Now, NazwaT = trasa.NazwaT, NazwaPP = trasa.NazwaPP, NazwaPK = trasa.NazwaPK };
                        repository.Add(wylaczenie);
                        repository.SaveChangesAsync();
                    }
                    


                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                }
                repository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NazwaPK"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP", trasa.NazwaPK);
            ViewData["NazwaPP"] = new SelectList(repository.Punkt, "NazwaP", "NazwaP", trasa.NazwaPP);
            return View(trasa);
        }

        // GET: Trasas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trasa = await repository.Trasa
                .Include(t => t.PunktKonc)
                .Include(t => t.PunktPocz)
                .FirstOrDefaultAsync(m => m.NazwaT == id);
            if (trasa == null)
            {
                return NotFound();
            }

            return View(trasa);
        }

        // POST: Punkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string NazwaT, string NazwaPP, string NazwaPK)
        {
            try
            {
                var punkt = await repository.Trasa.FirstOrDefaultAsync(t => t.NazwaT == NazwaT && t.NazwaPP == NazwaPP && t.NazwaPK == NazwaPK);
                repository.RemoveTrasa(NazwaT, NazwaPP, NazwaPK);
                repository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ViewBag.Tabela = "Punkt";
                ViewBag.Wiadomosc = "Nie można usunąć, ponieważ  punkt należy do trasy!";
                return View("BladBazyDanych");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TrasaExists(string id, string pp, string pk)
        {
            return repository.Trasa.Any(e => e.NazwaT == id && e.NazwaPP == pp && e.NazwaPK== pk);
        }

        public JsonResult GetPoints(string NazwaPP)
        {   var regiony = repository.Punkt_RegionGorski
              .Where(m => m.NazwaP.Equals(NazwaPP)).Select(p => p.IdRG).ToList();

            List<Punkt> Punkty = repository.Punkt.Where(x => x.NazwaP != NazwaPP).Where(x => x.RegionyGorskie.Select(r => r.IdRG).Any(tag => regiony.Contains(tag))).ToList();
            return Json(new SelectList(Punkty, "NazwaP", "NazwaP"));

        }
    }
}

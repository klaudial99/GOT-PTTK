using Got_PTTK_PO.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public class Repository : IRepository
    {
        private ApplicationDbContext context;

        public Repository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Punkt> Punkt => context.Punkt;

        public IQueryable<Trasa> Trasa => context.Trasa;

        public IQueryable<Wycieczka> Wycieczka => context.Wycieczka;

        public IQueryable<FragmentWycieczki> FragmentWycieczki => context.FragmentWycieczki;

        public IQueryable<WylaczenieTrasy> WylaczenieTrasy => context.WylaczenieTrasy;

        public IQueryable<KsiazeczkaGOTPTTK> Ksiazeczka => context.KsiazeczkaGOTPTTKs;

        public IQueryable<Punkt_RegionGorski> Punkt_RegionGorski => context.Punkt_RegionGorski;

        public IQueryable<IdentityUser> Users => context.Users;

        public IQueryable<EkspertGorski> EksperciGorski => context.EksperciGorski;

        public IQueryable<ObszarGorski> ObszarGorski => context.ObszarGorski;

        public IQueryable<RegionGorski> RegionGorski => context.RegionGorski;

        public IQueryable<Legitymacja_ObszarGorski> Legitymacja_ObszarGorski => context.Legitymacja_ObszarGorski;

        public IQueryable<Legitymacja> Legitymacje => context.Legitymacje;

        public IQueryable<Turysta> Turysta => context.Turysta;

        public void Add(Trasa trasa)
        {
            
            context.Trasa.Add(trasa);
            context.SaveChanges();
        }
        public void Update(Trasa trasa)
        {
            context.Update(trasa);
            context.SaveChanges();
        }

        public void Add(Punkt punkt)
        {
            context.Punkt.Add(punkt);

            context.SaveChanges(); ;
        }

        public void Add(Wycieczka wycieczka)
        {
            context.Wycieczka.Add(wycieczka);

            context.SaveChanges();
        }

        public void Add(FragmentWycieczki fragmentWycieczki)
        {
            context.FragmentWycieczki.Add(fragmentWycieczki);

            context.SaveChanges();
        }

        public void Add(WylaczenieTrasy wylaczenieTrasy)
        {
            context.WylaczenieTrasy.Add(wylaczenieTrasy);
            context.SaveChanges();
        }

        public void Add(KsiazeczkaGOTPTTK ksiazeczka)
        {
            context.KsiazeczkaGOTPTTKs.Add(ksiazeczka);
            context.SaveChanges();
        }

        public Trasa RemoveTrasa(string NazwaT, string NazwaPP, string NazwaPK)
        {
            Trasa dbEntry = context.Trasa
                .FirstOrDefault(p => p.NazwaT == NazwaT && p.NazwaPP == NazwaPP && p.NazwaPK == NazwaPK);
            if (dbEntry != null)
            {
                context.Trasa.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public FragmentWycieczki RemoveFragmentWycieczki(int IdW, int NumerFW)
        {
            FragmentWycieczki dbEntry = context.FragmentWycieczki
                .FirstOrDefault(p => p.IdW== IdW && p.NumerFW== NumerFW);
            if (dbEntry != null)
            {
                context.FragmentWycieczki.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public KsiazeczkaGOTPTTK RemoveKsiazeczka(int NumerK)
        {
            KsiazeczkaGOTPTTK dbEntry = context.KsiazeczkaGOTPTTKs
                .FirstOrDefault(p => p.NumerK == NumerK);
            if (dbEntry != null)
            {
                context.KsiazeczkaGOTPTTKs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Punkt RemovePunkt(string NazwaP)
        {
            Punkt dbEntry = context.Punkt
                .FirstOrDefault(p => p.NazwaP== NazwaP);
            if (dbEntry != null)
            {
                context.Punkt.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        public Wycieczka RemoveWycieczka(int IdW)
        {
            Wycieczka dbEntry = context.Wycieczka
                .FirstOrDefault(p => p.IdW == IdW);
            if (dbEntry != null)
            {
                context.Wycieczka.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void AddPunktRegion(Punkt_RegionGorski punkt_Region)
        {
            context.Add(punkt_Region);
            context.SaveChanges();
        }

        public Punkt_RegionGorski RemovePunktRegion(string NazwaP, string IdRG)
        {
            Punkt_RegionGorski dbEntry = context.Punkt_RegionGorski
                .FirstOrDefault(p => p.NazwaP == NazwaP && p.IdRG == IdRG);
            if (dbEntry != null)
            {
                context.Punkt_RegionGorski.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void AddUser(IdentityUser user)
        {
            context.Add(user);
            context.SaveChanges();
        }

        public IdentityUser RemoveUser(string id)
        {
            IdentityUser dbEntry = context.Users
                .FirstOrDefault(p => p.Id == id);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public int SaveChangesAsync()
        {
            return context.SaveChanges();
        }


        public void Add(EkspertGorski ekspertGorski)
        {
            context.Add(ekspertGorski);
            context.SaveChangesAsync();
        }

        public EkspertGorski RemoveEkspert(string IdU)
        {
            EkspertGorski dbEntry = context.EksperciGorski
                .FirstOrDefault(p => p.IdUz == IdU);
            if (dbEntry != null)
            {
                context.EksperciGorski.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Add(ObszarGorski obszarGorski)
        {
            context.Add(obszarGorski);
            context.SaveChangesAsync();
        }

        public ObszarGorski RemoveObszar(string NazwaOG)
        {
            ObszarGorski dbEntry = context.ObszarGorski
                .FirstOrDefault(p => p.NazwaOG == NazwaOG);
            if (dbEntry != null)
            {
                context.ObszarGorski.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Add(RegionGorski region)
        {
            context.Add(region);
            context.SaveChangesAsync();
        }

        public RegionGorski RemoveRegion(string IdRG)
        {
            RegionGorski dbEntry = context.RegionGorski
                .FirstOrDefault(p => p.IdRG == IdRG);
            if (dbEntry != null)
            {
                context.RegionGorski.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Add(Legitymacja_ObszarGorski legitymacja_ObszarGorski)
        {
            context.Add(legitymacja_ObszarGorski);
            context.SaveChangesAsync();
        }

        public Legitymacja_ObszarGorski RemoveLegitymacjaObszar(string NumerL, string NazwaOG)
        {
            Legitymacja_ObszarGorski dbEntry = context.Legitymacja_ObszarGorski
                .FirstOrDefault(p => p.NumerL == NumerL && p.NazwaOG == NazwaOG);
            if (dbEntry != null)
            {
                context.Legitymacja_ObszarGorski.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Add(Legitymacja legitymacja)
        {
            context.Add(legitymacja);
            context.SaveChangesAsync();
        }

        public Legitymacja RemoveLegitymacja(string NumerL)
        {
            Legitymacja dbEntry = context.Legitymacje
                .FirstOrDefault(p => p.NumerL == NumerL);
            if (dbEntry != null)
            {
                context.Legitymacje.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Add(Turysta turysta)
        {
            context.Add(turysta);
            context.SaveChangesAsync();
        }

        public Turysta RemoveTurysta(string IdUz)
        {
            Turysta dbEntry = context.Turysta
                .FirstOrDefault(p => p.IdUz == IdUz);
            if (dbEntry != null)
            {
                context.Turysta.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

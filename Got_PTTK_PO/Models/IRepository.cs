using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Models
{
    public interface IRepository
    {
        IQueryable<IdentityUser> Users { get; }
        void AddUser(IdentityUser user);
        IdentityUser RemoveUser(string id);

        IQueryable<Punkt> Punkt { get; }
        void Add(Punkt punkt);
        Punkt RemovePunkt(string NazwaP);

        IQueryable<Punkt_RegionGorski> Punkt_RegionGorski { get; }
        void AddPunktRegion(Punkt_RegionGorski punkt_Region);
        Punkt_RegionGorski RemovePunktRegion(string NazwaP, string IdRG);

        IQueryable<Trasa> Trasa { get; }
        void Add(Trasa trasa);
        void Update(Trasa trasa);
        Trasa RemoveTrasa(string NazwaT, string NazwaPP, string NazwaPK);

        IQueryable<Wycieczka> Wycieczka { get; }
        void Add(Wycieczka wycieczka);
        Wycieczka RemoveWycieczka(int IdW);

        IQueryable<FragmentWycieczki> FragmentWycieczki { get; }
        void Add(FragmentWycieczki fragmentWycieczki);
        FragmentWycieczki RemoveFragmentWycieczki(int IdW, int NumerFW);

        IQueryable<WylaczenieTrasy> WylaczenieTrasy { get; }
        void Add(WylaczenieTrasy wylaczenieTrasy);

        IQueryable<KsiazeczkaGOTPTTK> Ksiazeczka{ get; }
        void Add(KsiazeczkaGOTPTTK ksiazeczka);
        KsiazeczkaGOTPTTK RemoveKsiazeczka(int NumerK);

        int SaveChangesAsync();

        IQueryable<EkspertGorski> EksperciGorski { get; }
        void Add(EkspertGorski ekspertGorski);
        EkspertGorski RemoveEkspert(string IdU);

        IQueryable<ObszarGorski> ObszarGorski { get; }
        void Add(ObszarGorski obszarGorski);
        ObszarGorski RemoveObszar(string NazwaOG);

        IQueryable<RegionGorski> RegionGorski { get; }
        void Add(RegionGorski regionGorski);
        RegionGorski RemoveRegion(string IdRG);


        IQueryable<Legitymacja_ObszarGorski> Legitymacja_ObszarGorski { get; }
        void Add(Legitymacja_ObszarGorski legitymacja_ObszarGorski);
        Legitymacja_ObszarGorski RemoveLegitymacjaObszar(string NumerL, string NazwaOG);

        IQueryable<Legitymacja> Legitymacje { get; }
        void Add(Legitymacja legitymacja);
        Legitymacja RemoveLegitymacja(string NumerL);

        IQueryable<Turysta> Turysta { get; }
        void Add(Turysta turysta);
        Turysta RemoveTurysta(string IdUz);



    }

    
}
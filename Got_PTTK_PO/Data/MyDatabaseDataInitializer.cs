using Got_PTTK_PO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Data
{
    public static class MyDatabaseDataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegionGorski>().HasData(
                new RegionGorski()
                {
                    IdRG = "TEST",
                    NazwaOG = "A1"

                }
                );
            modelBuilder.Entity<Punkt>().HasData(
                new Punkt()
                {
                    NazwaP = "Pierwszy",
                    SzerGeo = 12,
                    DlGeo = 1,
                    Rodzaj = Rodzaj_Punktu.Początkowy,
                    WysNpm = 1231

                },
                new Punkt()
                {
                    NazwaP = "Drugi",
                    SzerGeo = 122,
                    DlGeo = 2,
                    Rodzaj = Rodzaj_Punktu.Pośredni,
                    WysNpm = 1232

                },
                new Punkt()
                {
                    NazwaP = "Trzeci",
                    SzerGeo = 124,
                    DlGeo = 3,
                    Rodzaj = Rodzaj_Punktu.Początkowy,
                    WysNpm = 1233

                }

                );
            modelBuilder.Entity<Trasa>().HasData(
                new Trasa()
                {
                    NazwaT = "Pierwsza",
                    NazwaPP = "Pierwszy",
                    NazwaPK = "Trzeci",
                    LiczbaPkt = 7,
                    CzyAktywna = true

                }
                );

        //    public int IdA { get; set; }
        //[MaxLength(30)]
        //public string Ulica { get; set; }
        //[MaxLength(5)]
        //public string NrDomu { get; set; }
        //[MaxLength(5)]
        //public string NrMieszkania { get; set; }
        //[MaxLength(6)]
        //public string KodPocztowy { get; set; }
        //[MaxLength(30)]
        //public string Miasto { get; set; }
        //[MaxLength(30)]
        //public string Kraj { get; set; }
        //public string IdUz { get; set; }

        modelBuilder.Entity<Adres>().HasData(
                new Adres()
                {
                    IdA = 1,
                    Ulica = "Ametystowa",
                    NrDomu = "1",
                    NrMieszkania = "2",
                    KodPocztowy = "52-215",
                    Miasto = "Wroclaw",
                    Kraj = "Polska"
                },
                new Adres()
                {
                    IdA = 2,
                    Ulica = "Brzegowa",
                    NrDomu = "3c",
                    NrMieszkania = "2a",
                    KodPocztowy = "57-215",
                    Miasto = "Wałbrzych",
                    Kraj = "Polska"
                },
                new Adres()
                {
                    IdA = 3,
                    Ulica = "Brzegowa",
                    NrDomu = "12",
                    NrMieszkania = "4",
                    KodPocztowy = "58-298",
                    Miasto = "Wałbrzych",
                    Kraj = "Polska"
                });

            modelBuilder.Entity<Turysta>().HasData(
                new Turysta()
                {
                    IdUz = "832b741c-eed5-4a47-989d-cd5957355cef",
                    IdA = 1,
                    Imie = "Konrad",
                    Nazwisko = "Liuras",
                    DataUrodzenia = new DateTime(2008, 6, 1, 7, 47, 0),
                    CzyDziecko = false
                },
                new Turysta()
                {
                    IdUz = "24412758-bf78-4b21-a421-cf1b349683f1",
                    IdA = 3,
                    Imie = "Turysta1",
                    Nazwisko = "NazwiskoTurysty1",
                    DataUrodzenia = new DateTime(1986, 3, 3, 7, 47, 0),
                    CzyDziecko = false
                },
                new Turysta()
                {
                    IdUz = "c3fe7b5e-7dc5-46da-9437-3ecf54f6dc6d",
                    IdA = 2,
                    Imie = "Turysta2",
                    Nazwisko = "NazwiskoTurysty2",
                    DataUrodzenia = new DateTime(1995, 4, 1, 7, 47, 0),
                    CzyDziecko = false
                });
            modelBuilder.Entity<KsiazeczkaGOTPTTK>().HasData(
                new KsiazeczkaGOTPTTK()
                {
                    IdUz = "832b741c-eed5-4a47-989d-cd5957355cef",
                    NumerK = 1,
                    DataUtworzenia = new DateTime(2020, 6, 1, 7, 47, 0)
                },
                new KsiazeczkaGOTPTTK()
                {
                    IdUz = "24412758-bf78-4b21-a421-cf1b349683f1",
                    NumerK = 2,
                    DataUtworzenia = new DateTime(2020, 6, 1, 7, 47, 0)
                },
                new KsiazeczkaGOTPTTK()
                {
                    IdUz = "c3fe7b5e-7dc5-46da-9437-3ecf54f6dc6d",
                    NumerK = 3,
                    DataUtworzenia = new DateTime(2020, 10, 1, 17, 7, 3)
                },
                new KsiazeczkaGOTPTTK()
                {
                    IdUz = "c9f02a8f-e780-4f08-b99d-41996e763671",
                    NumerK = 4,
                    DataUtworzenia = new DateTime(2020, 12, 8, 9, 27, 0)
                }
                );
            modelBuilder.Entity<Legitymacja>().HasData(
                new Legitymacja
                {
                    NumerL = "1111",
                    CzyWazna = true,
                    DataWaznosci = new DateTime(2022, 12, 8, 9, 27, 0)
                },
                new Legitymacja
                {
                    NumerL = "2222",
                    CzyWazna = false,
                    DataWaznosci = new DateTime(2019, 12, 8, 9, 27, 0)
                },
                new Legitymacja
                {
                    NumerL = "1111p",
                    CzyWazna = true,
                    DataWaznosci = new DateTime(2022, 9, 2, 9, 27, 0)
                },
                new Legitymacja
                {
                    NumerL = "2222p",
                    CzyWazna = false,
                    DataWaznosci = new DateTime(2021, 1, 8, 9, 27, 0)
                });

            modelBuilder.Entity<Legitymacja_ObszarGorski>().HasData(
                new Legitymacja_ObszarGorski()
                {
                    NazwaOG = "A1",
                    NumerL = "1111"
                },
                new Legitymacja_ObszarGorski()
                {
                    NazwaOG = "C3",
                    NumerL = "1111"
                },
                new Legitymacja_ObszarGorski()
                {
                    NazwaOG = "C3",
                    NumerL = "2222"
                },
                new Legitymacja_ObszarGorski()
                {
                    NazwaOG = "C3",
                    NumerL = "1111p"
                },
                new Legitymacja_ObszarGorski()
                {
                    NazwaOG = "A2",
                    NumerL = "2222"
                });

            modelBuilder.Entity<EkspertGorski>().HasData(
                new EkspertGorski()
                {
                    IdUz = "f97cf24a-826f-4bb7-86dc-fb3dd75db49e",
                    NumerL = "1111",
                    IdA = 2,
                    Imie = "Przodownik1",
                    Nazwisko = "Kowalski",
                    NrTel = "696380122",
                    DataUrodzenia = new DateTime(1962, 1, 8, 9, 27, 0)
                },
                new EkspertGorski()
                {
                    IdUz = "672e4d89-8a65-4171-a757-60a0271a2148",
                    NumerL = "2222",
                    IdA = 3,
                    Imie = "Przodownik2",
                    Nazwisko = "Kowalski",
                    NrTel = "111234432",
                    DataUrodzenia = new DateTime(1962, 1, 8, 9, 27, 0)
                },
                new EkspertGorski()
                {
                    IdUz = "c5186eea-0e69-4523-96e3-e69841245e5a",
                    NumerL = "1111p",
                    IdA = 2,
                    Imie = "Przewodnik1",
                    Nazwisko = "Nowak1",
                    NrTel = "501380756",
                    DataUrodzenia = new DateTime(1962, 1, 8, 9, 27, 0)
                },
                new EkspertGorski()
                {
                    IdUz = "22923dfe-c5a2-4f8c-8d5c-dbc8de208b38",
                    NumerL = "2222p",
                    IdA = 1,
                    Imie = "Przewodnik2",
                    Nazwisko = "Kowalski2",
                    NrTel = "123423123",
                    DataUrodzenia = new DateTime(1962, 1, 8, 9, 27, 0)
                });
            //new Turysta()
            //{
            //    IdUz = "24412758-bf78-4b21-a421-cf1b349683f1",
            //    IdA = 3,
            //    Imie = "Turysta1",
            //    Nazwisko = "NazwiskoTurysty1",
            //    DataUrodzenia = new DateTime(1986, 3, 3, 7, 47, 0),
            //    CzyDziecko = false
            //},
            //    new Turysta()
            //    {
            //        IdUz = "c3fe7b5e-7dc5-46da-9437-3ecf54f6dc6d",
            //        IdA = 3,
            //        Imie = "Turysta2",
            //        Nazwisko = "NazwiskoTurysty2",
            //        DataUrodzenia = new DateTime(1995, 4, 1, 7, 47, 0),
            //        CzyDziecko = false
            //    },
            //    new Turysta()
            //    {
            //        IdUz = "c9f02a8f-e780-4f08-b99d-41996e763671",
            //        IdA = 3,
            //        Imie = "Turysta3Dziecko",
            //        Nazwisko = "NazwiskoTurysty3",
            //        DataUrodzenia = new DateTime(2007, 2, 4, 9, 47, 0),
            //        CzyDziecko = true
            //    }
        }
    }
}

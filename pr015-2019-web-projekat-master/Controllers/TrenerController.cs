using MyWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class TrenerController : ApiController
    {


        

        

            [HttpGet]
        public List<GrupniTrening> GetGrupniTrenerovTreningRaniji()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            Korisnik kor = new Korisnik();
            List<GrupniTrening> izabrani = new List<GrupniTrening>();
            DateTime sada = DateTime.Now;

            List<GrupniTrening> treninzi = new List<GrupniTrening>();

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(json);
                foreach (var t in items)
                {
                    if (t.KorisnickoIme == Staticka.trenutni.KorisnickoIme)
                    {
                        kor = t;
                    }



                }
            }

            foreach (var tr in kor.Treninzi)
            {
                if (tr.Obrisan == false && tr.DatumIVreme < sada )//da prikaze samo one treninge koji nisu obrisani
                {
                    izabrani.Add(tr);
                }
            }




            return izabrani;

        }




        [HttpGet]
        public List<GrupniTrening> GetTreninziTrenera()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            Korisnik kor = new Korisnik();
            List<GrupniTrening> izabrani = new List<GrupniTrening>();

            
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(json);
                foreach (var t in items)
                {
                    if (t.KorisnickoIme == Staticka.trenutni.KorisnickoIme)
                    {
                        kor = t;
                    }



                }
            }

            foreach(var tr in kor.Treninzi)
            {
                if (tr.Obrisan == false)//da prikaze samo one treninge koji nisu obrisani
                {
                    izabrani.Add(tr);
                }
            }

           


            return izabrani;

        }

       public static List<Korisnik> novi = new List<Korisnik>();
        [HttpPost]
        public List<Korisnik> PrikaziPosetioce()
        {

            string idd = HttpContext.Current.Request.Params["id"];//za taj trening
            int id = Int32.Parse(idd);
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");
            List<string> posetioci = new List<string>();
            string filePath1 = Path.Combine(currentDirectory, "App_Data/korisnici.json");

           
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                Staticka.grupniTreninzi = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);

                foreach( var t in Staticka.grupniTreninzi)
                {
                    if(t.Id == id)
                    {
                        posetioci = t.Posetioci;
                    }
                }


            }

            using (StreamReader r = new StreamReader(filePath1))
            {
                string json1 = r.ReadToEnd();
                Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json1);

                foreach(var k in Staticka.korisnici)
                {


                    if (posetioci.Contains(k.KorisnickoIme))
                    {
                        novi.Add(k);
                    }
                }

            }
            return novi;


         }


        [HttpGet]
        public List<Korisnik> VratiKorisnike()
        {
            return novi;
        }


        [HttpPost]
        public IHttpActionResult DodavanjeTreninga()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");
            string filePath1 = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            int ind = -1;


            Korisnik kNovi = new Korisnik();
            string naziv = HttpContext.Current.Request.Params["naziv"];
            string tip = HttpContext.Current.Request.Params["tip"];
            string trajanje = HttpContext.Current.Request.Params["trajanje"];
            string datum = HttpContext.Current.Request.Params["datum"];
            string maxBr = HttpContext.Current.Request.Params["maxBr"];

            GrupniTrening grupni = new GrupniTrening();

            grupni.Naziv = naziv;
            grupni.Tip = tip;
            grupni.Trajanje = Int32.Parse(trajanje);
            grupni.DatumIVreme = DateTime.Parse(datum);
            grupni.MaxBrPosetilaca =Int32.Parse(maxBr);
            grupni.Id = GrupniTrening.GenerateId();
            grupni.Posetioci = new List<string>();
            grupni.Obrisan = false;
            DateTime sada = DateTime.Now;
            grupni.Fitnes = Staticka.trenutni.FitnesCentri[0];//fitnes centar gde se odrzava je onaj gde trener radi




            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                Staticka.grupniTreninzi = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);




            }
           DateTime datum1 = DateTime.Parse(datum);//da se trening kreira 3 dana unapred
            if (datum1.Day >= (sada.Day + 3) && datum1.Year >= sada.Year &&  datum1.Month >= sada.Month)
            {



                Staticka.grupniTreninzi.Add(grupni);
            }
            else
            {
                return BadRequest();
            }

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.grupniTreninzi, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, output);



            using (StreamReader r = new StreamReader(filePath1))
            {
                string json1 = r.ReadToEnd();
                Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json1);
                foreach (var kor in Staticka.korisnici)
                {
                    //da taj trener dobije svoj grupni trening(on je trener na tom grupnom treningu)
                    if (kor.KorisnickoIme == Staticka.trenutni.KorisnickoIme && kor.Uloga == UlogaKorisnika.Trener)
                    {
                        ind = Staticka.korisnici.IndexOf(kor);
                        kNovi.KorisnickoIme = kor.KorisnickoIme;
                        kNovi.Lozinka = kor.Lozinka;
                        kNovi.Ime = kor.Ime;
                        kNovi.Prezime = kor.Prezime;
                        kNovi.Pol = kor.Pol;
                        kNovi.Email = kor.Email;
                        kNovi.Blokiran = kor.Blokiran;
                        kNovi.DatumRodjenja = kor.DatumRodjenja;
                        kNovi.Treninzi = kor.Treninzi;
                        kNovi.Treninzi.Add(grupni);

                        kNovi.Uloga = kor.Uloga;
                        kNovi.Ulogovan = kor.Ulogovan;
                        kNovi.FitnesCentri = kor.FitnesCentri;

                    }
                }






            }
            Staticka.korisnici[ind] = kNovi;

            string output1 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath1, output1);

            return Ok();


        }

        [HttpPost]
        public IHttpActionResult PrikazTreninga()//da bih znala koji trenin je selektovan sad
        {
            string idd = HttpContext.Current.Request.Params["id"];
            int id = Int32.Parse(idd);

            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<GrupniTrening> items = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);

                foreach (var v in items)
                {
                    if (v.Id == id && v.Obrisan == false)
                    {
                        Staticka.gr = v;
                        return Ok();
                    }
                }

            }

            return BadRequest();
        }

        [HttpGet]
        public GrupniTrening TrenutniTrening()//koji je trenutni koji menjam
        {
            return Staticka.gr;
        }

        public static GrupniTrening stari = new GrupniTrening();





        [HttpPost]
        public IHttpActionResult BrisanjeTreninga()
        {
            string idd = HttpContext.Current.Request.Params["id"];
            int id = Int32.Parse(idd);//taj brisemo
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");
            int index = -1;
            DateTime sada = DateTime.Now;
            GrupniTrening novi = new GrupniTrening();
            bool moze = false;
            int ind = -1;
            string filePath1 = Path.Combine(currentDirectory, "App_Data/korisnici.json");

            Korisnik kNovi = new Korisnik();

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
               Staticka.grupniTreninzi= JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
                foreach (var t in Staticka.grupniTreninzi)
                {
                   
                    if(t.Id == id && t.Obrisan == false && t.DatumIVreme > sada && t.Posetioci.Count == 0)//ako se nije odrzao i ako nema pos
                    {
                        novi.Obrisan = true;
                        novi.Id = t.Id;
                        novi.Naziv = t.Naziv;
                        novi.MaxBrPosetilaca = t.MaxBrPosetilaca;
                        novi.DatumIVreme = t.DatumIVreme;
                        novi.Fitnes = t.Fitnes;
                        novi.Posetioci = t.Posetioci;
                        novi.Tip = t.Tip;
                        novi.Trajanje = t.Trajanje;
                        index = Staticka.grupniTreninzi.IndexOf(t);//taj menjamo
                        moze = true;
                    }
                 


                }
            }

            if(moze == true)
            {
                Staticka.gr = novi;
                Staticka.grupniTreninzi[index] = Staticka.gr;
                int indUListi = -1;
               string output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.grupniTreninzi, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath, output);


                using (StreamReader r = new StreamReader(filePath1))
                {
                    string json1 = r.ReadToEnd();
                    Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json1);
                    foreach (var kor in Staticka.korisnici)
                    {
                        //da taj trener dobije svoj grupni trening(on je trener na tom grupnom treningu)
                        if (kor.KorisnickoIme == Staticka.trenutni.KorisnickoIme && kor.Uloga == UlogaKorisnika.Trener)
                        {
                            ind = Staticka.korisnici.IndexOf(kor);
                            kNovi.KorisnickoIme = kor.KorisnickoIme;
                            kNovi.Lozinka = kor.Lozinka;
                            kNovi.Ime = kor.Ime;
                            kNovi.Prezime = kor.Prezime;
                            kNovi.Pol = kor.Pol;
                            kNovi.Email = kor.Email;
                            kNovi.Blokiran = kor.Blokiran;
                            kNovi.DatumRodjenja = kor.DatumRodjenja;
                            kNovi.Uloga = kor.Uloga;
                            kNovi.Ulogovan = kor.Ulogovan;
                            kNovi.FitnesCentri = kor.FitnesCentri;


                            foreach (var t in kor.Treninzi)
                            {
                                if (t.Id == novi.Id)
                                {
                                    indUListi = kor.Treninzi.IndexOf(t);
                                }
                            }

                            kNovi.Treninzi = kor.Treninzi;
                            kNovi.Treninzi[indUListi] = novi;

                        }
                    }






                }
                Staticka.korisnici[ind] = kNovi;

                string output1 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath1, output1);
                return Ok();

            }
            else
            {
                return BadRequest();
            }



        }



        [HttpPut]
        public IHttpActionResult IzmenaTreninga()
        {
            bool izmenio = false;
            int ind = -1;
            int index = -1;
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");
            string filePath1 = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            string output = "";
            string naziv = HttpContext.Current.Request.Params["naziv"];
            string tip = HttpContext.Current.Request.Params["tip"];
            string trajanje = HttpContext.Current.Request.Params["trajanje"];
            string datum = HttpContext.Current.Request.Params["datum"];
            string maxBr = HttpContext.Current.Request.Params["maxBr"];

            GrupniTrening grupni = new GrupniTrening();
            Korisnik kNovi = new Korisnik();
            grupni.Naziv = naziv;
            grupni.Tip = tip;
            grupni.Trajanje = Int32.Parse(trajanje);
            grupni.DatumIVreme = DateTime.Parse(datum);
            grupni.MaxBrPosetilaca = Int32.Parse(maxBr);//mogu da menjam onaj trening koji nije obrisan i onda ga izmenim i u treneru
                                                        //tako da ce trener u sebi imati samo ne obrisane treninge
            DateTime sada = DateTime.Now;
            using (StreamReader r = new StreamReader(filePath))
            {
                string obj = r.ReadToEnd();
                Staticka.grupniTreninzi = JsonConvert.DeserializeObject<List<GrupniTrening>>(obj);


                foreach (var k in Staticka.grupniTreninzi)
                {
                    if (k.Id == Staticka.gr.Id && k.Obrisan == false && k.DatumIVreme > sada)
                    {
                        stari = k;//da zapamtim stari objekat
                        index = Staticka.grupniTreninzi.IndexOf(k);
                        grupni.Id = k.Id;
                        grupni.Posetioci = k.Posetioci;
                        grupni.Fitnes = k.Fitnes;
                        izmenio = true;

                    }

                }

            }

            if (izmenio == true)
            {
                Staticka.gr = grupni;
                Staticka.grupniTreninzi[index] = Staticka.gr;
                int indUListi = -1;
                output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.grupniTreninzi, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath, output);


                using (StreamReader r = new StreamReader(filePath1))
                {
                    string json1 = r.ReadToEnd();
                    Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json1);
                    foreach (var kor in Staticka.korisnici)
                    {
                        //da taj trener dobije svoj grupni trening(on je trener na tom grupnom treningu)
                        if (kor.KorisnickoIme == Staticka.trenutni.KorisnickoIme && kor.Uloga == UlogaKorisnika.Trener)
                        {
                            ind = Staticka.korisnici.IndexOf(kor);
                            kNovi.KorisnickoIme = kor.KorisnickoIme;
                            kNovi.Lozinka = kor.Lozinka;
                            kNovi.Ime = kor.Ime;
                            kNovi.Prezime = kor.Prezime;
                            kNovi.Pol = kor.Pol;
                            kNovi.Email = kor.Email;
                            kNovi.Blokiran = kor.Blokiran;
                            kNovi.DatumRodjenja = kor.DatumRodjenja;
                            kNovi.Uloga = kor.Uloga;
                            kNovi.Ulogovan = kor.Ulogovan;
                            kNovi.FitnesCentri = kor.FitnesCentri;


                            foreach (var t in kor.Treninzi)
                            {
                                if (t.Id == grupni.Id)
                                {
                                    indUListi = kor.Treninzi.IndexOf(t);
                                }
                            }

                            kNovi.Treninzi = kor.Treninzi;
                            kNovi.Treninzi[indUListi] = grupni;

                        }
                    }






                }
                Staticka.korisnici[ind] = kNovi;

                string output1 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath1, output1);
                return Ok();
            }
            else
            {
                return BadRequest();
            }





        }


        }
    }

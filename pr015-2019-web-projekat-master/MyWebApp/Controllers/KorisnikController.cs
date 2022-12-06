using MyWebApp.Models;
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
    public class KorisnikController : ApiController
    {





        [HttpGet]
        public List<FitnesCentar> GetKorisnikPoNazivuRastuce()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            List<FitnesCentar> sortiraniRastuce = new List<FitnesCentar>();
            List<FitnesCentar> fit = new List<FitnesCentar>();

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);

                foreach (var centar in items)//centar je jedan fitnes centar 
                {
                    if (centar.Obrisan == false)
                    {
                        fit.Add(centar);
                    }

                }
                sortiraniRastuce = fit.OrderBy(o => o.Naziv).ToList();


                return sortiraniRastuce;
            }

        }

        [HttpGet]
        public List<FitnesCentar> GetKorisnikPoNazivuOpadajuce()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            List<FitnesCentar> sortiraniRastuce = new List<FitnesCentar>();
        
            List<FitnesCentar> fit = new List<FitnesCentar>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);

                foreach (var centar in items)//centar je jedan fitnes centar 
                {
                    if (centar.Obrisan == false)
                    {
                        fit.Add(centar);
                    }

                }
                sortiraniRastuce = fit.OrderBy(o => o.Naziv).ToList();

                sortiraniRastuce.Reverse();

                return sortiraniRastuce;
               
            }

        }



        [HttpGet]
        public List<FitnesCentar> GetKorisnikPoGodiniOpadajuce()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            List<FitnesCentar> sortiraniRastuce = new List<FitnesCentar>();
           
            List<FitnesCentar> fit = new List<FitnesCentar>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);

                foreach (var centar in items)//centar je jedan fitnes centar 
                {
                    if (centar.Obrisan == false)
                    {
                        fit.Add(centar);
                    }

                }
                sortiraniRastuce = fit.OrderBy(o => o.GodinaOtvaranja).ToList();

                sortiraniRastuce.Reverse();

                return sortiraniRastuce;
            }

        }



        [HttpGet]
        public List<FitnesCentar> FitnesCentriVlasnika()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");

            List<FitnesCentar> fit = new List<FitnesCentar>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);
                foreach(var centar in items)
                {
                    if(centar.KorisnickoImeVlasnika == Staticka.trenutni.KorisnickoIme && centar.Obrisan == false)
                    {
                        fit.Add(centar);
                    }
                }
            }
            return fit;
        }

        [HttpGet]
        public List<FitnesCentar> GetKorisnikPoGodiniRastuce()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            List<FitnesCentar> sortiraniRastuce = new List<FitnesCentar>();
            List<int> godine = new List<int>();
          
            List<FitnesCentar> fit = new List<FitnesCentar>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);


                foreach (var centar in items)//centar je jedan fitnes centar 
                {
                    if (centar.Obrisan == false)
                    {
                        fit.Add(centar);
                    }

                }

                sortiraniRastuce = fit.OrderBy(o => o.GodinaOtvaranja).ToList();
               



                return sortiraniRastuce;
            }

        }




        [HttpGet]
        public List<FitnesCentar> GetKorisnikPoAdresiRastuce()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            List<FitnesCentar> sortiraniRastuce = new List<FitnesCentar>();
            List<FitnesCentar> fit = new List<FitnesCentar>();


            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);

                foreach (var centar in items)//centar je jedan fitnes centar 
                {
                    if (centar.Obrisan == false)
                    {
                        fit.Add(centar);
                    }

                }


                sortiraniRastuce = fit.OrderBy(o => o.AdresaFitnesCentra).ToList();

                return sortiraniRastuce;
            }

        }



        [HttpGet]
        public List<GrupniTrening> GetGrupniTrening()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");
            DateTime vr;
            DateTime sada = DateTime.Now;
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<GrupniTrening> items = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
               foreach(var t in items)
                {
                    vr = t.DatumIVreme;
                    if (vr >= sada && t.Fitnes.Id == Staticka.fc.Id)
                    {
                        treninzi.Add(t);
                    }
           

                }
            }
            return treninzi;

        }



        [HttpGet]
        public List<GrupniTrening> GetGrupniTreningRaniji()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            Korisnik kor = new Korisnik();
           
            DateTime sada = DateTime.Now;
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            List<GrupniTrening> raniji = new List<GrupniTrening>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(json);
                foreach (var t in items)
                {
                    if(t.KorisnickoIme == Staticka.trenutni.KorisnickoIme)
                    {
                        kor = t;
                    }
                    


                }
            }

            treninzi = kor.Treninzi;

            foreach(var tr in treninzi)
            {
                if(tr.DatumIVreme < sada)
                {
                    raniji.Add(tr);
                }
            }

            return raniji;

        }



        [HttpGet]
        public List<FitnesCentar> GetKorisnikPoAdresiOpadajuce()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            List<FitnesCentar> sortiraniRastuce = new List<FitnesCentar>();
            List<string> adrese = new List<string>();

            List<FitnesCentar> fit = new List<FitnesCentar>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);

                foreach (var centar in items)//centar je jedan fitnes centar 
                {
                    if (centar.Obrisan == false)
                    {
                        fit.Add(centar);
                    }

                }


                sortiraniRastuce = fit.OrderBy(o => o.AdresaFitnesCentra).ToList();

              
                sortiraniRastuce.Reverse();


                return sortiraniRastuce;
            }

        }


        [HttpPost]
        public List<FitnesCentar> PretragaCentra()
        {

            string naziv = HttpContext.Current.Request.Params["naziv"];
            string god = HttpContext.Current.Request.Params["godinaMin"];
            string god1 = HttpContext.Current.Request.Params["godinaMax"];
            string adresa = HttpContext.Current.Request.Params["adresa"];
            Int32.TryParse(god, out int godinaMin);
            Int32.TryParse(god1, out int godinaMax);
            List<FitnesCentar> pretrazeni = new List<FitnesCentar>();

            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);
                foreach (var v in items)
                {
                    string adresaa = v.AdresaFitnesCentra;
                    if (v.Obrisan == false)
                    {
                        if (v.Naziv.ToLower() == naziv.ToLower() && (adresa == null || adresa == "") && (god1 == null || god1 == "") && (god == null || god == ""))
                        {
                            pretrazeni.Add(v);
                        }

                        else if (adresaa.ToLower() == adresa.ToLower() && (naziv == null || naziv == "") && (god1 == null || god1 == "") && (god == null || god == ""))
                        {
                            pretrazeni.Add(v);

                        }
                        else if ((v.GodinaOtvaranja >= godinaMin && v.GodinaOtvaranja <= godinaMax) && (adresa == null || adresa == "") && (naziv == null || naziv == ""))
                        {
                            pretrazeni.Add(v);
                        }

                        else if (v.Naziv.ToLower() == naziv.ToLower() && adresaa.ToLower() == adresa.ToLower() && (v.GodinaOtvaranja >= godinaMin && v.GodinaOtvaranja <= godinaMax))
                        {
                            pretrazeni.Add(v);
                        }

                        else if (v.Naziv.ToLower() == naziv.ToLower() && adresaa.ToLower() == adresa.ToLower() && (god == null || god == ""))
                        {
                            pretrazeni.Add(v);
                        }
                        else if (v.Naziv.ToLower() == naziv.ToLower() && (adresa == null || adresa == "") && (v.GodinaOtvaranja >= godinaMin && v.GodinaOtvaranja <= godinaMax))
                        {
                            pretrazeni.Add(v);
                        }
                        else if ((naziv == null || naziv == "") && adresaa.ToLower() == adresa.ToLower() && (v.GodinaOtvaranja >= godinaMin && v.GodinaOtvaranja <= godinaMax))
                        {
                            pretrazeni.Add(v);
                        }

                        else
                        {
                            Console.WriteLine("dalje");
                        }

                    } 
                    
                }
                return pretrazeni;
            }





        }


        [HttpPost]
        public FitnesCentar FitnesCentarDetalji()
        {


            string id = HttpContext.Current.Request.Params["id"];

            Int32.TryParse(id, out int idd);
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);

                foreach (var v in items)
                {
                    if (v.Id == idd && v.Obrisan == false)
                    {

                        Staticka.fc = v;

                    }
                }

            }

            return Staticka.fc;

        }

        [HttpGet]
        public FitnesCentar FitnesCentarDetalji1()
        {
            return Staticka.fc;
        }



      [HttpPost]
      public IHttpActionResult DodavanjeFitnesCentra()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            string filePath1 = Path.Combine(currentDirectory, "App_Data/korisnici.json");

            string naziv = HttpContext.Current.Request.Params["naziv"];
            string adresa = HttpContext.Current.Request.Params["adresa"];
            string godina = HttpContext.Current.Request.Params["godina"];
            string cenaMes = HttpContext.Current.Request.Params["cenaMes"];
            string cenaGod = HttpContext.Current.Request.Params["cenaGod"];
            string cenaJednog = HttpContext.Current.Request.Params["cenaJednog"];
            string cenaJedGr = HttpContext.Current.Request.Params["cenaJedGr"];
            Korisnik kNovi = new Korisnik();

            string cenaJedGrSaTr = HttpContext.Current.Request.Params["cenaJedGrSaTr"];

            FitnesCentar fitnes = new FitnesCentar();
            fitnes.Naziv = naziv;
            fitnes.AdresaFitnesCentra = adresa;
            fitnes.GodinaOtvaranja = Int32.Parse(godina);
            fitnes.CenaMesecneClanarine = Double.Parse(cenaMes);
            fitnes.CenaGodisnjeClanarine = Double.Parse(cenaGod);
            fitnes.CenaJednogTreninga = Double.Parse(cenaJednog);
            fitnes.CenaJednogTrSaPersTrenerom = Double.Parse(cenaJedGrSaTr);
            fitnes.CenaJednogGrupnogTreninga = Double.Parse(cenaJedGr);

            fitnes.KorisnickoImeVlasnika = Staticka.trenutni.KorisnickoIme;
            fitnes.Id = FitnesCentar.GenerateId();//generise jedinstven id uvek
            fitnes.Obrisan = false;//inicijalno nije obrisan

            int ind = -1;
           

                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    Staticka.centri = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);




                }
                Staticka.centri.Add(fitnes);


                string output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.centri, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath, output);


            using (StreamReader r = new StreamReader(filePath1))
            {
                string json1= r.ReadToEnd();
                Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json1);
                foreach(var kor in Staticka.korisnici)
                {
                    if (kor.KorisnickoIme == Staticka.trenutni.KorisnickoIme && kor.Uloga == UlogaKorisnika.Vlasnik)
                    {
                        ind = Staticka.korisnici.IndexOf(kor);
                        kNovi.KorisnickoIme =kor.KorisnickoIme;
                        kNovi.Lozinka = kor.Lozinka;
                        kNovi.Ime = kor.Ime;
                        kNovi.Prezime = kor.Prezime;
                        kNovi.Pol = kor.Pol;
                        kNovi.Email =kor.Email;
                        kNovi.Blokiran = kor.Blokiran;
                        kNovi.DatumRodjenja = kor.DatumRodjenja;
                        kNovi.Treninzi = kor.Treninzi;
                        kNovi.Uloga = kor.Uloga;
                        kNovi.Ulogovan =kor.Ulogovan;
                        kNovi.FitnesCentri.Add(fitnes);

                    }
                }
               





            }
            Staticka.korisnici[ind] = kNovi;

            string output1 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath1, output1);



            return Ok();
          



        }


        [HttpPost]
        public IHttpActionResult Registracija()
        {
            List<Korisnik> nekiK = new List<Korisnik>();
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            bool moze = true;

            string kIme = HttpContext.Current.Request.Params["kIme"];
            string lozinka = HttpContext.Current.Request.Params["lozinka"];
            string ime = HttpContext.Current.Request.Params["ime"];
            string prezime = HttpContext.Current.Request.Params["prezime"];
            string pol= HttpContext.Current.Request.Params["pol"];
            string email = HttpContext.Current.Request.Params["email"];
            string datum = HttpContext.Current.Request.Params["datum"];

            Korisnik k = new Korisnik();
            k.KorisnickoIme = kIme;
            k.Lozinka = lozinka;
            k.Ime = ime;
            k.Prezime = prezime;
            if (pol == "muski")
            {
                k.Pol = EnumPol.musko;
            }
            else
            {
                k.Pol = EnumPol.zensko;
            }
            k.Email = email;
            k.DatumRodjenja = DateTime.Parse(datum);
            k.Uloga = UlogaKorisnika.Posetilac;
            k.FitnesCentri = new List<FitnesCentar>();
            k.Treninzi = new List<GrupniTrening>();
            k.Ulogovan = false;
            using (StreamReader r = new StreamReader(filePath))
            {
                string obj = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(obj);
                foreach(var i in items)
                {
                    if(i.KorisnickoIme == kIme)
                    {
                        moze = false;
                    }
                }


            }


            if (moze)
            {

                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json);
                    



                }
                Staticka.korisnici.Add(k);


                string output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath, output);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           







          


        }



       


        [HttpPost]
        public IHttpActionResult DodajTrenera()
        {


            List<Korisnik> nekiK = new List<Korisnik>();
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");

            FitnesCentar fitnesC = new FitnesCentar();
           
            string filePath1 = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");

            using (StreamReader r = new StreamReader(filePath1))
            {
                string json = r.ReadToEnd();
                Staticka.centri = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);
                foreach(var c in Staticka.centri)
                {
                    if(c.Id == fitnesCent)//za taj fitnes centar hocemo da dodamo
                    {
                        fitnesC = c;//njega cu dodati kao fitnes centar ovog trenera(tu radi)
                    }
                }



            }
           


            bool moze = true;

            string kIme = HttpContext.Current.Request.Params["kIme"];
            string lozinka = HttpContext.Current.Request.Params["lozinka"];
            string ime = HttpContext.Current.Request.Params["ime"];
            string prezime = HttpContext.Current.Request.Params["prezime"];
            string pol = HttpContext.Current.Request.Params["pol"];
            string email = HttpContext.Current.Request.Params["email"];
            string datum = HttpContext.Current.Request.Params["datum"];

            Korisnik k = new Korisnik();
            k.KorisnickoIme = kIme;
            k.Lozinka = lozinka;
            k.Ime = ime;
            k.Prezime = prezime;
            if (pol == "muski")
            {
                k.Pol = EnumPol.musko;
            }
            else
            {
                k.Pol = EnumPol.zensko;
            }
            k.Email = email;
            k.DatumRodjenja = DateTime.Parse(datum);
            k.Uloga = UlogaKorisnika.Trener;





          
             
            k.Treninzi = new List<GrupniTrening>();
            k.Ulogovan = false;
            using (StreamReader r = new StreamReader(filePath))
            {
                string obj = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(obj);
                foreach (var i in items)
                {
                    if (i.KorisnickoIme == kIme)//ako je taj korisnik vec negde dodat ne moze ponovo
                    {
                        moze = false;
                    }
                }


            }

            if (moze)
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json);


                }
                k.FitnesCentri.Add(fitnesC);
                Staticka.korisnici.Add(k);


                string output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath, output);
                return Ok();
            }
            else
            {
                return BadRequest();
            }











        }




        [HttpPost]
        public int Prijava()
        {
            int br = -1;//nije ulogovan
            string kIme = HttpContext.Current.Request.Params["kIme"];
            string lozinka = HttpContext.Current.Request.Params["lozinka"];
            
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(json);

                foreach(var k in items)
                {
                    if(k.KorisnickoIme == kIme && k.Lozinka == lozinka)//ako je blokiran ne moze se prijaviti
                    {
                        if (k.Blokiran == false)
                        {

                            Staticka.ulogovani.Add(k);
                            Staticka.trenutni = k;
                            Staticka.trenutni.Ulogovan = true;
                            br = 0;//ulogovao se
                            
                        }
                        else
                        {
                            br = 1;//blokiran je

                        }

                    }
                  
                      
                    
                  
                  
                }
            }
            return br;
            }



      


        [HttpGet]
        public Korisnik DaLiJeLogovan()
        {
           
            return Staticka.trenutni;
          
        }





        [HttpPost]
        public IHttpActionResult BrisanjeFitnesCentra()            
        {


            List<Korisnik> kori = new List<Korisnik>();
            bool jesteObrisan = false;
            string output2 = "";
            int indexKor = -1;
            string idd = HttpContext.Current.Request.Params["id"];
            int id = Int32.Parse(idd);
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            bool moze = true;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");

            string filePath3 = Path.Combine(currentDirectory, "App_Data/korisnici.json");

            Korisnik nekiNovi = new Korisnik();
            List<Korisnik> treneri = new List<Korisnik>();

            List<Korisnik> kojiSeBlok = new List<Korisnik>();


            DateTime vr;
            DateTime sada = DateTime.Now;
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<GrupniTrening> items = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
                foreach (var t in items)
                {
                    vr = t.DatumIVreme;
                    if (vr > sada && t.Fitnes.Id == Staticka.fc.Id)
                    {
                        treninzi.Add(t);
                    }


                }
            }

            foreach (var tr in treninzi)
            {
                if (tr.Fitnes.Id == id)
                {
                    moze = false;
                }
            }





            int index = -1;
            string output1 = "";

            FitnesCentar novi = new FitnesCentar();
            string filePath1 = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");


            if(moze)
            {
                using (StreamReader r = new StreamReader(filePath1))
                {
                    string obj = r.ReadToEnd();
                    Staticka.centri = JsonConvert.DeserializeObject<List<FitnesCentar>>(obj);


                    foreach (var k in Staticka.centri)
                    {
                        if (k.Id == Staticka.fcc.Id && k.Obrisan == false)
                        {
                            index = Staticka.centri.IndexOf(k);
                            novi.Id = k.Id;
                            novi.Obrisan = true;
                            novi.Naziv = k.Naziv;
                            novi.AdresaFitnesCentra = k.AdresaFitnesCentra;
                            novi.CenaGodisnjeClanarine = k.CenaGodisnjeClanarine;
                            novi.CenaJednogGrupnogTreninga = k.CenaJednogGrupnogTreninga;
                            novi.CenaJednogTreninga = k.CenaJednogTreninga;
                            novi.CenaJednogTrSaPersTrenerom = k.CenaJednogTrSaPersTrenerom;
                            novi.CenaMesecneClanarine = k.CenaMesecneClanarine;
                            novi.KorisnickoImeVlasnika = k.KorisnickoImeVlasnika;
                            jesteObrisan = true;

                        }
                    }

                }

            }



            if (jesteObrisan)
            {
                Staticka.fcc = novi;

                Staticka.centri[index] = Staticka.fcc;
                output1 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.centri, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath1, output1);

                using (StreamReader r = new StreamReader(filePath3))
                {
                    string obj1 = r.ReadToEnd();
                    Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(obj1);
                    foreach (var i in Staticka.korisnici)
                    {
                        if (i.Uloga == UlogaKorisnika.Trener)
                        {
                            foreach (var b in i.FitnesCentri)
                            {
                                if (b.Id == id)
                                {
                                    kojiSeBlok.Add(i);
                                }
                            }
                        }

                    }





                }

            }


            foreach (var kor in kori)//da bi blokiralo sve korisnike
            {
                foreach (var k in kojiSeBlok)
                {
                    if (kor.KorisnickoIme == k.KorisnickoIme)
                    {
                        indexKor = kori.IndexOf(k);

                        nekiNovi.Ime = kor.Ime;
                        nekiNovi.Prezime = kor.Prezime;
                        nekiNovi.KorisnickoIme = kor.KorisnickoIme;
                        nekiNovi.Lozinka = kor.Lozinka;
                        nekiNovi.Pol = kor.Pol;
                        nekiNovi.Uloga = kor.Uloga;
                        nekiNovi.Ulogovan = kor.Ulogovan;
                        nekiNovi.Treninzi = kor.Treninzi;
                        nekiNovi.FitnesCentri = kor.FitnesCentri;
                        nekiNovi.DatumRodjenja = kor.DatumRodjenja;
                        nekiNovi.Email = kor.Email;
                        nekiNovi.Blokiran = true;

                        Staticka.korisnici[indexKor] = nekiNovi;
                        output2 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

                        System.IO.File.WriteAllText(filePath3, output2);
                    }
                }

            }
            return Ok();


        }

    




        [HttpPost]
        public IHttpActionResult PrikazFitnesCentra()
        {
            string idd = HttpContext.Current.Request.Params["id"];
            int id = Int32.Parse(idd);

            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<FitnesCentar> items = JsonConvert.DeserializeObject<List<FitnesCentar>>(json);

                foreach (var v in items)
                {
                    if (v.Id == id && v.Obrisan == false)
                    {
                        Staticka.fcc = v;
                        return Ok();
                    }
                }

            }

            return BadRequest();
        }





        [HttpGet]
        public FitnesCentar TrenutniFc()//koji je trenutni koji menjam
        {
            return Staticka.fcc;
        }

        [HttpPost]
        public Korisnik PrikazProfilaKorisnika()//taj profil da mi prikaze kad kliknem na prikaz
        {


            string id = HttpContext.Current.Request.Params["id"];

           
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(json);

                foreach (var v in items)
                {
                    if (v.KorisnickoIme == id)
                    {
                        Staticka.trenutni = v;
              }
                }

            }
            Staticka.trenutni.Ulogovan = true;
            return Staticka.trenutni;

        }
        [HttpGet]
        public Korisnik Ulogovani()
        {
            return Staticka.trenutni;
        }




        [HttpPost]
        public IHttpActionResult BlokiranjeTrenera()
        {
            string id = HttpContext.Current.Request.Params["korimrTr"];
            int index = -1;
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            Korisnik kor = new Korisnik();
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
             Staticka.korisnici= JsonConvert.DeserializeObject<List<Korisnik>>(json);

                foreach (var k in Staticka.korisnici)
                {
                   if(k.KorisnickoIme == id && k.Uloga == UlogaKorisnika.Trener)
                    {
                        index = Staticka.korisnici.IndexOf(k);
                        kor.KorisnickoIme = k.KorisnickoIme;
                        kor.Lozinka = k.Lozinka;
                        kor.Ime = k.Ime;
                        kor.Prezime = k.Prezime;
                        kor.Blokiran = true;
                        kor.DatumRodjenja = k.DatumRodjenja;
                        kor.Email = k.Email;
                        kor.FitnesCentri = k.FitnesCentri;
                        kor.Uloga = k.Uloga;
                        kor.Pol = k.Pol;
                        kor.Treninzi = k.Treninzi; 
                    }

                   
                }

               
            }
            Staticka.korisnici[index] = kor;
            string output2 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, output2);
            return Ok();
        }


        [HttpPost]
        public IHttpActionResult OdbijKomentar()
        {
            Komentar k = new Komentar();
            int index = -1;
            string id = HttpContext.Current.Request.Params["id"];
            List<Komentar> items = new List<Komentar>();
            Int32.TryParse(id, out int idd);
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/komentari.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Komentar>>(json);

                foreach(var i in items)
                {
                    if(i.Id == idd)
                    {
                        index = items.IndexOf(i);
                        k.Posetilac = i.Posetilac;
                        k.Centar = i.Centar;
                        k.Ocena = i.Ocena;
                        k.TekstKomentara = i.TekstKomentara;
                        k.Odobren = false;
                        k.Id = i.Id;
                    }
                }

            }
            items[index] = k;
           
           string output = Newtonsoft.Json.JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, output);
            return Ok();

        }


        [HttpPost]
        public IHttpActionResult OdobriKomentar()
        {
            Komentar k = new Komentar();
            int index = -1;
            string id = HttpContext.Current.Request.Params["id"];
            List<Komentar> items = new List<Komentar>();
            Int32.TryParse(id, out int idd);
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/komentari.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Komentar>>(json);

                foreach (var i in items)
                {
                    if (i.Id == idd)
                    {
                        index = items.IndexOf(i);
                        k.Posetilac = i.Posetilac;
                        k.Centar = i.Centar;
                        k.Ocena = i.Ocena;
                        k.TekstKomentara = i.TekstKomentara;
                        k.Odobren = true;
                        k.Id = i.Id;
                    }
                }

            }
            items[index] = k;
           
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, output);
            return Ok();

        }



        [HttpGet]
        public int DaLiJeOdbijen()
        {
            return Staticka.Odbij;
        }




        [HttpPut]
        public IHttpActionResult IzmenaFitnesCentra()
        {
            int index = -1;
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/fitnesCentri.json");

            string naziv = HttpContext.Current.Request.Params["naziv"];
            string adresa = HttpContext.Current.Request.Params["adresa"];
            string godina = HttpContext.Current.Request.Params["godina"];
            string cenaMes = HttpContext.Current.Request.Params["cenaMes"];
            string cenaGod = HttpContext.Current.Request.Params["cenaGod"];
            string cenaJednog = HttpContext.Current.Request.Params["cenaJednog"];
            string cenaJedGr = HttpContext.Current.Request.Params["cenaJedGr"];
            string output = "";
            string cenaJedGrSaTr = HttpContext.Current.Request.Params["cenaJedGrSaTr"];
            FitnesCentar novi = new FitnesCentar();

            novi.Naziv = naziv;
            novi.AdresaFitnesCentra = adresa;
            novi.GodinaOtvaranja = Int32.Parse(godina);
            novi.CenaMesecneClanarine = Double.Parse(cenaMes);
            novi.CenaGodisnjeClanarine = Double.Parse(cenaGod);
            novi.CenaJednogTreninga = Double.Parse(cenaJednog);
            novi.CenaJednogTrSaPersTrenerom = Double.Parse(cenaJedGrSaTr);
            novi.CenaJednogGrupnogTreninga = Double.Parse(cenaJedGr);

            novi.KorisnickoImeVlasnika = Staticka.trenutni.KorisnickoIme;
            

            using (StreamReader r = new StreamReader(filePath))
            {
                string obj = r.ReadToEnd();
                Staticka.centri = JsonConvert.DeserializeObject<List<FitnesCentar>>(obj);


                foreach (var k in Staticka.centri)
                {
                    if (k.Id == Staticka.fcc.Id && k.Obrisan == false)
                    {
                        index = Staticka.centri.IndexOf(k);
                        novi.Id = k.Id;
                        novi.Obrisan = k.Obrisan;

                    }
                }

            }

            Staticka.fcc = novi;

            Staticka.centri[index] = Staticka.fcc;
            output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.centri, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, output);
            return Ok();




        }

        [HttpPut]
        public IHttpActionResult Izmena()
        {
          
            List<Korisnik> noviKor = new List<Korisnik>();
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            Korisnik jedan = new Korisnik();

            int index = -1;
            Korisnik neki = new Korisnik();
            Korisnik menjam = new Korisnik();
            string kIme = HttpContext.Current.Request.Params["kIme"];
            string lozinka = HttpContext.Current.Request.Params["lozinka"];
            string ime = HttpContext.Current.Request.Params["ime"];
            string prezime = HttpContext.Current.Request.Params["prezime"];
            string pol = HttpContext.Current.Request.Params["pol"];
            string email = HttpContext.Current.Request.Params["email"];
            string datum = HttpContext.Current.Request.Params["datum"];
            string output = "";


            neki.KorisnickoIme = kIme;
            neki.Lozinka = lozinka;
            neki.Ime = ime;
            neki.Prezime = prezime;
            if (pol == "muski")
            {
                neki.Pol = EnumPol.musko;
            }
            else
            {
                neki.Pol = EnumPol.zensko;
            }
            neki.Email = email;
            neki.DatumRodjenja = DateTime.Parse(datum);

            neki.Treninzi = Staticka.trenutni.Treninzi;
            neki.FitnesCentri = Staticka.trenutni.FitnesCentri;
            neki.Uloga = Staticka.trenutni.Uloga;
            neki.Ulogovan = true;



            using (StreamReader r = new StreamReader(filePath))
            {
                string obj = r.ReadToEnd();
                Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(obj);


                foreach (var k in Staticka.korisnici)
                {
                    if (k.KorisnickoIme == Staticka.trenutni.KorisnickoIme)
                    {
                        index = Staticka.korisnici.IndexOf(k);

                        
                    }
                }
              
            }


            Staticka.trenutni = neki;

            Staticka.korisnici[index] = Staticka.trenutni;
            output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, output);
             return Ok();


        }


        [HttpPost]
        public IHttpActionResult Odjava()//taj profil da mi prikaze kad kliknem na prikaz
        {

            
            string koriME = HttpContext.Current.Request.Params["id"];


            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Korisnik> items = JsonConvert.DeserializeObject<List<Korisnik>>(json);

                foreach (var v in items)
                {
                    if (v.KorisnickoIme == koriME)
                    {

                        Staticka.ulogovani.Remove(v);
                        Staticka.trenutni.Ulogovan = false;

                    }
                }

            }

            return Ok();

        }




        [HttpPost]
        public IHttpActionResult PrijaviSeNaGrupniTrening()
        {
           
            string output = "";
            string output1 = "";

            GrupniTrening gr = new GrupniTrening();
            int index = -1;
            int index1 = -1;
            string id = HttpContext.Current.Request.Params["id"];
           
            Int32.TryParse(id, out int idd);
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/treninzi.json");

          



                using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                Staticka.grupniTreninzi = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);

                foreach (var trening in Staticka.grupniTreninzi)
                {
                    if (trening.Id == idd)
                    {
                        index = Staticka.grupniTreninzi.IndexOf(trening);
                        gr.Id = idd;
                        gr.Naziv = trening.Naziv;
                        gr.Tip = trening.Tip;
                        gr.Fitnes = Staticka.fc;
                        gr.Trajanje = trening.Trajanje;
                        gr.DatumIVreme = trening.DatumIVreme;
                        gr.MaxBrPosetilaca = trening.MaxBrPosetilaca;
                        Staticka.posetioci = trening.Posetioci;
                        if (!Staticka.posetioci.Contains(Staticka.trenutni.KorisnickoIme) &&  (Staticka.posetioci.Count() + 1) <= trening.MaxBrPosetilaca)//tu sam uradila da jedan moze da se prijavi na jedan trening samo
                        {
                            Staticka.posetioci.Add(Staticka.trenutni.KorisnickoIme);
                            
                        }
                        else
                        {
                            return BadRequest();
                        }
                     
                    }
                }

            }

            gr.Posetioci = Staticka.posetioci;
            Staticka.grup = gr;
            Staticka.grupniTreninzi[index] = Staticka.grup;
            output = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.grupniTreninzi, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath, output);






            string filePath1 = Path.Combine(currentDirectory, "App_Data/korisnici.json");

            using (StreamReader r = new StreamReader(filePath1))
            {
                string json1 = r.ReadToEnd();
                Staticka.korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json1);
                foreach (var kor in Staticka.korisnici)
                {
                    if (kor.KorisnickoIme == Staticka.trenutni.KorisnickoIme)
                    {
                        index1 = Staticka.korisnici.IndexOf(kor);//na kom indeksu mi je bas taj trenutni korisnik
                    }
                }

            }



            Staticka.korisnici[index1].Treninzi.Add(Staticka.grup);
            output1 = Newtonsoft.Json.JsonConvert.SerializeObject(Staticka.korisnici, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(filePath1, output1);


            return Ok();
        }
        [HttpPost]
        public IHttpActionResult DodajKomentar()
        {
            List<Komentar> noviKor = new List<Komentar>();
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/komentari.json");
            Komentar jedan = new Komentar();
            string komentar = HttpContext.Current.Request.Params["komentar"];
            string ocena = HttpContext.Current.Request.Params["ime"];
            Komentar koment = new Komentar();

            List<Komentar> komentari = new List<Komentar>();


            bool mozeKomentarisati = false;
            string output1 = "";

            string imee = Staticka.trenutni.KorisnickoIme;
            string filePath1 = Path.Combine(currentDirectory, "App_Data/treninzi.json");

            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            using (StreamReader r = new StreamReader(filePath1))
            {
                string json = r.ReadToEnd();
                List<GrupniTrening> items = JsonConvert.DeserializeObject<List<GrupniTrening>>(json);
                foreach (var g in items)
                {
                    if (g.Posetioci.Contains(imee))
                    {
                        if (g.Fitnes.Id == Staticka.fc.Id)
                        {
                            mozeKomentarisati = true;
                        }
                    }
                }

            }
            if (mozeKomentarisati)
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string obj = r.ReadToEnd();
                    komentari = JsonConvert.DeserializeObject<List<Komentar>>(obj);

                }
                if (komentari == null)
                {
                    komentari = new List<Komentar>();
                }
                koment.TekstKomentara = komentar;
                koment.Ocena = Int32.Parse(ocena);
                koment.Posetilac = Staticka.trenutni;
                koment.Centar = Staticka.fc;
                koment.Odobren = false; //inicijalno nije odobren
                koment.Id = Komentar.GenerateId();
                komentari.Add(koment);
                output1 = Newtonsoft.Json.JsonConvert.SerializeObject(komentari, Newtonsoft.Json.Formatting.Indented);

                System.IO.File.WriteAllText(filePath, output1);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


            [HttpGet]
            public List<Komentar> IspisKomentara()
            {


            List<Komentar> dozvoljeni = new List<Komentar>();
            List<Komentar> komentari = new List<Komentar>();
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/komentari.json");
            
            using (StreamReader r = new StreamReader(filePath))
            {
                string obj = r.ReadToEnd();
                komentari = JsonConvert.DeserializeObject<List<Komentar>>(obj);

            }
            foreach(var k in komentari)
            {
                if(k.Centar.Id == Staticka.fc.Id)
                {
                    dozvoljeni.Add(k);
                }
            }
          

            return dozvoljeni;


        }

        public static int fitnesCent;

        [HttpPost]
        public IHttpActionResult DodajUFitnes()
        {
            string id = HttpContext.Current.Request.Params["id"];
            fitnesCent = Int32.Parse(id);
            return Ok();

        }






    }
}

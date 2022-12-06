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
    public class PretragaController : ApiController
    {







        private List<GrupniTrening> GetGrupniTrenerovTreningRaniji()
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
                if (tr.Obrisan == false && tr.DatumIVreme < sada)//da prikaze samo one treninge koji nisu obrisani
                {
                    izabrani.Add(tr);
                }
            }




            return izabrani;

        }


        [HttpGet]
        public List<GrupniTrening> RastucePoNazivu()//za ranije tr(trener)
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<string> nazivi = new List<string>();
            List<GrupniTrening> tr = new List<GrupniTrening>();
            tr = GetGrupniTrenerovTreningRaniji();






            sortiraniRastuce = tr.OrderBy(o => o.Naziv).ToList();




            return sortiraniRastuce;






        }
        [HttpGet]
        public List<GrupniTrening> OpadajucePoNazivu()//za ranije tr(trener)
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<string> nazivi = new List<string>();
            List<GrupniTrening> tr = new List<GrupniTrening>();
            tr = GetGrupniTrenerovTreningRaniji();






            sortiraniRastuce = tr.OrderBy(o => o.Naziv).ToList();
            sortiraniRastuce.Reverse();



            return sortiraniRastuce;






        }


        [HttpGet]
        public List<GrupniTrening> RastucePoTipu()//za ranije tr(trener)
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<string> nazivi = new List<string>();
            List<GrupniTrening> tr = new List<GrupniTrening>();
            tr = GetGrupniTrenerovTreningRaniji();
            sortiraniRastuce = tr.OrderBy(o => o.Tip).ToList();
            return sortiraniRastuce;






        }




        [HttpGet]
        public List<GrupniTrening> OpadajucePoTipu()//za ranije tr(trener)
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<string> nazivi = new List<string>();
            List<GrupniTrening> tr = new List<GrupniTrening>();
            tr = GetGrupniTrenerovTreningRaniji();






            sortiraniRastuce = tr.OrderBy(o => o.Tip).ToList();
            sortiraniRastuce.Reverse();



            return sortiraniRastuce;






        }


        [HttpGet]
        public List<GrupniTrening> OpadajucePoDatumu()//za ranije tr(trener)
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<string> nazivi = new List<string>();
            List<GrupniTrening> tr = new List<GrupniTrening>();
            tr = GetGrupniTrenerovTreningRaniji();






            sortiraniRastuce = tr.OrderBy(o => o.DatumIVreme).ToList();
            sortiraniRastuce.Reverse();



            return sortiraniRastuce;






        }

        [HttpGet]
        public List<GrupniTrening> RastucePoDatumu()//za ranije tr(trener)
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<string> nazivi = new List<string>();
            List<GrupniTrening> tr = new List<GrupniTrening>();
            tr = GetGrupniTrenerovTreningRaniji();






            sortiraniRastuce = tr.OrderBy(o => o.DatumIVreme).ToList();
          


            return sortiraniRastuce;






        }
















        private List<GrupniTrening> Lista()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            Korisnik kor = new Korisnik();

            DateTime sada = DateTime.Now;
            List<GrupniTrening> treninzi = new List<GrupniTrening>();

          
            List<GrupniTrening> raniji = new List<GrupniTrening>();//nju pretrazujem
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

            treninzi = kor.Treninzi;

            foreach (var tr in treninzi)
            {
                if (tr.DatumIVreme < sada)
                {
                    raniji.Add(tr);
                }
            }

            return raniji;

        }
        [HttpGet]
        public List<GrupniTrening> SortiranjeRastuceNaziv()
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<string> nazivi = new List<string>();
            List<GrupniTrening> tr = new List<GrupniTrening>();
            List<GrupniTrening> trening = Lista();
            foreach (var centar in trening)//centar je jedan fitnes centar 
            {
                if (centar.Obrisan == false)
                {
                    tr.Add(centar);
                }

            }


            sortiraniRastuce = tr.OrderBy(o => o.Naziv).ToList();


        

            return sortiraniRastuce;






        }


      





        [HttpGet]
        public List<GrupniTrening> SortiranjeRastuceTip()
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<GrupniTrening> tr = new List<GrupniTrening>();
            List<GrupniTrening> trening = Lista();
            foreach (var centar in trening)//centar je jedan fitnes centar 
            {
                if (centar.Obrisan == false)
                {
                    tr.Add(centar);
                }

            }


            sortiraniRastuce = tr.OrderBy(o => o.Tip).ToList();




            return sortiraniRastuce;
         











        }






        [HttpGet]
        public List<GrupniTrening> SortiranjeRastuceDatum()
        {

            List<GrupniTrening> sortiraniRastuce = new List<GrupniTrening>();

            List<GrupniTrening> tr = new List<GrupniTrening>();
            List<GrupniTrening> trening = Lista();
            foreach (var centar in trening)//centar je jedan fitnes centar 
            {
                if (centar.Obrisan == false)
                {
                    tr.Add(centar);
                }

            }


            sortiraniRastuce = tr.OrderBy(o => o.DatumIVreme).ToList();




            return sortiraniRastuce;
          
        }




        [HttpGet]
        public List<GrupniTrening> SortiranjeOpadajuceDatum()
        {

            List<GrupniTrening> sortiraniOpadajuce = new List<GrupniTrening>();

            List<GrupniTrening> tr = new List<GrupniTrening>();
            List<GrupniTrening> trening = Lista();
            foreach (var centar in trening)//centar je jedan fitnes centar 
            {
                if (centar.Obrisan == false)
                {
                    tr.Add(centar);
                }

            }


            sortiraniOpadajuce = tr.OrderBy(o => o.DatumIVreme).ToList();

            sortiraniOpadajuce.Reverse();


            return sortiraniOpadajuce;
        }



        [HttpGet]
        public List<GrupniTrening> SortiranjeOpadajuceTip()
        {

            List<GrupniTrening> sortiraniOpadajuce = new List<GrupniTrening>();

            List<GrupniTrening> tr = new List<GrupniTrening>();
            List<GrupniTrening> trening = Lista();
            foreach (var centar in trening)//centar je jedan fitnes centar 
            {
                if (centar.Obrisan == false)
                {
                    tr.Add(centar);
                }

            }


            sortiraniOpadajuce = tr.OrderBy(o => o.Tip).ToList();

            sortiraniOpadajuce.Reverse();


            return sortiraniOpadajuce;






        }



        [HttpGet]
        public List<GrupniTrening> SortiranjeOpadajuceNaziv()
        {

            List<GrupniTrening> sortiraniOpadajuce = new List<GrupniTrening>();

            List<GrupniTrening> tr = new List<GrupniTrening>();
            List<GrupniTrening> trening = Lista();
            foreach (var centar in trening)//centar je jedan fitnes centar 
            {
                if (centar.Obrisan == false)
                {
                    tr.Add(centar);
                }

            }


            sortiraniOpadajuce = tr.OrderBy(o => o.Naziv).ToList();

            sortiraniOpadajuce.Reverse();


            return sortiraniOpadajuce;





        }







        [HttpPost]
        public List<GrupniTrening> PretragaCentraTrener()
        {
            List<GrupniTrening> tr = new List<GrupniTrening>();
            tr = GetGrupniTrenerovTreningRaniji();//tu listu pretrazujem

            string naziv = HttpContext.Current.Request.Params["naziv"];
            string tip = HttpContext.Current.Request.Params["tip"];

            string god = HttpContext.Current.Request.Params["godinaMin"];
            string god1 = HttpContext.Current.Request.Params["godinaMax"];
            Int32.TryParse(god, out int godinaMin);
            Int32.TryParse(god1, out int godinaMax);

            List<GrupniTrening> pretrazeni = new List<GrupniTrening>();
            foreach (var v in tr)
            {

                int godina = v.DatumIVreme.Year;

                if (v.Naziv.ToLower() == naziv.ToLower() && (tip == null || tip == "") && (god1 == null || god1 == "") && (god1 == null || god1 == ""))
                {
                    pretrazeni.Add(v);
                }

                else if (v.Tip.ToLower() == tip.ToLower() && (naziv == null || naziv == "") && (god1 == null || god1 == "") && (god == null || god == ""))
                {
                    pretrazeni.Add(v);

                }
                else if ((godina >= godinaMin && godina <= godinaMax) && (tip == null || tip == "") && (naziv == null || naziv == ""))
                {
                    pretrazeni.Add(v);
                }
                else if (v.Naziv.ToLower() == naziv.ToLower() && v.Tip.ToLower() == tip.ToLower() && (godina >= godinaMin && godina <= godinaMax))
                {
                    pretrazeni.Add(v);
                }
                else if (v.Naziv.ToLower() == naziv.ToLower() && v.Tip.ToLower() == tip.ToLower() && (god == null || god == ""))
                {
                    pretrazeni.Add(v);
                }

                else if (v.Naziv.ToLower() == naziv.ToLower() && (tip == null || tip == "") && (godina >= godinaMin && godina <= godinaMax))
                {
                    pretrazeni.Add(v);
                }
                else if ((naziv == null || naziv == "") && v.Tip.ToLower() == tip.ToLower() && (godina >= godinaMin && godina <= godinaMax))
                {
                    pretrazeni.Add(v);
                }
                else
                {
                    Console.WriteLine("Dalje");
                }

            }
            return pretrazeni;

        }





        [HttpPost]
        public List<GrupniTrening> PretragaTreninga()
        {
            string currentDirectory = HttpRuntime.AppDomainAppPath;
            string filePath = Path.Combine(currentDirectory, "App_Data/korisnici.json");
            Korisnik kor = new Korisnik();

            DateTime sada = DateTime.Now;
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            List<GrupniTrening> raniji = new List<GrupniTrening>();//nju pretrazujem
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

            treninzi = kor.Treninzi;

            foreach (var tr in treninzi)
            {
                if (tr.DatumIVreme < sada)
                {
                    raniji.Add(tr);
                }
            }
            string naziv = HttpContext.Current.Request.Params["naziv"];
            string nazivFc = HttpContext.Current.Request.Params["nazFc"];

            string tip = HttpContext.Current.Request.Params["tip"];


            List<GrupniTrening> pretrazeni = new List<GrupniTrening>();


            foreach (var v in raniji)
            {


                if (v.Naziv.ToLower() == naziv.ToLower() && (nazivFc == null || nazivFc == "") && (tip == null || tip == ""))
                {
                    pretrazeni.Add(v);
                }

                else if ((tip == null || tip == "") && (naziv == null || naziv == "") && (v.Fitnes.Naziv.ToLower() == nazivFc.ToLower()))
                {
                    pretrazeni.Add(v);

                }
                else if ((v.Tip.ToLower() == tip.ToLower()) && (naziv == null || naziv == "") && (nazivFc == null || nazivFc == ""))
                {
                    pretrazeni.Add(v);
                }

                else if (v.Naziv.ToLower() == naziv.ToLower() && v.Fitnes.Naziv.ToLower() == nazivFc.ToLower() && (tip == null || tip == ""))
                {
                    pretrazeni.Add(v);
                }

                else if (v.Naziv.ToLower() == naziv.ToLower() && (v.Tip.ToLower() == tip.ToLower()) && (nazivFc == null || nazivFc == ""))
                {
                    pretrazeni.Add(v);
                }
                else if ((naziv == null || naziv == "") && (v.Tip.ToLower() == tip.ToLower()) && (v.Fitnes.Naziv.ToLower() == nazivFc.ToLower()))
                {
                    pretrazeni.Add(v);
                }
                else if (v.Naziv.ToLower() == naziv.ToLower() && v.Tip.ToLower() == tip.ToLower() && v.Fitnes.Naziv.ToLower() == nazivFc.ToLower())
                {
                    pretrazeni.Add(v);
                }

                else
                {
                    Console.WriteLine("dalje");
                }





            }

            return pretrazeni;




        }

    }
}

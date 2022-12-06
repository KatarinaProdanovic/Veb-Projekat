using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public EnumPol Pol { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public List<GrupniTrening> Treninzi { get; set; }
        public List<FitnesCentar>FitnesCentri { get; set; }//ako ima ulogu trenera bice samo jedan FitnesCentar u listi ovoj
        public UlogaKorisnika Uloga { get; set; }
        public bool Ulogovan { get; set; }
        public bool Blokiran { get; set; }//da li je trener blokiran
        public Korisnik()
        {
            Treninzi = new List<GrupniTrening>();
            FitnesCentri = new List<FitnesCentar>();

        }

        

    }
}
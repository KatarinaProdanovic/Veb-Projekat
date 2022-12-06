using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class FitnesCentar
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string AdresaFitnesCentra { get; set; }
        public int GodinaOtvaranja { get; set; }
       
        //cuvati korisnicko ime  vlasnika a ne celog vlasnika zbog kruzne reference

        public string KorisnickoImeVlasnika { get; set; }
        public double CenaMesecneClanarine { get; set; }
        public double CenaGodisnjeClanarine { get; set; }
        public double CenaJednogTreninga { get; set; }
        public double CenaJednogGrupnogTreninga { get; set; }
        public double CenaJednogTrSaPersTrenerom { get; set; }
        public bool Obrisan { get; set; }


        public FitnesCentar()
        {

        }
        public static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

    }
   

    
}
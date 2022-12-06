using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Komentar
    {
        public Korisnik Posetilac { get; set; }
        public FitnesCentar Centar { get; set; }
        public string TekstKomentara { get; set; }
        public int Ocena { get; set; }
        public bool Odobren { get; set; }
        public int Id { get; set; }
        public Komentar()
        {

        }

        public static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

    }
}
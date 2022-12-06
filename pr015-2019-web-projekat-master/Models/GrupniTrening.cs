using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class GrupniTrening
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public FitnesCentar Fitnes { get; set; }//msm da ce morati objekat fitnes centra
        public int Trajanje { get; set; }
        public DateTime DatumIVreme { get; set; }
        public int MaxBrPosetilaca { get; set; }
        public List<string> Posetioci { get; set; }
        public bool Obrisan { get; set; }
        public GrupniTrening()
        {
            Posetioci = new List<string>();
        }
        public static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }
    }
}
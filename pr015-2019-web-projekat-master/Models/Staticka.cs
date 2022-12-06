using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Models
{
    public class Staticka
    {

      

        public static List<Korisnik> korisnici = new List<Korisnik>();//svi korisnici u fajlu
     
        public static int Odbij = 0; //ako nije nista radjeno sa komentarom

        public static GrupniTrening grup = new GrupniTrening();//jedan frupni trening na koji se neko prijavljuje

        public static List<string> posetioci = new List<string>();//svi posetioci iz nekog grupnog treninga
        public static List<GrupniTrening> treninziGdeJePrijavljen = new List<GrupniTrening>();


        public static List<GrupniTrening> grupniTreninzi = new List<GrupniTrening>();//oni svi u fajlu

        public static List<Korisnik> menjani = new List<Korisnik>();//lista onih koji su menjati


        public static Korisnik trenutni = new Korisnik();//trenutni korisnik koji je aktivan sad
        public static FitnesCentar fc = new FitnesCentar();//trenutni fitnes centar u cijim smo detaljima

        public static List<Korisnik> ulogovani = new List<Korisnik>();//lista ulogovanih korisnika(za vise stranica)
        public static List<FitnesCentar> centri = new List<FitnesCentar>();//oni svi u fajlu
        public static FitnesCentar fcc = new FitnesCentar();//onaj koji se trenutno menja
        public static GrupniTrening gr = new GrupniTrening();//onaj koji je trenutno neko kliknuo.. 
      
    }
}
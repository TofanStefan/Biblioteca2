using System;
using System.Collections.Generic;
using System.Text;

namespace EvidentaBiblioteca
{

   public class Carte
    {
        string titlu { get; set; }
        string autor { get; set; }
        int exemplare { get; set; }

        public Carte()
        {
            titlu = "null";
            autor = "null";
            exemplare = 0;
        }

        public Carte(string titlu, string autor, int exemplare)
        {
            this.titlu = titlu;
            this.autor = autor;
            this.exemplare = exemplare;
        }
        public Carte(string linie)
        {
            string[] date;
            date = linie.Split(';');
            titlu = date[0];
            autor = date[1];
            exemplare = Convert.ToInt32(date[2]);
        }

        public string Info
        {
            get
            {
                return  String.Format("{0} scrisa de {1} - {2} exemplare .",titlu,autor,exemplare);

            }
        }

        public string Titlu
        {
            get { return titlu; }
            set { titlu = value; }
        }
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public int Exemplare
        {
            get { return exemplare; }
            set { exemplare = value; }
        }
        public bool Comparatie(Carte x)
        {
            if (x.Exemplare > exemplare)
                return false;
            return true;
        }


    }
}

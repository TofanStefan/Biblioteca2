using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidentaBiblioteca
{
   public  class Persoana : Carte
    {
        static int maxImprumut = 3;
        string numePers { get; set; }
        List<Carte> imprumut = new List<Carte>();
        public int pozCurenta()
        {
            return imprumut.Count - 1;
        }
        public void setExemplare_To1(int poz)
        {
            imprumut[poz].Exemplare = 1;
        }
        public Persoana(string nume)
        {
            numePers = nume;
        }
        public void Adaugare(Carte x)
        {
            imprumut.Add(new Carte(x.Titlu, x.Autor, x.Exemplare));

        }
        public bool dublura(Carte x)
        {
            foreach (var book in imprumut)
                if (string.Equals(book.Titlu, x.Titlu) && string.Equals(book.Autor, x.Autor))
                    return true;
            return false;
        }
        public string Nume
        {
            get { return numePers; }
            set { numePers = value; }
        }
        public void Afisare()
        {
            Console.WriteLine(numePers + " a imprumutat urmatoarele carti :");
            foreach (var book in imprumut)
                Console.WriteLine(book.Info);

        }
    }
}

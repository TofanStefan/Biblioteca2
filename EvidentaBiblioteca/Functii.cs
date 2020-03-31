using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidentaBiblioteca
{
    public class Functii
    {
        //==========================================================================================================\\
        public void CitireTastatura(ref string titlu, ref string autor, ref string exemplare)
        {
            Console.Clear();
            Console.WriteLine("Titlu cartii : ");
            titlu = Console.ReadLine();
            Console.WriteLine("Autorul cartii : ");
            autor = Console.ReadLine();
            Console.WriteLine("Exemplare : ");
            exemplare = Console.ReadLine();
        }
        //==========================================================================================================\\


        public void Meniu(ref string optiune)
        {
            Console.Clear();
            Console.WriteLine("1.Adauga Carte");
            Console.WriteLine("2.Afiseaza biblioteca");
            Console.WriteLine("3.Eliminare carte");
            Console.WriteLine("4.Editare carte");
            Console.WriteLine("5.Eliminare Autor");
            Console.WriteLine("6.Imprumut");
            Console.WriteLine("7.Adauga carte (date pe o singura linie)");
            Console.WriteLine("8.Afisara carte (in fisier)");
            Console.WriteLine("9.Adauga carte (din fisier)");
            Console.WriteLine("X.Exit");
            Console.WriteLine("---------------------");
            Console.WriteLine("Introduceti optiunea");
            optiune = Console.ReadLine();
            Console.WriteLine("---------------------\n");
        }


        //==========================================================================================================\\


        public void Afisare_Biblioteca(ref List<Carte> biblioteca)
        {
            Console.Clear();
            foreach (var carte in biblioteca)
                Console.WriteLine(carte.Info);
            Console.ReadKey();
        }

        //==========================================================================================================\\


        public void Eliminare_Carte(ref List<Carte> biblioteca)
        {
            Console.Clear();
            Console.WriteLine("Ce carte doriti sa eliminati? (tastati un numar 1 - " + biblioteca.Count + ".\n ");
            int index = 0;
            foreach (var carte in biblioteca)
            {
                index++;
                Console.WriteLine(index + ". " + carte.Info);
            }

            int eliminare = Convert.ToInt32(Console.ReadLine());
            biblioteca.RemoveAt(eliminare - 1);
            Console.Clear();
        }

        //==========================================================================================================\\


        public void Editare_Carte(ref List<Carte> biblioteca)
        {
            Console.Clear();
            Console.WriteLine("Ce carte doriti sa editati (tastati un numar 1 - " + biblioteca.Count + ".\n ");
            int index_ = 0;
            foreach (var carte in biblioteca)
            {
                index_++;
                Console.WriteLine(index_ + ". " + carte.Info + "\n");
            }
            int editare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ce doriti sa editati ?\n");
            Console.WriteLine("1.Titlu");
            Console.WriteLine("2.Autor");
            Console.WriteLine("3.Numar Exemplare");
            string optiune = Console.ReadLine();
            switch (optiune)
            {
                case "1":
                    Console.WriteLine("Introduceti titlul nou");
                    biblioteca[editare - 1].Titlu = Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Introduceti titlul nou");
                    biblioteca[editare - 1].Autor = Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Introduceti numarul nou de exemplare");
                    biblioteca[editare - 1].Exemplare = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    break;
            }
            //==========================================================================================================\\




        }


        //==========================================================================================================\\


        public void Eliminare_Autor(ref List<Carte> biblioteca)
        {
            Console.Clear();
            int index = 0, aparitii=0;
            int[] x = new int[biblioteca.Count];
            //Vector aparitii autor
            for (int i = 0; i < biblioteca.Count; i++)
                x[i] = 0;
            //Verificare 
            for (int i = 0; i < biblioteca.Count - 1; i++)
            {

                for (int j = i + 1; j < biblioteca.Count; j++)
                {
                    if (string.Equals(biblioteca[i].Autor, biblioteca[j].Autor))
                    {
                        x[j]++;

                    }
                }
                if(x[i]!=0)
                { aparitii++; }
            }
            
            //Afisare carti
            foreach (var carte in biblioteca)
            {
                index++;
                if (x[index - 1] == 0)
                {
                    Console.WriteLine((index) + ". " + carte.Autor + "\n");
                }
            }
            Console.WriteLine("Ce autor doriti sa eliminati (tastati un numar 1 - " + (biblioteca.Count-aparitii) + ".\n ");
            Console.WriteLine(aparitii);
            //Eliminare
            int optiune = Convert.ToInt32(Console.ReadLine());
            string autor = biblioteca[optiune - 1].Autor;
            biblioteca.RemoveAt(optiune - 1);
            int poz = 0;
            while(poz<biblioteca.Count)
            { 
                if (string.Equals(biblioteca[poz].Autor, autor))
                {
                    biblioteca.RemoveAt(poz);
                    poz--;
                }
                poz++;
            }
            Console.Clear();

        }


        //==========================================================================================================\\


        public void Imprumut(ref List<Carte> biblioteca, ref List<Persoana> persoane)
        {
            Console.Clear();
            Console.WriteLine("Ce carte doriti sa imprumutati (tastati un numar 1 - " + biblioteca.Count + ".)\n ");
            int index = 0;
            foreach (var carte in biblioteca)
            {
                index++;
                Console.WriteLine(index + ". " + carte.Info + "\n");
            }
            int optiune = Convert.ToInt32(Console.ReadLine());
            if (biblioteca[optiune- 1].Exemplare==0)
            {
                Console.WriteLine("Cartea dorita este imprumutata altei persoane");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Introduceti numele persoanei : ");
            string nume = Console.ReadLine();
            int ok = 1, pozitie = 0;
            foreach (var per in persoane)
            {
                if (string.Equals(per.Nume,nume))
                {
                    if (per.dublura(biblioteca[optiune - 1]) == true)
                    {
                        Console.WriteLine("Cartea dorita este deja imprumutata acestei persoane");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        biblioteca[optiune - 1].Exemplare = biblioteca[optiune - 1].Exemplare - 1;
                        per.setExemplare_To1(per.pozCurenta());
                        per.Adaugare(biblioteca[optiune - 1]);

                        ok = 0;
                    }


                }
            }
            if (ok == 1)
            {
                pozitie = persoane.Count;
                persoane.Add(new Persoana(nume));
                biblioteca[optiune - 1].Exemplare = biblioteca[optiune - 1].Exemplare - 1;
                persoane[pozitie].Adaugare(biblioteca[optiune - 1]);
                persoane[pozitie].setExemplare_To1(persoane[pozitie].pozCurenta());
                pozitie++;

            }
            foreach (var ps in persoane)
            {
                Console.WriteLine("---------------------------\n\n");
                ps.Afisare();
            }

            Console.ReadKey();
            Console.Clear();
        }



    }
}

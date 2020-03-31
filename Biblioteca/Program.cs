using System;
using System.Collections.Generic;
using EvidentaBiblioteca;
using NivelAccesDate;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            IStocareDate adminCarti = StocareFactory.GetAdministratorStocare();
            List<Carte> biblioteca = new List<Carte>();
            List<Persoana> persoane = new List<Persoana>();
            string titlu = string.Empty, autor = string.Empty, exemplare = string.Empty, nume = string.Empty, optiune = string.Empty,linie;
            Functii functii = new Functii();
            int nrCarti;
          

            do
            {
                functii.Meniu(ref optiune);
                switch (optiune.ToUpper())
                {
                    case "1":
                        functii.CitireTastatura(ref titlu, ref autor, ref exemplare);
                        biblioteca.Add(new Carte(titlu, autor, Convert.ToInt32(exemplare)));
                        break;
                    case "2":
                        functii.Afisare_Biblioteca(ref biblioteca);
                        break;
                    case "3":
                        functii.Eliminare_Carte(ref biblioteca);

                        break;
                    case "4":
                        functii.Editare_Carte(ref biblioteca);
                        break;
                    case "5":
                        functii.Eliminare_Autor(ref biblioteca);
                        break;
                    case "6":
                        functii.Imprumut(ref biblioteca, ref persoane);
                        break;
                    case "7":
                        Console.WriteLine("Introduceti datele in formatul: tiltu;autor;nrExemplare");
                        linie=Console.ReadLine();
                        Carte x = new Carte(linie);
                        biblioteca.Add(x);
                        break;
                    case "8":
                        foreach (var carte in biblioteca)
                            adminCarti.AdaugaCarte(carte);
                        break;
                    case "9":
                        Carte[] carti = adminCarti.GetCarti(out nrCarti);
                        for (int i = 0; i < nrCarti; i++)
                            biblioteca.Add(carti[i]);
                        break;

                            
                   
                    default:
                        Console.Clear();
                        Console.WriteLine("Optiune invalida");
                        Console.ReadKey();
                        break;
                    case "X":
                        return;

                }
            } while (true);




        }
    }
}

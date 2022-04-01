using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieMasini;
using DateStocareMasini;
using LibrariePersoane;
using DateStocarePersoana;
using System.Configuration;
namespace InchiriereMasini
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeFisier = ConfigurationManager.AppSettings.Get("numeFisier");
            string numeFisierPersoana = ConfigurationManager.AppSettings.Get("numeFisierPersoana");
            AdministrareMasini administrareMasini = new AdministrareMasini(numeFisier);
            AdministrarePersoane administrarePersoane = new AdministrarePersoane(numeFisierPersoana);
            int nrMasini = 0;
            int idMasini = 0;
           
            int idPersoane = 0;
            int nrPersoane = 0;
            string marca;
            string anul;
            string model;
            string numepers;
            string prenumepers;
            string datanastere;

            string optiune;
            do
            {

                Console.WriteLine("A. Citire date masina de la tastatura                   E. Citire date persoana de la tastatura");
                Console.WriteLine("B. Salvarea in fisier a datelor masinii:                F. Salvare  in fisier a datelor persoanei                    ");
                Console.WriteLine("C. Citire masini din fisier:                            G. Citire persoane din fisier");
                Console.WriteLine("D. Cauta masina dupa nume:                              D. Cauta persoana dupa nume");
                Console.WriteLine(" X. Inchidere program");


                optiune = Console.ReadLine();
                administrareMasini.GetMasini(out nrMasini);
                administrarePersoane.GetPersoane(out nrPersoane);
                switch (optiune.ToUpper())
                {

                    case "A":
                        idMasini = nrMasini + 1;
                        nrMasini = nrMasini + 1;

                        Console.WriteLine("Introduceti marca masinii: ");
                        marca = Console.ReadLine();
                        Console.WriteLine("Introduceti modelul masinii: ");
                        model = Console.ReadLine();
                        Console.WriteLine("Introduceti anul masinii : ");
                        anul = Console.ReadLine();

                        Masina masina_tastaura = new Masina(idMasini, marca, model, anul);
                        administrareMasini.AddMasina(masina_tastaura);
                            


                        break;

                    case "B":
                        idMasini = nrMasini + 1;
                        nrMasini = nrMasini + 1;

                        Masina masina = new Masina(idMasini, "Opel", "Astra", "2007");
                        administrareMasini.AddMasina(masina);
                        break;

                    case "C":
                        Masina[] masini = administrareMasini.GetMasini(out nrMasini);
                        afisareMasini(masini, nrMasini);

                        break;

                    case "D":
                        Console.Write("Adaugati marca masinii: ");
                        marca = Console.ReadLine();
                        Console.Write("Adaugati modelul masinii: ");
                        model = Console.ReadLine();
                        Console.Write("Adaugati anul de fabricare: ");
                        anul = Console.ReadLine();

                        Masina masina_cautata = administrareMasini.GetMasina(marca, model, anul);
                        if(string.IsNullOrEmpty(masina_cautata.GetMarca()) &&  string.IsNullOrEmpty(masina_cautata.GetModel())  && string.IsNullOrEmpty(masina_cautata.GetAnul()))
                        {

                            Console.WriteLine("Nu avem aceasta masina\n");

                        }
                        else
                        {

                            string info_masina_cautata = string.Format("Masina cu id-ul {0} si marca {1} avand modelul {2} din anul {3}\n",
                                masina_cautata.GetidMasini(), masina_cautata.GetMarca(), masina_cautata.GetModel(), masina_cautata.GetAnul());
                            Console.WriteLine(info_masina_cautata);
                                

                        }
                        break;

                    case "E":
                        idMasini = nrMasini + 1;
                        nrMasini = nrMasini + 1;

                        Console.WriteLine("Introduceti numele persoanei care inchiriaza masina :");
                        numepers = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele persoanei care a inchiriat masina ");
                        prenumepers = Console.ReadLine();
                        Console.WriteLine("Introduceti data de nastere a respectivei persoane:");
                        datanastere = Console.ReadLine();

                        Persoana persoana_tastatura = new Persoana(idPersoane, numepers, prenumepers, datanastere);
                        administrarePersoane.AddPersoana(persoana_tastatura);

                        break;

                    case "F":

                        idPersoane = nrPersoane + 1;
                        nrPersoane = nrPersoane + 1;

                        Persoana persoane = new Persoana(idPersoane, "Alexandru", "Dinu", "23");
                        administrarePersoane.AddPersoana(persoane);

                        break;

                    case "G":

                        Persoana[] persoana1 = administrarePersoane.GetPersoane(out nrPersoane);
                        afisarePersoane(persoana1, nrPersoane);

                        break;

                    case "H":

                        Console.Write("Adaugati numele persoanei: ");
                        numepers = Console.ReadLine();
                        Console.Write("Adaugati prenumele persoanei: ");
                        prenumepers = Console.ReadLine();
                        Console.Write("Adaugati data nastere: ");
                        datanastere = Console.ReadLine();

                        Persoana persoana_cautata = administrarePersoane.GetPersoana(numepers, prenumepers, datanastere);
                        if (string.IsNullOrEmpty(persoana_cautata.GetNumePers()) && string.IsNullOrEmpty(persoana_cautata.GetPrenumePers()) && string.IsNullOrEmpty(persoana_cautata.GetDataNastere()))
                        {

                            Console.WriteLine("Nu avem aceasta persoana");

                        }
                        else
                        {

                            string info_persoana_cautata = string.Format("Persoana cu id-ul {0} este {1}{2} nascut pe data de {3}\n",
                                persoana_cautata.GetIdPersoane(), persoana_cautata.GetNumePers(), persoana_cautata.GetPrenumePers(), persoana_cautata.GetDataNastere());
                            Console.WriteLine(info_persoana_cautata);

                        }
                            


                        

                        break;
                }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            } while (optiune.ToUpper() != "X");
           
            Console.ReadLine();
        }
        public static void afisareMasini(Masina[] masini, int nrMasini)
        {

            Console.WriteLine("Masinile sunt : ");
            for (int contor = 0; contor < nrMasini; contor ++)
            {

                string infoMasini = string.Format("Masina cu id-ul {0} avand marca {1} si modelul  {2} din anul {3}",
                    masini[contor].GetidMasini(),
                    masini[contor].GetMarca(),
                    masini[contor].GetModel(),
                    masini[contor].GetAnul());
                Console.WriteLine(infoMasini);

            }

        }

        public static void afisarePersoane(Persoana[] persoane, int nrPersoane)
        {

            Console.WriteLine("Persoanele sunt: ");
            for (int contor1 = 0; contor1 < nrPersoane; contor1++)
            {

                string infoPersoana = string.Format("Persoana cu id-ul {0} are numele {1} {2} si varsta de {3}\n",
                    persoane[contor1].GetIdPersoane(),
                    persoane[contor1].GetNumePers(),
                    persoane[contor1].GetPrenumePers(),
                    persoane[contor1].GetDataNastere());
                Console.WriteLine(infoPersoana);

            }

        }
    }
}

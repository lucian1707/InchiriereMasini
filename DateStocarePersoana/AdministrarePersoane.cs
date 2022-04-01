using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrariePersoane;

namespace DateStocarePersoana
{
    public class AdministrarePersoane
    {

        private const int nr_max_persoane = 20;
        private string numeFisierPersoana;

        public AdministrarePersoane(string numeFisierPersoana)
        {

            this.numeFisierPersoana = numeFisierPersoana;
            Stream streamFisierPersoane = File.Open(numeFisierPersoana, FileMode.OpenOrCreate);
            streamFisierPersoane.Close();

        }

        public void AddPersoana(Persoana persoana)
        {

            using (StreamWriter streamWriterFisierPersoane = new StreamWriter(numeFisierPersoana, true))
            {

                streamWriterFisierPersoane.WriteLine(persoana.ConversieFisierTextPersoane());

            }

        }

        public Persoana[] GetPersoane(out int nrPersoane)
        {

            Persoana[] persoane = new Persoana[nr_max_persoane];
            using (StreamReader streamReader = new StreamReader(numeFisierPersoana))
            {

                string linieFisier_Persoana;
                nrPersoane = 0;
                while ((linieFisier_Persoana = streamReader.ReadLine())!=null)
                {

                    persoane[nrPersoane++] = new Persoana(linieFisier_Persoana);

                }

            }
            return persoane;

        }

        public Persoana GetPersoana(string numepers, string prenumepers, string datanastere)
        {

            Persoana persoana;
            using (StreamReader streamReader = new StreamReader(numeFisierPersoana))
            {

                string linieFisier_Persoana;
                while ((linieFisier_Persoana = streamReader.ReadLine())!=null)
                {

                    persoana = new Persoana(linieFisier_Persoana);
                    if (persoana.GetNumePers() == numepers && persoana.GetPrenumePers() == prenumepers && persoana.GetDataNastere() == datanastere)
                    {

                        return persoana;

                    }
                    

                }
                Persoana persoana_invalida = new Persoana();
                return persoana_invalida;

            }


        }

    }


}

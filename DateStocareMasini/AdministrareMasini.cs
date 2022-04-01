using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateStocareMasini;
using LibrarieMasini;
using System.IO;

namespace DateStocareMasini
{
    public class AdministrareMasini
    {

        private const int nr_max_masini = 20;
        private string numeFisier;
    


        public AdministrareMasini (string numeFisier)
        {

            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        
        }

        public void AddMasina(Masina masina)
        {

            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {

                streamWriterFisierText.WriteLine(masina.ConversieFisierText());

            }

        }

        public Masina[] GetMasini(out int nrMasini)
        {

            Masina[] masini = new Masina[nr_max_masini];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {

                string linieFisier;
                nrMasini = 0;
                while ((linieFisier = streamReader.ReadLine())!= null)
                {

                    masini[nrMasini++] = new Masina(linieFisier);

                }

            }
            return masini;
        }

        public Masina GetMasina(string marca, string model, string anul)
        {

            Masina masina;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {

                string linieFisier;
                
                while((linieFisier = streamReader.ReadLine())!=null)
                {

                    masina = new Masina(linieFisier);
                    if (masina.GetMarca() == marca  &&  masina.GetModel() == model  &&  masina.GetAnul() == anul )
                    {

                        return masina;

                    }

                }
                Masina masina_invalida = new Masina();
                return masina_invalida;

            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LibrarieMasini
{
    public class Masina
    {
        private const char Separator_FISIER = ';';

        private const int ID_MASINI = 0;
        private const int MARCA = 1;
        private const int MODEL = 2;
        private const int ANUL = 3;

        private int idMasini;
        private string marca;
        private string model;
        private string anul;
    
    
        public Masina()
        {

            this.marca = this.model = this.anul = string.Empty;

        }

        public Masina(int idMasini , string marca , string model , string anul)
        {

            this.idMasini = idMasini;
            this.marca = marca;
            this.model = model;
            this.anul = anul; 

        }

        public Masina(string linieFisier)
        {

            var dateFisier = linieFisier.Split(Separator_FISIER);
            this.idMasini = Convert.ToInt32(dateFisier[ID_MASINI]);
            this.marca = dateFisier[MARCA];
            this.model = dateFisier[MODEL];
            this.anul = dateFisier[ANUL];

        }

        public string ConversieFisierText()
        {

            string format_fisierText = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                Separator_FISIER,
                idMasini.ToString(),
                (marca ?? "NECUNOSCUT"),
                (model ?? "NECUNOSCUT"),
                (anul ?? "NECUNOSCUT"));
            return format_fisierText;
        }

        public int GetidMasini()
        {

            return idMasini;

        }

        public string  GetMarca()
        {

            return marca;

        }

        public string GetModel()
        {

            return model;

        }

        public string GetAnul()
        {

            return anul;

        }
            
    
    }
}

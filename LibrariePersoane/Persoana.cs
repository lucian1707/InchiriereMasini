using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariePersoane
{
    public class Persoana
    {
        private const char Separator_Fisier_Persoane = ';';

        private const int IDPersoana = 0;
        private const int NUMEPERS = 1;
        private const int PRENUMEPERS = 2;
        private const int DATANASTERE = 3;

        private int idPersoane;
        private string numepers;
        private string prenumepers;
        private string datanastere;


        public Persoana()
        {

            this.numepers = this.prenumepers = this.datanastere = string.Empty;

        }

        public Persoana(int idPersoane, string numepers, string prenumepers, string datanastere)
        {

            this.idPersoane = idPersoane;
            this.numepers = numepers;
            this.prenumepers = prenumepers;
            this.datanastere = datanastere;
            

        }

        public Persoana(string linieFisier_Persoana)
        {

            var dateFisier_Persoana = linieFisier_Persoana.Split(Separator_Fisier_Persoane);
            this.idPersoane = Convert.ToInt32(dateFisier_Persoana[IDPersoana]);
            this.numepers = dateFisier_Persoana[NUMEPERS];
            this.prenumepers = dateFisier_Persoana[PRENUMEPERS];
            this.datanastere = dateFisier_Persoana[DATANASTERE];
        }

        public string ConversieFisierTextPersoane()
        {

            string format_fisierTextPersoane = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                Separator_Fisier_Persoane,
                idPersoane.ToString(),
                (numepers ?? "NECUNOSCUT"),
                (prenumepers ?? "NECUNOSCUT"),
                (datanastere ?? "NECUNOSCUT"));
            return format_fisierTextPersoane;


        }

        public int GetIdPersoane()
        {

            return idPersoane;

        }

        public string  GetNumePers()
        {

            return numepers;

        }

        public string GetPrenumePers()
        {

            return prenumepers;

        }

        public string GetDataNastere()
        {

            return datanastere;

        }
    }
}

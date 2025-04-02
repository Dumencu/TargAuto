using System;
using System.Collections.Generic;
using System.IO;
using TargAutoLibrary;

namespace NivelStocareDate
{
    public class AdministrareMasini_FisierText
    {
        private string numeFisier;

        public AdministrareMasini_FisierText(string numeFisier) //creaza fisier
        {
            this.numeFisier = numeFisier;
            if (!File.Exists(numeFisier))
                File.Create(numeFisier).Close();
        }

        public void AddMasina(Masina m) //adauga masina in fisier
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(m.ConversieLaSir_PentruFisier());
            }
        }

        public void StergeTot() //sterge masinile
        {
            File.WriteAllText(numeFisier, string.Empty); 
        }

        public List<Masina> GetMasini() //return lista tuturor masinilor
        {
            var masini = new List<Masina>();
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    masini.Add(new Masina(linie));
                }
            }
            return masini;
        }

        public int GetUltimulId() //ret cel mai mare id
        {
            int id = 0;
            var masini = GetMasini();
            foreach (var m in masini)
            {
                if (m.Id > id)
                    id = m.Id;
            }
            return id;
        }
    }
}

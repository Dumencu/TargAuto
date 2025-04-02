using System.Collections.Generic;
using TargAutoLibrary;

namespace TargAutoBusiness
{
    public class TargAuto
    {
        private List<Masina> masini = new List<Masina>(); // lista interna masini

        public void AddMasina(Masina m) // adauga masina
        {
            masini.Add(m);
        }

        public List<Masina> GetMasini() // return toate masinile
        {
            return masini;
        }

        public List<Masina> CautaMasinaDupaMarca(string marca) // cauta masina dupa marca
        {
            List<Masina> rezultat = new List<Masina>();
            foreach (var m in masini)
            {
                if (m.Marca.ToLower() == marca.ToLower()) // cautar insensibila litere mari mici
                    rezultat.Add(m);
            }
            return rezultat;
        }
    }
}

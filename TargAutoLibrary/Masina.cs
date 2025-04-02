using System;
using TargAutoLibrary;

namespace TargAutoLibrary
{
    public class Masina
    {
        private const char SEPARATOR = ';'; // separat pt salvare in fisier

        public int Id { get; set; } // propriet publice ale masininilor
        public string Vanzator { get; set; } = string.Empty;
        public string Cumparator { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public int AnFabricatie { get; set; }
        public Culoare Culoare { get; set; }
        public OptiuniDotari Optiuni { get; set; }
        public DateTime DataTranzactie { get; set; }

        public Masina() { } // construct gol (instantiere implicita

        public Masina(string linie) // constr primeste o linie din fisier si o parseaza
        {
            var parts = linie.Split(SEPARATOR);
            Id = int.Parse(parts[0]);
            Vanzator = parts[1];
            Cumparator = parts[2];
            Marca = parts[3];
            Model = parts[4];
            AnFabricatie = int.Parse(parts[5]);
            Culoare = Enum.Parse<Culoare>(parts[6]);
            Optiuni = (OptiuniDotari)Enum.Parse(typeof(OptiuniDotari), parts[7]);
            DataTranzactie = DateTime.ParseExact(parts[8], "dd/MM/yyyy", null);
        }

        public string ConversieLaSir_PentruFisier() // conv un obiect la sir pt scriere fisier
        {
            return string.Join(SEPARATOR,
                Id, Vanzator, Cumparator, Marca, Model, AnFabricatie,
                Culoare, Optiuni, DataTranzactie.ToString("dd/MM/yyyy"));
        }

        public string Info() // return o descriere a masinii
        {
            return $"#{Id} {Marca} {Model} ({AnFabricatie})\n" +
                   $"- Vanzator: {Vanzator}, Cumparator: {Cumparator}\n" +
                   $"- Culoare: {Culoare}, Optiuni: {Optiuni}\n" +
                   $"- Data Tranzactie: {DataTranzactie:dd/MM/yyyy}\n";
        }
    }
}

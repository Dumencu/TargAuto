using System;
using TargAutoLibrary;
using NivelStocareDate;
using TargAutoBusiness;
using System.Collections.Generic;

namespace TargAutoApp
{
    class Program
    {
        static void Main()
        {
            string locatieWinForms = @"..\..\..\..\InterfataUtilizator_TargAuto\bin\Debug\net8.0-windows";
            string caleFisier = Path.GetFullPath(Path.Combine(locatieWinForms, "masini.txt"));
            AdministrareMasini_FisierText adminFisier = new AdministrareMasini_FisierText(caleFisier); // initial obiect pt gest fisier
            TargAuto targAuto = new TargAuto(); // initializ obiectt pt stocare memorie

            int idCurent = adminFisier.GetUltimulId(); //obtine ultimul id folosit

            bool running = true;
            while (running) // meniu cu optiuni
            {
                Console.Clear();
                Console.WriteLine("=== Meniu Targ Auto ===");
                Console.WriteLine("1. Adauga masina");
                Console.WriteLine("2. Info masini");
                Console.WriteLine("3. Cauta masina dupa marca");
                Console.WriteLine("4. Sterge toate masinile");
                Console.WriteLine("5. Exit");

                Console.Write("Alege o optiune: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.Write("Cate masini vrei sa adaugi? ");
                        if (int.TryParse(Console.ReadLine(), out int nrMasini) && nrMasini > 0)
                        {
                            for (int i = 0; i < nrMasini; i++)
                            {
                                Console.WriteLine($"\n--- Masina {i + 1} ---");
                                var masinaNoua = CitireMasina(++idCurent);
                                targAuto.AddMasina(masinaNoua);
                                adminFisier.AddMasina(masinaNoua);
                                Console.WriteLine("Masina adaugata cu succes!\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Numar invalid.");
                        }
                        break;

                    case "2":
                        var masini = adminFisier.GetMasini();
                        if (masini.Count == 0)
                            Console.WriteLine("Nu exista masini salvate.");
                        else
                            foreach (var m in masini)
                                Console.WriteLine(m.Info());
                        break;

                    case "3":
                        Console.Write("Introduceti marca cautata: ");
                        string marca = Console.ReadLine();
                        var gasite = targAuto.CautaMasinaDupaMarca(marca);
                        if (gasite.Count == 0)
                            Console.WriteLine("Nicio masina gasita.");
                        else
                            foreach (var m in gasite)
                                Console.WriteLine(m.Info());
                        break;

                    case "4":
                        Console.Write("Esti sigur ca vrei sa stergi TOT? (da/nu): ");
                        string confirmare = Console.ReadLine();
                        if (confirmare.ToLower() == "da")
                        {
                            adminFisier.StergeTot();
                            Console.WriteLine("Toate masinile au fost sterse.");
                        }
                        else
                        {
                            Console.WriteLine("Stergerea a fost anulata.");
                        }
                        Console.ReadKey();
                        break;


                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Optiune invalida!");
                        break;
                }

                Console.WriteLine("\nApasa o tasta pentru a continua...");
                Console.ReadKey();
            }
        }

        static Masina CitireMasina(int id) // citeste datele unei masini de la tastatura
        {
            Console.Write("Vanzator: ");
            string vanzator = Console.ReadLine();

            Console.Write("Cumparator: ");
            string cumparator = Console.ReadLine();

            Console.Write("Marca: ");
            string marca = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("An fabricatie: ");
            int an = int.Parse(Console.ReadLine());

            Console.WriteLine("Culoare: 1 - Rosu, 2 - Alb, 3 - Negru, 4 - Gri, 5 - Albastru, 6 - Verde");
            Culoare culoare = (Culoare)int.Parse(Console.ReadLine());

            Console.WriteLine("Optiuni (ex: 1 2 4):");
            Console.WriteLine("1 - AerConditionat\n2 - Navigatie\n4 - CutieAutomata\n8 - ScauneIncalzite\n16 - PilotAutomat\n32 - CameraParcare");
            string[] optiuniInput = Console.ReadLine().Split(' ');
            OptiuniDotari optiuni = OptiuniDotari.Nimic;
            foreach (string o in optiuniInput)
            {
                if (int.TryParse(o, out int val))
                    optiuni |= (OptiuniDotari)val;
            }

            return new Masina // returneaza o masina completa
            {
                Id = id,
                Vanzator = vanzator,
                Cumparator = cumparator,
                Marca = marca,
                Model = model,
                AnFabricatie = an,
                Culoare = culoare,
                Optiuni = optiuni,
                DataTranzactie = DateTime.Now
            };
        }
    }
}

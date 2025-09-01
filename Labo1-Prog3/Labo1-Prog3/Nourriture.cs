using System;
using System.Collections.Generic;
using System.Threading;

namespace CaféChezGino
{
    public class Nourriture : Produit
    {
        public bool Collation { get; }

        public Nourriture(string nom, double prix, int tempsPreparationSuppEnSec, bool collation, List<Ingredient> ingredients)
            : base(nom, prix, tempsPreparationSuppEnSec, ingredients)
        {
            Collation = collation;
        }

        public override Produit Preparer(string numCommande)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Début de la préparation de la commande {numCommande} : {Nom}");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);

            Console.WriteLine("Mise de la nourriture dans l’assiette...");
            Thread.Sleep(1000);

            Cuisson();
            Dressage();
            FairePayer(numCommande);

            return this;
        }

        private void Cuisson()
        {
            if (TempsPreparationSuppEnSec >= 3)
            {
                Console.WriteLine("La nourriture est en cuisson...");
                Thread.Sleep(2000);
            }
        }

        public override void Dressage()
        {
            if (TempsPreparationSuppEnSec == 1)
            {
                Console.WriteLine("Dressage rapide du plat...");
                Thread.Sleep(1000);
            }
            else if (TempsPreparationSuppEnSec > 2)
            {
                Console.WriteLine("Dressage élaboré du plat...");
                Thread.Sleep((TempsPreparationSuppEnSec - 2) * 1000);
            }
        }
    }
}

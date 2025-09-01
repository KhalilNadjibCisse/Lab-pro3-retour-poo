using System;
using System.Collections.Generic;
using System.Threading;

namespace Caf�ChezGino
{
    public class Boisson : Produit
    {
        public bool BoissonChaude { get; }

        public Boisson(string nom, double prix, int tempsPreparationSuppEnSec, bool boissonChaude, List<Ingredient> ingredients)
            : base(nom, prix, tempsPreparationSuppEnSec, ingredients)
        {
            BoissonChaude = boissonChaude;
        }

        public override Produit Preparer(string numCommande)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"D�but de la pr�paration de la commande {numCommande} : {Nom}");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);

            if (BoissonChaude)
                ChaufferEau();

            bool contientCafeine = Ingredients.Exists(i => i.ContientCafeine);
            if (contientCafeine)
            {
                Console.WriteLine("Infusion du breuvage...");
                Thread.Sleep(5000);
            }

            Console.WriteLine("Versement de la boisson dans la tasse...");
            Thread.Sleep(1000);

            Dressage();
            FairePayer(numCommande);

            return this;
        }

        private void ChaufferEau()
        {
            Random rnd = new Random();
            int temps = rnd.Next(5, 11);
            Console.WriteLine("L�eau est en train de chauffer...");
            Thread.Sleep(temps * 1000);
            Console.WriteLine("L�eau est pr�te !");
        }

        public override void Dressage()
        {
            if (TempsPreparationSuppEnSec > 0)
            {
                Console.WriteLine("Dressage de la boisson en cours...");
                Thread.Sleep(TempsPreparationSuppEnSec * 1000);
            }
        }
    }
}

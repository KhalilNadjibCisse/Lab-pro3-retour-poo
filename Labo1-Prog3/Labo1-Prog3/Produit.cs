using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaféChezGino
{
    public abstract class Produit
    {
        public string Nom { get; }
        public double Prix { get; }
        public int TempsPreparationSuppEnSec { get; }
        public List<Ingredient> Ingredients { get; }

        protected Produit(string nom, double prix, int tempsPreparationSuppEnSec, List<Ingredient> ingredients)
        {
            Nom = nom;
            Prix = prix;
            TempsPreparationSuppEnSec = tempsPreparationSuppEnSec;
            Ingredients = ingredients;
        }

        // Maintenant virtual async
        public virtual async Task<Produit> Preparer(string numCommande)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Début de la préparation de la commande {numCommande} : {Nom}");
            Console.ForegroundColor = ConsoleColor.White;
            await Task.Delay(1000);
            return this;
        }

        public abstract Task Dressage();

        public async Task FairePayer(string numCommande)
        {
            await Task.Yield(); // petit point d’attente
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Commande {numCommande} est prête !");
            Console.WriteLine($"Prix à payer : {Prix}$");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
using System;
using System.Collections.Generic;

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

        public abstract Produit Preparer(string numCommande);
        public abstract void Dressage();

        public void FairePayer(string numCommande)
        {
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

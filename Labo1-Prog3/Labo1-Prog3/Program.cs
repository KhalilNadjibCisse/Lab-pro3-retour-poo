using System;
using System.Collections.Generic;
using System.Threading;

namespace CaféChezGino
{
    class Program
    {
        static void Main(string[] args)
        {
            double montantTotal = 0;
            Random rand = new Random();
            int nbClients = rand.Next(5, 100);
            int choix;

            // Création des ingrédients
            Ingredient cafe = new Ingredient("café", true, true, true);
            Ingredient farine = new Ingredient("farine", false, true, false);
            Ingredient oeuf = new Ingredient("oeuf", false, false, true);
            Ingredient eau = new Ingredient("eau", false, true, true);
            Ingredient fruit = new Ingredient("fruit", false, true, true);
            Ingredient beurre = new Ingredient("beurre", false, false, true);
            Ingredient patate = new Ingredient("patate", false, true, true);
            Ingredient the = new Ingredient("thé", true, true, true);

            // Création des produits
            List<Produit> produits = new List<Produit>();
            produits.Add(new Nourriture("Croissant", 2.49, 0, false, new List<Ingredient> { farine, beurre }));
            produits.Add(new Nourriture("Muffin aux fruits", 1.99, 0, true, new List<Ingredient> { farine, fruit }));
            produits.Add(new Nourriture("Sandwich déjeuner", 4.79, 3, false, new List<Ingredient> { farine, beurre, oeuf }));
            produits.Add(new Nourriture("Patates déjeuner", 1.99, 2, true, new List<Ingredient> { patate }));
            produits.Add(new Boisson("Chocolat chaud", 2.49, 0, true, new List<Ingredient> { eau }));
            produits.Add(new Boisson("Latté", 4.29, 2, true, new List<Ingredient> { eau, cafe }));
            produits.Add(new Boisson("Espresso", 1.79, 0, true, new List<Ingredient> { eau, cafe }));
            produits.Add(new Boisson("Thé glacé maison", 2.49, 0, false, new List<Ingredient> { eau, the, fruit }));
            produits.Add(new Boisson("Jus de fruits", 1.49, 0, false, new List<Ingredient> { fruit }));

            Console.WriteLine("Bienvenu au Café Chez Gino !");

            // Pour chaque client
            for (int i = 0; i < nbClients; i++)
            {
                Thread.Sleep(1000);

                choix = rand.Next(produits.Count);
                Produit commande = produits[choix];

                Console.WriteLine($"Client {i + 1} veut commander : {commande.Nom}");

                string numCommande = "Com" + (i + 1).ToString("D3");
                commande.Preparer(numCommande);

                montantTotal += commande.Prix;

                Console.WriteLine("-------------------");
            }

            Console.WriteLine("Merci d'avoir travaillé au Café Chez Gino !");
            Console.WriteLine("Aujourd'hui, le café a fait " + Math.Round(montantTotal, 2) + "$ !");
        }
    }
}
 
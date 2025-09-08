using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaféChezGino
{
    class Program
    {
        static async Task Main(string[] args)
        {
            double montantTotal = 0;
            Random rand = new Random();
            int nbClients = rand.Next(5, 15);

            // Ingrédients
            Ingredient cafe = new Ingredient("café", true, true, true);
            Ingredient farine = new Ingredient("farine", false, true, false);
            Ingredient oeuf = new Ingredient("oeuf", false, false, true);
            Ingredient eau = new Ingredient("eau", false, true, true);
            Ingredient fruit = new Ingredient("fruit", false, true, true);
            Ingredient beurre = new Ingredient("beurre", false, false, true);
            Ingredient patate = new Ingredient("patate", false, true, true);
            Ingredient the = new Ingredient("thé", true, true, true);

            List<Ingredient> tousIngredients = new List<Ingredient> { cafe, farine, oeuf, eau, fruit, beurre, patate, the };

            // Produits
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

            Console.WriteLine("Bienvenue au Café Chez Gino !");

            // Liste des tâches
            List<Task> commandes = new List<Task>();

            for (int i = 0; i < nbClients; i++)
            {
                int clientId = i + 1;
                Produit commande = produits[rand.Next(produits.Count)];
                string numCommande = "Com" + clientId.ToString("D3");

                Console.WriteLine($"Client {clientId} veut : {commande.Nom}");

                commandes.Add(Task.Run(async () =>
                {
                    Produit p = await commande.Preparer(numCommande);
                    montantTotal += p.Prix;
                }));
            }

            await Task.WhenAll(commandes);

            Console.WriteLine("\nMerci d'avoir travaillé au Café Chez Gino !");
            Console.WriteLine("Aujourd'hui, le café a fait " + Math.Round(montantTotal, 2) + "$!\n");

            // --- Requêtes LINQ ---
            var nourritures = produits.OfType<Nourriture>().ToList();
            var boissons = produits.OfType<Boisson>().ToList();

            var boissonsChaudes = boissons.Where(b => b.BoissonChaude);
            var boissonsCafeinees = boissons.Where(b => b.EstCafeinee());

            var nourrituresSansGluten = nourritures
                .Where(n => !n.Ingredients.Any(ing => ing.SansGluten == false));
            var nourrituresVegan = nourritures
                .Where(n => n.Ingredients.All(ing => ing.Vegan));

            var combos = from n in nourritures
                         where !n.Collation
                         from b in boissons
                         select $"{n.Nom} + {b.Nom}";

            // --- Affichage du menu ---
            Console.WriteLine("\n--- MENU ---");

            Console.WriteLine("\nToutes les nourritures :");
            nourritures.ForEach(n => Console.WriteLine(n.Nom));

            Console.WriteLine("\nNourritures sans gluten :");
            foreach (var n in nourrituresSansGluten) Console.WriteLine(n.Nom);

            Console.WriteLine("\nNourritures végan :");
            foreach (var n in nourrituresVegan) Console.WriteLine(n.Nom);

            Console.WriteLine("\nToutes les boissons :");
            boissons.ForEach(b => Console.WriteLine(b.Nom));

            Console.WriteLine("\nBoissons caféinées :");
            foreach (var b in boissonsCafeinees) Console.WriteLine(b.Nom);

            Console.WriteLine("\nBoissons chaudes :");
            foreach (var b in boissonsChaudes) Console.WriteLine(b.Nom);

            Console.WriteLine("\nCombos possibles (nourriture non-collation + boisson) :");
            foreach (var combo in combos) Console.WriteLine(combo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaféChezGino
{
    public class Boisson : Produit
    {
        public bool BoissonChaude { get; }

        public Boisson(string nom, double prix, int tempsPreparationSuppEnSec, bool boissonChaude, List<Ingredient> ingredients)
            : base(nom, prix, tempsPreparationSuppEnSec, ingredients)
        {
            BoissonChaude = boissonChaude;
        }

        public override async Task<Produit> Preparer(string numCommande)
        {
            await base.Preparer(numCommande);

            if (BoissonChaude)
                await ChaufferEau();

            if (Ingredients.Any(i => i.ContientCafeine))
            {
                Console.WriteLine("Infusion du breuvage...");
                await Task.Delay(5000);
            }

            Console.WriteLine("Versement de la boisson dans la tasse...");
            await Task.Delay(1000);

            await Dressage();
            await FairePayer(numCommande);

            return this;
        }

        private async Task ChaufferEau()
        {
            Random rnd = new Random();
            int temps = rnd.Next(5, 11);
            Console.WriteLine("L’eau est en train de chauffer...");
            await Task.Delay(temps * 1000);
            Console.WriteLine("L’eau est prête !");
        }

        public override async Task Dressage()
        {
            if (TempsPreparationSuppEnSec > 0)
            {
                Console.WriteLine("Dressage de la boisson en cours...");
                await Task.Delay(TempsPreparationSuppEnSec * 1000);
            }
        }

        // Méthode pour savoir si caféinée (LINQ)
        public bool EstCafeinee()
        {
            return Ingredients.Any(i => i.ContientCafeine);
        }
    }
}
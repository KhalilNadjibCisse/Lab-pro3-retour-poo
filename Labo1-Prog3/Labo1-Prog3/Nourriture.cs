using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public override async Task<Produit> Preparer(string numCommande)
        {
            await base.Preparer(numCommande);

            Console.WriteLine("Mise de la nourriture dans l’assiette...");
            await Task.Delay(1000);

            await Cuisson();
            await Dressage();
            await FairePayer(numCommande);

            return this;
        }

        private async Task Cuisson()
        {
            if (TempsPreparationSuppEnSec >= 3)
            {
                Console.WriteLine("La nourriture est en cuisson...");
                await Task.Delay(2000);
            }
        }

        public override async Task Dressage()
        {
            if (TempsPreparationSuppEnSec == 1)
            {
                Console.WriteLine("Dressage rapide du plat...");
                await Task.Delay(1000);
            }
            else if (TempsPreparationSuppEnSec > 2)
            {
                Console.WriteLine("Dressage élaboré du plat...");
                await Task.Delay((TempsPreparationSuppEnSec - 2) * 1000);
            }
        }
    }
}
namespace CaféChezGino
{
	public class Ingredient
	{
		public string Nom { get; }
		public bool ContientCafeine { get; }
		public bool Vegan { get; }
		public bool SansGluten { get; }

		public Ingredient(string nom, bool contientCafeine, bool vegan, bool sansGluten)
		{
			Nom = nom;
			ContientCafeine = contientCafeine;
			Vegan = vegan;
			SansGluten = sansGluten;
		}

		public override string ToString()
		{
			return Nom;
		}
	}
}

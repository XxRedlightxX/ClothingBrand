namespace ClothingStore.Models
{
    public class SampleDonnes
    {

        private static List<Clothe> listehabits = new();

        public static List<Clothe> Livres => listehabits;

        public static Categorie?[] GetCategories()
        {
            Categorie chandail = new Categorie { NomCategorie = "Chandails" };
            Categorie pantalon = new Categorie { NomCategorie = "Pantalons" };


            chandail.clothes = new List<Clothe>();
            Clothe livre1 = new Clothe
            {
                ClotheId = 1,
                ClotheName = "t-shirt",
                Description = "test",
                Quantite = 3,
                Prix = 5,
                Categorie = chandail


            };

            chandail.clothes.Add(livre1);
            listehabits.Add(livre1);

            return new Categorie?[] { chandail, pantalon };
        }
         
}
}

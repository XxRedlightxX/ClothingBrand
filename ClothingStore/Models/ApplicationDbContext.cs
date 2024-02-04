using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace ClothingStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Clothe> Clothes { get; set; }

        public void SeedData()
        {
            // Obtenez la liste de blogs avec des données préremplies
            var SampleCategories = SampleDonnes.GetCategories();
            // Créez un HashSet des URLs de blogs existants pour une recherche plus rapide
            var existingCategorieDesignation = new HashSet<string>(Categorie.Select(c => c.NomCategorie));
            foreach (var categorie in SampleCategories)
            {
                if (!existingCategorieDesignation.Contains(categorie.NomCategorie))
                {
                    // Ajoutez le blog au contexte s'il n'existe pas déjà
                    Categorie.Add(categorie);
                }
            }
            // Enregistrez les changements une seule fois après avoir ajouté tous les blogs
            SaveChanges();
        }
    
}
}

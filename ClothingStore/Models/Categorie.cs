using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorieId { get; set; }
        [Required(ErrorMessage = "La catégorie du livre est obligatoire.")]

        public string NomCategorie { get; set; }


        public virtual ICollection<Clothe> clothes { get; set; }
    }
}

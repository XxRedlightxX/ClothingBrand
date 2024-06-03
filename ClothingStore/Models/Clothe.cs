using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Clothe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClotheId { get; set; }

        [Required(ErrorMessage = "Le numéro ISBN est obligatoire.")]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Display(Name = "ISBN")]
        public string? ClotheName { get; set; }



      


        [Required(ErrorMessage = "Une description  est obligatoire.")]
      
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Description de l'article")]
        [MaxLength(6000, ErrorMessage = "La description ne doit pas dépasser 6000 caractères.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La quantité en stock est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être supérieure à zéro.")]
        [Display(Name = "Quantité en stock")]
        public int? Quantite { get; set; }

        [Required(ErrorMessage = "Le prix du vetement est obligatoire.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro.")]
        [Display(Name = "Prix du Article")]
        public decimal? Prix { get; set; }

        [DataType(DataType.Upload)]
        public byte[]? Photo { get; set; }

        [ForeignKey(nameof(CategorieId))]
        public int? CategorieId { get; set; }
        public virtual Categorie? Categorie { get; set; }
    }
}

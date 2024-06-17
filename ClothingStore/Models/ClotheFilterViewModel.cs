namespace ClothingStore.Models
{
    public class ClotheFilterViewModel
    {
        public IEnumerable<Categorie>? Categories { get; set; }
        public IEnumerable<Clothe>? Clothes { get; set; }
        public int? SelectedCategoryId { get; set; }
    }
}

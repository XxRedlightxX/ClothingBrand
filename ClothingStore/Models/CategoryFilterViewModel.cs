using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Models
{
    [ViewComponent(Name = "CategorieMenu")]
    public class CategoryFilterViewModel : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = SampleDonnes.GetCategories(); // Chargez vos catégories depuis SampleDonnes
            return View("CategoriesMenu", categories);
        }
    }

}

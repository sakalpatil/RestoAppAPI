using System.Collections.Generic;
using System.Threading.Tasks;
using RestoAppAPI.Modal;
using RestoAppAPI.Repository;
namespace RestoAppAPI.Service
{
    public class MenuCategoryService : IMenuCategoryService
    {
       
        private readonly IMenuCategoryRepository _categoryRepository;
        private readonly IImageService _imageService;

        public MenuCategoryService(IMenuCategoryRepository categoryRepository,
                                   IImageService imageService)
        {
            _categoryRepository=categoryRepository;
            _imageService=imageService;
        }
        public List<MenuCategoryModal> GetMenuCategory(int Pagesize=10, int PageNumber=1)
        {
           return  _categoryRepository.GetMenuCategory( Pagesize, PageNumber);
        }

        public async Task<string> SaveMenuCategory(MenuCategoryModal menuCategory)
        {            
                        
                menuCategory.Image= await _imageService.Save(menuCategory.Image);                
                if(menuCategory.Image.ValidationMessage.Length==0)
                {
                   return _categoryRepository.SaveMenuCategory(menuCategory);
                }
                else
                {
                    return menuCategory.Image.ValidationMessage;
                }
        }
    }
}
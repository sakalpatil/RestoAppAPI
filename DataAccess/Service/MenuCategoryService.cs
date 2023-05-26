using System.Collections.Generic;
using RestoAppAPI.Modal;
using RestoAppAPI.Repository;
namespace RestoAppAPI.Service
{
    class MenuCategoryService : IMenuCategoryService
    {
        private readonly IMenuCategoryRepository _categoryRepository;
        public MenuCategoryService(IMenuCategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }
        public List<MenuCategoryModal> GetMenuCategory(int Pagesize=10, int PageNumber=1)
        {
           return  _categoryRepository.GetMenuCategory( Pagesize, PageNumber);
        }
    }
}
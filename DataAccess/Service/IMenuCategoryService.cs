using System.Collections.Generic;
using System.Threading.Tasks;
using RestoAppAPI.Modal;

namespace RestoAppAPI.Service
{
    public interface IMenuCategoryService
    {
         List<MenuCategoryModal> GetMenuCategory(int Pagesize=10, int PageNumber=1);
        Task<string>  SaveMenuCategory(MenuCategoryModal menuCategoryModal);
        
    }
}
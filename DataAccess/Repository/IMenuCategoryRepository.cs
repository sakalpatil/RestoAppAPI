using RestoAppAPI.Modal;
using System.Collections.Generic;
namespace RestoAppAPI.Repository
{
    interface IMenuCategoryRepository
    {
         List<MenuCategoryModal> GetMenuCategory(int Pagesize=10, int PageNumber=1);
        
    }
}
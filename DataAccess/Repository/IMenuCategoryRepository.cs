using RestoAppAPI.Modal;
using System.Collections.Generic;
namespace RestoAppAPI.Repository
{
    public interface IMenuCategoryRepository
    {
         List<MenuCategoryModal> GetByPagination(int Pagesize=10, int PageNumber=1);
        string Save(MenuCategoryModal menuCategoryModal);
        
    }
}
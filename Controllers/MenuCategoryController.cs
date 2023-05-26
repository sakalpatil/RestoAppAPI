using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoAppAPI.Modal;
using RestoAppAPI.Service;
namespace RestoAppAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuCategoryController : ControllerBase
    {         
        private readonly IMenuCategoryService _menuCategoryService;
      
        public MenuCategoryController(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService=menuCategoryService;
            
        }   

        [HttpGet()]
        // [Authorize]
        public IActionResult Get(int Pagesize, int PageNumber)
        {            
            
            return Ok(_menuCategoryService.GetMenuCategory(Pagesize, PageNumber));
        }
    [HttpPost()]
        public async Task<IActionResult> Post([FromForm]MenuCategoryModal category)
        {
       
                
                category.Image.FileName=category.Name;
                category.Image.FileDescription=category.Description;   
                string error= await _menuCategoryService.SaveMenuCategory(category); 
                if(error!=string.Empty)
                {
                    return BadRequest(error);
                }   
                return Ok();
                 
        }

    }
}

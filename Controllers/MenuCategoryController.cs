using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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

        // public IActionResult Post(MenuCategoryModal category, IFile)
        // {

        // }

    }
}

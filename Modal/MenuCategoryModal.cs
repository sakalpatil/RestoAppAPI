using System;
using Microsoft.AspNetCore.Http;

namespace RestoAppAPI.Modal
{
   public class MenuCategoryModal
   {
      
      public int ID { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }   
      
   
      public IFormFile File { get; set; }
   }

}
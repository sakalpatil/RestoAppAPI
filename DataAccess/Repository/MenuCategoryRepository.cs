using System.Collections.Generic;
using RestoAppAPI.Modal;
using System.Data;
using System.Data.SqlClient;
using System;
using Microsoft.Extensions.Configuration;

namespace RestoAppAPI.Repository
{
    class MenuCategoryRepository : IMenuCategoryRepository
    {
        private readonly IConfiguration _configuration;
        public MenuCategoryRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }        

        public List<MenuCategoryModal> GetMenuCategory(int Pagesize=10, int PageNumber=1)
        {
            //  @"Data Source=PUN3OL-PF1KGMNG\SQLEXPRESS;Initial Catalog=RestoManager;Integrated Security=True;";
        string connectionString=  _configuration.GetConnectionString("DefaultConnection");
        List<MenuCategoryModal> menuCategories = new List<MenuCategoryModal>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("Get_MenuCategories", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                command.Parameters.AddWithValue("@PageSize", Pagesize);
                command.Parameters.AddWithValue("@PageNumber", PageNumber);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MenuCategoryModal menuCategory = new MenuCategoryModal();

                        menuCategory.ID = (int)reader["ID"];
                        menuCategory.Name = (string)reader["Name"];
                        menuCategory.Description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : null;
                        menuCategories.Add(menuCategory);
                    }
                }
            }
        }
        return menuCategories;
        }
        
    }
}
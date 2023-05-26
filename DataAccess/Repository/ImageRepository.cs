using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RestoAppAPI.Modal;

namespace RestoAppAPI.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IConfiguration Configuration;
        public ImageRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }  

        public string Save(ImageModal image)
        {       
        string connectionString= @"Data Source=PUN3OL-PF1KGMNG\SQLEXPRESS;Initial Catalog=RestoManager;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertOrUpdateImage", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        command.Parameters.AddWithValue("@Id", image.Id);
                        command.Parameters.AddWithValue("@FileName", image.FileName);
                        command.Parameters.AddWithValue("@FileDescription", image.FileDescription);
                        command.Parameters.AddWithValue("@FilePath", image.FilePath); // Assuming you want to use the uploaded file's name as the FilePath
                        command.Parameters.AddWithValue("@CreatedBy", 1);
                        command.Parameters.AddWithValue("@UpdatedBy", 1);

                        // Output parameter
                        SqlParameter errorMessageParam = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 255);
                        errorMessageParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(errorMessageParam);

                        // Execute the command
                        command.ExecuteNonQuery();
                        // Retrieve the output parameter value
                       return command.Parameters["@ErrorMessage"].Value.ToString();
                    }
                }
                catch (SqlException ex)
                {                
                    throw(ex);
                }
            }
        }
    }
    
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBooking.Models
{
    public class LodgingModel
    {

        //string ConnectionString = "Server=tcp:bookingserver.database.windows.net,1433;Initial Catalog=BookingAppDB;Persist Security Info=False;User ID=adminbooking;Password=Hola123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string ConnectionString = "Server=tcp:bookinglmglserver.database.windows.net,1433;Initial Catalog=BookingDatabase;Persist Security Info=False;User ID=adminbooking;Password=Hola123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        public int IDLodging { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string Location { get; set; }
        public int AdultAvailable { get; set; }
        public int KidAvailable { get; set; }
        public string Category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public ResponseModel GetAll() {

            List<LodgingModel> list = new List<LodgingModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Lodging";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new LodgingModel
                                {
                                    IDLodging = (int)reader["IDLodging"],
                                    Picture = reader["Picture"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = (double)reader["Price"],
                                    CheckIn = (string)reader["CheckIn"],
                                    CheckOut = (string)reader["CheckIn"],
                                    Location = reader["Location"].ToString(),
                                    AdultAvailable = (int)reader["AdultAvailable"],
                                    KidAvailable = (int)reader["KidAvailable"],
                                    Category = reader["Category"].ToString(),
                                    Latitude = (double)reader["Latitude"],
                                    Longitude = (double)reader["Longitude"],

                                });
                            }
                        }
                    }
                }
                return new ResponseModel
                {
                    IsSuccess = true,
                    Message = "Lodgings were successfully obtained",
                    Result = list
                };

            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = $"An error was generated when consulting the lodgings.({ex.Message})",
                    Result = null
                };
            }
        }


        public ResponseModel Get(int id) {
            LodgingModel obj = new LodgingModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Lodging WHERE IDLodging = @IDLodging";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDLodging", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                obj = new LodgingModel
                                {
                                    IDLodging = (int)reader["IDLodging"],
                                    Picture = reader["Picture"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = (double)reader["Price"],
                                    CheckIn = (string)reader["CheckIn"],
                                    CheckOut = (string)reader["CheckIn"],
                                    Location = reader["Location"].ToString(),
                                    AdultAvailable = (int)reader["AdultAvailable"],
                                    KidAvailable = (int)reader["KidAvailable"],
                                    Category = reader["Category"].ToString(),
                                    Latitude = (double)reader["Latitude"],
                                    Longitude = (double)reader["Longitude"],
                                };
                            }
                        }
                    }
                }
                return new ResponseModel
                {
                    IsSuccess = true,
                    Message = "Lodgings were successfully obtained",
                    Result = obj
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = $"An error was generated when consulting the lodgings({ex.Message})",
                    Result = null
                };
            }
        }



        public ResponseModel Insert(LodgingModel lodgingModel) {
            try
            {
                object newID;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                   
                    string tsql = "INSERT INTO Lodging (Picture, Title, Description, Price, CheckIn, CheckOut, Location, AdultAvailable, KidAvailable, Category, Latitude, Longitude) VALUES(@Picture, @Title, @Description, @Price, @CheckIn, @CheckOut, @Location, @AdultAvailable, @KidAvailable, @Category, @Latitude, @Longitude); SELECT @@IDENTITY;";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Picture",lodgingModel.Picture);
                        cmd.Parameters.AddWithValue("@Title", lodgingModel.Title);
                        cmd.Parameters.AddWithValue("@Description", lodgingModel.Description);
                        cmd.Parameters.AddWithValue("@Price", lodgingModel.Price);
                        cmd.Parameters.AddWithValue("@CheckIn", lodgingModel.CheckIn);
                        cmd.Parameters.AddWithValue("@CheckOut", lodgingModel.CheckOut);
                        cmd.Parameters.AddWithValue("@Location", lodgingModel.Location);
                        cmd.Parameters.AddWithValue("@AdultAvailable", lodgingModel.AdultAvailable);
                        cmd.Parameters.AddWithValue("@KidAvailable", lodgingModel.KidAvailable);
                        cmd.Parameters.AddWithValue("@Category", lodgingModel.Category);
                        cmd.Parameters.AddWithValue("@Latitude", lodgingModel.Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", lodgingModel.Longitude);
                        newID = cmd.ExecuteScalar();

                        if (newID != null && newID.ToString().Length > 0)
                        {
                            return new ResponseModel
                            {
                                IsSuccess = true,
                                Message = "Lodging was successfully added.",
                                Result = newID
                            };
                        }
                        else
                        {
                            return new ResponseModel
                            {
                                IsSuccess = false,
                                Message = "An error was generated when inserting an lodging.",
                                Result = null
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = $"An error was generated when inserting an lodging.({ex.Message})",
                    Result = null
                };
            }
        }



        public ResponseModel Update(LodgingModel lodging) {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "UPDATE Lodging SET Picture = @Picture, Title = @Title, Description = @Description, Price = @Price, CheckIn = @CheckIn, CheckOut = @CheckOut, Location = @Location, AdultAvailable = @AdultAvailable, KidAvailable = @KidAvailable, Category = @Category, Latitude = @Latitude, Longitude = @Longitude WHERE IDLodging = @IDLodging;";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Picture", lodging.Picture);
                        cmd.Parameters.AddWithValue("@Title", lodging.Title);
                        cmd.Parameters.AddWithValue("@Description", lodging.Description);
                        cmd.Parameters.AddWithValue("@Price", lodging.Price);
                        cmd.Parameters.AddWithValue("@CheckIn", lodging.CheckIn);
                        cmd.Parameters.AddWithValue("@CheckOut", lodging.CheckOut);
                        cmd.Parameters.AddWithValue("@Location", lodging.Location);
                        cmd.Parameters.AddWithValue("@AdultAvailable", lodging.AdultAvailable);
                        cmd.Parameters.AddWithValue("@KidAvailable", lodging.KidAvailable);
                        cmd.Parameters.AddWithValue("@Category", lodging.Category);
                        cmd.Parameters.AddWithValue("@Latitude", lodging.Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", lodging.Longitude);
                        cmd.Parameters.AddWithValue("@IDLodging", lodging.IDLodging);

                       

                        cmd.ExecuteNonQuery();
                        return new ResponseModel
                        {
                            IsSuccess = true,
                            Message = "The lodging was successfully updated",
                            Result = IDLodging
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = $"An error occurred while updating the lodging({ex.Message})",
                    Result = null
                };
            }
        }


        public ResponseModel Delete( int id) {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "DELETE FROM Lodging WHERE IDLodging = @IDLodging;";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@IDLodging", id);
                        cmd.ExecuteNonQuery();
                        return new ResponseModel
                        {
                            IsSuccess = true,
                            Message = "Lodging was successfully removed",
                            Result = IDLodging
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = $"An error occurred while removing the lodging({ex.Message})",
                    Result = null
                };
            }
        }


    }
}

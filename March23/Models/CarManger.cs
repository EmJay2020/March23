using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace March23.Models
{
    public class CarManger
    {
        private string _connection;
        public CarManger(string cs)
        {
            _connection = cs;
        }
        public List<Cars> GetAll(bool asc)
        {
            SqlConnection connection = new SqlConnection(_connection);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select * from car";
            if (asc)
            {
                cmd.CommandText += " order by Year asc";
            }
            else
            {
                cmd.CommandText += " order by Year desc";
            }
            connection.Open();
            List<Cars> result = new List<Cars>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Cars
                {
                    Id = (int)reader["Id"],
                    Make = (string)reader["Make"],
                    Model = (string)reader["Model"],
                    Year = (int)reader["Year"],
                    Price = (decimal)reader["Price"],
                    Cartype = (Cartype)reader["Cartype"],
                    HasLeatherSeats = (bool)reader["IsLeather"]

                });
            }
            connection.Close();
            connection.Dispose();
            return result;
        }
        public void AddCar(Cars c)
        {
            SqlConnection connection = new SqlConnection(_connection);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"insert into car(Make, Model, Year, Price, CarType, IsLeather)
                            values (@Make, @Model, @Year, @Price, @CarType, @IsLeather)";
            cmd.Parameters.AddWithValue("@Make", c.Make);
            cmd.Parameters.AddWithValue("@Model", c.Model);
            cmd.Parameters.AddWithValue("@Year", c.Year);
            cmd.Parameters.AddWithValue("@Price", c.Price);
            cmd.Parameters.AddWithValue("@CarType", c.Cartype);
            cmd.Parameters.AddWithValue("@IsLeather", c.HasLeatherSeats);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        
    }
    public class Cars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public Cartype Cartype { get; set; }
        public bool HasLeatherSeats { get; set; }
    }
    public enum Cartype
    {
        SUV,
        Sedan,
        Supercar
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DogRegistry
{
    public class Dog 
    {
        #region Dog Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public string Hobbies { get; set; }

        public string Gender { get; set; }
        #endregion

        SqlConnection conn = new SqlConnection(@"server = DESKTOP-AL42T46\TRAINEEINSTANCE; database=dogRegistryApp; integrated security=true");

        public string AddDog(Dog registeredDog)
        {
            
            
            SqlCommand cmd_addAnimal = new SqlCommand("INSERT INTO Registry VALUES (@Name, @Breed, @Age, @Weight, @Hobbies, @Gender)", conn);

            cmd_addAnimal.Parameters.AddWithValue("@Name", registeredDog.Name);
            cmd_addAnimal.Parameters.AddWithValue("@Breed", registeredDog.Breed);
            cmd_addAnimal.Parameters.AddWithValue("@Age", registeredDog.Age);
            cmd_addAnimal.Parameters.AddWithValue("Weight", registeredDog.Weight);
            cmd_addAnimal.Parameters.AddWithValue("@Hobbies", registeredDog.Hobbies);
            cmd_addAnimal.Parameters.AddWithValue("@Gender", registeredDog.Gender);

            try
            {
                conn.Open();
                cmd_addAnimal.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return "Account added successfully";
        }

        public string UpdateDog(Dog updateRegistry)
        {
            SqlCommand cmd_updateAnimal = new SqlCommand("update Registry set Name=@updateName, Breed = @updateBreed, Age = @updateAge, Weight = @updateWeight, Hobbies = @updateHobbies, Gender = @updateGender where Id = @Id", conn);
            cmd_updateAnimal.Parameters.AddWithValue("@updateName", updateRegistry.Name);
            cmd_updateAnimal.Parameters.AddWithValue("@updateBreed", updateRegistry.Breed);
            cmd_updateAnimal.Parameters.AddWithValue("@updateAge", updateRegistry.Age);
            cmd_updateAnimal.Parameters.AddWithValue("@updateWeight", updateRegistry.Weight);
            cmd_updateAnimal.Parameters.AddWithValue("@updateHobbies", updateRegistry.Hobbies);
            cmd_updateAnimal.Parameters.AddWithValue("@updateGender", updateRegistry.Gender);
            cmd_updateAnimal.Parameters.AddWithValue("@Id", updateRegistry.Id);

            try
            {
                conn.Open();
                cmd_updateAnimal.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return "Account updated successfully!";
        }

        public string deleteDog(int Id)
        {
            SqlCommand cmd_deleteRegistry = new SqlCommand("DELETE FROM Registry WHERE Id = @Id", conn);
            cmd_deleteRegistry.Parameters.AddWithValue("Id", Id);

            try
            {
                conn.Open();
                cmd_deleteRegistry.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return "Entry Deleted Successfully!";
        }

        public Dog getID(int Id)
        {
            //create an object
            Dog _search = new Dog();
            SqlCommand cmd_search = new SqlCommand("SELECT * FROM Registry WHERE Id = @Id", conn);
            cmd_search.Parameters.AddWithValue("@Id", Id);
            SqlDataReader _read = null;

            try
            {
                conn.Open();
                _read = cmd_search.ExecuteReader();

                    if(_read.Read())
                    {
                    _search.Id = Id;
                    _search.Name = Convert.ToString(_read[1]);
                    _search.Breed = Convert.ToString(_read[2]);
                    _search.Age = Convert.ToInt32(_read[3]);
                    _search.Weight = Convert.ToInt32(_read[4]);
                    _search.Hobbies = Convert.ToString(_read[5]);
                    _search.Gender = Convert.ToString(_read[6]);

                    // here would put a password 
                    return _search;

                    }
                    else
                    {
                        Console.WriteLine("Id Not Found!");
                    }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _read.Close();
                conn.Close();
            }

            return _search;

        }
        
        public List<Dog> GetList()
        {
            SqlCommand cmd_details = new SqlCommand("SELECT * FROM Registry", conn);
            SqlDataReader read_Details = null;
            List<Dog> dbDetails = new List<Dog>();

            try
            {
                conn.Open();
                read_Details = cmd_details.ExecuteReader();//ExecuteReader() is used to execute an SQL command and return a group of rows
                while (read_Details.Read()) //Reads the next character from the input stream
                    {
                    dbDetails.Add(new Dog()
                    {
                        Id = Convert.ToInt32(read_Details[0]),
                        Name = read_Details[1].ToString(),
                        Breed = read_Details[2].ToString(),
                        Age = Convert.ToInt32(read_Details[3]),
                        Weight = Convert.ToInt32(read_Details[4]),
                        Hobbies = read_Details[5].ToString(),
                        Gender = read_Details[6].ToString()

                    });
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                read_Details.Close();
                conn.Close();
            }

            return dbDetails;
        }
    }
}

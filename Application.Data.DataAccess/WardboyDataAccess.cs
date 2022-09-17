using Application.DAL.Contract;
using Application.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Application.Data.DataAccess
{
    public class WardboyDataAccess : IDataAccess<Wardboy, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public WardboyDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }


        public Wardboy Create(Wardboy entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO wardboy VALUES ({entity.WordboyID} , {entity.WardID} ,'{entity.FirstName}' ,'{entity.MiddleName}' ,'{entity.LastName}' ,{entity.Mobile} ,'{entity.Email}' ,'{entity.Gender}')";

                int result = Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entity;
        }

        public Wardboy Delete(int id)
        {
            Wardboy entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From wardboy where wardboy_id={id}";

                int result = Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }

        public IEnumerable<Wardboy> Get()
        {
            List<Wardboy> entities = new List<Wardboy>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from wardboy";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Wardboy()
                          {
                              WordboyID = Convert.ToInt32(reader["wardboy_id"]),
                              WardID = Convert.ToInt32(reader["ward_id"]),
                              FirstName = reader["first_name"].ToString(),
                              MiddleName = reader["middle_name"].ToString(),
                              LastName = reader["last_name"].ToString(),
                              Mobile = reader["mobile"].ToString(),
                              Email = reader["email"].ToString(),
                              Gender = reader["gender"].ToString()
                          }
                        );
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entities;
        }

        public Wardboy Get(int id)
        {
            Wardboy entity = new Wardboy();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from wardboy where wardboy_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Wardboy()
                {
                    WordboyID = Convert.ToInt32(reader["wardboy_id"]),
                    WardID = Convert.ToInt32(reader["ward_id"]),
                    FirstName = reader["first_name"].ToString(),
                    MiddleName = reader["middle_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    Mobile = reader["mobile"].ToString(),
                    Email = reader["email"].ToString(),
                    Gender = reader["gender"].ToString()
                };

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entity;
        }

        public Wardboy Update(int id, Wardboy entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE wardboy SET wardboy_id = {entity.WordboyID} , {entity.WardID} ,first_name = '{entity.FirstName}' ,middle_name = '{entity.MiddleName}' ,last_name = '{entity.LastName}' ,mobile = '{entity.Mobile}' ,email = '{entity.Email}' ,gender = {entity.Gender} WHERE wardboy_id={id}";

                int result = Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }

            return entity;
        }

    }
}


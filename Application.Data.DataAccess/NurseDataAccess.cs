using Application.DAL.Contract;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class NurseDataAccess : IDataAccess<Nurse, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public NurseDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Nurse Create(Nurse entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO nurse VALUES ({entity.NurseID} , {entity.WardID} ,'{entity.FirstName}' ,'{entity.MiddleName}' ,'{entity.LastName}' ,{entity.Mobile} ,'{entity.Email}' ,'{entity.Gender}')";

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

        public Nurse Delete(int id)
        {
            Nurse entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From nurse where nurse_id={id}";

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

        public IEnumerable<Nurse> Get()
        {
            List<Nurse> entities = new List<Nurse>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from nurse";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Nurse()
                          {
                              NurseID = Convert.ToInt32(reader["nurse_id"]),
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

        public Nurse Get(int id)
        {
            Nurse entity = new Nurse();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from nurse where nurse_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Nurse()
                {
                    NurseID = Convert.ToInt32(reader["nurse_id"]),
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

        public Nurse Update(int id, Nurse entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE nurse SET nurse_id = {entity.NurseID} , {entity.WardID} ,first_name = '{entity.FirstName}' ,middle_name = '{entity.MiddleName}' ,last_name = '{entity.LastName}' ,mobile = '{entity.Mobile}' ,email = '{entity.Email}' ,gender = {entity.Gender} WHERE wardboy_id={id}";

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

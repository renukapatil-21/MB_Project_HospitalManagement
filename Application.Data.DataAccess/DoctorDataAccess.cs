using Application.DAL.Contract;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class DoctorDataAccess : IDataAccess<Doctor, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public DoctorDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Doctor Create(Doctor entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO doctor VALUES ({entity.DoctorID} ,'{entity.FirstName}' ,'{entity.MiddleName}' ,'{entity.LastName}' ,{entity.Mobile} ,'{entity.Email}' ,'{entity.Specialisation}', '{entity.DoctorType}' ,'{entity.Gender}')";

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

        public Doctor Delete(int id)
        {
            Doctor entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From doctor where doctor_id={id}";

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

        public IEnumerable<Doctor> Get()
        {
            List<Doctor> entities = new List<Doctor>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from doctor";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Doctor()
                          {
                              DoctorID = Convert.ToInt32(reader["doctor_id"]),
                              FirstName = reader["first_name"].ToString(),
                              MiddleName = reader["middle_name"].ToString(),
                              LastName = reader["last_name"].ToString(),
                              Mobile = reader["mobile"].ToString(),
                              Email = reader["email"].ToString(),
                              Specialisation = reader["specialisation"].ToString(),
                              DoctorType = reader["doctor_type"].ToString(),
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

        public Doctor Get(int id)
        {
            Doctor entity = new Doctor();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from doctor where doctor_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Doctor()
                {
                    DoctorID = Convert.ToInt32(reader["doctor_id"]),
                    FirstName = reader["first_name"].ToString(),
                    MiddleName = reader["middle_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    Mobile = reader["mobile"].ToString(),
                    Email = reader["email"].ToString(),
                    Specialisation = reader["specialisation"].ToString(),
                    DoctorType = reader["doctor_type"].ToString(),
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

        public Doctor Update(int id, Doctor entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE doctor SET doctor_id = {entity.DoctorID} ,first_name = '{entity.FirstName}' ,middle_name = '{entity.MiddleName}' ,last_name = '{entity.LastName}' ,mobile = '{entity.Mobile}' ,email = '{entity.Email}' , '{entity.Specialisation}', '{entity.DoctorType}' ,gender = {entity.Gender} WHERE doctor_id={id}";

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

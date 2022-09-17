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
    public class HospitalSettingDataAccess : IDataAccess<Hospital_Setting, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public HospitalSettingDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Hospital_Setting Create(Hospital_Setting entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO hospital_setting VALUES ({entity.HospitalSettingID} ,'{entity.HospitalSettingName}' ,'{entity.HospitalSettingValue}')";

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

        public Hospital_Setting Delete(int id)
        {
            Hospital_Setting entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From hospital_setting where hospital_setting_id={id}";

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

        public IEnumerable<Hospital_Setting> Get()
        {
            List<Hospital_Setting> entities = new List<Hospital_Setting>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from hospital_setting";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Hospital_Setting()
                          {
                              HospitalSettingID = Convert.ToInt32(reader["hospital_setting_id"]),
                              HospitalSettingName = reader["hospital_setting_name"].ToString(),
                              HospitalSettingValue = reader["hospital_setting_value"].ToString(),
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

        public Hospital_Setting Get(int id)
        {
            Hospital_Setting entity = new Hospital_Setting();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from hospital_setting where hospital_setting_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Hospital_Setting()
                {
                    HospitalSettingID = Convert.ToInt32(reader["hospital_setting_id"]),
                    HospitalSettingName = reader["hospital_setting_name"].ToString(),
                    HospitalSettingValue = reader["hospital_setting_value"].ToString(),
                 
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

        public Hospital_Setting Update(int id, Hospital_Setting entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE hospital_setting SET HospitalSettingID = {entity.HospitalSettingID} ,first_name = '{entity.HospitalSettingName}' ,middle_name = '{entity.HospitalSettingValue}' WHERE HospitalSettingID={id}";

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

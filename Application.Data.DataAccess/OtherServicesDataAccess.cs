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
    public class OtherServicesDataAccess : IDataAccess<Other_Services, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public OtherServicesDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Other_Services Create(Other_Services entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO other_services VALUES ({entity.OtherServicesID} ,'{entity.OtherServicesDate}' ,{entity.HospitalSettingID} ,'{entity.PatientID}')";

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

        public Other_Services Delete(int id)
        {
            Other_Services entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From other_services where other_services_id={id}";

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

        public IEnumerable<Other_Services> Get()
        {
            List<Other_Services> entities = new List<Other_Services>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from other_services";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Other_Services()
                          {
                              OtherServicesID = Convert.ToInt32(reader["other_services_id"]),
                              OtherServicesDate = reader["other_services_date"].ToString(),
                              HospitalSettingID = Convert.ToInt32(reader["hospital_setting_id"]),
                              PatientID = Convert.ToInt32(reader["patient_id"]),

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

        public Other_Services Get(int id)
        {
            Other_Services entity = new Other_Services();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from other_services where other_services_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Other_Services()
                {
                    OtherServicesID = Convert.ToInt32(reader["other_services_id"]),
                    OtherServicesDate = reader["other_services_date"].ToString(),
                    HospitalSettingID = Convert.ToInt32(reader["hospital_setting_id"]),
                    PatientID = Convert.ToInt32(reader["patient_id"]),
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

        public Other_Services Update(int id, Other_Services entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE other_services SET other_services_id = {entity.OtherServicesID} ,other_services_date = '{entity.OtherServicesDate}' ,hospital_setting_id = '{entity.HospitalSettingID}' ,patient_id = {entity.PatientID} WHERE other_services_id={id}";

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

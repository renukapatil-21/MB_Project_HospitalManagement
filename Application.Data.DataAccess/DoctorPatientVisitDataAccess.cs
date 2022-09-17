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
    public class DoctorPatientVisitDataAccess : IDataAccess<Doctor_Patient_Visit, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public DoctorPatientVisitDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Doctor_Patient_Visit Create(Doctor_Patient_Visit entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO patient_doctor_visit VALUES ({entity.VisitID} ,'{entity.VisitType}' ,'{entity.VisitDate}' ,{entity.DoctorID} ,{entity.PatientID} )";

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

        public Doctor_Patient_Visit Delete(int id)
        {
            Doctor_Patient_Visit entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From patient_doctor_visit where visit_id={id}";

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

        public IEnumerable<Doctor_Patient_Visit> Get()
        {
            List<Doctor_Patient_Visit> entities = new List<Doctor_Patient_Visit>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from patient_doctor_visit";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Doctor_Patient_Visit()
                          {
                              VisitID = Convert.ToInt32(reader["visit_id"]),
                              VisitType = reader["visit_type"].ToString(),
                              VisitDate = reader["visit_date"].ToString(),
                              DoctorID = Convert.ToInt32(reader["doctor_id"]),
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

        public Doctor_Patient_Visit Get(int id)
        {
            Doctor_Patient_Visit entity = new Doctor_Patient_Visit();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from patient_doctor_visit where doctor_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Doctor_Patient_Visit()
                {
                    VisitID = Convert.ToInt32(reader["visit_id"]),
                    VisitType = reader["visit_type"].ToString(),
                    VisitDate = reader["visit_date"].ToString(),
                    DoctorID = Convert.ToInt32(reader["doctor_id"]),
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

        public Doctor_Patient_Visit Update(int id, Doctor_Patient_Visit entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE patient_doctor_visit SET visit_id = {entity.VisitID} ,visit_type = '{entity.VisitType}' ,visit_date = '{entity.VisitDate}' ,doctor_ID = {entity.DoctorID} , patient_ID = {entity.PatientID} WHERE visit_id={id}";

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

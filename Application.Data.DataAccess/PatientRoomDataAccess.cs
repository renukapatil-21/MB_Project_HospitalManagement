using Application.DAL.Contract;
using Application.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Application.Data.DataAccess
{
    public class PatientRoomDataAccess : IDataAccess<Patient_Room , int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        
        public PatientRoomDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }


        public Patient_Room Create(Patient_Room entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO patient_room VALUES ({entity.PatientID} , {entity.WardID} , {entity.RoomID} ,{entity.PatientRoomDate})";

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

        public Patient_Room Delete(int id)
        {
            Patient_Room entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From patient_room where patient_id={id}";

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

        public IEnumerable<Patient_Room> Get()
        {
            List<Patient_Room> entities = new List<Patient_Room>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from patient_room";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Patient_Room()
                          {
                              PatientID = Convert.ToInt32(reader["patient_id"]),
                              WardID = Convert.ToInt32(reader["ward_id"]),
                              RoomID = Convert.ToInt32(reader["room_id"]),
                              PatientRoomDate = reader["patient_room_date"].ToString()
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

        public Patient_Room Get(int id)
        {
            Patient_Room entity = new Patient_Room();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from patient_room where patient_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Patient_Room()
                {
                    PatientID = Convert.ToInt32(reader["patient_id"]),
                    WardID = Convert.ToInt32(reader["ward_id"]),
                    RoomID = Convert.ToInt32(reader["room_id"]),
                    PatientRoomDate = reader["patient_room_date"].ToString()
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

        public Patient_Room Update(int id, Patient_Room entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE patient_room SET patient_id = {entity.PatientID} , ward_id = {entity.WardID} , room_id = {entity.RoomID} , patient_room_date = {entity.PatientRoomDate} WHERE patient_id={id} ";
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


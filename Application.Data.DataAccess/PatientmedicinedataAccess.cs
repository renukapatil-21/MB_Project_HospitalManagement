using Application.DAL.Contract;
using Application.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Application.Data.DataAccess
{
    public class PatientMedicineDataAccess : IDataAccess<Patient_Medicine, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public PatientMedicineDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Patient_Medicine Create(Patient_Medicine entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO patient_medicine VALUES ({entity.PatientID} , {entity.DoctorID} ,'{entity.MedicineName}' ,'{entity.MedicineType}' , {entity.MedicineCost} , {entity.MedicineDate})";

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


        public Patient_Medicine Delete(int id)
        {
            Patient_Medicine entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From patient_medicine where patient_id={id}";

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

        public IEnumerable<Patient_Medicine> Get()
        {
            List<Patient_Medicine> entities = new List<Patient_Medicine>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from patient_medicine";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Patient_Medicine()
                          {
                              PatientID = Convert.ToInt32(reader["patient_id"]),
                              DoctorID = Convert.ToInt32(reader["doctor_id"]),
                              MedicineName = reader["medicine_name"].ToString(),
                              MedicineType = reader["medicine_type"].ToString(),
                              MedicineCost = Convert.ToDecimal(reader["medicine_cost"]),
                              MedicineDate = reader["medicine_date"].ToString()
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

        public Patient_Medicine Get(int id)
        {
            Patient_Medicine entity = new Patient_Medicine();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from patient_medicine where patient_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Patient_Medicine()
                {
                    PatientID = Convert.ToInt32(reader["patient_id"]),
                    DoctorID = Convert.ToInt32(reader["doctor_id"]),
                    MedicineName = reader["medicine_name"].ToString(),
                    MedicineType = reader["medicine_type"].ToString(),
                    MedicineCost = Convert.ToDecimal(reader["medicine_cost"]),
                    MedicineDate = reader["medicine_date"].ToString()
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

        public Patient_Medicine Update(int id, Patient_Medicine entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE patient_medicine SET patient_id = {entity.PatientID} , doctor_id = {entity.DoctorID} , medicine_name = '{entity.MedicineName}' , medicine_type = '{entity.MedicineType}' , medicine_cost = {entity.MedicineCost} , medicine_date = {entity.MedicineDate} WHERE patient_id={id}";

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


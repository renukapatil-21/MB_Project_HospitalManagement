using Application.DAL.Contract;
using Application.Entities;
using System.Data;
using System.Data.SqlClient;



namespace Application.Data.DataAccess
{
    public class RoomDataAccess : IDataAccess<Room, int>
    {

        SqlConnection Conn;
        SqlCommand Cmd;

        public RoomDataAccess()
        {
            Conn = new SqlConnection(configuration.connectionString);
        }

        public Room Create(Room entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"INSERT INTO room VALUES ({entity.RoomID} , {entity.WardID} ,'{entity.RoomType}' ,'{entity.RoomStatus}' , {entity.RoomCharge})";

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


        public Room Delete(int id)
        {
            Room entity = null;
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From room where room_id={id}";

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

        public IEnumerable<Room> Get()
        {
            List<Room> entities = new List<Room>();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Select * from room";

                SqlDataReader reader = Cmd.ExecuteReader();



                while (reader.Read())
                {
                    entities.Add(
                          new Room()
                          {
                              RoomID = Convert.ToInt32(reader["room_id"]),
                              WardID = Convert.ToInt32(reader["ward_id"]),
                              RoomType = reader["room_type"].ToString(),
                              RoomStatus = reader["room_status"].ToString(),
                              RoomCharge = Convert.ToDecimal(reader["room_charge"])
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

        public Room Get(int id)
        {
            Room entity = new Room();

            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Select * from room where room_id = {id}";

                SqlDataReader reader = Cmd.ExecuteReader();


                reader.Read();
                entity = new Room()
                {
                    RoomID = Convert.ToInt32(reader["room_id"]),
                    WardID = Convert.ToInt32(reader["ward_id"]),
                    RoomType = reader["room_type"].ToString(),
                    RoomStatus = reader["room_status"].ToString(),
                    RoomCharge = Convert.ToDecimal(reader["room_charge"])
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

        public Room Update(int id, Room entity)
        {
            try
            {
                Conn.Open();

                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"UPDATE room SET room_id = {entity.RoomID} , ward_id = {entity.WardID} , room_type = '{entity.RoomType}' , room_status = '{entity.RoomStatus}' , room_charge =  {entity.RoomCharge} WHERE room_id={id}";

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


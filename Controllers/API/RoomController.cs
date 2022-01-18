using Hotel_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_App.Controllers.API
{
    public class RoomController : ApiController
    {
        string connectionString = "Data Source=DESKTOP-IGIOI52;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";

        // GET: api/Room
        public IHttpActionResult Get()
        {
            try
            {
                List<Room> roomList = new List<Room>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT * FROM Room";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            roomList.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetBoolean(3), reader.GetInt32(4)));
                        }
                    }
                    connection.Close();
                    return Ok(roomList);
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: api/Room/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string idQuery = $@"SELECT * FROM Room WHERE Id={id}";
                    SqlCommand cmd = new SqlCommand(idQuery, connection);
                    SqlDataReader idreader = cmd.ExecuteReader();
                    if (idreader.HasRows)
                    {
                        while (idreader.Read())
                        {
                            Room room = new Room(idreader.GetInt32(0), idreader.GetInt32(1), idreader.GetString(2), idreader.GetBoolean(3), idreader.GetInt32(4));
                            return Ok(new { ROOM = room });
                        }
                    }
                    connection.Close();
                }
                return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // POST: api/Room
        public IHttpActionResult Post([FromBody] Room addRoom)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string queryPost = $@"INSERT INTO Room (RoomNumber,TypeRoom,IsAvailable,Price) 
                    values({addRoom.RoomNumber},'{addRoom.TypeRoom}','{addRoom.IsAvailable}',{addRoom.Price})";
                    SqlCommand sqlCommand = new SqlCommand(queryPost, connection);
                    int rows = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Room was Added Successfully");
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Room/5
        public IHttpActionResult Put(int id, [FromBody] Room updateRoom)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = $@"UPDATE Room SET RoomNumber={updateRoom.RoomNumber},TypeRoom='{updateRoom.TypeRoom}',IsAvailable='{updateRoom.IsAvailable}',Price={updateRoom.Price} WHERE Id ={id}";
                    SqlCommand sqlCommand = new SqlCommand(updateQuery, connection);
                    int rowsUpdate = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Room was Updated Successfully");
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/Room/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = $@"DELETE FROM Room WHERE Id={id}";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    int deleteRows = deleteCommand.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Room was Deleted Successfully");
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

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
    public class OrdersController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-IGIOI52;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        HotelOrdersDataContext hotelOrdersDataContext = new HotelOrdersDataContext(connectionString);
        // GET: api/Orders
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(hotelOrdersDataContext.Orders.ToList());
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

        // GET: api/Orders/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(new { ORDER = hotelOrdersDataContext.Orders.First(orderItem => orderItem.Id == id) });
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

        // POST: api/Orders
        public IHttpActionResult Post([FromBody] Order addOrder)
        {
            try
            {
                hotelOrdersDataContext.Orders.InsertOnSubmit(addOrder);
                hotelOrdersDataContext.SubmitChanges();
                return Ok("Order was Added Successfully");
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

        // PUT: api/Orders/5
        public IHttpActionResult Put(int id, [FromBody] Order updateOrder)
        {
            try
            {
                Order orderToUpdate = hotelOrdersDataContext.Orders.First(orderItem => orderItem.Id == id);
                if (orderToUpdate.WorkerNumber != null)
                {
                    orderToUpdate.OrderId = updateOrder.WorkerNumber;
                    orderToUpdate.WorkerNumber = updateOrder.WorkerNumber;
                    orderToUpdate.OrderDate = updateOrder.OrderDate;
                    orderToUpdate.Price = updateOrder.Price;
                    hotelOrdersDataContext.SubmitChanges();
                    return Ok("Order was Updated Successfully");
                }
                else { return NotFound(); }
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

        // DELETE: api/Orders/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Order orderToDelete = hotelOrdersDataContext.Orders.First(orderItem => orderItem.Id == id);
                hotelOrdersDataContext.Orders.DeleteOnSubmit(orderToDelete);
                hotelOrdersDataContext.SubmitChanges();
                return Ok();

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

using Hotel_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hotel_App.Controllers.API
{
    public class GuestController : ApiController
    {
        HotelContext hotelContext = new HotelContext();
        // GET: api/Guest
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { MESS= hotelContext.Guests.ToList() });
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

        // GET: api/Guest/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Guest guest = await hotelContext.Guests.FindAsync(id);
                if (guest.FirstName != null) return Ok(guest);
                else
                {
                    return NotFound();
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

        // POST: api/Guest
        public async Task<IHttpActionResult> Post([FromBody] Guest addGuest)
        {
            try
            {
                hotelContext.Guests.Add(addGuest);
                await hotelContext.SaveChangesAsync();
                return Ok("Guest was Added Successfully");
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

        // PUT: api/Guest/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Guest updaeGuest)
        {
            try
            {
                Guest guest = await hotelContext.Guests.FindAsync(id);
                if (guest.FirstName != null)
                {
                    guest.FirstName = updaeGuest.FirstName;
                    guest.LastName = updaeGuest.LastName;
                    guest.Gender = updaeGuest.Gender;
                    guest.BirthDate = updaeGuest.BirthDate;
                    guest.CheckIn = updaeGuest.CheckIn;

                    await hotelContext.SaveChangesAsync();
                    return Ok("Guest was Updated Successfully");
                }
                else
                {
                    return NotFound();
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

        // DELETE: api/Guest/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Guest guestToDelete = await hotelContext.Guests.FindAsync(id);
                if(guestToDelete.FirstName != null)
                {
                    hotelContext.Guests.Remove(guestToDelete);
                    await hotelContext.SaveChangesAsync();
                    return Ok("Guest was Deleted Successfully");
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
    }
}

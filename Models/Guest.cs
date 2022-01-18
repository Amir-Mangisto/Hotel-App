using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_App.Models
{
    public class Guest
    {
        public Guest(int id, string firstName, string lastName, string gender, string birthDate, string checkIn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            CheckIn = checkIn;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string CheckIn { get; set; }
    }
}
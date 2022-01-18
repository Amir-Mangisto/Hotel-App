using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_App.Models
{
    public class Ceo
    {
        public Ceo(int id, string fullName, int age, int salary)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            Salary = salary;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_App.Models
{
    public class Room
    {
        public Room(int id, int roomNumber, string typeRoom, bool isAvailable, int price)
        {
            Id = id;
            RoomNumber = roomNumber;
            TypeRoom = typeRoom;
            IsAvailable = isAvailable;
            Price = price;
        }

        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string TypeRoom { get; set; }
        public bool IsAvailable { get; set; }
        public int Price { get; set; }
    }
}
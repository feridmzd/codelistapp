using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppList
{
    public class Hotel
    {
        public string Name;
        private List<Room> Roomlists;
        public int? Roomid;
        public Hotel(string name)
        {
            Name = name;
            Roomlists = new List<Room>();
        }

        public void AddRoom(Room rooms)
        {
            Roomlists.Add(rooms);
        }
        public void MakeReservation(int? roomId)
        {
            if (!roomId.HasValue)
                throw new NullReferenceException("Room ID cannot be null.");

            Room room = Roomlists.Find(r => r.Id == roomId);

            if (room == null)
                throw new ArgumentException($"Room with ID {roomId} does not exist.");

            room.Rezervasiya();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppList
{
    public  class Room
    {

        private int id { get; }
        public int Id;
        public string Name;
        public int Price;
        public int PersonCapacity;
        public bool Isaviable;
        

        public Room(int id,string name,int price,int personcapacity,bool isaviable)
        
        { 
            this.id = id++;
            Name = name;
            Price = price;
            PersonCapacity = personcapacity;
            Isaviable = true;
        
        
        }
        public string  Showinfo()
        {
            return ($"Id:{Id}\nName:{Name}\nPrice:{Price}\nPersoncpt:{PersonCapacity}");
        }
        public override string ToString()
        {
            return Showinfo();
        }
        public bool Rezervasiya()
        {
            if (!Isaviable)
            {
                return false;
            }
            Isaviable=true; 
            return true;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppList
{
    public  class Employe
    {
        private static int _id;
        public int Id { get; set; }
        public string Name;
        public string Surname;
        public int Age;
        public int DepartmentNo;
        public string Position;
        public int salary;
        public Position Posit;
        public int Salary
        {
            get
            {

                return salary;
            }
            set
            {

                if (value > 0)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("0 ola bilmez veya menfi");
                }

            }


        }
        public Employe(string name, string surname, int age, int departmentNo,Position position, int salary)
        {
            Name = name;
            Surname = surname;
            Age = age;
            DepartmentNo = departmentNo;
            Posit = position;
            Salary = salary;
            _id++;
            Id= _id;

        }
        public void Showinfo()
        {
            Console.WriteLine($" {Name}\n {Surname} \n{Age}\n {DepartmentNo}\n{Position}\n{Salary} ");
        }

    }
}

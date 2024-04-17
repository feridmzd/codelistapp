using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace ConsoleAppList
{
    public class Department
    {

        public int No;
        private List<Employe> Employes;
        public int Employelimit;




        public Department(int no, int employelimit)
        {
            No = no;
            Employelimit = employelimit;
            Employes = new List<Employe>();
            if (employelimit <= 0 || employelimit > 20)
            {
                throw new ArgumentOutOfRangeException("Employenin  limiti 1-20");
            }

        }
        public void AddEmploye(Employe employe)
        {

            Employes.Add(employe);
        }




        public Employe GetEmployelimit(int id)

        {
            return Employes.Find(p => p.Id == id);

        }



        public List<Employe> GetProductsBySalary(double minSalary, double maxSalary)
        {
            return Employes.FindAll(p => p.salary >= minSalary && p.salary <= maxSalary);
        }



        public Employe GetemployebyPosition(Position position)
        {

            var selectededPosition = Employes.FirstOrDefault(p => p.Posit == position);
            if (selectededPosition == null)
            {
                throw new NullReferenceException("Wrong!");
            }
            return selectededPosition;
        }


        public void GetAllemploye()

        {
            foreach (Employe emps in Employes)
            {
                if (emps != null)
                {
                    emps.Showinfo();

                }

            }

        }

    }
}

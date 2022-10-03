using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    public abstract class BaseSalaryCalculator
    {
        public abstract double CalculateSalary();
    }

    class SeniorDeveloper
    {
        public virtual void Salary()
        {

        }
    }


    class Developer 
    {
        private Developer()
        {

        }
    }

    class Employee 
    {
        
    }
}

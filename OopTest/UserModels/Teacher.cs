using System;

namespace OopTest
{
    public class Teacher : User
    {
        public int Salary { get; set; }

        public Teacher(string firstName, string lastName, string emailAddress, int salary = 35000) : base(firstName, lastName, emailAddress)
        {
            Salary = salary;
        }
    }
}


using System;
namespace OopTest
{
	public class Student : User
	{
        public string Major { get; set; }

        public Student(string firstName, string lastName, string emailAddress, string major = "undecided") : base(firstName, lastName, emailAddress)
        {
            Major = major;
        }
    }
}


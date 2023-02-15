using System;
namespace OopTest
{
	public abstract class User
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }

		private string password;		// field
		public string Password			// property
		{
			//get { return password;  } // commented out. We don't want to 'get' the password
			set { password = value; }	// we can set the password if needed.
		}

		public User(string firstName, string lastName, string emailAddress)
		{
			FirstName = firstName;
			LastName = lastName;
			EmailAddress = emailAddress;
			Password = "password";			// Setting a default password for everyone upon user creation.
		}

		public bool VerifyPassword(string passwordEntered)
		{
			if (passwordEntered == password) return true;

			return false;
		}

		public void ChangePassword(string newPassword)
		{
			password = newPassword;
		}

        public override string ToString()
        {
			return $"{FirstName}, {LastName}, {EmailAddress}, {GetType().Name}";	
        }
    }
}


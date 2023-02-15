using System;

namespace OopTest
{
	public static class UserDatabase
	{
		private static List<User> allUsers = new()
		{
            new Teacher("Ahmed", "Mansouri", "ahmed@mail.com"),
            new Student("Yuki", "Miyamoto", "yuki@mail.com", "BFA"),
			new Student("Robert", "Forestman", "robert@mail.com", "MS"),
			new Student("Tyrone", "Callum", "tyrone@mail.com", "BS"),
			new SystemAdmin("Cristina", "Calavera", "cristina@mail.com")
		};

		public static List<User> GetUsers()
		{
			return allUsers;
		}

		public static bool IsValidUser(string email)
		{
			return allUsers.Any(u => u.EmailAddress == email);
		}

		public static User GetUser(string email)
		{
			return allUsers.Find(u => u.EmailAddress == email);
		}

        // returns a string to verify to the user that a student was added successfully. This could be void. 
        public static string AddUser(User userToAdd) 
		{
			string response = "Unknown error occurred.";

			// We expect this to always work in this example...
			// But in a situaton where we are connecting to a database or writing to a file,
			// it's possible that the connection might be bad and throw an exception

			try
			{
				allUsers.Add(userToAdd);

				if (IsValidUser(userToAdd.EmailAddress))
				{
					User verifiedNewUser = GetUser(userToAdd.EmailAddress);

					return $"{verifiedNewUser.FirstName} successfully added!";
				}
			}
			catch (Exception ex)
			{
                response = $"Oops. Something went wrong. Details: {ex.Message}";

            }

			return response;
		}

		public static void DeleteUser(User userToDelete)
		{
			allUsers.Remove(userToDelete);
		}
	}
}


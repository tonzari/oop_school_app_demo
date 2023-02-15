using System;
namespace OopTest
{
    public class SystemAdmin : User
    {
        public string AddUser(User userToAdd)
        {
            string responseMessage = string.Empty;

            if (userToAdd is Student)
            {
                responseMessage = UserDatabase.AddUser(userToAdd);
            }

            return responseMessage;
        }

        public void DeleteUser(User userToDelete)
        {
            if (userToDelete is Teacher)
            {
                UserDatabase.DeleteUser(userToDelete);
            }
        }


        public SystemAdmin(string firstName, string lastName, string emailAddress) : base(firstName, lastName, emailAddress)
        {
        }
    }
}



using OopTest;

Console.WriteLine("Welcome to the School Online System! Please login in to continue.");

do
{
    Console.Write("\nEnter your email address: ");
    string userInputEmail = Console.ReadLine();

    Console.Write("\nEnter your password: ");
    string userInputPassword = Console.ReadLine();

    if (UserDatabase.HasEmailAddress(userInputEmail))
    {
        User loggedInUser = UserDatabase.GetUser(userInputEmail);

        if (loggedInUser.VerifyPassword(userInputPassword))
        {
            // Route user to correct menu

            switch (loggedInUser)
            {
                case Student student:

                    LoadStudentPortal(student);

                    break;

                case Teacher teacher:

                    LoadTeacherLMS(teacher);

                    break;

                case SystemAdmin systemAdmin:

                    LoadSystemAdminPanel(systemAdmin);

                    break;
            }
        }
        else
        {
            Console.WriteLine("Sorry, wrong password.");
        }
    }
    else
    {
        Console.WriteLine("Not a valid email address and/or email. Try again.\n");
    }

    Console.WriteLine("\nRestart app? [y]");

} while (Console.ReadLine() == "y");


/*
 * 
 * Local Methods below!
 * 
 * These methods encapsulate the different logic that is needed based on
 * which type of user has logged in.
 * 
 * Students, teachers, and system admins each have a different experience.
 * 
 * We will focus heavily on the System Admin, and their ability to Add/Remove students/teachers
 * 
 * To clean up our app...
 * Everything below could be moved into a Menu class, for example.
 * 
 */


static void LoadStudentPortal(Student student)
{
    Console.WriteLine($"Welcome to the Student Portal, {student.FirstName}.");
    Console.WriteLine($"Major: {student.Major}");

    // Can give students ability to see their list of courses, or list of grades...
    Console.WriteLine("\nSorry... The Student Portal is under construction... [hit enter to exit]" );
    Console.ReadLine();
}

static void LoadTeacherLMS(Teacher teacher)
{
    Console.WriteLine($"Welcome to the Teacher Learning Management System, {teacher.FirstName}. ");
    Console.WriteLine($"Salary: {teacher.Salary}");

    // Can give teachers the ability to see list of their courses, list of their students with grades, their salary info, remove student from class...
    Console.WriteLine("\nSorry... The Teacher Learning Management System is under construction... [hit enter to exit]");
    Console.ReadLine();
}

static void LoadSystemAdminPanel(SystemAdmin systemAdmin)
{
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
    Console.WriteLine($"Welcome to the System Admin Panel, {systemAdmin.FirstName}. ");
    Console.WriteLine($"With power comes responsibility!");

    do
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Add student");
        Console.WriteLine("2. Remove student");
        Console.WriteLine("3. Add teacher");
        Console.WriteLine("4. Remove teacher");
        Console.WriteLine("5. See list of all users");

        Console.WriteLine();

        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "1":

                Console.WriteLine("Please add student details. ");
                Console.Write("First name: ");
                string newFirstName = Console.ReadLine();

                Console.Write("Last name: ");
                string newLastName = Console.ReadLine();

                Console.Write("Email address: ");
                string newEmail = Console.ReadLine();

                Student newStudent = new Student(newFirstName, newLastName, newEmail);

                string responseMessage = UserDatabase.AddUser(newStudent);

                Console.WriteLine(responseMessage);

                break;

            case "2":

                Console.Write("Please enter the email address of the student account you wish to remove: ");
                string userEmailToDelete = Console.ReadLine();

                if (UserDatabase.HasEmailAddress(userEmailToDelete))
                {
                    User userToDelete = UserDatabase.GetUser(userEmailToDelete);

                    UserDatabase.DeleteUser(userToDelete);
                }
                else
                {
                    Console.WriteLine("That user does not exist.");
                }

                break;

            case "5":
                foreach (var user in UserDatabase.GetUsers())
                {
                    Console.WriteLine(user); // We overrode user's built-in .ToString() method! This will print out exactly what we tell it print out (definied in User class)
                }

                break;
        }

        Console.WriteLine("\nContinue? [y]");
    } while (Console.ReadLine() == "y");


    // Can give system admins the ability to add/remove students, teachers, courses, etc...
}
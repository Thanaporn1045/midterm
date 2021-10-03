using System;
using System.Collections.Generic;

namespace ข้อสองห้องสมุด
{
    class Program
    {

        enum Menu
        {
            Login = 1,
            Register
        }
        static void Main(string[] args)
        {
            PersonList InfoFromInput = new PersonList();
            InputandCheckMenu(InfoFromInput);
        }
        static void InputandCheckMenu(PersonList InfoFromInput)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Digital library");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.Write("Select Menu : ");
            Menu numMenu = (Menu)int.Parse(Console.ReadLine());
            if (numMenu == Menu.Login) { Console.Clear(); LoginPage(InfoFromInput); }
            else if (numMenu == Menu.Register) { Console.Clear(); RegisterPage(InfoFromInput); }
        }
        static void RegisterPage(PersonList InfoFromInput)
        {
            SystemBase InputList = new SystemBase();
            Studentinfo InfoOfStudent = new Studentinfo();
            Employeeinfo InfoOfEmployee = new Employeeinfo();
           
            Console.WriteLine("Register new Person");
            Console.WriteLine("----------------------");
            Console.Write("Input name : ");
            InputList.Username = Console.ReadLine();
            Console.Write("Input password : ");
            InputList.Password = Console.ReadLine();
            Console.Write("Input User Type 1 = Student, 2 = Employee: ");
            InputList.usertype = (Usertype)int.Parse(Console.ReadLine());
            if (InputList.usertype == Usertype.Student)
            {
                Console.Write("Student ID : ");
                InputList.ID = Console.ReadLine();
                InfoOfStudent = InputList as Studentinfo;
                InfoFromInput.AddlistStudent(InfoOfStudent);
            }
            else
            {
                Console.Write("Employee ID : ");
                InputList.ID = Console.ReadLine();
                InfoOfEmployee = InputList as Employeeinfo;
                InfoFromInput.AddlistEmployee(InfoOfEmployee);
            }

            Console.Clear();
            InputandCheckMenu(InfoFromInput); 
        }
        static void LoginPage(PersonList InfoFromInput)
        {
            SystemBase InfoForLogin = new SystemBase();
            Console.Write("Name : ");
            InfoForLogin.Username = Console.ReadLine();
            Console.Write("Password : ");
            InfoForLogin.Password = Console.ReadLine();
            CheckStudentUser(InfoFromInput, InfoForLogin);
        }
        static void CheckStudentUser(PersonList InfoFromInput, SystemBase InfoForLogin)
        {
            Console.Clear();
            foreach (SystemBase ReadList in InfoFromInput.ListStudent )
            {
                if (InfoForLogin.Username == ReadList.Username &&InfoForLogin.Password == ReadList.Password)
                {
                     Console.Clear(); StudentMenu(InfoFromInput, InfoForLogin); 

                }
                else { CheckEmployeeUser(InfoFromInput, InfoForLogin); }
            }
        }
        static void CheckEmployeeUser(PersonList InfoFromInput, SystemBase InfoForLogin)
        {
            foreach (SystemBase ReadList2 in InfoFromInput.ListEmployee)
            {
                if (InfoForLogin.Username == ReadList2.Username)
                {
                    if (InfoForLogin.Password == ReadList2.Password) { Console.Clear(); EmployeeMenu(InfoFromInput,InfoForLogin); }
                    else { InputandCheckMenu(InfoFromInput); }
                }
                else { InputandCheckMenu(InfoFromInput); }
            }
        }
        static void EmployeeMenu(PersonList InfoFromInput, SystemBase InfoForLogin)
        {
            foreach (SystemBase ReadList3 in InfoFromInput.ListEmployee )
            {
                if (InfoForLogin.Username == ReadList3.Username)
                {
                    InfoForLogin.ID = ReadList3.ID;
                }

            }
            Console.WriteLine("Employee Management");
            Console.WriteLine("---------------------");
            Console.WriteLine("Name :{0}", InfoForLogin.Username);
            Console.WriteLine("Empolyee ID : {0}", InfoForLogin.ID);
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Get List Books");
            Console.Write("Input Menu : ");
            int MenuPage = int.Parse(Console.ReadLine());
            if (MenuPage == 1) { Getlistbooks(); }
            else { InputandCheckMenu(InfoFromInput); }
        }

        static List<booklist> Getlistbooks()

        {
            List<booklist> Booklist = new List<booklist>();
            booklist book1 = new booklist(1, "NOW I UNDERSTAND");
            booklist book2 = new booklist(2, "REVOLUTIONARY WEALTH");
            booklist book3 = new booklist(3, " Six Degrees");
            booklist book4 = new booklist(4, "Les Vacances");

            Booklist.Add(book1);
            Booklist.Add(book2);
            Booklist.Add(book3);
            Booklist.Add(book4);

            Console.Clear();
            Console.WriteLine("Book List");
            Console.WriteLine("----------");
            foreach (booklist Readlist6 in Booklist)
            {
                Console.WriteLine("Book ID: {0}", Readlist6.ID);
                Console.WriteLine("Book name: {0}", Readlist6.namebook);
            }
            return Booklist;

        }
        static void StudentMenu(PersonList InfoFromInput, SystemBase InfoForLogin)
        {
            foreach (SystemBase ReadList4 in InfoFromInput.ListStudent)
            {
                if (InfoForLogin.Username == ReadList4.Username)
                {
                    InfoForLogin.ID = ReadList4.ID;
                }
            }
            Console.WriteLine("Student Management");
            Console.WriteLine("---------------------");
            Console.WriteLine("Name :{0}", InfoForLogin.Username);
            Console.WriteLine("Student ID : {0}", InfoForLogin.ID);
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Borrow Book");
            Console.Write("Input Menu : ");
            int MenuPage = int.Parse(Console.ReadLine());
            if (MenuPage == 1) { Getlistbooks(); BorrowBook(); }
            else { }
        }
        static void BorrowBook()
        {
            string borrowbook; int numbook;
            List<booklist> Booklist = Getlistbooks(); 
            Console.WriteLine("");
            Getlistbooks();
            do
            {
                Console.Write("Input book ID : ");
                borrowbook = Console.ReadLine();
                numbook = int.Parse(borrowbook);
                foreach (booklist Readlist7 in Booklist)
                {
                    if (numbook == Readlist7.ID)
                    {
                        Console.WriteLine("Book ID: {0}", Readlist7.ID);
                        Console.WriteLine("Book name: {0}", Readlist7.namebook);
                    }
                }
            } while (borrowbook != "exit");

        }
    }
}

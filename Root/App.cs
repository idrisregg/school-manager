using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dap.Members;
using Dap.Root;

namespace dap.root;


interface IShowPerf
{
    Task ShowPerformance()
    {
        return App.ShowPerformance();
    }
}

public class App
{


    // lists to not use Linq or anything they live temporarily whiel program is runing
    static public List<Student> Students = new List<Student>();
    static public List<Teacher> Teachers = new List<Teacher>();

    static public Principal Principal = new Principal();

    static public Receptionist Receptionist = new Receptionist();


    enum SchoolMemberType
    {
        typePrincipal = 1,

        typTeacher,

        typeStudent,

        typeReceptionist
    }

    public static SchoolMember AcceptAttributes()
    {
        var member = new SchoolMember();
        member.Name = Dap.Helper.Console.AskQuestion("Type in your Name :");
        member.Address = Dap.Helper.Console.AskQuestion("Type in your Address :");
        member.Phone = Dap.Helper.Console.AskQuestionInt("Type in your Phone Number :");

        return member;
    }

    internal static int AcceptedChoices()
    {
        return Dap.Helper.Console.AskQuestionInt("\n1. Add\n2. Display\n3. Pay\n4. Student Performance\nPlease enter the member type: ");
    }

    internal static int AcceptedMemberType()
    {
        int x = Dap.Helper.Console.AskQuestionInt("\n1. Principal\n2. Teacher\n3. Student\n4. Receptionist\nPlease enter the member type: ");
        return Enum.IsDefined(typeof(SchoolMemberType), x) ? x : -1;
    }

    public static void AddPrincipal()
    {
        SchoolMember member = AcceptAttributes();
        Principal.Name = member.Name;
        Principal.Address = member.Address;
        Principal.Phone = member.Phone;
    }

    private static void AddStudent()
    {
        SchoolMember member = AcceptAttributes();
        Student newStudent = new Student(member.Name, member.Address, member.Phone);
        newStudent.Grade = Dap.Helper.Console.AskQuestionInt("Type in your Grade :");
        Students.Add(newStudent);
    }

    private static void AddTeacher()
    {
        SchoolMember member = AcceptAttributes();
        Teacher newTeacher = new Teacher(member.Name, member.Address, member.Phone);
        newTeacher.Subject = Dap.Helper.Console.AskQuestion("Type in your Subject :");
        Teachers.Add(newTeacher);
    }

    public static void Add()
    {
        Console.WriteLine("\nPlease note that the Principal/Receptionist details cannot be added or modified now");
        int memberType = AcceptedMemberType();

        switch (memberType)
        {
            case 2:
                AddTeacher();
                break;
            case 3:
                AddStudent();
                break;

            default:
                Console.WriteLine("Invalid input");
                break;
        }

    }

    public static void Display()
    {
        int memberType = AcceptedMemberType();

        switch (memberType)
        {
            case 1:
                Console.WriteLine("Here Are the Principal Details :");
                Principal.Display();
                break;

            case 2:
                Console.WriteLine("Here Are the Teachers Details :");
                foreach (var teach in Teachers)
                {
                    teach.Display();
                }

                break;

            case 3:
                Console.WriteLine("Here Are the Students Details :");
                foreach (var stud in Students)
                {
                    stud.Display();
                }
                break;

            case 4:
                Console.WriteLine("Here Are the Receptionist Details :");
                Receptionist.Display();
                break;


            default:
                Console.WriteLine("Invalid Input..");
                break;

        }
    }
    public static void Pay()
    {
        Console.WriteLine("Note that students Cannot be Paid.");
        var memberType = AcceptedMemberType();

        switch (memberType)
        {
            case 1:
                Principal.Pay();
                break;

            case 2:
                List<Task> payments = new List<Task>();
                foreach (var teach in Teachers)
                {
                    Task payment = new Task(teach.Pay);
                    payments.Add(payment);
                    payment.Start();
                }
                Task.WaitAll(payments.ToArray());
                break;

            case 4:
                Receptionist.Pay();
                break;
            default:
                Console.WriteLine("Invalid Input..");
                break;
        }
        Console.WriteLine("\n Payments has been Completed");
    }


    public static async Task ShowPerformance()
    {
        double average = await Task.Run(() => Student.GradeAverage(Students));
        Console.WriteLine($"/n The Student average Grade is : {average}");
    }


    //seed data for the school
    internal static void AddData()
    {
        Receptionist = new Receptionist("Receptionist", " 1911 Watson Lane", 0794578896);

        Principal = new Principal("Principal", " 22 Fodo Lane", 0656963214);

        for (int i = 0; i < 5; i++)
        {
            Students.Add(new Student(i.ToString(), i.ToString(), i, i));
            Teachers.Add(new Teacher(i.ToString(), i.ToString(), i));
        }
    }

}
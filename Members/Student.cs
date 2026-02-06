using Dap.Root;

namespace Dap.Members;

public class Student : SchoolMember
{
    private int _grade;

    public int Grade
    {
        get
        {
            return _grade;
        }
        set
        {
            if (value < 0 || value > 20)
            {
                throw new Exception("Invalide Grades");
            }
            _grade = value;
        }
    }

    public Student(string name = "", string address = "", int phoneNum = 0, int grade = 0)
    {
        Name = name;
        Address = address;
        Phone = phoneNum;
        Grade = grade;
    }

    public void Display()
    {
        Console.WriteLine($"Name : {Name}, Address : {Address}, Phone : {Phone}, Grade :{Grade}");
    }

    public static double GradeAverage(List<Student> students)
    {
        double avg = 0;
        foreach (Student student in students)
        {
            avg += student.Grade;
        }
        return avg / students.Count;
    }
}
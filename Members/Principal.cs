using Dap.Root;
using Dap.Helper;

namespace Dap.Members;

public class Principal : SchoolMember, IPayroll
{
    private int income;

    private int balance;


    public Principal(int income = 50000)
    {
        this.income = income;
        balance = 0;
    }

    public Principal(string name, string address, int phoneNum, int income = 50000)
    {
        Name = name;
        Address = address;
        Phone = phoneNum;
        this.income = income;
        balance = 0;
    }

    public void Display()
    {
        System.Console.WriteLine($"Name: {Name}, Address: {Address}, Phone: {Phone}");
    }

    public void Pay()
    {
        NetworkDelay.PayEntity("Principal", Name, ref balance, income);
    }
}

using Dap.Root;
using System;
using Dap.Helper;

namespace Dap.Members;

public class Teacher : SchoolMember, IPayroll
{
    private readonly int income;

    private int balance;

    public string? Subject;

    public Teacher(string name, string address, int phoneNum, string subject = "", int income = 25000)
    {
        Name = name;
        Address = address;
        Phone = phoneNum;
        this.income = income;
        Subject = subject;
        balance = 0;
    }
    public void Display()
    {
        System.Console.WriteLine($"Name: {Name}, Address: {Address}, Phone: {Phone}, Subject: {Subject}");
    }

    public void Pay()
    {
        NetworkDelay.PayEntity("Teacher", Name, ref balance, income);
    }
}
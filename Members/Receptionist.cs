using System;
using System.Collections.Generic;
using Dap.Root;
using Dap.Helper;

namespace Dap.Members;

public class Receptionist : SchoolMember, IPayroll
{
    private int income;

    private int balance;



    public Receptionist(int income = 10000)
    {
        this.income = income; balance = 0;
    }

    public Receptionist(string name, string address, int phoneNum, int income = 1000)
    {
        Name = name;
        Phone = phoneNum;
        Address = address;
        this.income = income;
        balance = 0;
    }

    public void Display()
    {
        System.Console.WriteLine($"Name: {Name}, Phone: {Phone}, Address: {Address}");
    }
    public void Pay()
    {
        NetworkDelay.PayEntity("Receptionist", Name, ref balance, income);
    }

}
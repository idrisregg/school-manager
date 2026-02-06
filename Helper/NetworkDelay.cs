using System;
using System.Threading;

namespace Dap.Helper;

public class NetworkDelay
{
    private static int minDelay = 1000;

    public static int MinDelay
    {
        get
        {
            return minDelay;
        }
        set
        {
            if (value < 1000)
            {
                throw new Exception("Minimum Delay cannot be Less than 1000ms");
            }
            minDelay = value;
        }
    }

    private static int maxDelay = 5000;

    public static int MaxDelay
    {
        get
        {
            return maxDelay;
        }
        set
        {
            if (value > 5000)
            {
                throw new Exception("Maximum Delay cannot be more than 5000ms");
            }
            maxDelay = value;
        }
    }



    // simulate delay for payment like is in real world app
    public static void SimualteNetworkDelay()
    {
        var ran = new Random();
        var rand = ran.Next(MinDelay, MaxDelay);
        //sleep thread for specific time
        Thread.Sleep(rand);
    }

    public static void PayEntity(string entity, string name, ref int balance, int income)
    {
        SimualteNetworkDelay();
        balance += income;
        System.Console.WriteLine($"Paid {entity}: {name}. Total balance: {balance}");
    }
}

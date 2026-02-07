using dap.root;
namespace dap;

public class Program : App
{


    public static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        //call seed data on start 
        AddData();

        Console.WriteLine("----------------------------------------Welcome :----------------------------------------");

        bool start = true;

        while (start)
        {
            int choice = AcceptedChoices();

            switch (choice)
            {
                case 1:

                    Add();
                    break;
                case 2:

                    Display();
                    break;
                case 3:
                    Pay();
                    break;
                case 4:
                    await ShowPerformance();
                    break;
                default:
                    start = false;
                    break;
            }
        }
        Console.WriteLine("\nClosing...");
    }
}
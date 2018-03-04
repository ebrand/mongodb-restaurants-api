using PowerArgs;
using System;

namespace Restaurants.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Args.InvokeAction<ActionMethods>(args);
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
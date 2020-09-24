using System;
using System.Net;
using System.Threading.Tasks;

namespace ServiceApp
{
    class Program
    {
        private static ServiceClient serviceClient = ServiceClient.CreateFromConnectionString("");
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static async Task InvokeMetod() 
        {
         var methodInvocation = new
         Console.WriteLine($"Response status: {}");
        
        
        }
    }
}

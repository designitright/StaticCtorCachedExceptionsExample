using System;
using System.Threading;

namespace StaticCtorCachedExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    StaticCtorWithThrow.DoWork();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                Thread.Sleep(50);
            }

            Console.WriteLine("Press enter when done");
            Console.ReadLine();
        }
    }

    static class StaticCtorWithThrow
    {
        static StaticCtorWithThrow()
        {
            var key = Guid.NewGuid();
            throw new Exception($"I created {key} at {DateTime.UtcNow:O}");
        }
        public static void DoWork()
        {

        }
    }
}

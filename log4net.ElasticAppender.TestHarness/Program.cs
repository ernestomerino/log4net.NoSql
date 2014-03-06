using System;

namespace log4net.NoSql.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {

            var logger = log4net.LogManager.GetLogger(typeof(RandomLogger));

            //XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));

            var harness = new RandomLogger(logger)
            {
                NumberOfEntries = 100
            };

            harness.Start();

            Console.WriteLine("DONE!");
            Console.ReadLine();
        }
    }
}

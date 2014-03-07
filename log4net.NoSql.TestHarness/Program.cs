using System;

namespace log4net.NoSql.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {

            var logger = log4net.LogManager.GetLogger(typeof(RandomLogger));

            //XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));

            var startTime = DateTime.UtcNow;
            const int numberOfRecords = 10000;

            var harness = new RandomLogger(logger)
            {
                NumberOfEntries = numberOfRecords
            };

            harness.Start();

            var durationMs = DateTime.UtcNow.Subtract(startTime).TotalMilliseconds;

            Console.WriteLine("Inserted {0} records in {1} ms ", numberOfRecords, durationMs);
            Console.ReadLine();
        }
    }
}

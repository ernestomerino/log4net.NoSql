using System;

namespace log4net.NoSql.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = log4net.LogManager.GetLogger(typeof(RandomLogger));

            var startTime = DateTime.UtcNow;
            const int numberOfRecords = 100;

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

using System;

namespace HWK.Zeitrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime toDate = DateTime.Now;
            DateTime fromDate = toDate.AddDays(-730);
            //DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            //TimeSpan toDateTimeSpan = (toDate - epoch);
            //TimeSpan fromDateTimeSpan = (fromDate - epoch);
            double toDateMilliseconds = Program.CalcEpochMilliseconds(toDate);
            double fromDateMilliseconds = Program.CalcEpochMilliseconds(fromDate);
            string toDateJSON = Program.CreateJSONDate("toDate", toDateMilliseconds);
            string fromDateJSON = Program.CreateJSONDate("fromDate", fromDateMilliseconds);
            Console.WriteLine(fromDateJSON);
            Console.WriteLine(toDateJSON);
            var aaa = "aaa";

        }

        private static string CreateJSONDate(string field, double milliseconds)
        {
            char quotes = '"';
            string fieldval = quotes + field + quotes + ":";
            string datevalue =  quotes + "\\/Date(" + milliseconds.ToString() + "+0100)\\/" + quotes;
            return fieldval + datevalue + ",";
        }
        private static double CalcEpochMilliseconds(DateTime date)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            TimeSpan timeSpan = (date - epoch);
            return Math.Truncate(timeSpan.TotalMilliseconds);
        }



    }
}

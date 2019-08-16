using System;
using System.Globalization;
using System.Deployment.Application;

namespace TimeTracker
{
    public static class TTStatic
    {
        //Using static varibales for some variables
        public static string ttVersion = "2019.07.24.1";
        public static string ttPathToDataLocal = "";
        public static string ttPathToDataCentral = "";
        public static string ttPathToWBS = "";
        public static string ttAppPath;

        public static string GetDelimitedFieldData(string line, int fieldno, string separator)
        {
            //Utility method to return the data in the field on selected position based on separator received by method, all fields will be returned as "string"

            int start = 0;
            int end = 0;
            int i = 0;

            //Separator not found in string
            if (line.IndexOf(separator, start) == -1)
            {
                return "0";
            }

            //Cycle through string to find correct field number
            while (line.IndexOf(separator, start) != -1 && i < fieldno - 1)
            {
                i += 1;

                start = line.IndexOf(separator, start) + 1;
            }

            //Find end point for Subsring function
            end = line.IndexOf(separator, start);

            if (end == 0 || end == -1)
            {
                end = line.Length;
            }

            return line.Substring(start, end - start);
        }

        public static int GetWeekNumber(string date)
        {
            //Get week number from date received into method
            int weekNumber = 0;

            //Week number based on US culture including Sunday start
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            weekNumber= myCal.GetWeekOfYear(DateTime.Parse(date), myCWR, myFirstDOW);

            return weekNumber;
        }

        public static string ConvertDate(string date)
        {
            string d = "";

            //Try to convert dates to format YYYYMMDD from string date received by method
            try
            {
                //US
                if (date.IndexOf("/") >= 0)
                {
                    d = GetDelimitedFieldData(date, 3, "/") + GetDelimitedFieldData(date, 1, "/") + GetDelimitedFieldData(date, 2, "/");
                }

                //EU
                if (date.IndexOf("-") >= 0)
                {
                    d = GetDelimitedFieldData(date, 1, "-") + GetDelimitedFieldData(date, 2, "-") + GetDelimitedFieldData(date, 3, "-");
                }

                return d;
            }
            //If conversion fails today's date in format YYYYMMDD will be returned
            catch
            {
                return DateTime.Now.ToString("yyyyMMdd").ToString();
            }
        }
    }
}

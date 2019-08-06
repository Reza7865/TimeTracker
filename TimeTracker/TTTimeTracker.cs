using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace TimeTracker
{
    class TTTimeTracker
    {
        private string employeeId;
        private string date;

        public double CalculateSumHoursForDate(string employeeid, string date)
        {
            this.employeeId = employeeid;
            this.date = date;

            int weekNumber = 0;

            string line;
            string data;
            double hours = 0.0;

            //Get weeknumber and convert date to use to open file
            weekNumber = TTStatic.GetWeekNumber(date);
            date = TTStatic.ConvertDate(date);

            try
            {
                //Open file and cycle through, adding hours from each line to sum hours
                StreamReader file = new StreamReader(TTStatic.ttPathToDataLocal + "\\" + this.employeeId + "_" + weekNumber + "_" + date + ".txt");

                while ((line = file.ReadLine()) != null)
                {
                    data = TTStatic.GetDelimitedFieldData(line, 5, ",");

                    hours += double.Parse(data);
                }

                file.Close();

                return hours;
            }

            catch
            {
                return 0.0;
            }
        }

        public double CalculateSumHoursForWeek(string employeeid, string date)
        {
            this.employeeId = employeeid;
            this.date = date;

            int weekNumber = 0;

            string line;
            string data = "";
            double hours = 0.0;
            
            

            //Get weeknumber for date
            weekNumber = TTStatic.GetWeekNumber(date);

            //Find all files for week number for employee id in form
            string[] files = Directory.GetFiles(TTStatic.ttPathToDataLocal, employeeid + "_" + weekNumber + "_*");

            //Open each file and cycle through, adding hours from each line to sum hours
            foreach (string f in files)
            {
                StreamReader file = new StreamReader(f);

                while ((line = file.ReadLine()) != null)
                {
                    

                    data = TTStatic.GetDelimitedFieldData(line, 5, ",");

                    hours += double.Parse(data);

                }

                file.Close();

            }
            return hours;
        }

        public string CalculateSumHoursForWeekPPSAP(string employeeid, string date)
        {
            //Create empty list of TTTimeEntry models
            List<TTTimeEntry> lte = new List<TTTimeEntry>();

            int weekNumber = 0;
            string line;
            string WBS;
            double hours = 0.0;

            bool Found = false;

            weekNumber = TTStatic.GetWeekNumber(date);

            //Find all files for week number for employee id in form
            string[] files = Directory.GetFiles(TTStatic.ttPathToDataLocal, employeeid + "_" + weekNumber + "_*");

            //Open each file and cycle through, adding hours from each line to sum hours
            foreach (string f in files)
            {
                StreamReader file = new StreamReader(f);

                while ((line = file.ReadLine()) != null)
                {
                    Found = false;

                    WBS = TTStatic.GetDelimitedFieldData(line, 3, ",");

                    foreach (TTTimeEntry t in lte)
                    {
                        //Only one line per WBS should be created, so if WBS found the hours will be added
                        if (t.WBS == WBS)
                        {
                            Found = true;   
                            t.Hours += Double.Parse(TTStatic.GetDelimitedFieldData(line, 5, ","));

                            //Add to total hours variable
                            hours += Double.Parse(TTStatic.GetDelimitedFieldData(line, 5, ","));
                        }
                    }

                    //If list is empty or no line (object) for WBS is found in list, a new list entry is created
                    if (lte.Count == 0 || Found == false)
                    {
                        TTTimeEntry te = new TTTimeEntry();

                        te.EmployeeId = TTStatic.GetDelimitedFieldData(line, 1, ",");
                        te.Week = weekNumber.ToString();
                        te.WBS = TTStatic.GetDelimitedFieldData(line, 3, ",");
                        te.WBSDescription = TTStatic.GetDelimitedFieldData(line, 4, ",");
                        te.Hours = Double.Parse(TTStatic.GetDelimitedFieldData(line, 5, ","));
                        te.Comment = TTStatic.GetDelimitedFieldData(line, 6, ",");

                        lte.Add(te);

                        //Add to total hours variable
                        hours += Double.Parse(TTStatic.GetDelimitedFieldData(line, 5, ","));
                    }
                }

                file.Close();
            }

            bool First = true;
            string fileName = "";
            string Header;
            double HoursSAP = 0.0;

            //Prepare the data to be sent to file
            if (lte.Count > 0)
            {
                foreach (TTTimeEntry t in lte)
                {
                    //SAP should never receive more than 40 hours, so if hours for weeks >40, SAP hours are "scaled to 40"
                    if (hours > 40)
                    {
                        HoursSAP = Math.Round(40 / hours * t.Hours, 2);
                    }
                    else
                    //If hours <=40 no "scaling" is done
                    {
                        HoursSAP = t.Hours;
                    }

                    //Crate line to write to file
                    line = t.EmployeeId + "," + t.Week + "," + t.WBS + "," + t.WBSDescription + "," + t.Hours + "," + HoursSAP;

                    //When wrining the first line, also headers should be created 
                    if (First == true)
                    {
                        fileName = TTStatic.ttPathToDataLocal + "\\" + t.EmployeeId + "_" + t.Week + ".csv";
                        Header = "EmployeeID,WeekNumber,WBS,WBSDescription,HoursPP,HoursSAP";

                        //Always create new file, deleting old file if exists with same employee id and week number
                        using (StreamWriter file = new StreamWriter(TTStatic.ttPathToDataLocal + "\\" + t.EmployeeId + "_" + t.Week + ".csv", false))
                        {
                            file.WriteLine(Header);
                        }

                        //Add first data line, one per WBS
                        using (StreamWriter file = new StreamWriter(TTStatic.ttPathToDataLocal + "\\" + t.EmployeeId + "_" + t.Week + ".csv", true))
                        {
                            file.WriteLine(line);
                        }

                        //Set first to false to only create new file and add headers once
                        First = false;
                    }
                    else
                    {
                        //Add following data lines, one per WBS
                        using (StreamWriter file = new StreamWriter(TTStatic.ttPathToDataLocal + "\\" + t.EmployeeId + "_" + t.Week + ".csv", true))
                        {
                            file.WriteLine(line);
                        }
                    }
                }
            }

            //If no data found for employee id and week number is found will return "NO_DATA" and trigger message box in calling method
            if (lte.Count == 0)
            {
                return "NO_DATA";
            }
            else
            {
                return fileName;
            }
        }

    }
}

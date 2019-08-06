using System;

namespace TimeTracker
{
    class TTTimeEntry
    {
        //Model used for output to PPSAP file
        public string EmployeeId { get; set; }
        public string Week { get; set; }
        public string WBS { get; set; }
        public string WBSDescription { get; set; }
        public double Hours { get; set; }
        public string Comment { get; set; }
    }
}

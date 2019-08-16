using System;

namespace TimeTracker
{
    class TTSetting
    {
        //Model for Settings used to read and write TTSETTINGS.JSON
        public string EmployeeId { get; set; }
        public Int32 Interval { get; set; }
        public Int32 Left { get; set; }
        public Int32 Top { get; set; }
        public string PathToDataLocal { get; set; }
        public string PathToDataCentral { get; set; }
        public string PathToWBS { get; set; }
    }
}

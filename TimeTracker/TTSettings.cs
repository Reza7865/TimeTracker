using System;
using System.IO;
using System.Windows.Forms;
//using Newtonsoft.Json;

namespace TimeTracker
{
    class TTSettings
    {
        //SET and GET functions ending with "JSON" use NewtonSofts JSON serializer/deserializer to write/read TTSETTINGS.JSON
        //To remove dependency on NewtonSoft there are also SET and GET methods for .TXT file settings

        public TTSetting GetTTSettings()
        {
            //Get all settings when stored in .TXT file
            string line;
            string name;
            string value;

            TTSetting tts = new TTSetting();

            StreamReader file = new StreamReader(Application.StartupPath + "\\ttsettings.txt");

            while ((line = file.ReadLine()) != null)
            {
                name = TTStatic.GetDelimitedFieldData(line, 1, "=");
                value = TTStatic.GetDelimitedFieldData(line, 2, "=");

                switch (name.ToUpper())
                {
                    case "EMPLOYEEID":
                        tts.EmployeeId = value;
                        break;
                    case "INTERVAL":
                        tts.Interval = Int32.Parse(value);
                        break;
                    case "LEFT":
                        tts.Left = Int32.Parse(value);
                        break;
                    case "TOP":
                        tts.Top = Int32.Parse(value);
                        break;
                    case "PATHTODATALOCAL":
                        if (value.Substring(0, 2) == "..") { value = Application.StartupPath + value.Substring(2); }
                        tts.PathToDataLocal = value;
                        break;
                    case "PATHTODATACENTRAL":
                        if (value.Substring(0,2) == "..") { value = Application.StartupPath + value.Substring(2); }

                        tts.PathToDataCentral = value;
                        break;
                    default:
                        tts.Interval = 360000;
                        break;
                }
            }

            file.Close();

            return tts;
        }

        public void SetTTSettings(TTSetting t)
        {
            using (StreamWriter file = File.CreateText(@"ttsettings.txt"))
            {
                file.WriteLine("EmployeeID=" + t.EmployeeId);
                file.WriteLine("Interval=" + t.Interval);
                file.WriteLine("Left=" + t.Left);
                file.WriteLine("Top=" + t.Top);
                file.WriteLine("PathToDataLocal=" + t.PathToDataLocal);
                file.WriteLine("PathToDataCentral=" + t.PathToDataCentral);
            }
        }

        public string GetTTSettingsEmployeeId()
        {
            TTSetting t = GetTTSettings();

            return t.EmployeeId;
        }

        public void SetTTSettingsEmployeeId(string employeeid)
        {
            TTSetting t = GetTTSettings();

            t.EmployeeId = employeeid;

            SetTTSettings(t);
        }

        public Int32 GetTTSettingsInterval()
        {
            TTSetting t = GetTTSettings();

            return t.Interval;
        }

        public void SetTTSettingsInterval(Int32 interval)
        {
            TTSetting t = GetTTSettings();

            t.Interval = interval;

            SetTTSettings(t);
        }

        public void SetTTSettingsLocation(FrmMain f)
        {
            TTSetting t = GetTTSettings();

            t.Left = f.Left;
            t.Top = f.Top;

            SetTTSettings(t);
        }

        //*** To use JSON instead of .TXT to store settings, use these methods, NewtonSoft JSON package needed ***

        //public void SetTTSettingsLocationJSON(frmMain f)
        //{
            //TTSetting t = new TTSetting();

            //t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

            //t.Left = f.Left;
            //t.Top = f.Top;

            //string jsonData = JsonConvert.SerializeObject(t);

            //using (StreamWriter file = File.CreateText(@"ttsettings.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, t);
            //}
        //}

        //public void SetTTSettingsEmployeeIdJSON(frmMain f)
        //{
            //TTSetting t = new TTSetting();

            //t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

            //t.EmployeeId = f.TxtEmployeeId.Text;

            //string jsonData = JsonConvert.SerializeObject(t);

            //using (StreamWriter file = File.CreateText(@"ttsettings.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, t);
            //}
        //}

        //public void SetTTSettingsIntervalJSON(Int32 interval)
        //{
            //TTSetting t = new TTSetting();

            //t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

            //t.Interval = interval;

            //string jsonData = JsonConvert.SerializeObject(t);

            //using (StreamWriter file = File.CreateText(@"ttsettings.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, t);
            //}
        //}

        //public TTSetting GetTTSettingsJSON()
        //{
            //TTSetting t = new TTSetting();

            //t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

            //return t;
        //}

        //public string GetTTSettingsEmployeeIdJSON()
        //{
            //TTSetting t = new TTSetting();

            //t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

            //return t.EmployeeId;
        //}

        //public string GetTTSettingsPathToDataLocalJSON()
        //{
        //    TTSetting t = new TTSetting();

        //    t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

        //    return t.PathToDataLocal;
        //}

        //public string GetTTSettingsPathToDataCentralJSON()
        //{
        //    TTSetting t = new TTSetting();

        //    t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

        //    return t.PathToDataCentral;
        //}

        //public Int32 GetTTSettingsIntervalJSON()
        //{
        //    TTSetting t = new TTSetting();

        //    t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

        //    return t.Interval;
        //}

        //public Int32 GetTTSettingsLeftJSON()
        //{
        //    TTSetting t = new TTSetting();

        //    t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

        //    return t.Left;
        //}

        //public Int32 GetTTSettingsTopJSON()
        //{
        //    TTSetting t = new TTSetting();

        //    t = JsonConvert.DeserializeObject<TTSetting>(File.ReadAllText(@"ttsettings.json"));

        //    return t.Top;
        //}
    }
}

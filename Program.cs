using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace fixedResolutionSysTray
{
    static class Program
    {
        //public static List<resolutionSet> allResolution = new List<resolutionSet>();
        public static Boolean appIsPaused = false;
        public static Resolution.ScreenResolution resObj = new Resolution.ScreenResolution();
        public static List<fixedResolutionSysTray.resolutionSet> allResolution = new List<resolutionSet>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (PriorProcess() != null)
            {

                MessageBox.Show("Another instance of the app is already running.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            getMonitorsAndResolutions();
         
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

            using (MainClass myContext = new MainClass())
            {
                    Application.Run(myContext);
            }
        }

        static void getMonitorsAndResolutions()
        {
            allResolution.Clear();
            allResolution = Resolution.ScreenResolution.getDevices();

            String res = fixedResolutionSysTray.Properties.Settings.Default.resolutions;

            if (res == "x")
            {
                fixedResolutionSysTray.Program.appIsPaused = true;
            }
            else
            {
               
                String[] resArray = res.Split(';');
                foreach (String oneResString in resArray)
                {
                    String[] data = oneResString.Split(',');
                    int width = 0;
                    int height = 0;
                    int freq = 0;
                    Boolean active = false;
                    int deviceId = 0;

                    if (int.TryParse(data[0].ToString(), out width) &&
                        int.TryParse(data[1].ToString(), out height) &&
                        int.TryParse(data[2].ToString(), out freq) &&
                        Boolean.TryParse(data[3].ToString(), out active) &&
                        int.TryParse(data[4].ToString(), out deviceId))
                    {
                        resolutionSet device = fixedResolutionSysTray.Program.allResolution.Find(foundDevice => foundDevice.deviceId == deviceId);
                        if (device != null)
                        {
                            device.setConfig(width, height, freq, active);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to parse your settings!\r\nSettings is reseted.");
                        fixedResolutionSysTray.Properties.Settings.Default.resolutions = "x";
                        fixedResolutionSysTray.Properties.Settings.Default.Save();
                        fixedResolutionSysTray.MainClass.pauseApp(true);
                    }
                }
                changedAllResolutons();
            }
        }

        public static void changedAllResolutons() 
        {
            if (!appIsPaused) 
            {
                foreach (var monitor in allResolution)
                {
                    if (monitor.active)
                    {
                        Resolution.ScreenResolution.ChangeResolution(monitor.width, monitor.height, monitor.refreshRate, monitor.deviceId);
                    }
                }
            }
        }

        static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                changedAllResolutons();
            }
        }

        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fixedResolutionSysTray
{
    public partial class MainSettingsForm : Form
    {
        public static Boolean isRunning = false;
        public Boolean multiMontior = false;
        List<resolutionSet> newSettings = new List<resolutionSet>(Program.allResolution);
        int currentComboIndex = -1;

        public MainSettingsForm()
        {
 
            InitializeComponent();
            multiMontior = newSettings.Count > 1 ? true : false;
            devicesCombo.SelectedValueChanged += new EventHandler(devicesCombo_SelectedValueChanged);
            activeChkBox.CheckedChanged += new EventHandler(activeChkBox_CheckedChanged);

            devicesCombo.DisplayMember = "devicePrettyName";
            devicesCombo.ValueMember = "deviceId";
            devicesCombo.DataSource = newSettings;
            
        }

        void activeChkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox thisChkBox = (CheckBox)sender;
            if (thisChkBox.Checked)
            {
                disableFields(false);
            }
            else 
            {
                disableFields(true);
            }
        }

        void devicesCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (devicesCombo.SelectedIndex != -1) 
            {
                saveCurrentMonitorToList();
                currentComboIndex = devicesCombo.SelectedIndex;
                resolutionSet newMonitor = (resolutionSet)devicesCombo.Items[devicesCombo.SelectedIndex];
                setDataIntoForm(newMonitor.width, newMonitor.height, newMonitor.refreshRate, newMonitor.active);
            }

        }

        void saveCurrentMonitorToList() 
        {
            if (currentComboIndex != -1)
            {
                resolutionSet lastMonitor = (resolutionSet)devicesCombo.Items[currentComboIndex];
                if (lastMonitor != null)
                {
                    lastMonitor.width = int.Parse(primWidth.Text);
                    lastMonitor.height = int.Parse(primHeight.Text);
                    lastMonitor.refreshRate = int.Parse(primRefresh.Text);
                    lastMonitor.active = activeChkBox.Checked;
                }
            }
        }

        private void disableFields(Boolean toDisable) 
        {
            if (toDisable)
            {
                primHeight.Enabled = false;
                primWidth.Enabled = false;
                primRefresh.Enabled = false;
            }
            else
            {
                primHeight.Enabled = true;
                primWidth.Enabled = true;
                primRefresh.Enabled = true;
            }
        }

        private void setDataIntoForm(int width, int height, int refreshRate, Boolean active)
        {
            primWidth.Text = width.ToString();
            primHeight.Text = height.ToString();
            primRefresh.Text = refreshRate.ToString();
            activeChkBox.Checked = active;

            if (!active)
            {
                disableFields(true);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            fixedResolutionSysTray.Program.allResolution.Clear();
            int results = 0;
            if (int.TryParse(primWidth.Text, out results) &&
                   int.TryParse(primHeight.Text, out results) &&
                    int.TryParse(primRefresh.Text, out results))
            {
                saveCurrentMonitorToList();
                saveList();
                Program.allResolution = newSettings;
                this.Close();
                fixedResolutionSysTray.MainClass.pauseApp(false);
             
                //saveResolutionToSetting(new String[] { primWidth.Text, primHeight.Text, primRefresh.Text, activeChkBox.Checked.ToString(), ";" }, false);
                //fixedResolutionSysTray.Program.allResolution.Add(new resolutionSet(int.Parse(primWidth.Text), int.Parse(primHeight.Text), int.Parse(primRefresh.Text)));
            }
        }

        private void saveList()
        {
            for (int i = 0; i < newSettings.Count; i++)
            {
                String[] array = new String[] { newSettings[i].width.ToString(), newSettings[i].height.ToString(), newSettings[i].refreshRate.ToString(), newSettings[i].active.ToString(), newSettings[i].deviceId.ToString() };
                if (i != 0)
                {
                    fixedResolutionSysTray.Properties.Settings.Default.resolutions += ";";
                    fixedResolutionSysTray.Properties.Settings.Default.resolutions += String.Join(",", array);
                }
                else 
                {
                    fixedResolutionSysTray.Properties.Settings.Default.resolutions = String.Join(",", array);
                }
            }
            fixedResolutionSysTray.Properties.Settings.Default.Save();
        }



        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

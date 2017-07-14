using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace fixedResolutionSysTray
{
    class MainClass : ApplicationContext
    {
        public static NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip sysTrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pauseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;

      

        public MainClass()
        {
           
     


            #region systray
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sysTrayMenuStrip = new ContextMenuStrip();


            // 
            // settingsMenuItem
            // 
            //this.settingsMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.settingsMenuItem.Image = global::fixedResolutionSysTray.Properties.Resources.settings;
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsMenuItem.Text = "Settings";
            this.settingsMenuItem.Click += new EventHandler(settingsMenuItem_Click);
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Image = global::fixedResolutionSysTray.Properties.Resources.close;
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pauseMenuItem.Text = "Pause / Resume";
            
            this.pauseMenuItem.Click += new EventHandler(pauseMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::fixedResolutionSysTray.Properties.Resources.close;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new EventHandler(exitMenuItem_Click);

            // 
            // sysTrayMenuStrip
            // 
            this.sysTrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.pauseMenuItem,
            this.exitMenuItem});
            this.sysTrayMenuStrip.Name = "contextMenuStrip1";
            this.sysTrayMenuStrip.Size = new System.Drawing.Size(153, 70);


            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            if (Program.appIsPaused)
            {
                lockSystrayIcon(true);
            }
            else 
            {
                lockSystrayIcon(false);
            }
            trayIcon.DoubleClick += new EventHandler(pauseMenuItem_Click);
            trayIcon.ContextMenuStrip = this.sysTrayMenuStrip;
       

            #endregion
        }

        void pauseMenuItem_Click(object sender, EventArgs e)
        {
            fixedResolutionSysTray.MainClass.pauseApp(!fixedResolutionSysTray.Program.appIsPaused);
        }

        static public void pauseApp(Boolean apply) 
        {
            if (!apply && fixedResolutionSysTray.Properties.Settings.Default.resolutions != "x")
            {
                lockSystrayIcon(false);
                fixedResolutionSysTray.Program.appIsPaused = false;
                fixedResolutionSysTray.Program.changedAllResolutons();
            }
            else
            {
                lockSystrayIcon(true);
                fixedResolutionSysTray.Program.appIsPaused = true;
            }

        }

        static public void lockSystrayIcon(Boolean apply)
        {
            if (apply)
            {
                trayIcon.Icon = new System.Drawing.Icon("screenLockDisabled.ico");
                trayIcon.Text = "Fixed Resolution - Paused";
            }
            else 
            {
                trayIcon.Icon = new System.Drawing.Icon("screenLock.ico");
                trayIcon.Text = "Fixed Resolution";
            }
            trayIcon.Visible = false;
            trayIcon.Visible = true;
       
        }

        void settingsMenuItem_Click(object sender, EventArgs e)
        {
            IntPtr handle = (IntPtr)null;
            if (!MainSettingsForm.isRunning)
            {
                MainSettingsForm set = new MainSettingsForm();
                handle = set.Handle;
                set.ShowDialog();
                MainSettingsForm.isRunning = false;
            }
            else
            {
                SetForegroundWindow(handle);
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        void exitMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();

        }

  

    
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

    }
}

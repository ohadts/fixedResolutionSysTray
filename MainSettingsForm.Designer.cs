namespace fixedResolutionSysTray
{
    partial class MainSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.primRefresh = new System.Windows.Forms.TextBox();
            this.primHeight = new System.Windows.Forms.TextBox();
            this.primWidth = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.devicesCombo = new System.Windows.Forms.ComboBox();
            this.activeChkBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.activeChkBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.primRefresh);
            this.groupBox1.Controls.Add(this.primHeight);
            this.groupBox1.Controls.Add(this.primWidth);
            this.groupBox1.Location = new System.Drawing.Point(11, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screen Config";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Refresh Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width";
            // 
            // primRefresh
            // 
            this.primRefresh.Location = new System.Drawing.Point(214, 74);
            this.primRefresh.Name = "primRefresh";
            this.primRefresh.Size = new System.Drawing.Size(100, 20);
            this.primRefresh.TabIndex = 2;
            // 
            // primHeight
            // 
            this.primHeight.Location = new System.Drawing.Point(214, 48);
            this.primHeight.Name = "primHeight";
            this.primHeight.Size = new System.Drawing.Size(100, 20);
            this.primHeight.TabIndex = 1;
            // 
            // primWidth
            // 
            this.primWidth.Location = new System.Drawing.Point(214, 22);
            this.primWidth.Name = "primWidth";
            this.primWidth.Size = new System.Drawing.Size(100, 20);
            this.primWidth.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(58, 185);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(116, 32);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save and exit";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(200, 185);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(116, 32);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Close without saving";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // devicesCombo
            // 
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(13, 13);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(347, 21);
            this.devicesCombo.TabIndex = 4;
            // 
            // activeChkBox
            // 
            this.activeChkBox.AutoSize = true;
            this.activeChkBox.Location = new System.Drawing.Point(37, 105);
            this.activeChkBox.Name = "activeChkBox";
            this.activeChkBox.Size = new System.Drawing.Size(127, 17);
            this.activeChkBox.TabIndex = 6;
            this.activeChkBox.Text = "Active for this monitor";
            this.activeChkBox.UseVisualStyleBackColor = true;
            // 
            // MainSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 229);
            this.Controls.Add(this.devicesCombo);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainSettingsForm";
            this.Text = "Fixed Resolution";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox primRefresh;
        private System.Windows.Forms.TextBox primHeight;
        private System.Windows.Forms.TextBox primWidth;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox devicesCombo;
        private System.Windows.Forms.CheckBox activeChkBox;
    }
}


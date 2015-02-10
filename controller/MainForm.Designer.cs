using AxDAQDILib;
using AxDAQDOLib;

namespace ConveyorController
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._daqdi1 = new AxDAQDILib.AxDAQDI();
            this._daqdi2 = new AxDAQDILib.AxDAQDI();
            this._daqdo1 = new AxDAQDOLib.AxDAQDO();
            this._daqdo2 = new AxDAQDOLib.AxDAQDO();
            this._group_box_windows = new System.Windows.Forms.GroupBox();
            this._button_allocation = new System.Windows.Forms.Button();
            this._button_console_window = new System.Windows.Forms.Button();
            this._button_conveyor_monitor = new System.Windows.Forms.Button();
            this._button_conveyor_controller = new System.Windows.Forms.Button();
            this._image_rfid = new System.Windows.Forms.PictureBox();
            this._label_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._daqdi1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._daqdi2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._daqdo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._daqdo2)).BeginInit();
            this._group_box_windows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._image_rfid)).BeginInit();
            this.SuspendLayout();
            // 
            // _daqdi1
            // 
            this._daqdi1.Enabled = true;
            this._daqdi1.Location = new System.Drawing.Point(0, 0);
            this._daqdi1.Name = "_daqdi1";
            this._daqdi1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_daqdi1.OcxState")));
            this._daqdi1.Size = new System.Drawing.Size(33, 33);
            this._daqdi1.TabIndex = 0;
            this._daqdi1.Visible = false;
            // 
            // _daqdi2
            // 
            this._daqdi2.Enabled = true;
            this._daqdi2.Location = new System.Drawing.Point(0, 0);
            this._daqdi2.Name = "_daqdi2";
            this._daqdi2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_daqdi2.OcxState")));
            this._daqdi2.Size = new System.Drawing.Size(33, 33);
            this._daqdi2.TabIndex = 1;
            this._daqdi2.Visible = false;
            // 
            // _daqdo1
            // 
            this._daqdo1.Enabled = true;
            this._daqdo1.Location = new System.Drawing.Point(0, 0);
            this._daqdo1.Name = "_daqdo1";
            this._daqdo1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_daqdo1.OcxState")));
            this._daqdo1.Size = new System.Drawing.Size(33, 33);
            this._daqdo1.TabIndex = 2;
            this._daqdo1.Visible = false;
            // 
            // _daqdo2
            // 
            this._daqdo2.Enabled = true;
            this._daqdo2.Location = new System.Drawing.Point(0, 0);
            this._daqdo2.Name = "_daqdo2";
            this._daqdo2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_daqdo2.OcxState")));
            this._daqdo2.Size = new System.Drawing.Size(33, 33);
            this._daqdo2.TabIndex = 3;
            this._daqdo2.Visible = false;
            // 
            // _group_box_windows
            // 
            this._group_box_windows.Controls.Add(this._button_allocation);
            this._group_box_windows.Controls.Add(this._button_console_window);
            this._group_box_windows.Controls.Add(this._button_conveyor_monitor);
            this._group_box_windows.Controls.Add(this._button_conveyor_controller);
            this._group_box_windows.Location = new System.Drawing.Point(12, 42);
            this._group_box_windows.Name = "_group_box_windows";
            this._group_box_windows.Size = new System.Drawing.Size(200, 151);
            this._group_box_windows.TabIndex = 4;
            this._group_box_windows.TabStop = false;
            // 
            // _button_allocation
            // 
            this._button_allocation.Location = new System.Drawing.Point(6, 21);
            this._button_allocation.Name = "_button_allocation";
            this._button_allocation.Size = new System.Drawing.Size(187, 23);
            this._button_allocation.TabIndex = 10;
            this._button_allocation.Text = "Allocation";
            this._button_allocation.UseVisualStyleBackColor = true;
            this._button_allocation.Click += new System.EventHandler(this._button_allocation_Click);
            // 
            // _button_console_window
            // 
            this._button_console_window.Location = new System.Drawing.Point(6, 110);
            this._button_console_window.Name = "_button_console_window";
            this._button_console_window.Size = new System.Drawing.Size(187, 23);
            this._button_console_window.TabIndex = 2;
            this._button_console_window.Text = "Console Window";
            this._button_console_window.UseVisualStyleBackColor = true;
            this._button_console_window.Click += new System.EventHandler(this._button_console_window_Click);
            // 
            // _button_conveyor_monitor
            // 
            this._button_conveyor_monitor.Location = new System.Drawing.Point(6, 81);
            this._button_conveyor_monitor.Name = "_button_conveyor_monitor";
            this._button_conveyor_monitor.Size = new System.Drawing.Size(187, 23);
            this._button_conveyor_monitor.TabIndex = 1;
            this._button_conveyor_monitor.Text = "Conveyor Monitor";
            this._button_conveyor_monitor.UseVisualStyleBackColor = true;
            this._button_conveyor_monitor.Click += new System.EventHandler(this._button_conveyor_monitor_Click);
            // 
            // _button_conveyor_controller
            // 
            this._button_conveyor_controller.Location = new System.Drawing.Point(6, 50);
            this._button_conveyor_controller.Name = "_button_conveyor_controller";
            this._button_conveyor_controller.Size = new System.Drawing.Size(187, 23);
            this._button_conveyor_controller.TabIndex = 0;
            this._button_conveyor_controller.Text = "Conveyor Controller";
            this._button_conveyor_controller.UseVisualStyleBackColor = true;
            this._button_conveyor_controller.Click += new System.EventHandler(this._button_conveyor_controller_Click);
            // 
            // _image_rfid
            // 
            this._image_rfid.Image = global::ConveyorController.Properties.Resources.rfid_icon;
            this._image_rfid.Location = new System.Drawing.Point(252, 12);
            this._image_rfid.Name = "_image_rfid";
            this._image_rfid.Size = new System.Drawing.Size(180, 180);
            this._image_rfid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._image_rfid.TabIndex = 8;
            this._image_rfid.TabStop = false;
            this._image_rfid.Click += new System.EventHandler(this._image_rfid_Click);
            // 
            // _label_title
            // 
            this._label_title.AutoSize = true;
            this._label_title.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._label_title.Location = new System.Drawing.Point(12, 12);
            this._label_title.Name = "_label_title";
            this._label_title.Size = new System.Drawing.Size(234, 24);
            this._label_title.TabIndex = 9;
            this._label_title.Text = "Conveyor Belt System";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 207);
            this.Controls.Add(this._daqdi1);
            this.Controls.Add(this._label_title);
            this.Controls.Add(this._image_rfid);
            this.Controls.Add(this._group_box_windows);
            this.Controls.Add(this._daqdi2);
            this.Controls.Add(this._daqdo1);
            this.Controls.Add(this._daqdo2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Conveyor Controller Server";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._daqdi1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._daqdi2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._daqdo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._daqdo2)).EndInit();
            this._group_box_windows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._image_rfid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public AxDAQDI _daqdi1;
        public AxDAQDI _daqdi2;
        public AxDAQDO _daqdo1;
        public AxDAQDO _daqdo2;
        private System.Windows.Forms.GroupBox _group_box_windows;
        private System.Windows.Forms.Button _button_console_window;
        private System.Windows.Forms.Button _button_conveyor_monitor;
        private System.Windows.Forms.Button _button_conveyor_controller;
        private System.Windows.Forms.PictureBox _image_rfid;
        private System.Windows.Forms.Label _label_title;
        private System.Windows.Forms.Button _button_allocation;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ConveyorController.Properties;

namespace ConveyorController
{
    public partial class MonitorForm : Form
    {
        public const int num = 32;
        public PictureBox[] _image_input;
        public PictureBox[] _image_output;
        public MonitorForm()
        {
            InitializeComponent();
        }

        private void MonitorForm_Load(object sender, EventArgs e)
        {
            _image_input = new PictureBox[num];
            _image_output = new PictureBox[num];
            for (int t = 0; t < num; t++)
            {
                _image_input[t] = (PictureBox)typeof(MonitorForm).GetField(string.Format("_image_input_{0:D2}", t), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
                _image_output[t] = (PictureBox)typeof(MonitorForm).GetField(string.Format("_image_output_{0:D2}", t), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            }
            _timer_update_Tick(null, null);
            _timer_update.Enabled = true;
        }

        private void _timer_update_Tick(object sender, EventArgs e)
        {
            for (int t = 0; t < num; t++)
            {
                _image_input[t].Image = ConveyorBasicController.input[t] ? Resources.blue_lamp : Resources.darkblue_lamp;
                _image_output[t].Image = ConveyorBasicController.output[t] ? Resources.green_lamp : Resources.darkgreen_lamp;
            }
        }
    }
}
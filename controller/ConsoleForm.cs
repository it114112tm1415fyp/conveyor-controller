using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConveyorController
{
    public partial class ConsoleForm : Form
    {
        public ConsoleForm()
        {
            InitializeComponent();
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            Console.SetOut(new TextBoxWriter(_text_box_console_output));
        }

        private void ConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }
        
    }
}
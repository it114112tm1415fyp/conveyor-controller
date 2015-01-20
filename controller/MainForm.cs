using System;
using System.Windows.Forms;
using System.Threading;

namespace ConveyorController
{

    public partial class MainForm : Form
    {

        public ConsoleForm consoleForm;
        public ControllerForm controllerForm;
        public MonitorForm monitorForm;

        public MainForm()
        {
            InitializeComponent();
            consoleForm = new ConsoleForm();
            consoleForm.Show();
            consoleForm.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Server.init();
            ConveyorBasicController.init(this);
            ConveyorCleverController.init();
            RfidBasicController.init();
            RfidCleverController.init();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConveyorBasicController.stop();
        }

        private void _button_conveyor_controller_Click(object sender, EventArgs e)
        {
            if (controllerForm == null || controllerForm.IsDisposed)
            {
                controllerForm = new ControllerForm();
                controllerForm.Show();
            }
            else
                controllerForm.Focus();
        }

        private void _button_conveyor_monitor_Click(object sender, EventArgs e)
        {
            if (monitorForm == null || monitorForm.IsDisposed)
            {
                monitorForm = new MonitorForm();
                monitorForm.Show();
            }
            else
                monitorForm.Focus();
        }

        private void _button_console_window_Click(object sender, EventArgs e)
        {
            consoleForm.Show();
            consoleForm.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ArtificialIntelligence.start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArtificialIntelligence.stop();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine();
        }

    }

}
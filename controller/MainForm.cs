using System;
using System.Windows.Forms;
using System.Threading;

namespace ConveyorController
{

    public partial class MainForm : Form
    {

        public ArtificialIntelligenceForm artificialIntelligenceForm;
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
            ArtificialIntelligence.init();
            ConveyorBasicController.init(this);
            ConveyorCleverController.init();
            RfidBasicController.init();
            RfidCleverController.init();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConveyorBasicController.stop();
        }

        private void _button_allocation_Click(object sender, EventArgs e)
        {
            if (artificialIntelligenceForm == null || artificialIntelligenceForm.IsDisposed)
            {
                artificialIntelligenceForm = new ArtificialIntelligenceForm();
                artificialIntelligenceForm.Show();
            }
            else
                artificialIntelligenceForm.Focus();
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

    }

}
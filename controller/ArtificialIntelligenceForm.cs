using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConveyorController
{
    public partial class ArtificialIntelligenceForm : Form
    {
        public ArtificialIntelligenceForm()
        {
            InitializeComponent();
        }

        private void ArtificialIntelligenceForm_Load(object sender, EventArgs e)
        {
            _timer_update.Enabled = true;
        }

        private void _button_start_Click(object sender, EventArgs e)
        {
            ArtificialIntelligence.start();
        }

        private void _button_stop_Click(object sender, EventArgs e)
        {
            ArtificialIntelligence.stop();
        }

        private void _timer_update_Tick(object sender, EventArgs e)
        {
            _button_start.Enabled = !ArtificialIntelligence.running;
            _button_stop.Enabled = ArtificialIntelligence.running;
            _list_goods_on_conveyor.BeginUpdate();
            _list_goods_on_conveyor.Items.Clear();
            foreach (GoodOnConveyor x in ArtificialIntelligence.Goods)
            {
                ListViewItem item = new ListViewItem();
                item.Text = x.rfid_tag;
                item.SubItems.Add(x.position.ToString());
                item.Tag = x;
                _list_goods_on_conveyor.Items.Add(item);
            }
            _list_goods_on_conveyor.EndUpdate();
        }
    }
}
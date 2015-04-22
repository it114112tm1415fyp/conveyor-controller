using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConveyorController
{
    public partial class AllocationForm : Form
    {

        delegate void AddItemToListViewGoodsAllocation(ListViewItem item);
        delegate void AddItemToListViewGoodsOnConveyor(ListViewItem item);
        delegate void AutoChangeDisplayGood(Good good);
        delegate void RemoveGoodFromListViewGoodsOnConveyor(GoodOnConveyor good);

        public AllocationForm()
        {
            InitializeComponent();
        }

        private void AllocationForm_Load(object sender, EventArgs e)
        {
            _timer_update.Enabled = true;
            _list_view_goods_on_conveyor.BeginUpdate();
            foreach (GoodOnConveyor x in ArtificialIntelligence.Goods)
            {
                ListViewItem item = new ListViewItem();
                item.Text = x.rfidTag != null ? x.rfidTag : "---- ---- ---- ---- ---- ----";
                item.SubItems.Add(x.position.ToString());
                item.Tag = x;
                _list_view_goods_on_conveyor.Items.Add(item);
            }
            _list_view_goods_on_conveyor.EndUpdate();
            _list_view_goods_allocation.BeginUpdate();
            Good? displayingGood = null;
            foreach (Good x in Allocation.GoodDetails.Values)
            {
                ListViewItem item = new ListViewItem();
                item.Text = x.id.ToString();
                item.SubItems.Add(x.rfid_tag);
                item.SubItems.Add(x.store.ToString());
                item.Tag = x;
                _list_view_goods_allocation.Items.Add(item);
                displayingGood = x;
            }
            _list_view_goods_allocation.EndUpdate();
            displayGood(displayingGood);
        }

        private void _button_start_Click(object sender, EventArgs e)
        {
            _list_view_goods_on_conveyor.Items.Clear();
            _list_view_goods_allocation.Items.Clear();
            Allocation.onDetectNewGood = onDetectNewGood;
            Allocation.onReceiveGoodDetails = onReceiveGoodDetails;
            Allocation.onReceiveErrorMessage = onReceiveErrorMessage;
            ArtificialIntelligence.start(Allocation.instance);
        }

        private void _button_stop_Click(object sender, EventArgs e)
        {
            ArtificialIntelligence.stop();
        }

        private void _list_view_goods_allocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_list_view_goods_allocation.SelectedItems.Count != 0)
                displayGood((Good)_list_view_goods_allocation.SelectedItems[0].Tag);
            else
                displayGood(null);
        }

        private void _timer_update_Tick(object sender, EventArgs e)
        {
            _button_start.Enabled = !ArtificialIntelligence.running;
            _button_stop.Enabled = ArtificialIntelligence.running && !ArtificialIntelligence.stopWhenNoTask;
            _label_task_value.Text = ArtificialIntelligence.taskCount.ToString();
            List<ListViewItem> itemNeedToRemove = new List<ListViewItem>();
            _list_view_goods_on_conveyor.BeginUpdate();
            foreach (ListViewItem x in _list_view_goods_on_conveyor.Items)
            {
                GoodOnConveyor good = (GoodOnConveyor)x.Tag;
                x.SubItems[0].Text = good.rfidTag != null ? good.rfidTag : "---- ---- ---- ---- ---- ----";
                x.SubItems[1].Text = ((GoodOnConveyor)x.Tag).position.ToString();
                if (good.left)
                    itemNeedToRemove.Add(x);
            }
            foreach (ListViewItem x in itemNeedToRemove)
                _list_view_goods_on_conveyor.Items.Remove(x);
            _list_view_goods_on_conveyor.EndUpdate();
        }

        public void try_auto_start()
        {
            if (!ArtificialIntelligence.running)
                _button_start_Click(null, null);
        }

        public void try_auto_stop()
        {
            if (ArtificialIntelligence.running)
                _button_stop_Click(null, null);
        }

        public void onDetectNewGood(GoodOnConveyor good)
        {
            ListViewItem item = new ListViewItem();
            item.Text = "---- ---- ---- ---- ---- ----";
            item.SubItems.Add("0");
            item.Tag = good;
            _list_view_goods_on_conveyor.Invoke(new AddItemToListViewGoodsOnConveyor(addItemToListViewGoodsOnConveyor), item);
        }

        public void onReceiveGoodDetails(Good good, HandleMethod handleMethod)
        {
            ListViewItem item = new ListViewItem();
            item.Text = good.id.ToString();
            item.SubItems.Add(good.rfid_tag);
            item.SubItems.Add(handleMethod.exitPoint.ToString());
            item.Tag = good;
            _list_view_goods_allocation.Invoke(new AddItemToListViewGoodsAllocation(addItemToListViewGoodsAllocation), item);
            Invoke(new AutoChangeDisplayGood(autoChangeDisplayGood), good);
        }

        public void onReceiveErrorMessage(string reason)
        {
            MessageBox.Show(this, reason);
        }

        public void addItemToListViewGoodsAllocation(ListViewItem item)
        {
            _list_view_goods_allocation.Items.Add(item);
        }

        public void addItemToListViewGoodsOnConveyor(ListViewItem item)
        {
            _list_view_goods_on_conveyor.Items.Add(item);
        }

        public void autoChangeDisplayGood(Good good)
        {
            if (_list_view_goods_allocation.SelectedItems.Count == 0)
            {
                displayGood(good);
            }
        }

        void displayGood(Good? displayingGood)
        {
            if (displayingGood.HasValue)
            {
                Good good = displayingGood.Value;
                _label_departure_value.Text = good.departure;
                _label_destination_value.Text = good.destination;
                _label_flammable_value.Text = good.flammable.ToString();
                _label_fragile_value.Text = good.fragile.ToString();
                _label_goods_id_value.Text = good.id;
                _label_order_id_value.Text = good.order_id.ToString();
                _label_order_time_value.Text = good.created_at.ToString();
                _label_rfid_value.Text = good.rfid_tag;
                _label_weight_value.Text = good.weight.ToString();
            }
            else
            {
                _label_departure_value.Text = "";
                _label_destination_value.Text = "";
                _label_flammable_value.Text = "";
                _label_fragile_value.Text = "";
                _label_goods_id_value.Text = "";
                _label_order_id_value.Text = "";
                _label_order_time_value.Text = "";
                _label_rfid_value.Text = "";
                _label_weight_value.Text = "";
            }
        }
    }
}
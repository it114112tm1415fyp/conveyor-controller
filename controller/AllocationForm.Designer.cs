namespace ConveyorController
{
    partial class AllocationForm
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
            this.components = new System.ComponentModel.Container();
            this._list_view_goods_allocation = new System.Windows.Forms.ListView();
            this._list_view_goods_allocation_column_goods_id = new System.Windows.Forms.ColumnHeader();
            this._list_view_goods_allocation_column_rfid = new System.Windows.Forms.ColumnHeader();
            this._list_view_goods_allocation_column_gate = new System.Windows.Forms.ColumnHeader();
            this._list_view_goods_on_conveyor = new System.Windows.Forms.ListView();
            this._list_view_goods_on_conveyor_column_rfid = new System.Windows.Forms.ColumnHeader();
            this._list_view_goods_on_conveyor_column_position = new System.Windows.Forms.ColumnHeader();
            this._group_box_goods_on_conveyor = new System.Windows.Forms.GroupBox();
            this._group_box_goods_information = new System.Windows.Forms.GroupBox();
            this._label_order_time_value = new System.Windows.Forms.Label();
            this._label_destination_value = new System.Windows.Forms.Label();
            this._label_departure_value = new System.Windows.Forms.Label();
            this._label_flammable_value = new System.Windows.Forms.Label();
            this._label_fragile_value = new System.Windows.Forms.Label();
            this._label_weight_value = new System.Windows.Forms.Label();
            this._label_rfid_value = new System.Windows.Forms.Label();
            this._label_order_id_value = new System.Windows.Forms.Label();
            this._label_goods_id_value = new System.Windows.Forms.Label();
            this._label_order_time = new System.Windows.Forms.Label();
            this._label_destination = new System.Windows.Forms.Label();
            this._label_departure = new System.Windows.Forms.Label();
            this._label_flammable = new System.Windows.Forms.Label();
            this._label_fragile = new System.Windows.Forms.Label();
            this._label_weight = new System.Windows.Forms.Label();
            this._label_rfid = new System.Windows.Forms.Label();
            this._label_order_id = new System.Windows.Forms.Label();
            this._label_goods_id = new System.Windows.Forms.Label();
            this._button_start = new System.Windows.Forms.Button();
            this._button_stop = new System.Windows.Forms.Button();
            this._timer_update = new System.Windows.Forms.Timer(this.components);
            this._label_task = new System.Windows.Forms.Label();
            this._label_task_value = new System.Windows.Forms.Label();
            this._group_box_goods_on_conveyor.SuspendLayout();
            this._group_box_goods_information.SuspendLayout();
            this.SuspendLayout();
            // 
            // _list_view_goods_allocation
            // 
            this._list_view_goods_allocation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._list_view_goods_allocation_column_goods_id,
            this._list_view_goods_allocation_column_rfid,
            this._list_view_goods_allocation_column_gate});
            this._list_view_goods_allocation.FullRowSelect = true;
            this._list_view_goods_allocation.LabelWrap = false;
            this._list_view_goods_allocation.Location = new System.Drawing.Point(204, 339);
            this._list_view_goods_allocation.MultiSelect = false;
            this._list_view_goods_allocation.Name = "_list_view_goods_allocation";
            this._list_view_goods_allocation.Size = new System.Drawing.Size(363, 166);
            this._list_view_goods_allocation.TabIndex = 2;
            this._list_view_goods_allocation.UseCompatibleStateImageBehavior = false;
            this._list_view_goods_allocation.View = System.Windows.Forms.View.Details;
            this._list_view_goods_allocation.SelectedIndexChanged += new System.EventHandler(this._list_view_goods_allocation_SelectedIndexChanged);
            // 
            // _list_view_goods_allocation_column_goods_id
            // 
            this._list_view_goods_allocation_column_goods_id.Text = "ID";
            // 
            // _list_view_goods_allocation_column_rfid
            // 
            this._list_view_goods_allocation_column_rfid.Text = "RFID";
            this._list_view_goods_allocation_column_rfid.Width = 200;
            // 
            // _list_view_goods_allocation_column_gate
            // 
            this._list_view_goods_allocation_column_gate.Text = "Gate of Allocaton";
            this._list_view_goods_allocation_column_gate.Width = 99;
            // 
            // _list_view_goods_on_conveyor
            // 
            this._list_view_goods_on_conveyor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._list_view_goods_on_conveyor_column_rfid,
            this._list_view_goods_on_conveyor_column_position});
            this._list_view_goods_on_conveyor.Cursor = System.Windows.Forms.Cursors.Cross;
            this._list_view_goods_on_conveyor.Enabled = false;
            this._list_view_goods_on_conveyor.FullRowSelect = true;
            this._list_view_goods_on_conveyor.Location = new System.Drawing.Point(6, 21);
            this._list_view_goods_on_conveyor.Name = "_list_view_goods_on_conveyor";
            this._list_view_goods_on_conveyor.Size = new System.Drawing.Size(264, 294);
            this._list_view_goods_on_conveyor.TabIndex = 3;
            this._list_view_goods_on_conveyor.UseCompatibleStateImageBehavior = false;
            this._list_view_goods_on_conveyor.View = System.Windows.Forms.View.Details;
            // 
            // _list_view_goods_on_conveyor_column_rfid
            // 
            this._list_view_goods_on_conveyor_column_rfid.Text = "RFID";
            this._list_view_goods_on_conveyor_column_rfid.Width = 200;
            // 
            // _list_view_goods_on_conveyor_column_position
            // 
            this._list_view_goods_on_conveyor_column_position.Text = "Position";
            // 
            // _group_box_goods_on_conveyor
            // 
            this._group_box_goods_on_conveyor.Controls.Add(this._list_view_goods_on_conveyor);
            this._group_box_goods_on_conveyor.Location = new System.Drawing.Point(289, 12);
            this._group_box_goods_on_conveyor.Name = "_group_box_goods_on_conveyor";
            this._group_box_goods_on_conveyor.Size = new System.Drawing.Size(278, 321);
            this._group_box_goods_on_conveyor.TabIndex = 4;
            this._group_box_goods_on_conveyor.TabStop = false;
            this._group_box_goods_on_conveyor.Text = "Goods on Conveyor";
            // 
            // _group_box_goods_information
            // 
            this._group_box_goods_information.Controls.Add(this._label_order_time_value);
            this._group_box_goods_information.Controls.Add(this._label_destination_value);
            this._group_box_goods_information.Controls.Add(this._label_departure_value);
            this._group_box_goods_information.Controls.Add(this._label_flammable_value);
            this._group_box_goods_information.Controls.Add(this._label_fragile_value);
            this._group_box_goods_information.Controls.Add(this._label_weight_value);
            this._group_box_goods_information.Controls.Add(this._label_rfid_value);
            this._group_box_goods_information.Controls.Add(this._label_order_id_value);
            this._group_box_goods_information.Controls.Add(this._label_goods_id_value);
            this._group_box_goods_information.Controls.Add(this._label_order_time);
            this._group_box_goods_information.Controls.Add(this._label_destination);
            this._group_box_goods_information.Controls.Add(this._label_departure);
            this._group_box_goods_information.Controls.Add(this._label_flammable);
            this._group_box_goods_information.Controls.Add(this._label_fragile);
            this._group_box_goods_information.Controls.Add(this._label_weight);
            this._group_box_goods_information.Controls.Add(this._label_rfid);
            this._group_box_goods_information.Controls.Add(this._label_order_id);
            this._group_box_goods_information.Controls.Add(this._label_goods_id);
            this._group_box_goods_information.Location = new System.Drawing.Point(12, 12);
            this._group_box_goods_information.Name = "_group_box_goods_information";
            this._group_box_goods_information.Size = new System.Drawing.Size(271, 321);
            this._group_box_goods_information.TabIndex = 5;
            this._group_box_goods_information.TabStop = false;
            this._group_box_goods_information.Text = "Goods information";
            // 
            // _label_order_time_value
            // 
            this._label_order_time_value.AutoSize = true;
            this._label_order_time_value.Location = new System.Drawing.Point(85, 165);
            this._label_order_time_value.Name = "_label_order_time_value";
            this._label_order_time_value.Size = new System.Drawing.Size(15, 12);
            this._label_order_time_value.TabIndex = 17;
            this._label_order_time_value.Text = "??";
            // 
            // _label_destination_value
            // 
            this._label_destination_value.Location = new System.Drawing.Point(85, 253);
            this._label_destination_value.Name = "_label_destination_value";
            this._label_destination_value.Size = new System.Drawing.Size(180, 52);
            this._label_destination_value.TabIndex = 16;
            this._label_destination_value.Text = "??";
            this._label_destination_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label_departure_value
            // 
            this._label_departure_value.Location = new System.Drawing.Point(85, 189);
            this._label_departure_value.Name = "_label_departure_value";
            this._label_departure_value.Size = new System.Drawing.Size(180, 52);
            this._label_departure_value.TabIndex = 15;
            this._label_departure_value.Text = "??";
            this._label_departure_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label_flammable_value
            // 
            this._label_flammable_value.AutoSize = true;
            this._label_flammable_value.Location = new System.Drawing.Point(85, 141);
            this._label_flammable_value.Name = "_label_flammable_value";
            this._label_flammable_value.Size = new System.Drawing.Size(15, 12);
            this._label_flammable_value.TabIndex = 14;
            this._label_flammable_value.Text = "??";
            // 
            // _label_fragile_value
            // 
            this._label_fragile_value.AutoSize = true;
            this._label_fragile_value.Location = new System.Drawing.Point(85, 117);
            this._label_fragile_value.Name = "_label_fragile_value";
            this._label_fragile_value.Size = new System.Drawing.Size(15, 12);
            this._label_fragile_value.TabIndex = 13;
            this._label_fragile_value.Text = "??";
            // 
            // _label_weight_value
            // 
            this._label_weight_value.AutoSize = true;
            this._label_weight_value.Location = new System.Drawing.Point(85, 93);
            this._label_weight_value.Name = "_label_weight_value";
            this._label_weight_value.Size = new System.Drawing.Size(15, 12);
            this._label_weight_value.TabIndex = 12;
            this._label_weight_value.Text = "??";
            // 
            // _label_rfid_value
            // 
            this._label_rfid_value.AutoSize = true;
            this._label_rfid_value.Location = new System.Drawing.Point(85, 69);
            this._label_rfid_value.Name = "_label_rfid_value";
            this._label_rfid_value.Size = new System.Drawing.Size(15, 12);
            this._label_rfid_value.TabIndex = 11;
            this._label_rfid_value.Text = "??";
            // 
            // _label_order_id_value
            // 
            this._label_order_id_value.AutoSize = true;
            this._label_order_id_value.Location = new System.Drawing.Point(85, 45);
            this._label_order_id_value.Name = "_label_order_id_value";
            this._label_order_id_value.Size = new System.Drawing.Size(15, 12);
            this._label_order_id_value.TabIndex = 10;
            this._label_order_id_value.Text = "??";
            // 
            // _label_goods_id_value
            // 
            this._label_goods_id_value.AutoSize = true;
            this._label_goods_id_value.Location = new System.Drawing.Point(85, 21);
            this._label_goods_id_value.Name = "_label_goods_id_value";
            this._label_goods_id_value.Size = new System.Drawing.Size(15, 12);
            this._label_goods_id_value.TabIndex = 9;
            this._label_goods_id_value.Text = "??";
            // 
            // _label_order_time
            // 
            this._label_order_time.AutoSize = true;
            this._label_order_time.Location = new System.Drawing.Point(6, 165);
            this._label_order_time.Name = "_label_order_time";
            this._label_order_time.Size = new System.Drawing.Size(59, 12);
            this._label_order_time.TabIndex = 8;
            this._label_order_time.Text = "Order Time";
            // 
            // _label_destination
            // 
            this._label_destination.AutoSize = true;
            this._label_destination.Location = new System.Drawing.Point(6, 273);
            this._label_destination.Name = "_label_destination";
            this._label_destination.Size = new System.Drawing.Size(57, 12);
            this._label_destination.TabIndex = 7;
            this._label_destination.Text = "Destination";
            // 
            // _label_departure
            // 
            this._label_departure.AutoSize = true;
            this._label_departure.Location = new System.Drawing.Point(6, 209);
            this._label_departure.Name = "_label_departure";
            this._label_departure.Size = new System.Drawing.Size(51, 12);
            this._label_departure.TabIndex = 6;
            this._label_departure.Text = "Departure";
            // 
            // _label_flammable
            // 
            this._label_flammable.AutoSize = true;
            this._label_flammable.Location = new System.Drawing.Point(6, 141);
            this._label_flammable.Name = "_label_flammable";
            this._label_flammable.Size = new System.Drawing.Size(56, 12);
            this._label_flammable.TabIndex = 5;
            this._label_flammable.Text = "Flammable";
            // 
            // _label_fragile
            // 
            this._label_fragile.AutoSize = true;
            this._label_fragile.Location = new System.Drawing.Point(6, 117);
            this._label_fragile.Name = "_label_fragile";
            this._label_fragile.Size = new System.Drawing.Size(37, 12);
            this._label_fragile.TabIndex = 4;
            this._label_fragile.Text = "Fragile";
            // 
            // _label_weight
            // 
            this._label_weight.AutoSize = true;
            this._label_weight.Location = new System.Drawing.Point(6, 93);
            this._label_weight.Name = "_label_weight";
            this._label_weight.Size = new System.Drawing.Size(39, 12);
            this._label_weight.TabIndex = 3;
            this._label_weight.Text = "Weight";
            // 
            // _label_rfid
            // 
            this._label_rfid.AutoSize = true;
            this._label_rfid.Location = new System.Drawing.Point(6, 69);
            this._label_rfid.Name = "_label_rfid";
            this._label_rfid.Size = new System.Drawing.Size(31, 12);
            this._label_rfid.TabIndex = 2;
            this._label_rfid.Text = "RFID";
            // 
            // _label_order_id
            // 
            this._label_order_id.AutoSize = true;
            this._label_order_id.Location = new System.Drawing.Point(6, 45);
            this._label_order_id.Name = "_label_order_id";
            this._label_order_id.Size = new System.Drawing.Size(47, 12);
            this._label_order_id.TabIndex = 1;
            this._label_order_id.Text = "Order ID";
            // 
            // _label_goods_id
            // 
            this._label_goods_id.AutoSize = true;
            this._label_goods_id.Location = new System.Drawing.Point(6, 21);
            this._label_goods_id.Name = "_label_goods_id";
            this._label_goods_id.Size = new System.Drawing.Size(50, 12);
            this._label_goods_id.TabIndex = 0;
            this._label_goods_id.Text = "Goods ID";
            // 
            // _button_start
            // 
            this._button_start.Location = new System.Drawing.Point(64, 388);
            this._button_start.Name = "_button_start";
            this._button_start.Size = new System.Drawing.Size(75, 23);
            this._button_start.TabIndex = 6;
            this._button_start.Text = "Start";
            this._button_start.UseVisualStyleBackColor = true;
            this._button_start.Click += new System.EventHandler(this._button_start_Click);
            // 
            // _button_stop
            // 
            this._button_stop.Location = new System.Drawing.Point(64, 429);
            this._button_stop.Name = "_button_stop";
            this._button_stop.Size = new System.Drawing.Size(75, 23);
            this._button_stop.TabIndex = 7;
            this._button_stop.Text = "Stop";
            this._button_stop.UseVisualStyleBackColor = true;
            this._button_stop.Click += new System.EventHandler(this._button_stop_Click);
            // 
            // _timer_update
            // 
            this._timer_update.Tick += new System.EventHandler(this._timer_update_Tick);
            // 
            // _label_task
            // 
            this._label_task.AutoSize = true;
            this._label_task.Location = new System.Drawing.Point(10, 493);
            this._label_task.Name = "_label_task";
            this._label_task.Size = new System.Drawing.Size(27, 12);
            this._label_task.TabIndex = 8;
            this._label_task.Text = "Task";
            // 
            // _label_task_value
            // 
            this._label_task_value.AutoSize = true;
            this._label_task_value.Location = new System.Drawing.Point(43, 493);
            this._label_task_value.Name = "_label_task_value";
            this._label_task_value.Size = new System.Drawing.Size(11, 12);
            this._label_task_value.TabIndex = 9;
            this._label_task_value.Text = "0";
            // 
            // AllocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 517);
            this.Controls.Add(this._label_task_value);
            this.Controls.Add(this._label_task);
            this.Controls.Add(this._button_stop);
            this.Controls.Add(this._button_start);
            this.Controls.Add(this._group_box_goods_information);
            this.Controls.Add(this._group_box_goods_on_conveyor);
            this.Controls.Add(this._list_view_goods_allocation);
            this.Name = "AllocationForm";
            this.Text = "Allocation";
            this.Load += new System.EventHandler(this.ArtificialIntelligenceForm_Load);
            this._group_box_goods_on_conveyor.ResumeLayout(false);
            this._group_box_goods_information.ResumeLayout(false);
            this._group_box_goods_information.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _list_view_goods_allocation;
        private System.Windows.Forms.ListView _list_view_goods_on_conveyor;
        private System.Windows.Forms.ColumnHeader _list_view_goods_on_conveyor_column_rfid;
        private System.Windows.Forms.ColumnHeader _list_view_goods_on_conveyor_column_position;
        private System.Windows.Forms.ColumnHeader _list_view_goods_allocation_column_rfid;
        private System.Windows.Forms.ColumnHeader _list_view_goods_allocation_column_goods_id;
        private System.Windows.Forms.ColumnHeader _list_view_goods_allocation_column_gate;
        private System.Windows.Forms.GroupBox _group_box_goods_on_conveyor;
        private System.Windows.Forms.GroupBox _group_box_goods_information;
        private System.Windows.Forms.Label _label_destination;
        private System.Windows.Forms.Label _label_departure;
        private System.Windows.Forms.Label _label_flammable;
        private System.Windows.Forms.Label _label_fragile;
        private System.Windows.Forms.Label _label_weight;
        private System.Windows.Forms.Label _label_rfid;
        private System.Windows.Forms.Label _label_order_id;
        private System.Windows.Forms.Label _label_goods_id;
        private System.Windows.Forms.Button _button_start;
        private System.Windows.Forms.Button _button_stop;
        private System.Windows.Forms.Label _label_order_time;
        private System.Windows.Forms.Label _label_order_time_value;
        private System.Windows.Forms.Label _label_destination_value;
        private System.Windows.Forms.Label _label_departure_value;
        private System.Windows.Forms.Label _label_flammable_value;
        private System.Windows.Forms.Label _label_fragile_value;
        private System.Windows.Forms.Label _label_weight_value;
        private System.Windows.Forms.Label _label_rfid_value;
        private System.Windows.Forms.Label _label_order_id_value;
        private System.Windows.Forms.Label _label_goods_id_value;
        private System.Windows.Forms.Timer _timer_update;
        private System.Windows.Forms.Label _label_task;
        private System.Windows.Forms.Label _label_task_value;
    }
}
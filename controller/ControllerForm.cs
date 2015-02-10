using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConveyorController
{
    public partial class ControllerForm : Form
    {

        enum ChButtomType
        {
            Stop,
            Forward,
            Backward,
            Up
        }

        enum CrButtomType
        {
            Stop,
            Forward,
            Backward
        }

        enum MRButtomType
        {
            Stop,
            Clockwise,
            Anticlockwise
        }

        Dictionary<MRButtomType, Button> mrButton = new Dictionary<MRButtomType,Button>();
        List<Button> stButton = new List<Button>();
        List<Dictionary<ChButtomType, Button>> chButton = new List<Dictionary<ChButtomType,Button>>();
        List<Dictionary<CrButtomType, Button>> crButton = new List<Dictionary<CrButtomType,Button>>();

        public ControllerForm()
        {
            InitializeComponent();
        }

        private void ControllerForm_Load(object sender, EventArgs e)
        {
            mrButton[MRButtomType.Clockwise] = (Button)typeof(ControllerForm).GetField("_button_mr_clockwise", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            mrButton[MRButtomType.Anticlockwise] = (Button)typeof(ControllerForm).GetField("_button_mr_anticlockwise", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            mrButton[MRButtomType.Stop] = (Button)typeof(ControllerForm).GetField("_button_mr_stop", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            for (int t = 0; t < ConveyorBasicController.ChNum; t++)
            {
                chButton.Add(new Dictionary<ChButtomType, Button>());
                chButton[t].Add(ChButtomType.Forward, (Button)typeof(ControllerForm).GetField(string.Format("_button_ch{0}_forward", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
                chButton[t].Add(ChButtomType.Backward, (Button)typeof(ControllerForm).GetField(string.Format("_button_ch{0}_backward", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
                chButton[t].Add(ChButtomType.Stop , (Button)typeof(ControllerForm).GetField(string.Format("_button_ch{0}_stop", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
                chButton[t].Add(ChButtomType.Up , (Button)typeof(ControllerForm).GetField(string.Format("_button_ch{0}_updown", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
            }
            for (int t = 0; t < ConveyorBasicController.CrNum; t++)
            {
                crButton.Add(new Dictionary<CrButtomType, Button>());
                crButton[t].Add(CrButtomType.Forward, (Button)typeof(ControllerForm).GetField(string.Format("_button_cr{0}_forward", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
                crButton[t].Add(CrButtomType.Backward , (Button)typeof(ControllerForm).GetField(string.Format("_button_cr{0}_backward", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
                crButton[t].Add(CrButtomType.Stop , (Button)typeof(ControllerForm).GetField(string.Format("_button_cr{0}_stop", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
            }
            for (int t = 0; t < ConveyorBasicController.StNum; t++)
                stButton.Add((Button)typeof(ControllerForm).GetField(string.Format("_button_st{0}_updown", t + 1), BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
            _timer_update_Tick(null, null);
            _timer_update.Enabled = true;
        }

        private void _button_st_updown_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.stC(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_ch_updown_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.chC(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_ch_forward_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.chF(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_ch_backward_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.chB(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_ch_stop_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.chS(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_cr_forward_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.crF(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_cr_backward_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.crB(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_cr_stop_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.crS(Convert.ToInt32(new Regex(@"\d+").Match(((Button)sender).Name).ToString()) - 1);
        }

        private void _button_mr_clockwise_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.mrC(1);
        }

        private void _button_mr_anticlockwise_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.mrA(1);
        }

        private void _button_mr_stop_Click(object sender, EventArgs e)
        {
            ConveyorBasicController.mrS(1);
        }

        private void _timer_update_Tick(object sender, EventArgs e)
        {
            bool enabled = !ConveyorBasicController.output[(int)ConveyorOutputDevice.EmergencyStop] && !ArtificialIntelligence.running;
            foreach (Button x in mrButton.Values)
            {
                x.Enabled = enabled;
                x.BackColor = SystemColors.Control;
            }
            foreach (Dictionary<ChButtomType, Button> x1 in chButton)
            {
                foreach (Button x2 in x1.Values)
                {
                    x2.Enabled = enabled;
                    x2.BackColor = SystemColors.Control;
                }
            }
            foreach (Dictionary<CrButtomType, Button> x1 in crButton)
            {
                foreach (Button x2 in x1.Values)
                {
                    x2.Enabled = enabled;
                    x2.BackColor = SystemColors.Control;
                }
            }
            foreach (Button x in stButton)
            {
                x.Enabled = enabled;
                x.BackColor = SystemColors.Control;
            }
            mrButton[(MRButtomType)ConveyorBasicController.mrState].BackColor = Color.DodgerBlue;
            for (int t = 0; t < ConveyorBasicController.ChNum; t++)
            {
                chButton[t][(ChButtomType)((int)ConveyorBasicController.ChStatus[t] >> 1)].BackColor = Color.DodgerBlue;
                chButton[t][ChButtomType.Up].BackColor = (ConveyorBasicController.ChStatus[t] & ConveyorChState.Up) == ConveyorChState.Up ? Color.DodgerBlue : SystemColors.Control;
            }
            for (int t = 0; t < ConveyorBasicController.CrNum; t++)
            {
                crButton[t][(CrButtomType)ConveyorBasicController.CrStatus[t]].BackColor = Color.DodgerBlue;
            }
            for (int t = 0; t < ConveyorBasicController.StNum; t++)
            {
                stButton[t].BackColor = ConveyorBasicController.StStatus[t] == ConveyorStState.Up ? Color.DodgerBlue : SystemColors.Control;
            }
        }
    }
}
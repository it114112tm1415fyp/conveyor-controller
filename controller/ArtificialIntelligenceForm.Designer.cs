namespace ConveyorController
{
    partial class ArtificialIntelligenceForm
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
            this._listBox_Good_Detail = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _listBox_Good_Detail
            // 
            this._listBox_Good_Detail.FormattingEnabled = true;
            this._listBox_Good_Detail.ItemHeight = 12;
            this._listBox_Good_Detail.Location = new System.Drawing.Point(12, 12);
            this._listBox_Good_Detail.Name = "_listBox_Good_Detail";
            this._listBox_Good_Detail.Size = new System.Drawing.Size(246, 424);
            this._listBox_Good_Detail.TabIndex = 0;
            // 
            // ArtificialIntelligenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 449);
            this.Controls.Add(this._listBox_Good_Detail);
            this.Name = "ArtificialIntelligenceForm";
            this.Text = "ArtificialIntelligenceForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _listBox_Good_Detail;
    }
}
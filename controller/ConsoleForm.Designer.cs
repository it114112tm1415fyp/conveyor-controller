namespace ConveyorController
{
    partial class ConsoleForm
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
            this._text_box_console_output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _text_box_console_output
            // 
            this._text_box_console_output.Location = new System.Drawing.Point(13, 13);
            this._text_box_console_output.MaxLength = 2147483647;
            this._text_box_console_output.Multiline = true;
            this._text_box_console_output.Name = "_text_box_console_output";
            this._text_box_console_output.ReadOnly = true;
            this._text_box_console_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._text_box_console_output.Size = new System.Drawing.Size(567, 268);
            this._text_box_console_output.TabIndex = 0;
            // 
            // ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 293);
            this.Controls.Add(this._text_box_console_output);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 320);
            this.Name = "ConsoleForm";
            this.Text = "ConsoleForm";
            this.Load += new System.EventHandler(this.ConsoleForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsoleForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _text_box_console_output;
    }
}
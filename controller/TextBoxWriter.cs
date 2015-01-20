using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConveyorController {

	class TextBoxWriter : TextWriter {

        TextBox consoleOutput;

		public override Encoding Encoding {
			get {
				return Encoding.UTF8;
			}
		}

		public TextBoxWriter(TextBox consoleOutput) {
            this.consoleOutput = consoleOutput;
        }

        public override void Write(char value)
        {
            try
            {
                consoleOutput.Invoke(new Action<string>(consoleOutput.AppendText), value.ToString());
            }
            catch
            {
            }
        }

    }

}

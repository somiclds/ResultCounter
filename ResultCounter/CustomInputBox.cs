using System;
using System.Windows.Forms;

namespace ResultCounter
{
    public partial class CustomInputBox : Form
    {
        public CustomInputBox()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
        }

        public CustomInputBox(String headerText, String labelText) : this()
        {
            this.Text = headerText;
            this.labelText.Text = labelText;
        }

        public CustomInputBox(String headerText, String labelText, String textBoxText) : this(headerText, labelText)
        {
            textBox1.Text = textBoxText;
        }

        public string returnValue { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.returnValue = textBox1.Text;
            this.Close();
        }
    }
}

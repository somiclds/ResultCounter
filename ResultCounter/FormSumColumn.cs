using System;
using System.Windows.Forms;

namespace ResultCounter
{
    public partial class FormSumColumn : Form
    {
        private ListView.ListViewItemCollection columns;
        public ListViewItem SumColumn { get; private set;}

        public FormSumColumn(ListView.ListViewItemCollection _columns)
        {
            InitializeComponent();
            foreach (ListViewItem item in _columns)
            {
                checkedListBoxColumns.Items.Add(item.Text);
            }
            columns = _columns;
        }

        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            if (checkedListBoxColumns.CheckedItems.Count >= 2)
            {
                if (!textBoxColumnName.Text.Equals(""))
                {
                    // get type of first selected item
                    string type = this.columns[checkedListBoxColumns.CheckedIndices[0]].SubItems[1].Text;

                    string description = "Sum of: ";

                    // check if all types are equal by going through all selected values
                    foreach (int index in checkedListBoxColumns.CheckedIndices)
                    {
                        if (!this.columns[index].SubItems[1].Text.Equals(type))
                        {
                            MessageBox.Show("Column types must be the same");
                            return;
                        }
                        description = description + this.columns[index].Text + ", ";
                    }

                    SumColumn = new ListViewItem();
                    SumColumn.Text = textBoxColumnName.Text;
                    SumColumn.SubItems.Add(type);

                    description = description.Substring(0, description.Length-2);
                    SumColumn.SubItems.Add(description);

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please enter column name");
                }
            }
            else
            {
                MessageBox.Show("Please select two or more columns");
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace ResultCounter
{
    public partial class FormCustomStage : Form
    {
        public FormCustomStage()
        {
            InitializeComponent();

            // KeyDown events for deleting data when del button is pressed
            listViewColumns.KeyDown += listViewColumns_KeyDown;
            listBoxPriorities.KeyDown += listBoxPriorities_KeyDown;
            
            comboBoxColType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPriorities.DropDownStyle = ComboBoxStyle.DropDownList;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ActiveControl = textBoxStageName;

            var startItem = new ListViewItem("Start");
            startItem.SubItems.Add("time");
            var finishItem = new ListViewItem("Finish");
            finishItem.SubItems.Add("time");
            var timeItem = new ListViewItem("Time");
            timeItem.SubItems.Add("time");

            listViewColumns.Items.Insert(0, timeItem);
            listViewColumns.Items.Insert(0, finishItem);
            listViewColumns.Items.Insert(0, startItem);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!textBoxColName.Text.Equals(""))
            {
                if (comboBoxColType.SelectedIndex == -1)
                {
                    MessageBox.Show("Select column type");
                }
                else
                {
                    var item = new ListViewItem(textBoxColName.Text);
                    item.SubItems.Add(comboBoxColType.Text);
                    listViewColumns.Items.Add(item);

                    textBoxColName.Text = "";
                    comboBoxColType.SelectedIndex = -1;
                }
            }
        }

        private void buttonRemoveColumn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem col in listViewColumns.SelectedItems)
            {
                listViewColumns.Items.Remove(col);
            }
        }

        private void listViewColumns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem col in listViewColumns.SelectedItems)
                {
                    listViewColumns.Items.Remove(col);
                }
                e.Handled = true;
            }
        }

        private void listBoxPriorities_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                listBoxPriorities.Items.Remove(listBoxPriorities.SelectedItem);
                e.Handled = true;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!textBoxStageName.Text.Equals(""))
            {
                if (listViewColumns.Items.Count == 0)
                {
                    MessageBox.Show("Cannot create a stage with no columns");
                }
            }
            else
            {
                MessageBox.Show("Please enter stage name");
            }
        }

        private void buttonAddPriority_Click(object sender, EventArgs e)
        {
            if (comboBoxPriorities.SelectedIndex != -1)
            {
                listBoxPriorities.Items.Add(comboBoxPriorities.Text);
                comboBoxPriorities.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Please select column");
            }
        }

        private void buttonRemovePriority_Click(object sender, EventArgs e)
        {
            listBoxPriorities.Items.Remove(listBoxPriorities.SelectedItem);
        }

        private void comboBoxPriorities_Click(object sender, EventArgs e)
        {
            comboBoxPriorities.Items.Clear();
            if (!listBoxPriorities.Items.Contains("Time") && checkBoxStartFinishTime.Checked)
            {
                comboBoxPriorities.Items.Add("Time");
            }
            foreach (ListViewItem item in listViewColumns.Items)
            {
                if (!listBoxPriorities.Items.Contains(item.Text))
                {
                    comboBoxPriorities.Items.Add(item.Text);
                }
            }
        }

        private void buttonAddSumColumn_Click(object sender, EventArgs e)
        {
            var form = new FormSumColumn(listViewColumns.Items);
            var result = form.ShowDialog();

            if (result == DialogResult.OK && form.SumColumn != null)
            {
                listViewColumns.Items.Add(form.SumColumn);
            }
        }

        private void checkBoxStartFinishTime_Click(object sender, EventArgs e)
        {
            if (checkBoxStartFinishTime.Checked)
            {
                var startItem = new ListViewItem("Start");
                startItem.SubItems.Add("time");
                var finishItem = new ListViewItem("Finish");
                finishItem.SubItems.Add("time");
                var timeItem = new ListViewItem("Time");
                timeItem.SubItems.Add("time");

                listViewColumns.Items.Insert(0, timeItem);
                listViewColumns.Items.Insert(0, finishItem);
                listViewColumns.Items.Insert(0, startItem);
            }
            else
            {
                listViewColumns.Items.RemoveAt(0);
                listViewColumns.Items.RemoveAt(0);
                listViewColumns.Items.RemoveAt(0);
            }
        }
    }
}

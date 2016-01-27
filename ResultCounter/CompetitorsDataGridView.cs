using System;
using System.Windows.Forms;

namespace ResultCounter
{
    class CompetitorsDataGridView : DataGridView
    {        
        public const string ColumnNameStartNr = "ColumnStartNum";
        public const string ColumnNameDriver = "ColumnDriver";
        public const string ColumnNameCoDriver = "ColumnCoDriver";

        public CompetitorsDataGridView()
        {
            initialise();
        }
        
        private void initialise()
        {            
            //
            //  Columns
            //
            DataGridViewTextBoxColumn ColumnStartNr = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnDriver = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnCoDriver = new DataGridViewTextBoxColumn();

            ColumnStartNr.HeaderText = "Start Number";
            ColumnStartNr.Name = ColumnNameStartNr;
            ColumnDriver.HeaderText = "Driver";
            ColumnDriver.Name = ColumnNameDriver;
            ColumnCoDriver.HeaderText = "Co-driver";
            ColumnCoDriver.Name = ColumnNameCoDriver;

            //
            // CompetitorsDataGridViewStage
            //
            this.Name = this.GetType().Name;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                        ColumnStartNr,
                        ColumnDriver,
                        ColumnCoDriver});
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.TabIndex = 0;
            this.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            //
            //  Events
            //
            this.KeyUp += new KeyEventHandler(CompetitorsDataGridView_KeyUp);
        }

        private void CompetitorsDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            //if user clicked Shift+Ins or Ctrl+V (paste from clipboard)
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                char[] rowSplitter = { '\r', '\n' };
                char[] columnSplitter = { '\t' };
                //get the text from clipboard
                IDataObject dataInClipboard = Clipboard.GetDataObject();
                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
                //split it into lines
                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                //get the row and column of selected cell in grid
                int r = this.SelectedCells[0].RowIndex;
                int c = this.SelectedCells[0].ColumnIndex;
                //add rows into grid to fit clipboard lines
                if (this.Rows.Count < (r + rowsInClipboard.Length))
                {
                    this.Rows.Add(r + rowsInClipboard.Length - this.Rows.Count);
                }
                // loop through the lines, split them into cells and place the values in the corresponding cell.
                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
                {
                    //split row into cell values
                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                    //cycle through cell values
                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                    {
                        //assign cell value, only if it within columns of the grid
                        if (this.ColumnCount - 1 >= c + iCol)
                        {
                            this.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                        }
                    }
                }
            }
        }
    }    
}

using System;
using System.Globalization;
using System.Windows.Forms;

namespace ResultCounter
{
    class OsDataGridView : DataGridView
    {
        private const string cellValueError = "######";
        private int[,] pointsArray;

        public readonly int indexColumnStart;
        public readonly int indexColumnFinish;
        public readonly int indexColumnTime;
        public readonly int indexColumnSpeedPenalty;
        public readonly int indexColumnPointsPenalty;
        public readonly int indexColumnTotalTime;
        public readonly int indexColumnPlace;
        public readonly int indexColumnPoints;

        public OsDataGridView(int[,] pointsArray)
        {
            this.pointsArray = pointsArray;

            //
            //  Columns
            //
            DataGridViewTextBoxColumn ColumnStartNum = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnDriver = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnCoDriver = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnStart = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnFinish = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnTime = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnSpeedPenalty = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnPointsPenalty = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnTotalTime = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnPlace = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColumnPoints = new DataGridViewTextBoxColumn();

            ColumnStartNum.HeaderText = "Start Number";
            ColumnStartNum.Name = "ColumnStartNum";
            ColumnStartNum.ReadOnly = true;
            ColumnDriver.HeaderText = "Driver";
            ColumnDriver.Name = "ColumnDriver";
            ColumnDriver.ReadOnly = true;
            ColumnCoDriver.HeaderText = "Co-driver";
            ColumnCoDriver.Name = "ColumnCoDriver";
            ColumnCoDriver.ReadOnly = true;
            ColumnStart.HeaderText = "Start";
            ColumnStart.Name = "ColumnStart";
            ColumnFinish.HeaderText = "Finish";
            ColumnFinish.Name = "ColumnFinish";
            ColumnTime.HeaderText = "Time";
            ColumnTime.Name = "ColumnTime";
            ColumnTime.DefaultCellStyle.Format = "HH:mm:ss tt";
            ColumnTime.ReadOnly = true;
            ColumnSpeedPenalty.HeaderText = "Speed Penalty";
            ColumnSpeedPenalty.Name = "ColumnSpeedPenalty";
            ColumnPointsPenalty.HeaderText = "Points Penalty";
            ColumnPointsPenalty.Name = "ColumnPointsPenalty";
            ColumnTotalTime.HeaderText = "Total time";
            ColumnTotalTime.Name = "ColumnTotalTime";
            ColumnTotalTime.ReadOnly = true;
            ColumnPlace.HeaderText = "Place";
            ColumnPlace.Name = "ColumnPlace";
            ColumnPlace.ReadOnly = true;
            ColumnPoints.HeaderText = "Points";
            ColumnPoints.Name = "ColumnPoints";
            
            //
            // OsDataGridView
            //
            this.Name = this.GetType().Name;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                        ColumnStartNum,
                        ColumnDriver,
                        ColumnCoDriver,
                        ColumnStart,
                        ColumnFinish,
                        ColumnTime,
                        ColumnSpeedPenalty,
                        ColumnPointsPenalty,
                        ColumnTotalTime,
                        ColumnPlace,
                        ColumnPoints});
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TabIndex = 0;
            this.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            //
            //  Events
            //
            this.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            this.KeyUp += new KeyEventHandler(dataGridView1_KeyUp);

            //
            //  Indexes
            //
            this.indexColumnStart = ColumnStart.Index;
            this.indexColumnFinish = ColumnFinish.Index;
            this.indexColumnTime = ColumnTime.Index;
            this.indexColumnSpeedPenalty = ColumnSpeedPenalty.Index;
            this.indexColumnPointsPenalty = ColumnPointsPenalty.Index;
            this.indexColumnTotalTime = ColumnTotalTime.Index;
            this.indexColumnPlace = ColumnPlace.Index;
            this.indexColumnPoints = ColumnPoints.Index;
        }

        public void SortByPlaces()
        {
            var col = this.Columns[indexColumnPlace];
            this.Sort(col, System.ComponentModel.ListSortDirection.Ascending);
        }

        protected override void OnSortCompare(DataGridViewSortCompareEventArgs e)
        {
            if (SortedColumn.Index == this.indexColumnPlace && e.CellValue1 != null && e.CellValue2 != null)
            {
                /* e.SortResult:
                   Less than zero if the first cell will be sorted before the second cell; 
                   zero if the first cell and second cell have equivalent values; 
                   greater than zero if the second cell will be sorted before the first cell. */

                if (e.CellValue1.Equals("NS") && e.CellValue2.Equals("NS"))
                {
                    e.SortResult = 0;
                }
                else if (e.CellValue1.Equals("NF") && e.CellValue2.Equals("NF"))
                {
                    e.SortResult = 0;
                }
                else if (e.CellValue1.Equals("NS") && e.CellValue2.Equals("NF"))
                {
                    e.SortResult = 1;
                }
                else if (e.CellValue1.Equals("NF") && e.CellValue2.Equals("NS"))
                {
                    e.SortResult = -1;
                }
                else
                {
                    int value1;
                    int value2;

                    bool val1 = int.TryParse(e.CellValue1.ToString(), out value1);
                    bool val2 = int.TryParse(e.CellValue2.ToString(), out value2);

                    if (val1 && val2)
                    {
                        e.SortResult = value1.CompareTo(value2);
                    }
                    else if (val1 && !val2)
                    {
                        e.SortResult = -1;
                    }
                    else if (!val1 && val2)
                    {
                        e.SortResult = 1;
                    }
                }
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string aValue = null;
            
            // if entered value is not null, make it uppercase and assign to aValue
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                aValue = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
            }

            // Check if edited column is the one who requires time format and format it if needed
            // If competitor not finished or not started, update other cells depending
            if (aValue != null && (e.ColumnIndex == this.indexColumnStart || e.ColumnIndex == this.indexColumnFinish ||
                e.ColumnIndex == this.indexColumnPointsPenalty || e.ColumnIndex == this.indexColumnSpeedPenalty))
            {
                if (e.ColumnIndex == this.indexColumnStart && aValue.Equals("NS") ||
                    e.ColumnIndex == this.indexColumnFinish && aValue.Equals("NS"))
                {
                    this.Rows[e.RowIndex].Cells[this.indexColumnStart].Value = "NS";
                    this.Rows[e.RowIndex].Cells[this.indexColumnFinish].Value = "NS";
                    this.Rows[e.RowIndex].Cells[this.indexColumnTime].Value = "NS";
                }
                else if (e.ColumnIndex == this.indexColumnFinish && aValue.Equals("NF"))
                {
                    this.Rows[e.RowIndex].Cells[this.indexColumnFinish].Value = "NF";
                    this.Rows[e.RowIndex].Cells[this.indexColumnTime].Value = "NF";
                }
                else
                {
                    string formattedValue = this.stringToTimeFormat(aValue);
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = formattedValue;
                }
            }

            // Set Time column value if Start or Finish values are changed
            if (e.ColumnIndex == this.indexColumnStart || e.ColumnIndex == this.indexColumnFinish)
            {
                object start = this.Rows[e.RowIndex].Cells[indexColumnStart].Value;
                object finish = this.Rows[e.RowIndex].Cells[indexColumnFinish].Value;

                if (start == null || finish == null ||
                    finish.Equals(cellValueError) || start.Equals(cellValueError))
                {
                    this.Rows[e.RowIndex].Cells[indexColumnTime].Value = null;
                }
                else if (finish.Equals("NS") || finish.Equals("NF"))
                {
                    this.Rows[e.RowIndex].Cells[indexColumnTime].Value = finish.ToString();
                }
                else
                {
                    DateTime startTime = this.parseTime(start.ToString());
                    DateTime finishTime = this.parseTime(finish.ToString());

                    if (startTime != DateTime.MinValue && finishTime != DateTime.MinValue)
                    {
                        TimeSpan diff = finishTime - startTime;
                        if (diff.TotalHours < 0)
                        {
                            diff = diff.Add(new TimeSpan(864000000000));
                        }

                        string result = diff.ToString();
                        if (result.Length > 12)
                        {
                            result = result.Substring(0, 12);
                        }

                        this.Rows[e.RowIndex].Cells[indexColumnTime].Value = result;
                    }
                    else
                    {
                        //Parsing failed, set ColumnTime value as cellValueError
                        this.Rows[e.RowIndex].Cells[indexColumnTime].Value = cellValueError;
                    }
                }
            }

            // If one of columns which could change Total time are edited, update total time
            if (e.ColumnIndex == this.indexColumnTime || e.ColumnIndex == this.indexColumnPointsPenalty || e.ColumnIndex == this.indexColumnSpeedPenalty)
            {
                object time = this.Rows[e.RowIndex].Cells[this.indexColumnTime].Value;

                    // If time is null or NS/NF, total time must have the same value
                    if (time == null || time.Equals("NS") || time.Equals("NF") || time.Equals(cellValueError))
                {
                    this.Rows[e.RowIndex].Cells[this.indexColumnTotalTime].Value = time;
                }
                else
                {
                    object speedPenalty = this.Rows[e.RowIndex].Cells[indexColumnSpeedPenalty].Value;
                    object pointsPenalty = this.Rows[e.RowIndex].Cells[indexColumnPointsPenalty].Value;

                    speedPenalty = speedPenalty == null ? "00:00:00" : speedPenalty;
                    pointsPenalty = pointsPenalty == null ? "00:00:00" : pointsPenalty;
                    
                    DateTime sp = this.parseTime(speedPenalty.ToString());
                    DateTime pp = this.parseTime(pointsPenalty.ToString());
                    DateTime t = this.parseTime(time.ToString());

                    if (sp != DateTime.MinValue && pp != DateTime.MinValue && t != DateTime.MinValue)
                    {
                        DateTime sum = sp.Add(pp.TimeOfDay).Add(t.TimeOfDay);

                        string result = sum.TimeOfDay.ToString();
                        if (result.Length > 12)
                        {
                            result = result.Substring(0, 12);
                        }

                        this.Rows[e.RowIndex].Cells[indexColumnTotalTime].Value = result;
                    }
                    else
                    {
                        this.Rows[e.RowIndex].Cells[indexColumnTotalTime].Value = "######";
                    }
                }
            }
       
            if (e.ColumnIndex == this.indexColumnTotalTime)
            {
                if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    this.Rows[e.RowIndex].Cells[this.indexColumnPlace].Value = null;
                    this.Rows[e.RowIndex].Cells[this.indexColumnPoints].Value = null;
                }
                else
                {
                    DateTime time;
                    DateTime tempTime;
                    object cellValue;
                    object tempCellValue;
                    int rows = this.RowCount;
                    int place;

                    for (int i=0; i < rows; i++)
                    {
                        cellValue = this.Rows[i].Cells[this.indexColumnTotalTime].Value;
                        if (cellValue != null)
                        {
                            if (cellValue.Equals("NF") || cellValue.Equals("NS") || cellValue.Equals(cellValueError))
                            {
                                this.Rows[i].Cells[this.indexColumnPlace].Value = cellValue;
                                this.Rows[i].Cells[this.indexColumnPoints].Value = 0;
                                continue;
                            }
                            time = this.parseTime(cellValue.ToString());
                            if (time == DateTime.MinValue) { continue; }
                            place = 1;
                            for (int j=0; j < rows; j++)
                            {
                                if (i != j)
                                {
                                    tempCellValue = this.Rows[j].Cells[this.indexColumnTotalTime].Value;
                                    if (tempCellValue != null)
                                    {
                                        if (tempCellValue.Equals("NF") || tempCellValue.Equals("NS") || cellValue.Equals(cellValueError))
                                        {
                                            continue;
                                        }
                                        tempTime = this.parseTime(tempCellValue.ToString());
                                        if (tempTime == DateTime.MinValue) { continue; }
                                        if (time > tempTime)
                                        {
                                            place++;
                                        }
                                    }
                                }
                            }
                            this.Rows[i].Cells[this.indexColumnPlace].Value = place;
                            if (pointsArray != null)
                            {
                                this.Rows[i].Cells[this.indexColumnPoints].Value = pointsArray[place, rows];
                            }
                            else
                            {
                                this.Rows[i].Cells[this.indexColumnPoints].Value = "Error";
                            }
                        }
                    }
                }
            }
        }      

        /// <summary>
        /// Returns the string formatted as time in HH:mm:ss or HH:mm:ss.fff format.
        /// If formating fails, returns "######".
        /// </summary>
        /// <param name="s">pre-formatted string</param>
        private string stringToTimeFormat(string s)
        {
            string[] time = s.Split(':');
            int length = time.Length;

            string formatted = cellValueError;
            int num;

            // Check if time is in right format and edit if needed
            for (int i = 0; i < time.Length; i++)
            {
                time[i].Replace(":", "");

                if (time[i].Equals(""))
                {
                    length--;
                }
                else if (i != 2 && (!int.TryParse(time[i], out num) || (time[i].Length > 2)))
                {
                    return cellValueError;
                }
            }

            switch (length)
            {
                case 1:
                    if (time[0].Length == 1)
                    {
                        time[0] = "0" + time[0];
                    }
                    formatted = time[0] + ":00:00";
                    break;
                case 2:
                    if (time[0].Length == 1)
                    {
                        time[0] = "0" + time[0];
                    }
                    if (time[1].Length == 1)
                    {
                        time[1] = "0" + time[1];
                    }
                    formatted = time[0] + ":" + time[1] + ":00";
                    break;
                case 3:
                    if (time[0].Length == 1)
                    {
                        time[0] = "0" + time[0];
                    }
                    if (time[1].Length == 1)
                    {
                        time[1] = "0" + time[1];
                    }

                    if (int.TryParse(time[2], out num))
                    {
                        if (time[2].Length == 1)
                        {
                            time[2] = "0" + time[2];
                        }
                        else if (time[2].Length > 2)
                        {
                            return cellValueError;
                        }
                    }
                    else if (time[2].Contains("."))
                    {
                        String[] sec = time[2].Split('.');

                        if ((sec[0].Equals("") || int.TryParse(sec[0], out num) && (sec[1].Equals("") || int.TryParse(sec[1], out num))))
                        {
                            if (sec[0].Length == 1)
                            {
                                sec[0] = "0" + sec[0];
                            }
                            else if (sec[0].Length > 2)
                            {
                                return cellValueError;
                            }

                            if (sec[1].Length == 0)
                            {
                                sec[1] = "000";
                            }
                            else if (sec[1].Length == 1)
                            {
                                sec[1] = sec[1] + "00";
                            }
                            else if (sec[1].Length == 2)
                            {
                                sec[1] = sec[1] + "0";
                            }
                            else if (sec[1].Length > 3)
                            {
                                return cellValueError;
                            }

                            time[2] = sec[0] + "." + sec[1];
                        }
                        else
                        {
                            return cellValueError;
                        }
                    }
                    else
                    {
                        return cellValueError;
                    }
                formatted = time[0] + ":" + time[1] + ":" + time[2];
                    break;
                default:
                    break;
            }
            return formatted;
        }

        /// <summary>
        /// Converts HH:mm:ss or HH:mm:ss.fff string to DateTime format. Returns DateTime.MinValue if failed
        /// </summary>
        /// <param name="time">String in HH:mm:ss or HH:mm:ss.fff format</param>
        private DateTime parseTime(string time)
        {
            try{
                if (time.Length > 8)
                {
                    return DateTime.ParseExact(time, "HH:mm:ss.fff", CultureInfo.InvariantCulture);
                }
                else if (time.Length == 8)
                {
                    return DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            catch(Exception)
            {
                return DateTime.MinValue;
            }
        }      

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
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
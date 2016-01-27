using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ResultCounter
{
    public partial class FormResults : Form
    {
        private TabControl stagesTabControl;
        private int[,] pointsArray; // [place, competitors.Count]
        private List<Competitor> competitors;
        private string categoryName;

        public FormResults(TabControl stagesTabControl, int[,] pointsArray, string categoryName)
        {
            InitializeComponent();
            this.stagesTabControl = stagesTabControl;
            this.pointsArray = pointsArray;
            this.categoryName = categoryName;
            competitors = getCompetitorsList();
            fillDataGrid();
        }

        /// <summary>
        /// Fills dataGridView using competitors list and pointsArray
        /// </summary>
        private void fillDataGrid()
        {

            // Create Start number, Driver and Co-Driver columns
            this.dataGridViewResults.Columns.Add("columnStartNum", "Start Number");
            this.dataGridViewResults.Columns.Add("columnDriver", "Driver");
            this.dataGridViewResults.Columns.Add("columnCoDriver", "Co-Driver");

            //
            //  Loop through Tabs (stages) and add them as columns to resultGrid
            //
            foreach (TabPage stagesTab in stagesTabControl.TabPages)
            {
                // Skip Competitors Tab Page
                if (!stagesTab.Name.Equals("competitorsTabPage"))
                {
                    // Create column with stage
                    this.dataGridViewResults.Columns.Add(stagesTab.Name, stagesTab.Text);
                    
                    // Get OsDataGridView Control of a stage
                    foreach (Control control in stagesTab.Controls)
                    {
                        if (control.Name.Equals("OsDataGridView"))
                        {
                            DataGridView dataGridView = (DataGridView)control;
                            
                            // Loop through rows and search for a match with competitor
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                // Get start number of current row (column is start number)
                                var value = dataGridView.Rows[row.Index].Cells[0].Value;
                                foreach (Competitor comp in competitors)
                                {
                                    // if startNum equals current row startNum, than competitor is found
                                    if (value != null && comp.StartNum != null && comp.StartNum.Equals(value))
                                    {
                                        if (dataGridView.Rows[row.Index].Cells[10].Value != null)
                                        {
                                            comp.addPointsToList(dataGridView.Rows[row.Index].Cells[10].Value.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            this.dataGridViewResults.Columns.Add("ColumnTotalPoints", "Total");
            this.dataGridViewResults.Columns.Add("ColumnPlace", "Place");
            this.dataGridViewResults.Columns.Add("ColumnStagePoints", "Stage Points");

            // Sort Competitors List
            this.competitors.Sort((comp1, comp2) => comp2.TotalPoints.CompareTo(comp1.TotalPoints));

            for (int i = 0; i < competitors.Count; i++)
            {
                this.dataGridViewResults.Rows.Add("");
                this.dataGridViewResults.Rows[i].Cells[0].Value = competitors[i].StartNum;
                this.dataGridViewResults.Rows[i].Cells[1].Value = competitors[i].Driver;
                this.dataGridViewResults.Rows[i].Cells[2].Value = competitors[i].CoDriver;

                for (int j = 0; j < competitors[i].pointsList.Count; j++)
                {
                    this.dataGridViewResults.Rows[i].Cells[j+3].Value = competitors[i].pointsList[j];
                }
                this.dataGridViewResults.Rows[i].Cells[dataGridViewResults.Columns.Count - 3].Value = competitors[i].TotalPoints;
                
                if (i > 0 && competitors[i].TotalPoints == competitors[i-1].TotalPoints)
                {
                    int place = int.Parse(this.dataGridViewResults.Rows[i - 1].Cells[dataGridViewResults.Columns.Count - 2].Value.ToString());

                    this.dataGridViewResults.Rows[i].Cells[dataGridViewResults.Columns.Count - 2].Value = place;
                    if (pointsArray != null)
                        this.dataGridViewResults.Rows[i].Cells[dataGridViewResults.Columns.Count - 1].Value =
                            pointsArray[place, competitors.Count];

                }
                else
                {
                    this.dataGridViewResults.Rows[i].Cells[dataGridViewResults.Columns.Count - 2].Value = i+1;
                    if(pointsArray != null)
                        this.dataGridViewResults.Rows[i].Cells[dataGridViewResults.Columns.Count - 1].Value = 
                            pointsArray[i + 1, competitors.Count];
                }
            }
        }

        /// <summary>
        ///  Reads stageTabControl and returns sorted list of competitors from Competitors Tab
        /// </summary>
        /// <param name="stagesTabControl"></param>
        /// <returns></returns>
        private List<Competitor> getCompetitorsList()
        {
            List<Competitor> competitors = new List<Competitor>();
            
            // Loop through tabs to find competitors tab
            foreach (TabPage stagesTab in stagesTabControl.TabPages)
            {
                if (stagesTab.Name.Equals("competitorsTabPage"))
                {
                    // loop through controls to find dataGrid
                    foreach (Control control in stagesTab.Controls)
                    {
                        if (control.Name.Equals("CompetitorsDataGridView"))
                        {
                            CompetitorsDataGridView competitorsDataGridView = (CompetitorsDataGridView)control;

                            // Each row is comptetitor, and each column is data
                            foreach (DataGridViewRow row in competitorsDataGridView.Rows)
                            {
                                Competitor competitor = new Competitor();
                                foreach (DataGridViewColumn col in competitorsDataGridView.Columns)
                                {
                                    var value = competitorsDataGridView.Rows[row.Index].Cells[col.Index].Value;
                                    if (value == null)
                                        continue;
                                    switch (col.Name)
                                    {
                                        case CompetitorsDataGridView.ColumnNameStartNr:
                                            competitor.StartNum = value.ToString();
                                            break;
                                        case CompetitorsDataGridView.ColumnNameDriver:
                                            competitor.Driver = value.ToString();
                                            break;
                                        case CompetitorsDataGridView.ColumnNameCoDriver:
                                            competitor.CoDriver = value.ToString();
                                            break;
                                    }
                                }
                                competitors.Add(competitor);
                            }
                        }
                    }
                }
            }
            return competitors;
        }
        
        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Dialog
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel |*.xlsx";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                XLWorkbook workbook;
                IXLWorksheet worksheet;
                try
                {
                    if (Properties.Settings.Default.PathToTemplate.Equals(""))
                    {
                        MessageBox.Show("Please select a template in settings", "Failed to create file");
                    }
                    workbook = new XLWorkbook(Properties.Settings.Default.PathToTemplate);
                    if (!workbook.Worksheets.TryGetWorksheet("Results", out worksheet))
                    {
                        MessageBox.Show("Worksheet 'Results' not found in template");
                        return;
                    }

                    workbook.Worksheets.Delete("Points");

                    // Coordinates where table starts
                    int firstCol = 1;
                    int headerRow = 10;

                    // Insert columns of stages to table
                    for (int i = 3; i < this.dataGridViewResults.Columns.Count; i++)
                    {
                        if (!dataGridViewResults.Columns[i].HeaderText.Equals("Total"))
                        {
                            worksheet.Cell(headerRow, firstCol + i).Value = dataGridViewResults.Columns[i].HeaderText;
                            var col = worksheet.Column(firstCol + i);
                            col.InsertColumnsAfter(1);
                        }
                        else
                        {
                            worksheet.Column(firstCol + i).Delete();
                            break;
                        }
                    }

                    // Merge rows
                    const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    worksheet.Range("A7:" + letters[dataGridViewResults.Columns.Count - 1] + "7").Row(1).Merge();
                    worksheet.Range("A8:" + letters[dataGridViewResults.Columns.Count - 1] + "8").Row(1).Merge();
                    worksheet.Cell("A8").Value = categoryName + " results";

                    // Insert data
                    for (int i = 0; i < this.dataGridViewResults.Rows.Count; i++)
                    {
                        for (int j = 0; j < this.dataGridViewResults.Columns.Count; j++)
                        {
                            worksheet.Cell(i + headerRow + 1, j + firstCol).Value = this.dataGridViewResults.Rows[i].Cells[j].Value;
                        }
                        var row = worksheet.Row(i + headerRow + 1);
                        row.InsertRowsBelow(1);
                        worksheet.Row(i + headerRow + 2).Height = row.Height;
                    }
                    // Delete the last row which will be empty
                    worksheet.Row(headerRow + this.dataGridViewResults.Rows.Count + 1).Delete();
                    workbook.SaveAs(saveDialog.FileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

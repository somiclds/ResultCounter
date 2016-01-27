using ClosedXML.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ResultCounter
{
    public partial class FormResultCounter : Form
    {

        private ContextMenuStrip tabContextMenuCategories;
        private ContextMenuStrip tabContextMenuStages;

        public FormResultCounter()
        {
            InitializeComponent();

            //
            // Context menu items for categories
            //
            tabContextMenuCategories = new ContextMenuStrip();
            tabContextMenuCategories.Items.Add("Add OS");
            tabContextMenuCategories.Items.Add("Add SS");
            tabContextMenuCategories.Items.Add("Add Circle");
            tabContextMenuCategories.Items.Add("Rename");
            tabContextMenuCategories.Items.Add("Delete");
            tabContextMenuCategories.ItemClicked += new ToolStripItemClickedEventHandler(tabContextMenuCategories_ItemClicked);

            //
            // Context menu items for stages
            //
            tabContextMenuStages = new ContextMenuStrip();
            tabContextMenuStages.Items.Add("Rename");
            tabContextMenuStages.Items.Add("Delete");
            tabContextMenuStages.ItemClicked += new ToolStripItemClickedEventHandler(tabContextMenuStages_ItemClicked);

            //
            // Events for editing tabs
            //
            tabControlCategories.MouseClick += tabControlCategories_MouseClick;
            tabControlCategories.MouseDown += new MouseEventHandler(tc_MouseDown);
            tabControlCategories.MouseUp += new MouseEventHandler(tc_MouseUp);
            tabControlCategories.MouseMove += new MouseEventHandler(tc_MouseMove);
            tabControlCategories.DragOver += new DragEventHandler(tc_DragOver);
            tabControlCategories.AllowDrop = true;
        }

        private void toolStripButtonAddCategory_Click(object sender, EventArgs e)
        {
            addCategory();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCategory();
        }

        /// <summary>
        /// Shows contextMenu when tab is right clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlCategories_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TabControl clickedTabControl = (TabControl)sender;
                TabControl.TabPageCollection tabPages = clickedTabControl.TabPages;
                if (clickedTabControl == tabControlCategories)
                {
                    for (int i = 0; i < tabPages.Count; ++i)
                    {
                        if (clickedTabControl.GetTabRect(i).Contains(e.Location))
                        {
                            clickedTabControl.SelectedIndex = i;
                            tabContextMenuCategories.Show(clickedTabControl, e.Location);
                            return;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < tabPages.Count; ++i)
                    {
                        if (clickedTabControl.GetTabRect(i).Contains(e.Location))
                        {
                            clickedTabControl.SelectedIndex = i;
                            // If clicked tab is competitors, do not show tabContextMenu
                            if (clickedTabControl.SelectedTab.Name.Equals("competitorsTabPage")) return;
                            // else, show tabContextMenuStages
                            tabContextMenuStages.Show(clickedTabControl, e.Location);
                            return;
                        }
                    }
                }
            }
        } 

        private void tabContextMenuCategories_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            String item = e.ClickedItem.ToString();
            if (item.Equals("Rename"))
            {
                var form = new CustomInputBox(item.ToString(), "Enter the name", tabControlCategories.SelectedTab.Text);
                var result = form.ShowDialog();
                string input = form.returnValue;

                if (result == DialogResult.OK && !input.Equals(""))
                    tabControlCategories.SelectedTab.Text = input;
            }
            else if (item.Equals("Delete"))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to remove '"
                    + tabControlCategories.SelectedTab.Text+ "' category?", "Remove", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tabControlCategories.TabPages.Remove(tabControlCategories.SelectedTab);
                }
            }
            else if (item.Equals("Add OS"))
            {
                addStage();
            }
            
        }

        private void tabContextMenuStages_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TabControl selectedTabControlStages = this.getSelectedTabControlStages();
            if (selectedTabControlStages != null)
            {
                String item = e.ClickedItem.ToString();
                if (item.Equals("Rename"))
                {
                    var form = new CustomInputBox(item.ToString(), "Enter the name", selectedTabControlStages.SelectedTab.Text);
                    var result = form.ShowDialog();
                    string input = form.returnValue;

                    if (result == DialogResult.OK && !input.Equals(""))
                       selectedTabControlStages.SelectedTab.Text = input;
                }
                else if (item.Equals("Delete"))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to remove '"
                        + selectedTabControlStages.SelectedTab.Text + "' stage?", "Remove", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        selectedTabControlStages.TabPages.Remove(selectedTabControlStages.SelectedTab);
                    }
                }
            }
        }

        private void AddOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStage();
        }

        private void orientationStageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStage();
        }       

        private void toolStripButtonAddRow_Click(object sender, EventArgs e)
        {
            this.getSelectedDataGridView().Rows.Add();
        }

        private void toolStripButtonDeleteSelectedRow_Click(object sender, EventArgs e)
        {
            var gridView = this.getSelectedDataGridView();
            foreach (DataGridViewRow selectedRow in gridView.SelectedRows)
            {
                gridView.Rows.Remove(selectedRow);
            }
        }

        private void toolStripButtonNewCompetition_Click(object sender, EventArgs e)
        {
            newCompetition();
        }

        private void newCompetitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newCompetition();
        }

        private void addCategory()
        {
            var form = new CustomInputBox("Create a category", "Enter category name");
            var result = form.ShowDialog();
            string input = form.returnValue;

            if (result == DialogResult.OK && !input.Equals(""))
            {
                
                TabControl tabControlStages = new TabControl();
                tabControlStages.Dock = DockStyle.Fill;
                tabControlStages.Name = "stagesTabControl";
                tabControlStages.MouseClick += tabControlCategories_MouseClick;
                tabControlStages.MouseDown += new MouseEventHandler(tc_MouseDown);
                tabControlStages.MouseUp += new MouseEventHandler(tc_MouseUp);
                tabControlStages.MouseMove += new MouseEventHandler(tc_MouseMove);
                tabControlStages.DragOver += new DragEventHandler(tc_DragOver);
                tabControlStages.AllowDrop = true;

                TabPage competitorsTabPage = new TabPage();
                competitorsTabPage.Text = "Competitors";
                competitorsTabPage.Name = "competitorsTabPage";
                CompetitorsDataGridView competitorsDataGridView = new CompetitorsDataGridView();
                competitorsTabPage.Controls.Add(competitorsDataGridView);
                tabControlStages.TabPages.Add(competitorsTabPage);

                TabPage categoryTabPage = new TabPage(input);
                categoryTabPage.Controls.Add(tabControlStages);

                tabControlCategories.TabPages.Add(categoryTabPage);
            }
        }

        private void addStage()
        {
            if (tabControlCategories.SelectedTab != null)
            {
                var form = new CustomInputBox("Create a new stage", "Enter stage name");
                var result = form.ShowDialog();
                string input = form.returnValue;

                if (result == DialogResult.OK && !input.Equals(""))
                {
                    TabControl selectedTabControlStages = this.getSelectedTabControlStages();

                    if (selectedTabControlStages != null)
                    {
                        foreach (TabPage tab in selectedTabControlStages.TabPages)
                        {
                            if (tab.Name.Equals("competitorsTabPage"))
                            {
                                Control[] matchedControls = tab.Controls.Find("CompetitorsDataGridView", false);
                                if (matchedControls.Length > 0)
                                {
                                    int[,] points = getPointsFromFile();

                                    TabPage tabPageStage = new TabPage(input);
                                    OsDataGridView dataGridViewStage = new OsDataGridView(points);
                                    dataGridViewStage.Name = "OsDataGridView";

                                    DataGridView competitorsDataGridView = (DataGridView)matchedControls[0];
                                    foreach(DataGridViewRow row in competitorsDataGridView.Rows)
                                    {
                                        dataGridViewStage.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value);
                                    }
                                    tabPageStage.Controls.Add(dataGridViewStage);
                                    selectedTabControlStages.TabPages.Add(tabPageStage);
                                }
                            }
                        }
                    } 
                    else
                        MessageBox.Show("Tab not found", "Failed to create");
                }
            }
            else
            {
                MessageBox.Show("Create a category first", "Failed to create");
            }
        }

        private DataGridView getSelectedDataGridView()
        {
            DataGridView selectedDataGridView = null;

            TabControl selectedTabControl = this.getSelectedTabControlStages();
            if (selectedTabControl != null)
            {
                TabPage selectedTabPage = selectedTabControl.SelectedTab;
                if (selectedTabPage != null)
                {
                    Control[] matchedControls = selectedTabPage.Controls.Find("OsDataGridView", false);
                    if (matchedControls.Length > 0)
                    {
                        selectedDataGridView = (DataGridView)matchedControls[0];
                    }
                    else
                    {
                        matchedControls = selectedTabPage.Controls.Find("CompetitorsDataGridView", false);
                        if (matchedControls.Length > 0)
                        {
                            selectedDataGridView = (DataGridView)matchedControls[0];
                        }
                    }
                }
            }
            return selectedDataGridView;
        }

        private TabControl getSelectedTabControlStages()
        {
            TabPage selectedTabControl = tabControlCategories.SelectedTab;
            Control[] matchedControls;
            if (selectedTabControl != null)
            {
                matchedControls = selectedTabControl.Controls.Find("stagesTabControl", false);
                if (matchedControls.Length > 0)
                {
                    return (TabControl)matchedControls[0];
                }
                else
                    return null;
            }
            else
                return null;

        }

        public TabControl getSelectedCatagoryTabControl()
        {
            return this.tabControlCategories;
        }

        private void newCompetition()
        {
            if (tabControlCategories.TabCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Any unsaved progress will be lost" + System.Environment.NewLine + "Do you want to save?",
                "New Competition", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    saveToFile();
                }
                else if (dialogResult == DialogResult.No)
                {
                    tabControlCategories.TabPages.Clear();
                }
            }
        }

        private void saveToFile()
        {
            MessageBox.Show("Save to file");
            //tabControlCategories.TabPages.Clear();
        }

        /// <summary>
        /// Gets pointArray from file from specified path
        /// </summary>
        /// <returns></returns>
        private int[,] getPointsFromFile()
        {
            if (Properties.Settings.Default.PathToTemplate.Equals(""))
            {
                MessageBox.Show("Please select a template in settings", "Failed to read points");
                return null;
            }
            int[,] pointsArray = new int[41, 41];
            try
            {
                var workbook = new XLWorkbook(Properties.Settings.Default.PathToTemplate);
                IXLWorksheet worksheet;
                if (!workbook.TryGetWorksheet("Points", out worksheet))
                {
                    MessageBox.Show("Worksheet 'Points' not found in template", "Failed to read points");
                    return null;
                }

                for (int i = 3; i < 41; i++)
                {
                    for (int j = 2; j < 39; j++)
                    {
                        var value = worksheet.Cell(i, j).Value.ToString();
                        if (value.Equals(""))
                        {
                            break;
                        }
                        if (!int.TryParse(worksheet.Cell(i, j).Value.ToString(), out pointsArray[-2 + i, 42 - j]))
                        {
                            MessageBox.Show("Error reading points" + i + " " + j);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to read points");
                return null;
            }
            return pointsArray;
        }

        private void tc_MouseDown(object sender, MouseEventArgs e)
        {
            // store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = this.getHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
        }
        private void tc_MouseUp(object sender, MouseEventArgs e)
        {
            // clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }
        private void tc_MouseMove(object sender, MouseEventArgs e)
        {
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }
        private void tc_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            if (e.Data.GetData(typeof(TabPage)) == null) return;
            TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);
            if (dragTab_index < 0)
                return;

            // hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0 || (tc == this.getSelectedTabControlStages() && hoverTab_index == 0))
            { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }

            return -1;
        }

        private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            if (!(tc == this.getSelectedTabControlStages() && (index_src == 0 || index_dst == 0)))
            {
                tc.TabPages[index_dst] = src;
                tc.TabPages[index_src] = dst;
                tc.Refresh();
            }
        }        

        private void toolStripButtonSort_Click(object sender, EventArgs e)
        {
            TabControl selectedTabControlStages = this.getSelectedTabControlStages();

            foreach (Control control in selectedTabControlStages.SelectedTab.Controls){
                if (control.Name == "OsDataGridView")
                {
                    OsDataGridView osGridView = (OsDataGridView) control;
                    osGridView.SortByPlaces();
                    break;
                }
            }
        }

        private void toolStripButtonResults_Click(object sender, EventArgs e)
        {
            TabControl stagesControl = this.getSelectedTabControlStages();
            if (stagesControl != null)
            {
                int[,] points = getPointsFromFile();

                FormResults frmResults = new FormResults(stagesControl, points, this.tabControlCategories.SelectedTab.Text);
                frmResults.Show();
            }
        }

        private void toolStripSplitButtonCreateExcelFile_ButtonClick(object sender, EventArgs e)
        {
            
        }

        private void pathToTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            string path = Properties.Settings.Default.PathToTemplate;
            if (Directory.Exists(Path.GetExtension(path)))
            {
                dialog.InitialDirectory = path;
            }
            dialog.Filter = "Excel |*.xlsx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.PathToTemplate = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void customStageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customStageForm = new FormCustomStage();
            customStageForm.Show();
        }
    }
}
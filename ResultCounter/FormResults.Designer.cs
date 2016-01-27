namespace ResultCounter
{
    partial class FormResults
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResults));
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.toolStripResults = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButtonCreateExcelFile = new System.Windows.Forms.ToolStripSplitButton();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allStagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.toolStripResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.AllowUserToAddRows = false;
            this.dataGridViewResults.AllowUserToDeleteRows = false;
            this.dataGridViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResults.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.ReadOnly = true;
            this.dataGridViewResults.RowTemplate.Height = 24;
            this.dataGridViewResults.Size = new System.Drawing.Size(768, 422);
            this.dataGridViewResults.TabIndex = 0;
            // 
            // toolStripResults
            // 
            this.toolStripResults.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButtonCreateExcelFile});
            this.toolStripResults.Location = new System.Drawing.Point(0, 0);
            this.toolStripResults.Name = "toolStripResults";
            this.toolStripResults.Size = new System.Drawing.Size(768, 27);
            this.toolStripResults.TabIndex = 1;
            this.toolStripResults.Text = "toolStripResults";
            // 
            // toolStripSplitButtonCreateExcelFile
            // 
            this.toolStripSplitButtonCreateExcelFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButtonCreateExcelFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultsToolStripMenuItem,
            this.allStagesToolStripMenuItem});
            this.toolStripSplitButtonCreateExcelFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonCreateExcelFile.Image")));
            this.toolStripSplitButtonCreateExcelFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonCreateExcelFile.Name = "toolStripSplitButtonCreateExcelFile";
            this.toolStripSplitButtonCreateExcelFile.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButtonCreateExcelFile.Text = "Create Excel File";
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.resultsToolStripMenuItem.Text = "Results Only";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.resultsToolStripMenuItem_Click);
            // 
            // allStagesToolStripMenuItem
            // 
            this.allStagesToolStripMenuItem.Name = "allStagesToolStripMenuItem";
            this.allStagesToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.allStagesToolStripMenuItem.Text = "All Stages";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // FormResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 449);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.toolStripResults);
            this.Name = "FormResults";
            this.Text = "Results";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.toolStripResults.ResumeLayout(false);
            this.toolStripResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.ToolStrip toolStripResults;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonCreateExcelFile;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allStagesToolStripMenuItem;
    }
}
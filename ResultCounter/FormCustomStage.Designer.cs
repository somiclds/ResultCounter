namespace ResultCounter
{
    partial class FormCustomStage
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxStartFinishTime = new System.Windows.Forms.CheckBox();
            this.buttonAddCol = new System.Windows.Forms.Button();
            this.buttonRemoveCol = new System.Windows.Forms.Button();
            this.comboBoxColType = new System.Windows.Forms.ComboBox();
            this.textBoxColName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStageName = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPriorities = new System.Windows.Forms.ComboBox();
            this.listBoxPriorities = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddPriority = new System.Windows.Forms.Button();
            this.buttonRemovePriority = new System.Windows.Forms.Button();
            this.buttonAddSumColumn = new System.Windows.Forms.Button();
            this.listViewColumns = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Columns:";
            // 
            // checkBoxStartFinishTime
            // 
            this.checkBoxStartFinishTime.AutoSize = true;
            this.checkBoxStartFinishTime.Checked = true;
            this.checkBoxStartFinishTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStartFinishTime.Location = new System.Drawing.Point(12, 79);
            this.checkBoxStartFinishTime.Name = "checkBoxStartFinishTime";
            this.checkBoxStartFinishTime.Size = new System.Drawing.Size(136, 21);
            this.checkBoxStartFinishTime.TabIndex = 1;
            this.checkBoxStartFinishTime.Text = "Start/Finish/Time";
            this.checkBoxStartFinishTime.UseVisualStyleBackColor = true;
            this.checkBoxStartFinishTime.Click += new System.EventHandler(this.checkBoxStartFinishTime_Click);
            // 
            // buttonAddCol
            // 
            this.buttonAddCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCol.Location = new System.Drawing.Point(377, 148);
            this.buttonAddCol.Name = "buttonAddCol";
            this.buttonAddCol.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCol.TabIndex = 2;
            this.buttonAddCol.Text = "Add";
            this.buttonAddCol.UseVisualStyleBackColor = true;
            this.buttonAddCol.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemoveCol
            // 
            this.buttonRemoveCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveCol.Location = new System.Drawing.Point(12, 326);
            this.buttonRemoveCol.Name = "buttonRemoveCol";
            this.buttonRemoveCol.Size = new System.Drawing.Size(119, 28);
            this.buttonRemoveCol.TabIndex = 3;
            this.buttonRemoveCol.Text = "Remove column";
            this.buttonRemoveCol.UseVisualStyleBackColor = true;
            this.buttonRemoveCol.Click += new System.EventHandler(this.buttonRemoveColumn_Click);
            // 
            // comboBoxColType
            // 
            this.comboBoxColType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColType.FormattingEnabled = true;
            this.comboBoxColType.Items.AddRange(new object[] {
            "int",
            "time"});
            this.comboBoxColType.Location = new System.Drawing.Point(335, 115);
            this.comboBoxColType.Name = "comboBoxColType";
            this.comboBoxColType.Size = new System.Drawing.Size(117, 24);
            this.comboBoxColType.TabIndex = 5;
            this.comboBoxColType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxColName
            // 
            this.textBoxColName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxColName.Location = new System.Drawing.Point(175, 115);
            this.textBoxColName.Name = "textBoxColName";
            this.textBoxColName.Size = new System.Drawing.Size(154, 22);
            this.textBoxColName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Stage name:";
            // 
            // textBoxStageName
            // 
            this.textBoxStageName.Location = new System.Drawing.Point(103, 10);
            this.textBoxStageName.Name = "textBoxStageName";
            this.textBoxStageName.Size = new System.Drawing.Size(141, 22);
            this.textBoxStageName.TabIndex = 8;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Location = new System.Drawing.Point(335, 553);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(119, 28);
            this.buttonCreate.TabIndex = 9;
            this.buttonCreate.Text = "Create Stage";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sorting priorities:";
            // 
            // comboBoxPriorities
            // 
            this.comboBoxPriorities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxPriorities.FormattingEnabled = true;
            this.comboBoxPriorities.Location = new System.Drawing.Point(93, 398);
            this.comboBoxPriorities.Name = "comboBoxPriorities";
            this.comboBoxPriorities.Size = new System.Drawing.Size(118, 24);
            this.comboBoxPriorities.TabIndex = 11;
            this.comboBoxPriorities.Click += new System.EventHandler(this.comboBoxPriorities_Click);
            // 
            // listBoxPriorities
            // 
            this.listBoxPriorities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPriorities.FormattingEnabled = true;
            this.listBoxPriorities.ItemHeight = 16;
            this.listBoxPriorities.Location = new System.Drawing.Point(16, 447);
            this.listBoxPriorities.Name = "listBoxPriorities";
            this.listBoxPriorities.Size = new System.Drawing.Size(313, 84);
            this.listBoxPriorities.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Priority order:";
            // 
            // buttonAddPriority
            // 
            this.buttonAddPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddPriority.Location = new System.Drawing.Point(12, 398);
            this.buttonAddPriority.Name = "buttonAddPriority";
            this.buttonAddPriority.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPriority.TabIndex = 14;
            this.buttonAddPriority.Text = "Add";
            this.buttonAddPriority.UseVisualStyleBackColor = true;
            this.buttonAddPriority.Click += new System.EventHandler(this.buttonAddPriority_Click);
            // 
            // buttonRemovePriority
            // 
            this.buttonRemovePriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemovePriority.Location = new System.Drawing.Point(335, 503);
            this.buttonRemovePriority.Name = "buttonRemovePriority";
            this.buttonRemovePriority.Size = new System.Drawing.Size(119, 28);
            this.buttonRemovePriority.TabIndex = 15;
            this.buttonRemovePriority.Text = "Remove item";
            this.buttonRemovePriority.UseVisualStyleBackColor = true;
            this.buttonRemovePriority.Click += new System.EventHandler(this.buttonRemovePriority_Click);
            // 
            // buttonAddSumColumn
            // 
            this.buttonAddSumColumn.Location = new System.Drawing.Point(12, 146);
            this.buttonAddSumColumn.Name = "buttonAddSumColumn";
            this.buttonAddSumColumn.Size = new System.Drawing.Size(132, 27);
            this.buttonAddSumColumn.TabIndex = 16;
            this.buttonAddSumColumn.Text = "Add Sum column";
            this.buttonAddSumColumn.UseVisualStyleBackColor = true;
            this.buttonAddSumColumn.Click += new System.EventHandler(this.buttonAddSumColumn_Click);
            // 
            // listViewColumns
            // 
            this.listViewColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderType,
            this.columnHeaderDescription});
            this.listViewColumns.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewColumns.Location = new System.Drawing.Point(12, 179);
            this.listViewColumns.Name = "listViewColumns";
            this.listViewColumns.Size = new System.Drawing.Size(442, 132);
            this.listViewColumns.TabIndex = 17;
            this.listViewColumns.UseCompatibleStateImageBehavior = false;
            this.listViewColumns.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Column name";
            this.columnHeaderName.Width = 131;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderType.Width = 44;
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderDescription.Width = 142;
            // 
            // FormCustomStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 593);
            this.Controls.Add(this.listViewColumns);
            this.Controls.Add(this.buttonAddSumColumn);
            this.Controls.Add(this.buttonRemovePriority);
            this.Controls.Add(this.buttonAddPriority);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxPriorities);
            this.Controls.Add(this.comboBoxPriorities);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxStageName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxColName);
            this.Controls.Add(this.comboBoxColType);
            this.Controls.Add(this.buttonRemoveCol);
            this.Controls.Add(this.buttonAddCol);
            this.Controls.Add(this.checkBoxStartFinishTime);
            this.Controls.Add(this.label1);
            this.Name = "FormCustomStage";
            this.Text = "Custom stage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxStartFinishTime;
        private System.Windows.Forms.Button buttonAddCol;
        private System.Windows.Forms.Button buttonRemoveCol;
        private System.Windows.Forms.ComboBox comboBoxColType;
        private System.Windows.Forms.TextBox textBoxColName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStageName;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPriorities;
        private System.Windows.Forms.ListBox listBoxPriorities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddPriority;
        private System.Windows.Forms.Button buttonRemovePriority;
        private System.Windows.Forms.Button buttonAddSumColumn;
        private System.Windows.Forms.ListView listViewColumns;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
    }
}
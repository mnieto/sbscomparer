namespace SideBySide {
    partial class ListsConfigurationFrm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.FirstRowAsHeadersCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.separatorOtherTextBox = new System.Windows.Forms.TextBox();
            this.separatorOtherCheckBox = new System.Windows.Forms.CheckBox();
            this.separatorSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.separatorSemicolonCheckBox = new System.Windows.Forms.CheckBox();
            this.separatorColonCheckBox = new System.Windows.Forms.CheckBox();
            this.separatorTabCheckBox = new System.Windows.Forms.CheckBox();
            this.numberOfListTextBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.columnsTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfListTextBox)).BeginInit();
            this.columnsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.columnsTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 205);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // generalTab
            // 
            this.generalTab.BackColor = System.Drawing.SystemColors.Control;
            this.generalTab.Controls.Add(this.FirstRowAsHeadersCheckBox);
            this.generalTab.Controls.Add(this.groupBox1);
            this.generalTab.Controls.Add(this.numberOfListTextBox);
            this.generalTab.Controls.Add(this.label1);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(453, 179);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            // 
            // FirstRowAsHeadersCheckBox
            // 
            this.FirstRowAsHeadersCheckBox.AutoSize = true;
            this.FirstRowAsHeadersCheckBox.Location = new System.Drawing.Point(9, 38);
            this.FirstRowAsHeadersCheckBox.Name = "FirstRowAsHeadersCheckBox";
            this.FirstRowAsHeadersCheckBox.Size = new System.Drawing.Size(139, 17);
            this.FirstRowAsHeadersCheckBox.TabIndex = 7;
            this.FirstRowAsHeadersCheckBox.Text = "Use first row as headers";
            this.FirstRowAsHeadersCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.separatorOtherTextBox);
            this.groupBox1.Controls.Add(this.separatorOtherCheckBox);
            this.groupBox1.Controls.Add(this.separatorSpaceCheckBox);
            this.groupBox1.Controls.Add(this.separatorSemicolonCheckBox);
            this.groupBox1.Controls.Add(this.separatorColonCheckBox);
            this.groupBox1.Controls.Add(this.separatorTabCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Separator chars";
            // 
            // separatorOtherTextBox
            // 
            this.separatorOtherTextBox.Enabled = false;
            this.separatorOtherTextBox.Location = new System.Drawing.Point(186, 41);
            this.separatorOtherTextBox.Name = "separatorOtherTextBox";
            this.separatorOtherTextBox.Size = new System.Drawing.Size(29, 20);
            this.separatorOtherTextBox.TabIndex = 5;
            // 
            // separatorOtherCheckBox
            // 
            this.separatorOtherCheckBox.AutoSize = true;
            this.separatorOtherCheckBox.Location = new System.Drawing.Point(128, 44);
            this.separatorOtherCheckBox.Name = "separatorOtherCheckBox";
            this.separatorOtherCheckBox.Size = new System.Drawing.Size(52, 17);
            this.separatorOtherCheckBox.TabIndex = 4;
            this.separatorOtherCheckBox.Text = "Other";
            this.separatorOtherCheckBox.UseVisualStyleBackColor = true;
            this.separatorOtherCheckBox.CheckedChanged += new System.EventHandler(this.separatorOtherCheckBox_CheckedChanged);
            // 
            // separatorSpaceCheckBox
            // 
            this.separatorSpaceCheckBox.AutoSize = true;
            this.separatorSpaceCheckBox.Location = new System.Drawing.Point(128, 20);
            this.separatorSpaceCheckBox.Name = "separatorSpaceCheckBox";
            this.separatorSpaceCheckBox.Size = new System.Drawing.Size(57, 17);
            this.separatorSpaceCheckBox.TabIndex = 3;
            this.separatorSpaceCheckBox.Text = "Space";
            this.separatorSpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // separatorSemicolonCheckBox
            // 
            this.separatorSemicolonCheckBox.AutoSize = true;
            this.separatorSemicolonCheckBox.Location = new System.Drawing.Point(7, 66);
            this.separatorSemicolonCheckBox.Name = "separatorSemicolonCheckBox";
            this.separatorSemicolonCheckBox.Size = new System.Drawing.Size(75, 17);
            this.separatorSemicolonCheckBox.TabIndex = 2;
            this.separatorSemicolonCheckBox.Text = "Semicolon";
            this.separatorSemicolonCheckBox.UseVisualStyleBackColor = true;
            // 
            // separatorColonCheckBox
            // 
            this.separatorColonCheckBox.AutoSize = true;
            this.separatorColonCheckBox.Location = new System.Drawing.Point(6, 43);
            this.separatorColonCheckBox.Name = "separatorColonCheckBox";
            this.separatorColonCheckBox.Size = new System.Drawing.Size(53, 17);
            this.separatorColonCheckBox.TabIndex = 1;
            this.separatorColonCheckBox.Text = "Colon";
            this.separatorColonCheckBox.UseVisualStyleBackColor = true;
            // 
            // separatorTabCheckBox
            // 
            this.separatorTabCheckBox.AutoSize = true;
            this.separatorTabCheckBox.Location = new System.Drawing.Point(7, 20);
            this.separatorTabCheckBox.Name = "separatorTabCheckBox";
            this.separatorTabCheckBox.Size = new System.Drawing.Size(45, 17);
            this.separatorTabCheckBox.TabIndex = 0;
            this.separatorTabCheckBox.Text = "Tab";
            this.separatorTabCheckBox.UseVisualStyleBackColor = true;
            // 
            // numberOfListTextBox
            // 
            this.numberOfListTextBox.Location = new System.Drawing.Point(88, 12);
            this.numberOfListTextBox.Name = "numberOfListTextBox";
            this.numberOfListTextBox.Size = new System.Drawing.Size(51, 20);
            this.numberOfListTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of lists";
            // 
            // columnsTab
            // 
            this.columnsTab.Controls.Add(this.dataGridView1);
            this.columnsTab.Location = new System.Drawing.Point(4, 22);
            this.columnsTab.Name = "columnsTab";
            this.columnsTab.Padding = new System.Windows.Forms.Padding(3);
            this.columnsTab.Size = new System.Drawing.Size(453, 179);
            this.columnsTab.TabIndex = 1;
            this.columnsTab.Text = "Columns";
            this.columnsTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colIsKey});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(447, 173);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Validating += new System.ComponentModel.CancelEventHandler(this.dataGridView1_Validating);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(317, 223);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(398, 223);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ListComparer.ColumDef);
            this.bindingSource1.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource1_ListChanged);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ToolTipText = "Column name";
            // 
            // colIsKey
            // 
            this.colIsKey.DataPropertyName = "IsKey";
            this.colIsKey.HeaderText = "Is Key";
            this.colIsKey.Name = "colIsKey";
            this.colIsKey.ToolTipText = "Use this column for sorting the list";
            this.colIsKey.Width = 80;
            // 
            // ListsConfigurationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 256);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListsConfigurationFrm";
            this.ShowInTaskbar = false;
            this.Text = "Cofigure lists";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListsConfigurationFrm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.generalTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfListTextBox)).EndInit();
            this.columnsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox separatorOtherTextBox;
        private System.Windows.Forms.CheckBox separatorOtherCheckBox;
        private System.Windows.Forms.CheckBox separatorSpaceCheckBox;
        private System.Windows.Forms.CheckBox separatorSemicolonCheckBox;
        private System.Windows.Forms.CheckBox separatorColonCheckBox;
        private System.Windows.Forms.CheckBox separatorTabCheckBox;
        private System.Windows.Forms.NumericUpDown numberOfListTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage columnsTab;
        private System.Windows.Forms.CheckBox FirstRowAsHeadersCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsKey;
    }
}
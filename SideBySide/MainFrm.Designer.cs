namespace SideBySide {
    partial class MainFrm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.editPanel = new System.Windows.Forms.RibbonPanel();
            this.pasteButton = new System.Windows.Forms.RibbonButton();
            this.loadFromFileButton = new System.Windows.Forms.RibbonButton();
            this.listManagementPanel = new System.Windows.Forms.RibbonPanel();
            this.numListTextBox = new System.Windows.Forms.RibbonUpDown();
            this.numColumnsTextBox = new System.Windows.Forms.RibbonUpDown();
            this.useFirshtRowAsHeaderCheckBox = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.applyButton = new System.Windows.Forms.RibbonButton();
            this.resultsPanel = new System.Windows.Forms.RibbonPanel();
            this.compareButton = new System.Windows.Forms.RibbonButton();
            this.exportToExcel = new System.Windows.Forms.RibbonButton();
            this.exportToText = new System.Windows.Forms.RibbonButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.Size = new System.Drawing.Size(792, 118);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.editPanel);
            this.ribbonTab1.Panels.Add(this.listManagementPanel);
            this.ribbonTab1.Panels.Add(this.resultsPanel);
            this.ribbonTab1.Text = "Home";
            // 
            // editPanel
            // 
            this.editPanel.ButtonMoreVisible = false;
            this.editPanel.FlowsTo = System.Windows.Forms.RibbonPanelFlowDirection.Right;
            this.editPanel.Items.Add(this.pasteButton);
            this.editPanel.Items.Add(this.loadFromFileButton);
            this.editPanel.Text = "Paste";
            // 
            // pasteButton
            // 
            this.pasteButton.Image = global::SideBySide.Properties.Resources.Paste_32x32;
            this.pasteButton.SmallImage = global::SideBySide.Properties.Resources.Paste_16x16;
            this.pasteButton.Text = "Paste";
            this.pasteButton.ToolTip = "Paste a multiline string";
            this.pasteButton.ToolTipTitle = "Paste";
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Image = global::SideBySide.Properties.Resources.Open_32x32;
            this.loadFromFileButton.SmallImage = global::SideBySide.Properties.Resources.Open_16x16;
            this.loadFromFileButton.Text = "Open";
            this.loadFromFileButton.ToolTip = "Each selected file fils one data list";
            this.loadFromFileButton.ToolTipTitle = "Load from file";
            this.loadFromFileButton.Click += new System.EventHandler(this.loadFromFileButton_Click);
            // 
            // listManagementPanel
            // 
            this.listManagementPanel.Items.Add(this.numListTextBox);
            this.listManagementPanel.Items.Add(this.numColumnsTextBox);
            this.listManagementPanel.Items.Add(this.useFirshtRowAsHeaderCheckBox);
            this.listManagementPanel.Items.Add(this.ribbonSeparator1);
            this.listManagementPanel.Items.Add(this.applyButton);
            this.listManagementPanel.Text = "List management";
            this.listManagementPanel.ButtonMoreClick += new System.EventHandler(this.listManagementPanel_ButtonMoreClick);
            // 
            // numListTextBox
            // 
            this.numListTextBox.LabelWidth = 100;
            this.numListTextBox.Tag = "";
            this.numListTextBox.Text = "Num of lists";
            this.numListTextBox.TextBoxText = "2";
            this.numListTextBox.TextBoxWidth = 50;
            this.numListTextBox.ToolTip = "Number of available data lists";
            this.numListTextBox.ToolTipTitle = "Num of lists";
            this.numListTextBox.Value = "";
            this.numListTextBox.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.upButton_Click);
            this.numListTextBox.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.downButton_Click);
            // 
            // numColumnsTextBox
            // 
            this.numColumnsTextBox.LabelWidth = 100;
            this.numColumnsTextBox.Text = "Columns per list";
            this.numColumnsTextBox.TextBoxText = "1";
            this.numColumnsTextBox.TextBoxWidth = 50;
            this.numColumnsTextBox.ToolTip = "Number of columns in each data list. The first list determine the number of colum" +
    "ns for the rest of data lists.";
            this.numColumnsTextBox.ToolTipTitle = "Columns per list";
            this.numColumnsTextBox.Value = "";
            this.numColumnsTextBox.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.upButton_Click);
            this.numColumnsTextBox.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.downButton_Click);
            // 
            // useFirshtRowAsHeaderCheckBox
            // 
            this.useFirshtRowAsHeaderCheckBox.Checked = true;
            this.useFirshtRowAsHeaderCheckBox.Text = "Use 1st row as header";
            this.useFirshtRowAsHeaderCheckBox.ToolTip = "Use 1st row as column headeres";
            this.useFirshtRowAsHeaderCheckBox.ToolTipTitle = "Use 1st row as header";
            this.useFirshtRowAsHeaderCheckBox.CheckBoxCheckChanged += new System.EventHandler(this.useFirshtRowAsHeaderCheckBox_CheckBoxCheckChanged);
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Image = global::SideBySide.Properties.Resources.Apply_32x32;
            this.applyButton.SmallImage = global::SideBySide.Properties.Resources.Apply_16x16;
            this.applyButton.Text = "Apply";
            this.applyButton.ToolTip = "Apply changes of list management options";
            this.applyButton.ToolTipTitle = "Apply";
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // resultsPanel
            // 
            this.resultsPanel.ButtonMoreVisible = false;
            this.resultsPanel.Items.Add(this.compareButton);
            this.resultsPanel.Items.Add(this.exportToExcel);
            this.resultsPanel.Items.Add(this.exportToText);
            this.resultsPanel.Text = "Results";
            // 
            // compareButton
            // 
            this.compareButton.Enabled = false;
            this.compareButton.Image = global::SideBySide.Properties.Resources.Columns_32x32;
            this.compareButton.SmallImage = global::SideBySide.Properties.Resources.Columns_16x16;
            this.compareButton.Text = "Compare";
            this.compareButton.ToolTip = "Compare the data lists";
            this.compareButton.ToolTipTitle = "Compare";
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // exportToExcel
            // 
            this.exportToExcel.Enabled = false;
            this.exportToExcel.Image = global::SideBySide.Properties.Resources.ExportToXLS_32x32;
            this.exportToExcel.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.exportToExcel.SmallImage = global::SideBySide.Properties.Resources.ExportToXLS_16x16;
            this.exportToExcel.Tag = "xlsx";
            this.exportToExcel.Text = "To Excel";
            this.exportToExcel.ToolTip = "Export to Excel file";
            this.exportToExcel.ToolTipTitle = "Export";
            this.exportToExcel.Click += new System.EventHandler(this.exportTo_Click);
            // 
            // exportToText
            // 
            this.exportToText.Enabled = false;
            this.exportToText.Image = global::SideBySide.Properties.Resources.ExportToCSV_32x32;
            this.exportToText.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.exportToText.SmallImage = global::SideBySide.Properties.Resources.ExportToCSV_16x16;
            this.exportToText.Tag = "txt";
            this.exportToText.Text = "To Text";
            this.exportToText.ToolTip = "Export to text file";
            this.exportToText.ToolTipTitle = "Export";
            this.exportToText.Click += new System.EventHandler(this.exportTo_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 118);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(792, 210);
            this.tabControl.TabIndex = 1;
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "txt";
            this.openDialog.Filter = "Text files|*.txt;*.csv|All files|*.*";
            this.openDialog.Multiselect = true;
            this.openDialog.Title = "Open file";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 328);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Text = "Side by Side comparer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel editPanel;
        private System.Windows.Forms.RibbonButton pasteButton;
        private System.Windows.Forms.RibbonButton loadFromFileButton;
        private System.Windows.Forms.RibbonPanel listManagementPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.RibbonUpDown numListTextBox;
        private System.Windows.Forms.RibbonUpDown numColumnsTextBox;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonButton applyButton;
        private System.Windows.Forms.RibbonCheckBox useFirshtRowAsHeaderCheckBox;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.RibbonPanel resultsPanel;
        private System.Windows.Forms.RibbonButton compareButton;
        private System.Windows.Forms.RibbonButton exportToExcel;
        private System.Windows.Forms.RibbonButton exportToText;
    }
}


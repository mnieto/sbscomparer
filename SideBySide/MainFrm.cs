using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ListComparer;
using SideBySide.Properties;
using SideBySide.ExportTo;

namespace SideBySide {
    public partial class MainFrm : Form {

        /// <summary>
        /// Key used for identify the results tab
        /// </summary>
        private const string ResultsName = "Results";   //Do not localize

        /// <summary>
        /// Number of initial data list 
        /// </summary>
        private const int DefaultListNumber = 2;

        public ListManager ListManager { get; set; }

        public MainFrm() {
            InitializeComponent();
            numListTextBox.TextBoxText = DefaultListNumber.ToString();
            ListManager = new ListManager();
            for (int i = 0; i < DefaultListNumber; i++) {
                CreateNewTab(i);
            }
        }

        /// <summary>
        /// Change the number of lists in <see cref="ListManager"/>
        /// </summary>
        /// <param name="numLists">Final number of list that <see cref="ListManager"/> must have</param>
        private void AdjustNumberOfLists(int numLists) {
            
            if (numLists < ListManager.NumberOfLists) {
                for (int i = ListManager.NumberOfLists - 1; i >= numLists; i--) {
                    tabControl.TabPages.RemoveAt(i);
                    ListManager.RemoveAt(i);
                }
            } else if (numLists > ListManager.NumberOfLists) {
                for (int i = ListManager.NumberOfLists; i < numLists; i++) {
                    CreateNewTab(i);
                }
            }
        }

        /// <summary>
        /// Returns <c>true</c> if <see cref="ListManager"/> is empty or the user allow clear existing data; <c>false</c> if it has data and can not continue
        /// </summary>
        /// <returns></returns>
        private bool CheckListManagerHasData() {
            if (ListManager.HasData) {
                if (MessageBox.Show(Resources.ClearDataWarning, Resources.DeleteData, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return false;
                } else {
                    //TODO: Reset settings according with the list management ribbon panel specifications
                    ListManager.ResetSettings();
                    tabControl.TabPages.Clear();
                    for (int i = 0; i < DefaultListNumber; i++) {
                        CreateNewTab(i);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Create a new tab, with the associated grid and add the corresponding list to ListManager
        /// </summary>
        /// <param name="i"></param>
        private void CreateNewTab(int i) {
            string name = String.Format(Resources.ListNumber, i + 1);
            TabPage page = new TabPage(name);
            DataGridView grid = new DataGridView() {
                AutoGenerateColumns = true,
                Parent = page,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                Visible = false,
                ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            };
            page.Tag = grid;
            ListManager.Add(name);
            tabControl.TabPages.Add(page);
        }

        /// <summary>
        /// Enables or disabled export buttons
        /// </summary>
        /// <param name="enanble"><c>true</c> to enable buttons; <c>false</c> to disable buttons</param>
        private void EnableExportButtons(bool enanble) {
            resultsPanel.GetItems()
                .Where(x => x.Tag != null)
                .ToList()
                .ForEach(x => x.Enabled = enanble);
        }

        /// <summary>
        /// Returns the results tab. If it don't exists, it create and configure the tab first
        /// </summary>
        private TabPage GetResultsTab() {
            if (!tabControl.TabPages.ContainsKey(ResultsName)) {
                tabControl.TabPages.Add(ResultsName, Resources.Results);
                DataGridView grid = new DataGridView() {
                    AutoGenerateColumns = true,
                    Parent = tabControl.TabPages[ResultsName],
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToOrderColumns = false,
                };
                tabControl.TabPages[ResultsName].Tag = grid;
            }
            return tabControl.TabPages[ResultsName];
        }

        private DataGridView GetGrid(int index) {
            return (DataGridView)tabControl.TabPages[index].Tag;
        }

        private DataGridView GetGrid(TabPage page) {
            return (DataGridView)page.Tag;
        }

        private void ShowFilledDataList(int index) {
            DataGridView grid = GetGrid(index);
            grid.DataSource = ListManager[index].Data;
            grid.Visible = true;
            numColumnsTextBox.TextBoxText = ListManager.FillOptions.NumColumns.ToString();
            compareButton.Enabled = ListManager.CanCompare;
            tabControl.TabPages.RemoveByKey(ResultsName);
            EnableExportButtons(false);
        }

        private void downButton_Click(object sender, MouseEventArgs e) {
            RibbonUpDown upDown = (RibbonUpDown)sender;
            int value = int.Parse(upDown.TextBoxText);
            if (value > 1) {
                value--;
                upDown.TextBoxText = value.ToString();
                applyButton.Enabled = true;
            }
        }

        private void upButton_Click(object sender, MouseEventArgs e) {
            RibbonUpDown upDown = (RibbonUpDown)sender;
            int value = int.Parse(upDown.TextBoxText) + 1;
            upDown.TextBoxText = value.ToString();
            applyButton.Enabled = true;
        }

        private void useFirshtRowAsHeaderCheckBox_CheckBoxCheckChanged(object sender, EventArgs e) {
            applyButton.Enabled = true;
        }

        private void applyButton_Click(object sender, EventArgs e) {
            int numLists = int.Parse(numListTextBox.TextBoxText);
            int numColumns = int.Parse(numColumnsTextBox.TextBoxText);

            if (!CheckListManagerHasData())
                return;

            //Redefine the fill options with the configuration selected by the user (the number of data lists do not change here)
            ListManager.FillOptions.UseFirstRowAsHeaders = useFirshtRowAsHeaderCheckBox.Checked;
            ListManager.FillOptions.NumColumns = numColumns;
            ListManager.FillOptions.InferNumColumns = true;

            AdjustNumberOfLists(numLists);

            applyButton.Enabled = false;

        }

        private void pasteButton_Click(object sender, EventArgs e) {
            //TODO: Create a new paste all button, wich will fill all the data lists in one unique operation:
            //      Infer the total number of columns, divide between number of lists: the quotient should be equals to the number of columns defined in FillOptions
            if (!Clipboard.ContainsText())
                return;

            ListManager[tabControl.SelectedIndex].Fill(Clipboard.GetText());
            ShowFilledDataList(tabControl.SelectedIndex);
        }

        private void loadFromFileButton_Click(object sender, EventArgs e) {
            
            //TODO: Create a new load from Excel button: each selected worksheet is a datalist, the number of columns can be infered from the first worksheet

            if (openDialog.ShowDialog() == DialogResult.OK) {
                if (!CheckListManagerHasData())
                    return;
                if (openDialog.FileNames.Length > 1) {
                    AdjustNumberOfLists(openDialog.FileNames.Length);
                    for (int i = 0; i < openDialog.FileNames.Length; i++) {
                        //TODO: Control possible errors and set numListTextBox only for truly filled data lists
                        ListManager[i].FillFromFile(openDialog.FileNames[i]);
                        ShowFilledDataList(i);
                    }
                    numListTextBox.TextBoxText = openDialog.FileNames.Length.ToString();
                } else {
                    ListManager[tabControl.SelectedIndex].FillFromFile(openDialog.FileName);
                    ShowFilledDataList(tabControl.SelectedIndex);
                }
            }
        }

        private void compareButton_Click(object sender, EventArgs e) {
            DataGridView grid = GetGrid(GetResultsTab());
            grid.DataSource = ListManager.Compare();
            tabControl.SelectTab(GetResultsTab());
            EnableExportButtons(true);
        }

        private void exportTo_Click(object sender, EventArgs e) {
            string fileExtension = ((RibbonButton)sender).Tag.ToString();
            ExportBase exporter = ExportToFactory.GetExporter(fileExtension, ListManager.FillOptions);
            string fileName = exporter.Export((DataTable)GetGrid(GetResultsTab()).DataSource);
            ExportBase.Open(fileName);
        }

    }
}

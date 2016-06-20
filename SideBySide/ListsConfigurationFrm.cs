using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ListComparer;

namespace SideBySide {
    public partial class ListsConfigurationFrm : Form {

        public FillOptions FillOptions { get; private set; }
        public int NumberOfLists { get;  set; }

        public ListsConfigurationFrm() {
            InitializeComponent();
        }

        public ListsConfigurationFrm(int numOfLists, FillOptions fillOptions) : this() {
            FillOptions = (FillOptions)fillOptions.Clone();
            NumberOfLists = numOfLists;
            SetupControls();
        }

        private void SetupControls() {
            numberOfListTextBox.Value = NumberOfLists;
            FirstRowAsHeadersCheckBox.Checked = FillOptions.UseFirstRowAsHeaders;
            foreach (char c in FillOptions.SeparatorChars) {
                switch (c) { 
                    case '\t':
                        separatorTabCheckBox.Checked = true;
                        break;
                    case ',':
                        separatorColonCheckBox.Checked = true;
                        break;
                    case ';':
                        separatorSemicolonCheckBox.Checked = true;
                        break;
                    case ' ':
                        separatorSpaceCheckBox.Checked = true;
                        break;
                    default:
                        separatorOtherCheckBox.Checked = true;
                        separatorOtherTextBox.Text += c;
                        break;
                }
            }
            bindingSource1.DataSource = FillOptions.Columns;
        }

        private void ReadFromControls() {

            NumberOfLists = Convert.ToInt32(numberOfListTextBox.Value);
            FillOptions.UseFirstRowAsHeaders = FirstRowAsHeadersCheckBox.Checked;

            string separators = String.Empty;
            if (separatorTabCheckBox.Checked)
                separators += '\t';
            else if (separatorColonCheckBox.Checked)
                separators += ',';
            else if (separatorSemicolonCheckBox.Checked)
                separators += ';';
            else if (separatorSpaceCheckBox.Checked)
                separators += ' ';
            else if (separatorOtherCheckBox.Checked)
                separators += separatorOtherTextBox.Text;

            if (separators == String.Empty)
                separators = "\t";
            FillOptions.SeparatorChars = separators;

        }

        private void separatorOtherCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (separatorOtherCheckBox.Checked) {
                separatorOtherTextBox.Enabled = true;
            } else {
                separatorOtherTextBox.Enabled = false;
                separatorOtherTextBox.Text = String.Empty;
            }
        }

        private void ListsConfigurationFrm_FormClosed(object sender, FormClosedEventArgs e) {
            if (DialogResult == System.Windows.Forms.DialogResult.OK) {
                ReadFromControls();
            }
        }

        private void dataGridView1_Validating(object sender, CancelEventArgs e) {
            if (FillOptions.Columns.Count == 0) {
                MessageBox.Show("At least one column must be defined", "Columns definition");
                e.Cancel = true;
            } else if (!FillOptions.Columns.Any(x => x.IsKey)) {
                MessageBox.Show("At least one column must be declared as key column. The list need to be sorted by key columns", "Columns definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e) {
            if (FirstRowAsHeadersCheckBox.Checked && e.TabPage == columnsTab)
                e.Cancel = true;
        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e) {
            var source = bindingSource1.DataSource as List<ColumDef>;
            if (source != null)
                FillOptions.NumColumns = source.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SideBySide.Properties;
using System.IO;
using ListComparer;

namespace SideBySide.ExportTo {
    public class ToText: ExportBase {

        public ToText(FillOptions options): base(options) {
            FileExtension = "txt";
        }

        public override string Export(DataTable dt) {

            string fileName = Path.ChangeExtension(Path.GetTempFileName(), FileExtension);

            using (StreamWriter sw = new StreamWriter(fileName)) {
                writeHeaders(dt, sw);
                foreach (DataRow row in dt.Rows) {
                    WriteRow(row, sw);
                }
            }
            return fileName;

        }

        /// <summary>
        /// split column names and write 2 rows header
        /// </summary>
        private void writeHeaders(DataTable dt, StreamWriter sw) {
            
            //Write lists names
            StringBuilder listHeader = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i += Options.NumColumns) {
                int pos = dt.Columns[i].ColumnName.IndexOf(Options.HeaderSeparator);
                string listName = dt.Columns[i].ColumnName.Substring(0, pos);
                listHeader.Append(listName);
                listHeader.Append(new String(Options.SeparatorChars[0], Options.NumColumns));
            }
            sw.WriteLine(listHeader.ToString().Substring(0, listHeader.Length - 1));

            //Write column names
            var columns = dt.Columns
                .Cast<DataColumn>()
                .Select(x => x.ColumnName.Substring(x.ColumnName.IndexOf(Options.HeaderSeparator) + 1));
            sw.WriteLine(String.Join(Options.SeparatorChars[0].ToString(), columns));

        }

        private void WriteRow(DataRow row, StreamWriter sw) {
            sw.WriteLine(String.Join(Options.SeparatorChars[0].ToString(), row.ItemArray.Cast<string>()));

        }
    }
}

using ListComparer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideBySide.ExportTo
{
    public class ToExcel : ExportBase
    {

        public ToExcel(FillOptions options): base(options) {
            FileExtension = "xlsx";
        }

        public override string Export(DataTable dt) {
            string fileName = Path.ChangeExtension(Path.GetTempFileName(), FileExtension);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var pkg = new ExcelPackage(new FileInfo(fileName))) {
                pkg.Workbook.Worksheets.Add("Compare");
                var xls = pkg.Workbook.Worksheets[0];
                WriteHeaders(dt, xls);
                WriteData(dt, xls);
                pkg.Save();
            }
            return fileName;

        }

        private void WriteHeaders(DataTable dt, ExcelWorksheet xls) {

            //Write list names
            for (int i = 0; i < dt.Columns.Count; i += Options.NumColumns) {
                int pos = dt.Columns[i].ColumnName.IndexOf(Options.HeaderSeparator);
                string listName = dt.Columns[i].ColumnName.Substring(0, pos);
                int c = i + 1;
                xls.Cells[1, c].Value = listName;
                var titleRange = xls.Cells[1, c, 1, c + Options.NumColumns - 1];
                titleRange.Merge = true;
                titleRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            }
            
            //Write column names
            for (int i = 0; i < dt.Columns.Count; i++) {
                var col = dt.Columns[i];
                string name = col.ColumnName.Substring(col.ColumnName.IndexOf(Options.HeaderSeparator) + 1);
                xls.Cells[2, i + 1].Value = name;
            }

            xls.View.FreezePanes(3, 1);
        }

        private void WriteData(DataTable dt, ExcelWorksheet xls) {
            xls.Cells[3, 1].LoadFromDataTable(dt, false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using ListComparer.Properties;

namespace ListComparer {

    public class DataList {

        /// <summary>
        /// Is the data list empty or not set?
        /// </summary>
        public bool HasData {
            get {
                if (Data == null)
                    return false;
                else
                    return Data.Rows.Count > 0;
            }
        }

        /// <summary>
        /// Get or set the name or caption of the data list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Fill options shared between all the list managed by ListManager
        /// </summary>
        public FillOptions FillOptions { get; private set; }

        /// <summary>
        /// Constructor, with default fill options
        /// </summary>
        /// <param name="name">data list name</param>
        public DataList(string name) : this(name, new FillOptions()) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">data list name</param>
        /// <param name="fillOptions">fill options that controls the behavior during the filling process</param>
        public DataList(string name, FillOptions fillOptions) {
            Name = name;
            FillOptions = fillOptions;
        }

        /// <summary>
        /// Data table that store the data
        /// </summary>
        public DataTable Data { get; private set; }


        /// <summary>
        /// Fills the data list from a string
        /// </summary>
        /// <param name="input"></param>
        public void Fill(string input) {
            StringReader sr = new StringReader(input);
            Fill(sr);
        }

        /// <summary>
        /// Fills the data list from a text file and sets the data list name to the file name
        /// </summary>
        public void FillFromFile(string path) {
            Name = Path.GetFileNameWithoutExtension(path);
            StreamReader sr = new StreamReader(path);
            Fill(sr);
        }

        /// <summary>
        /// Fils the data list from a stream
        /// </summary>
        /// <param name="tr"></param>
        public void Fill(TextReader tr) {
            if (FillOptions.NumColumns <= 0)
                throw new InvalidOperationException(Resources.InvalidNumColumns);
            if (String.IsNullOrEmpty(FillOptions.SeparatorChars))
                throw new InvalidOperationException(Resources.NoSeparatorChars);
            string line = tr.ReadLine();
            Data = new DataTable(Name);

            //InferNumColumns should be true only for the very first list filled. 
            //The rest of list must have the same columns
            CreateColumns(line);
            if (FillOptions.InferNumColumns) {
                FillOptions.InferNumColumns = false;
            }

            if (FillOptions.UseFirstRowAsHeaders)
                line = tr.ReadLine();

            int counter = 1;
            char[] separators = FillOptions.SeparatorChars.ToCharArray();
            while (line != null) {
                string[] columns = line.Split(separators);
                if (columns.Length != FillOptions.NumColumns) {
                    string message = String.Concat(String.Format(Resources.ErrorAt, Name, counter),
                                                   String.Format(Resources.ColumnMismatch, FillOptions.NumColumns, columns.Length));
                    throw new InvalidOperationException(message);
                }

                //Ignore blank lines; otherwise, add a new row
                if (!columns.All(x => String.IsNullOrWhiteSpace(x))) {
                    DataRow row = Data.NewRow();
                    row.ItemArray = columns;
                    Data.Rows.Add(row);
                }

                counter++;
                line = tr.ReadLine();
            }
        }

        /// <summary>
        /// Clears internal data and set new fill options
        /// </summary>
        /// <param name="fillOptions">new fill options to consider in the next fill process</param>
        public void Reset(FillOptions fillOptions) {
            if (Data != null) Data.Dispose();
            Data = null;
            FillOptions = fillOptions;
        }

        /// <summary>
        /// Sorts the data list, as a previous step to do the comparation
        /// </summary>
        public void Sort() {
            DataView dv = Data.DefaultView;
            //TODO: Allow to sort by an arbitrary set of columns
            dv.Sort = Data.Columns[0].ColumnName;
            Data = dv.ToTable();
        }

        /// <summary>
        /// Gets the key for a specific row. The returned key is allways a string that can be the result of a compound key 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public string GetKey(int rowIndex) {
            return GetKey(Data.Rows[rowIndex]);
        }

        /// <summary>
        /// Gets the key for a specific row. The returned key is allways a string that can be the result of a compound key 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public string GetKey(DataRow row) {
            var keyNames = FillOptions.Columns.Where(x => x.IsKey).Select(x => x.Name);
            if (keyNames == null || keyNames.Count() == 0)
                return row[0].ToString();
            string key = String.Empty;
            foreach (string name in keyNames) {
                key += row[name].ToString();
            }
            return key;
        }

        private void CreateColumns(string line) {
            string[] columns = line.Split(FillOptions.SeparatorChars.ToCharArray());
            if (FillOptions.InferNumColumns == false && FillOptions.NumColumns != columns.Length) {
                string message = String.Concat(String.Format(Resources.ErrorAt, 1),
                                               String.Format(Resources.ColumnMismatch, FillOptions.NumColumns, columns.Length));
                throw new InvalidOperationException(message);
            }
            for (int i = 0; i < columns.Length; i++) {
                string colName = null;
                if (FillOptions.UseFirstRowAsHeaders) {
                    colName = columns[i];
                } else if (FillOptions.Columns.Count > i) {
                    colName = FillOptions.Columns[i].Name;
                } else {
                    colName = String.Format(Resources.ColumnNo, i + 1);
                }
                Data.Columns.Add(colName);
            }
            FillOptions.NumColumns = columns.Length;
        }

    }
}

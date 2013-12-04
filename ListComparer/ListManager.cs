using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ListComparer.Properties;
using System.Collections;

namespace ListComparer {

    public class ListManager : IEnumerable<DataList> {


        private List<DataList> Lists { get; set; }

        /// <summary>
        /// Fill options shared between all the list managed by ListManager
        /// </summary>
        public FillOptions FillOptions { get; private set; }

        /// <summary>
        /// Get or set the number of lists to compare each to other
        /// </summary>
        public int NumberOfLists {
            get {
                return Lists.Count;
            }
            set {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException(Resources.MustBeGreatherThanZero);
                } else if (value > Lists.Count) {
                    for (int i = Lists.Count; i < value; i++) {
                        Lists.Add(new DataList(String.Format(Resources.ListNumber, i + 1)));
                    }
                } else if (value < Lists.Count) {
                    Lists.RemoveRange(value, Lists.Count - value);
                }
            }
        }


        /// <summary>
        /// Returns <c>true</c> if all the data lists have data, otherwise, returns <c>false</c>
        /// </summary>
        public bool CanCompare {
            get {
                return Lists.All(x => x.HasData);
            }
        }

        /// <summary>
        /// Returns <c>true</c> if one or more lists has data. <c>false</c> if all the lists are empty
        /// </summary>
        public bool HasData {
            get {
                return Lists.Any(x => x.HasData);
            }
        }

        /// <summary>
        /// Gets the data list at <paramref name="index"/> position
        /// </summary>
        public DataList this[int index] {
            get { return Lists[index]; }
        }

        /// <summary>
        /// Gets the data list by name. The name comparation is case insensitive
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataList this[string name] {
            get { return Lists.FirstOrDefault(x => x.Name == name); }
        }


        /// <summary>
        /// Default constructor, with 0 lists
        /// </summary>
        public ListManager() : this(0, new FillOptions()) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listNumber">number of list to compare</param>
        /// <param name="fillOptions">settings of how fill each list</param>
        public ListManager(int listNumber, FillOptions fillOptions) {
            Lists = new List<DataList>(listNumber);
            FillOptions = fillOptions;
            for (int i = 0; i < listNumber; i++) {
                Add(String.Format(Resources.ListNumber, i + 1));
            }
        }

        /// <summary>
        /// Creates and adds a new data list to the ListManager
        /// </summary>
        /// <param name="name"></param>
        public void Add(string name) {
            DataList lst = new DataList(name, FillOptions);
            Lists.Add(lst);
        }

        /// <summary>
        /// Remove the specified data list from ListManager
        /// </summary>
        /// <param name="list"></param>
        public void Remove(DataList list) {
            Lists.Remove(list);
        }

        /// <summary>
        /// Remove the data list by position
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) {
            Lists.RemoveAt(index);
        }

        /// <summary>
        /// Compare all the defined data lists, each to other and return a new DataTable with the lists compared side by side
        /// </summary>
        /// <returns></returns>
        public DataTable Compare() {
            Lists.ForEach(x => x.Sort());
            DataTable result = CreateResultTable();
            IternalCompare(result);

            return result;
        }

        /// <summary>
        /// Reset the fill options and clear the data lists
        /// </summary>
        public void ResetSettings() {
            ResetSettings(FillOptions);
        }

        /// <summary>
        /// Assign a new fill options and clear the data lists
        /// </summary>
        /// <param name="fillOptions"></param>
        public void ResetSettings(FillOptions fillOptions) {
            FillOptions = fillOptions;
            //Lists.ForEach(x => x.Reset(fillOptions));
            Lists.Clear();
        }

        #region IEnumerable<ListGroup> Members

        public IEnumerator<DataList> GetEnumerator() {
            return Lists.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() {
            return Lists.GetEnumerator();
        }

        #endregion
        
        private DataTable CreateResultTable() {
            DataTable dt = new DataTable("Results");    //Do not localize
            foreach (DataList item in Lists) {
                string tableName = item.Name;
                foreach (DataColumn column in item.Data.Columns) {
                    DataColumn dc = dt.Columns.Add(String.Concat(tableName, "/", column.ColumnName));
                    dc.DefaultValue = String.Empty;     //Set a default value != DBNull, so we can export entire rows, without asking column per column
                }
            }
            return dt;
        }

        private void IternalCompare(DataTable dt) {
            List<int> pointers = Enumerable.Repeat(0, Lists.Count).ToList();

            while (ContinueComparation(pointers)) {
                Dictionary<int, string> keys = new Dictionary<int, string>(Lists.Count);
                for (int i = 0; i < Lists.Count; i++) {
                    if (pointers[i] < Lists[i].Data.Rows.Count)
                        keys.Add(i, Lists[i].GetKey(pointers[i]));
                }
                string first = keys.Values.OrderBy(x => x, StringComparer.CurrentCultureIgnoreCase).First();
                DataRow row = dt.NewRow();
                var selectedKeys = keys.Where(x => String.Compare(x.Value, first, true) == 0);
                foreach (var item in selectedKeys) {
                    int baseIndex = FillOptions.NumColumns * item.Key;
                    for (int i = 0; i < FillOptions.NumColumns; i++) {
                        row[baseIndex + i] = Lists[item.Key].Data.Rows[pointers[item.Key]][i];
                    }
                    pointers[item.Key]++;
                }
                dt.Rows.Add(row);
            }

        }

        /// <summary>
        /// Returns true as long as one of the pointers has not reached the data list end
        /// </summary>
        private bool ContinueComparation(List<int> pointers) {
            for (int i = 0; i < pointers.Count; i++) {
                if (pointers[i] < Lists[i].Data.Rows.Count)
                    return true;
            }
            return false;
        }
    }
}

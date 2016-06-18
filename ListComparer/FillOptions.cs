using System;
using System.Collections.Generic;
using System.Linq;

namespace ListComparer {

    public class FillOptions : ICloneable {

        /// <summary>
        /// For internal use only: Separator char for columns headers
        /// </summary>
        public char HeaderSeparator { get; set; }

        /// <summary>
        /// Infer the number of columns while filling the list data. Default <c>true</c>
        /// </summary>
        /// <remarks>
        /// This property should be <c>true</c> only for the first filled list.
        /// The remainder lists must have the same columns than the first list, so InferNumColumns
        /// must be set to <c>false</c> after fill the first list.
        /// </remarks>
        public bool InferNumColumns { get; set; }

        /// <summary>
        /// Number of columns for each list. Default 1
        /// </summary>
        public int NumColumns { get; set; }

        /// <summary>
        /// String containing any of the possible column separator. Default <c>\t</c>
        /// </summary>
        /// <remarks>
        /// The first char in this string is used as default separator char for export to text file
        /// </remarks>
        public string SeparatorChars { get; set; }

        /// <summary>
        /// Use first data row as column names? Default <c>true</c>
        /// </summary>
        public bool UseFirstRowAsHeaders { get; set; }

        /// <summary>
        /// List of column definitions
        /// </summary>
        public List<ColumDef> Columns { get; private set; }

        /// <summary>
        /// Default constructor. Initialize properties to their default values
        /// </summary>
        public FillOptions() {
            HeaderSeparator = '/';
            SeparatorChars = "\t";
            NumColumns = 1;
            UseFirstRowAsHeaders = true;
            InferNumColumns = true;
            Columns = new List<ColumDef>();
        }


        public void CopyTo(FillOptions another) {
            another.HeaderSeparator = HeaderSeparator;
            another.SeparatorChars = SeparatorChars;
            another.NumColumns = NumColumns;
            another.UseFirstRowAsHeaders = UseFirstRowAsHeaders;
            another.InferNumColumns = InferNumColumns;
            another.Columns.Clear();
            Columns.ForEach(x => another.Columns.Add(x));
        }

        #region ICloneable Members

        public object Clone() {
            FillOptions clon = (FillOptions)this.MemberwiseClone();
            clon.Columns = this.Columns.Select(x => (ColumDef)x.Clone()).ToList();
            return clon;
        }

        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ListComparer;
using System.Diagnostics;

namespace SideBySide.ExportTo {

    public abstract class ExportBase {

        public virtual string FileExtension { get; protected set; }
        protected FillOptions Options { get; set; }

        public ExportBase(FillOptions options) {
            this.Options = options;
        }

        public abstract string Export(DataTable dt);

        public static void Open(string fileName) {
            Process.Start(fileName);
        }
    }
}

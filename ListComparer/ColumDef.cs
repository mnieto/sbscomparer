using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListComparer {
    public class ColumDef: ICloneable {
        public string Name { get; set; }
        public bool IsKey { get; set; }

        #region ICloneable Members

        public object Clone() {
            return (ColumDef)this.MemberwiseClone();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SideBySide.Properties;
using ListComparer;

namespace SideBySide.ExportTo {

    public class ExportToFactory {

        public static ExportBase GetExporter(string fileExtension, FillOptions options) {
            switch (fileExtension) {
                case "txt":
                    return new ToText(options);
                case "xlsx":
                    return new ToText(options);
                default:
                    throw new ArgumentException(Resources.NotSupportedFormat, "fileExtension");
            }
        }
    }
}

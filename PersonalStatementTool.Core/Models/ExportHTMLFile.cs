using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalStatementTool.Core
{
    public class ExportHTMLFile : IExportFile
    {
        public string DisplayName { get; } = "HTML";

        public void ExportFile(ExportFileSettings fileSettings, PersonalStatement personalStatement)
        {
            // TODO: Implement HTML file export
            throw new NotImplementedException();
        }
    }
}

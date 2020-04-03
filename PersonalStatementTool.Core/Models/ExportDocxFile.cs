using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalStatementTool.Core
{
    public class ExportDocxFile : IExportFile
    {
        public string DisplayName { get; } = "Microsoft Word Document (.docx)";

        public void ExportFile(ExportFileSettings fileSettings, PersonalStatement personalStatement)
        {
            // TODO: Implement DOCX export
            throw new NotImplementedException();
        }
    }
}

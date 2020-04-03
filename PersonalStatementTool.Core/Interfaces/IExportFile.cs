using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalStatementTool.Core
{
    public interface IExportFile
    {
        void ExportFile(ExportFileSettings fileSettings, PersonalStatement personalStatement);
    }
}
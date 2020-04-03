using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalStatementTool.Core
{
    public class ExportPDFFile : IExportFile
    {
        public string DisplayName { get; } = "PDF";

        public void ExportFile(ExportFileSettings fileSettings, PersonalStatement personalStatement)
        {
            var pdfDocument = CreatePDF(fileSettings, personalStatement);

            try
            {
                pdfDocument.Save($"{fileSettings.DirectoryPath}\\{fileSettings.FileName}.pdf");
            }
            catch (UnauthorizedAccessException e)
            {
                // TODO: Create validation message
                throw;
            }
        }

        private PdfDocument CreatePDF(ExportFileSettings fileSettings, PersonalStatement personalStatement)
        {
            var pdfDocument = new PdfDocument();
            pdfDocument.Info.Author = personalStatement.Author;
            pdfDocument.Info.Creator = "Personal Statement Application";
            var pdfPage = pdfDocument.AddPage();
            var graphics = XGraphics.FromPdfPage(pdfPage);
            var font = new XFont(fileSettings.SelectedFont, fileSettings.FontSize, (XFontStyle)fileSettings.FontStyle);
            var rectangle = new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point);
            graphics.DrawString(personalStatement.FullText, font, XBrushes.Black, rectangle, XStringFormats.TopLeft);

            return pdfDocument;
        }
    }
}
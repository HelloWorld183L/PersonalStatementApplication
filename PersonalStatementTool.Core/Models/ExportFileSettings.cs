using System.Drawing;

namespace PersonalStatementTool.Core
{
    public class ExportFileSettings
    {
        public string FileName { get; set; }
        public string DirectoryPath { get; set; }
        public string SelectedFont { get; set; }
        public int FontSize { get; set; }
        public FontStyle FontStyle { get; set; }
    }
}

using PersonalStatementTool.Core;
using System.Windows.Forms;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing;
using System.Drawing.Text;

namespace PersonalStatementTool.Presentation2
{
    public class ExportViewModel : Stylet.Screen
    {
        public ICommand ExportCommand { get; private set; }
        public ICommand BrowseFileDialogCommand { get; private set; }
        public IList<IExportFile> ExportFiles { get; private set; }
        public Array FontStyles { get; set; }
        public IExportFile ExportFile { get; set; }
        public string FileName { get; set; }
        public string DirectoryPath { get; set; }
        public IList<string> Fonts { get; private set; }
        public string SelectedFont { get; set; }
        public int SelectedFontSize { get; set; }
        public FontStyle SelectedFontStyle { get; set; }
        private PersonalStatement _personalStatement;

        public ExportViewModel() { }

        public ExportViewModel(PersonalStatement personalStatement)
        {
            _personalStatement = personalStatement;
            SetUpFonts();
            SetUpFontStyles();
            SetUpCommands();
            SetUpExportFiles();
        }

        private void OnExport(object _)
        {
            var exportFileSettings = new ExportFileSettings();
            exportFileSettings.FileName = FileName;
            exportFileSettings.DirectoryPath = DirectoryPath;
            exportFileSettings.FontStyle = SelectedFontStyle;
            exportFileSettings.FontSize = SelectedFontSize;
            exportFileSettings.SelectedFont = SelectedFont;

            _personalStatement.FullText.Trim(Environment.NewLine.ToCharArray() );
            ExportFile.ExportFile(exportFileSettings, _personalStatement);
        }

        private void OpenBrowseFileDialog(object _)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the folder that you wish to export your file to...";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryPath = folderBrowserDialog.SelectedPath;
            }
        }

        private void SetUpCommands()
        {
            ExportCommand = new Command(OnExport, (obj) => true);
            BrowseFileDialogCommand = new Command(OpenBrowseFileDialog, (obj) => true);
        }

        private void SetUpFonts()
        {
            Fonts = new List<string>();
            var installedFonts = new InstalledFontCollection().Families;
            foreach (var font in installedFonts)
            {
                Fonts.Add(font.Name);
            }
        }

        private void SetUpFontStyles()
        {
            FontStyles = Enum.GetValues(typeof(FontStyle));
        }

        private void SetUpExportFiles()
        {
            ExportFiles = new List<IExportFile>();
            ExportFiles.Add(new ExportDocxFile());
            ExportFiles.Add(new ExportHTMLFile());
            ExportFiles.Add(new ExportPDFFile());
        }
    }
}
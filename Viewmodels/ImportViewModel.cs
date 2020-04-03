using PersonalStatementTool.Core;
using Stylet;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace PersonalStatementTool.Presentation2
{
    public class ImportViewModel : Stylet.Screen
    {
        public ICommand ImportCommand { get; private set; }
        public ICommand OpenFileDialogCommand { get; private set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }

        public ImportViewModel()
        {
            SetUpCommands();
        }

        private void OnImport(object _)
        {

        }

        private void OpenFileDialog(object _)
        {
            var openFileDialog = new OpenFileDialog();
            
            openFileDialog.Title = "Select the file to import";
            // TODO: Set up open file dialog filter to filter depending on the file type selected
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // TODO: Set the file path
            }

        }

        private void SetUpCommands()
        {
            ImportCommand = new Command(OnImport, (obj) => true);
            OpenFileDialogCommand = new Command(OpenFileDialog, (obj) => true);
        }
    }
}

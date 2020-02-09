using System.Diagnostics;
using System.Windows;

namespace PersonalStatementTool.Presentation2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(statementOutputBox.Text);
        }
    }
}
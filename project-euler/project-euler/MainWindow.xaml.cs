using System.Windows;
using System.Windows.Controls;

namespace project_euler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel VM = new ViewModel();
            DataContext = VM;
        }

        private void txtOutputDisplay_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            (sender as TextBox).ScrollToEnd();
        }
    }
}
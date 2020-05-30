using project_euler.Solutions;
using System.Windows;

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
            comboSolutionSelection.SelectedIndex = 0;
        }

        Functions functions = new Functions();

        private void addToOutput(string msg)
        {
            txtOutputDisplay.AppendText(msg + "\r\n");
            txtOutputDisplay.ScrollToEnd();
        }

        private void btnRunSolution_Click(object sender, RoutedEventArgs e)
        {
            Solution solution = null;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // Increment selection made as combo box indexes from 0. Solutions index from 1.
            int selectionMade = comboSolutionSelection.SelectedIndex + 1;
            addToOutput("———————————————————————————————————————————————————————");
            if (comboSolutionSelection.SelectedIndex >= 0)
            {
                addToOutput("Loading solution for " + comboSolutionSelection.Text);
            }
            switch (selectionMade)
            {
                case 1:
                    solution = new Solution_1();
                    break;
                case 2:
                    solution = new Solution_2();
                    break;
                case 3:
                    solution = new Solution_3();
                    break;
                case 4:
                    solution = new Solution_4();
                    break;
                case 5:
                    solution = new Solution_5();
                    break;
                case 6:
                    solution = new Solution_6();
                    break;
                case 7:
                    solution = new Solution_7();
                    break;
                case 8:
                    solution = new Solution_8();
                    break;
                case 9:
                    solution = new Solution_9();
                    break;
                default:
                    addToOutput("No implementation has been written for this function yet");
                    break;
            }
            addToOutput(solution.ProblemDefinition);
            addToOutput(solution.Answer);
            watch.Stop();
            addToOutput("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
        }
    }
}
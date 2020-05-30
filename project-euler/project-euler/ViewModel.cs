using project_euler.Solutions;
using project_euler.Helper;

namespace project_euler
{
    class ViewModel : ObservableProperty
    {
        public ViewModel()
        {
            solutions = new string[]
            {
                "[1] Multiples of 3 and 5",
                "[2] Fibonacci numbers",
                "[3] Largest prime factor",
                "[4] Largest palindrome product",
                "[5] Smallest multiple",
                "[6] Sum Square Difference",
                "[7] 10001st prime",
                "[8] Largest product in a series",
                "[9] Special Pythagorean triplet"
            };

            selectedSolution = 0;

            RunSolution = new Command(Run,
                () => { return true; });
        }

        private string[] _solutions;

        public string[] solutions
        {
            get
            {
                return _solutions;
            }
            set
            {
                if (_solutions != value)
                {
                    _solutions = value;
                    OnPropertyChanged(nameof(solutions));
                }
            }
        }

        private int _selectedSolution;

        public int selectedSolution
        {
            get { return _selectedSolution; }
            set
            {
                if (_selectedSolution != value)
                {
                    _selectedSolution = value;
                    OnPropertyChanged(nameof(selectedSolution));
                }
            }
        }

        private string _textOutputDisplay;

        public string textOutputDisplay
        {
            get { return _textOutputDisplay; }
            set
            {
                if (_textOutputDisplay != value)
                {
                    _textOutputDisplay = value;
                    OnPropertyChanged(nameof(textOutputDisplay));
                }
            }
        }

        public Command RunSolution { get; private set; }

        private void Run()
        {
            Solution solution = null;
            
            // Increment selection made as combo box indexes from 0. Solutions index from 1.
            int selectionMade = selectedSolution + 1;
            addToOutput("———————————————————————————————————————————————————————");
            if (selectedSolution >= 0)
            {
                addToOutput($"Loading solution for {selectionMade}");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

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

        private void addToOutput(string msg)
        {
            textOutputDisplay += $"{msg} \r\n";
        }
    }
}

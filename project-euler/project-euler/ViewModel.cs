using project_euler.Solutions;
using project_euler.Helpers;
using System;
using System.Threading;
using System.Diagnostics;

namespace project_euler
{
    class ViewModel : ObservableProperty
    {

        #region Fields

        private string[] _solutions;
        private int _selectedSolutionIndex;
        private string _textOutputDisplay;
        private bool _progressVisibility;
        private int _progressPercent;

        private bool _canRun;
        private bool _canCancel;

        private Progress<int> _progress;
        private CancellationTokenSource _tokenSource = null;

        #endregion Fields

        #region Bindable Properties

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
        public int selectedSolutionIndex
        {
            get { return _selectedSolutionIndex; }
            set
            {
                if (_selectedSolutionIndex != value)
                {
                    _selectedSolutionIndex = value;
                    OnPropertyChanged(nameof(selectedSolutionIndex));
                }
            }
        }
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
        public bool progressVisibility
        {
            get { return _progressVisibility; }
            set
            {
                if (_progressVisibility != value)
                {
                    _progressVisibility = value;
                    OnPropertyChanged(nameof(progressVisibility));
                }
            }
        }
        public int progressPercent
        {
            get { return _progressPercent; }
            set
            {
                if (_progressPercent != value)
                {
                    _progressPercent = value;
                    OnPropertyChanged(nameof(progressPercent));
                }
            }
        }

        #endregion Bindable Properties

        #region Constructor

        public ViewModel()
        {
            // Set Initial State
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
                "[9] Special Pythagorean triplet",
                "[10] Summation of primes",
                "[11] Largest product in a grid",
                "[12] Highly divisible triangle number"
            };

            selectedSolutionIndex = 0;

            _progress = new Progress<int>(percent =>
            {
                progressPercent = percent;
            });

            _canRun = true;
            _canCancel = false;
            progressVisibility = false;

            RunSolution = new Command(Run, () => { return _canRun; });
            CancelSolution = new Command(Cancel, () => { return _canCancel; });
        }

        #endregion Constructor

        #region Public Commands

        public Command RunSolution { get; private set; }
        public Command CancelSolution { get; private set; }

        #endregion Public Commands

        #region Private Methods

        private async void Run()
        {
            Solution solution = null;

            // Increment selection made as combo box indexes from 0. Solutions index from 1.
            int selectionMade = selectedSolutionIndex + 1;

            addToOutput("———————————————————————————————————————————————————————");
            if (selectedSolutionIndex >= 0)
            {
                addToOutput($"Loading solution for {selectionMade}");
            }

            switch (selectionMade)
            {
                case 1:
                    solution = new Solution_01();
                    break;
                case 2:
                    solution = new Solution_02();
                    break;
                case 3:
                    solution = new Solution_03();
                    break;
                case 4:
                    solution = new Solution_04();
                    break;
                case 5:
                    solution = new Solution_05();
                    break;
                case 6:
                    solution = new Solution_06();
                    break;
                case 7:
                    solution = new Solution_07();
                    break;
                case 8:
                    solution = new Solution_08();
                    break;
                case 9:
                    solution = new Solution_09();
                    break;
                case 10:
                    solution = new Solution_10();
                    break;
                case 11:
                    solution = new Solution_11();
                    break;
                case 12:
                    solution = new Solution_12();
                    break;
                default:
                    addToOutput("No implementation has been written for this function yet");
                    return;
            }

            _canRun = false;
            _canCancel = true;
            progressVisibility = true;
            progressPercent = 0;

            addToOutput(solution.ProblemDefinition);

            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                await solution.GetAnswer(token, _progress);
                watch.Stop();

                addToOutput(solution.Answer);
                addToOutput($"Time elapsed: {watch.ElapsedMilliseconds} (ms)");
            }

            catch (OperationCanceledException oce)
            {
                addToOutput(oce.Message);
            }

            _canCancel = false;
            _canRun = true;
            progressVisibility = false;
        }
        private void Cancel()
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
            }
        }
        private void addToOutput(string msg)
        {
            textOutputDisplay += $"{msg} \r\n";
        }

        #endregion Private Methods
    }
}

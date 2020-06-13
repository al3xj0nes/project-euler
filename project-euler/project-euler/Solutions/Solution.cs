using System;
using System.Threading;
using System.Threading.Tasks;

namespace project_euler.Solutions
{
    public abstract class Solution
    {
        public abstract string ProblemDefinition { get; }

        public string Answer = "\r\nYou need to run getAnswer before this is available.";

        public virtual async Task GetAnswer(CancellationToken token, IProgress<int> progress = null)
        {

        }
    }
}
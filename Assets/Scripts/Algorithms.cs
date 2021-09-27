using UnityEngine;

namespace Ru1t3rl
{
    public static class Algorithms
    {
        /// <summary>
        /// Gets the corresponding number from the fibonacci sequence
        /// </summary>
        /// <param name="n">The position in the sequence/></param>
        /// <returns>Corresponding number from the sequence</returns>
        public static ulong Fibonacci(int n)
        {
            // I have choosen for ulong since it starts at 0 and has a bigger (positive) range
            ulong a = 0;
            ulong b = 1;
            for (int i = 0; i < n; i++)
            {
                ulong temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
 

// A Dynamic Programming based solution for
// 0-1 Knapsack problem

namespace Knapsack
{
    class KnapsackAlgorithm
    {
        
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Returns the maximum value that
        // can be put in a knapsack of 
        // capacity W
        public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] K = new int[itemsCount + 1, capacity + 1];

            // Build table K[][]
 
            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }
 
            return K[itemsCount, capacity];
        }



        static void Main(string[] args)
        {
            int[] value = { 10, 50, 70 };
            int[] weight = { 10, 20, 30 };
            int capacity = 40;
            int itemsCount = value.Length;
 
            int result = KnapSack(capacity, weight, value, itemsCount);
            Console.WriteLine(result);
        }
    }
}
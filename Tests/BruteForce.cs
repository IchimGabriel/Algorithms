using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
Brute-force search or exhaustive search, is a very general problem-solving technique
that consists of systematically enumerating all possible candidates for the solution and 
checking whether each candidate satisfies the problem’s statement. 
 */
 
namespace BruteForceAlgorithm
{
    class BruteForce
    {
 
        public delegate bool BruteForceTest(ref char[] testChars);
 
        public static bool BruteForce(string testChars, int startLength, int endLength, BruteForceTest testCallback)
        {
            for (int len = startLength; len <= endLength; ++len)
            {
                char[] chars = new char[len];
 
                for (int i = 0; i < len; ++i)
                    chars[i] = testChars[0];
 
                if (testCallback(ref chars))
                    return true;
 
                for (int i1 = len - 1; i1 > -1; --i1)
                {
                    int i2 = 0;
 
                    for (i2 = testChars.IndexOf(chars[i1]) + 1; i2 < testChars.Length; ++i2)
                    {
                        chars[i1] = testChars[i2];
 
                        if (testCallback(ref chars))
                            return true;
 
                        for (int i3 = i1 + 1; i3 < len; ++i3)
                        {
                            if (chars[i3] != testChars[testChars.Length - 1])
                            {
                                i1 = len;
                                goto outerBreak;
                            }
                        }
                    }
 
                outerBreak:
                    if (i2 == testChars.Length)
                        chars[i1] = testChars[0];
                }
            }
 
            return false;
        }
 
 
        static void Main(string[] args)
        {
            BruteForceTest testCallback = delegate(ref char[] testChars)
            {
                var str = new string(testChars);
                return (str == "bbc");
            };
 
 
            bool result = BruteForce("abcde", 1, 5, testCallback);
            Console.WriteLine(result);
        }
    }
}
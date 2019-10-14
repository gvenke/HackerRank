using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HackerRank
{
    class Solution
    {

        // Complete the  function below, replacing s with whatever custom args the challenge calls for.
        static int HackerRankFunc(int n)
        {
            var l = new List<int> { 0, 1 };
            if (n <= 1) {
                return n == 1 ? 1 : 0;
            }
            for (var i = 2; i <= n; i++)
            {
                l.Add(l[i - 1] + l[i - 2]);
            }
            return l.Last();
        }

        static void Main(string[] args)
        {

            Start:
            // custom input goes here
            string s = Console.ReadLine();

            // end custom input

            int result = HackerRankFunc(Int32.Parse(s));

            Console.WriteLine(result);
            goto Start;
        }
    }
}

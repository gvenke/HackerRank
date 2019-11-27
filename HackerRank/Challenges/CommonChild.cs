using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public class CommonChild : HackerRankChallenge
    {

        public CommonChild()
        {
            _args = new string[2];
        }
        protected override void DoAutoTesting()
        {
            Assert.AreEqual(0, commonChild("ssdds", null));
            Assert.AreEqual(0, commonChild(null, "ssdds"));
            Assert.AreEqual(0, commonChild("ssdds", ""));
            Assert.AreEqual(0, commonChild("", "ssdds"));
            Assert.AreEqual(0, commonChild("AA", "BB"), "AA && BB");
            Assert.AreEqual(2, commonChild("HARRY", "SALLY"), "HARRY && SALLY");
            Assert.AreEqual(3, commonChild("ABCD", "ABDC"), "ABCD && ABDC");
            Assert.AreEqual(2, commonChild("ABCDEF", "FBDAMN"), "ABCDEF && FBDAMN");
            Assert.AreEqual(3, commonChild("SHINCHAN", "NOHARAAA"), "SHINCHAN && NOHARAAA");
            Assert.AreEqual(3, commonChild("FDAGCXGKCT", "CGTRMEZEPX"), "FDAGCXGKCT && CGTRMEZEPX");
        }

        public override object RunManualTest()
        {
            var s1 = _args[0];
            var s2 = _args[1];
            return commonChild(s1, s2);
        }

        private int commonChild(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                return 0;
            }
            int l1 = s1.Length, l2 = s2.Length;

            //create 2D grid representing x & y pos of each char
            int[,] grid = new int[l1 + 1, l2 + 1];

            // first column & row of the lookup table will be all 0. We need
            for (int i = 0; i <= l1; i++)
                grid[i, 0] = 0;

            // first row of the lookup table will be all 0
            for (int j = 0; j <= l2; j++)
                grid[0, j] = 0;

            // fill the lookup table in bottom-up manner
            for (int x = 1; x <= l1; x++)
            {
                for (int y = 1; y <= l2; y++)
                {
                    // if current character of X and Y matches
                    if (s1[x - 1] == s2[y - 1])
                        grid[x, y] = grid[x - 1, y - 1] + 1;

                    // else if current character of X and Y don't match
                    else
                        grid[x, y] = Math.Max(grid[x - 1, y], grid[x, y - 1]);
                }
            }

            // LCS will be last entry in the lookup table
            return grid[l1, l2];
        }
    }
}

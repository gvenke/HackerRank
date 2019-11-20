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
            //Assert.AreEqual(15, commonChild("WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS", "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC"), "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHK && FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC");
        }

        public override object RunManualTest()
        {
            var s1 = _args[0];
            var s2 = _args[1];
            return commonChild(s1, s2);
        }

        private int commonChild(string s1, string s2, bool recurse = false)
        {
            if ((s1 == null || s2 == null) || (s1 == "" || s2 == "") || s1.Length != s2.Length)
            {
                return 0;
            }
            var sb = new StringBuilder();
            var matches = new List<int>();
            var lhs = new HashSet<Tuple<char, int>>();
            var rhs = new HashSet<Tuple<char, int>>();
            for (var x = 0; x < s1.Length; x++)
            {
                var c1 = s1[x];
                for (var y = 0; y < s2.Length; y ++)
                {
                    var c2 = s2[y];
                    if (c1 == c2)
                    {
                        lhs.Add(new Tuple<char, int>(c1, x));
                        rhs.Add(new Tuple<char, int>(c2, y));
                    }
                }
            }
            if (lhs.Count == 0 || rhs.Count == 0)
            {
                return 0;
            }

            Tuple<char, int>[] primary;
            Tuple<char, int>[] secondary;
            if (lhs.Count > rhs.Count)
            {
                primary = lhs.OrderBy(o => o.Item2).ToArray();
                secondary = rhs.OrderBy(o => o.Item2).ToArray();
            } else
            {
                primary = rhs.OrderBy(o => o.Item2).ToArray();
                secondary = lhs.OrderBy(o => o.Item2).ToArray();
            }
            
            //var reset = false;
            //Start:
            foreach (var primaryItem in primary)
            {
                char charToTarget = primaryItem.Item1;
                var secondaryItem = secondary.First(o => o.Item1 == primaryItem.Item1);
                int curMatchThreshold = -1;
                int startIndex = -1;
 
                startIndex = Array.IndexOf(primary, new Tuple<char, int>(charToTarget, primaryItem.Item2));

                for (var i = startIndex; i < primary.Length; i++)
                {
                    var item = primary[i];
                    var match = secondary.FirstOrDefault(o => o.Item1 == item.Item1 && o.Item2 > curMatchThreshold);
                    if (match != null)
                    {
                        sb.Append(match.Item1);
                        curMatchThreshold = match.Item2;
                    }
                }
                if (sb.Length > 0)
                {
                    matches.Add(sb.Length);
                    sb.Length = 0;
                }
                startIndex = Array.IndexOf(secondary, new Tuple<char, int>(charToTarget, secondaryItem.Item2));

                for (var i = startIndex; i < secondary.Length; i++)
                {
                    var item = secondary[i];
                    var match = primary.FirstOrDefault(o => o.Item1 == item.Item1 && o.Item2 > curMatchThreshold);
                    if (match != null)
                    {
                        sb.Append(match.Item1);
                        curMatchThreshold = match.Item2;
                    }
                }
                if (sb.Length > 0)
                {
                    matches.Add(sb.Length);
                    sb.Length = 0;
                }
                //if (!reset)
                //{
                //    reset = true;

                //}

            }

            return matches.Count == 0 ? 0 : matches.Max(o => o);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public class SherlockString: HackerRankBase
    {
        public override object RunManualTest()
        {
            string s = _args[0];
            return GetValidString(s);
        }

        internal override void DoAutoTesting()
        {
            Assert.AreEqual("YES", GetValidString("abcd"), "abcd is valid");
            Assert.AreEqual("YES", GetValidString("abbcd"), "abbcd is valid");
            Assert.AreEqual("YES", GetValidString("aaaaab"), "aaaaab is valid");
            Assert.AreEqual("YES", GetValidString("aaabbbb"), "aaabbbb is valid");
            Assert.AreEqual("YES", GetValidString("aaaaab"), "aaaaab is valid");
            Assert.AreEqual("YES", GetValidString("abababab"), "abababab is valid");

            Assert.AreEqual("NO", GetValidString("abcdddd"), "abcdddd is not valid");
            Assert.AreEqual("NO", GetValidString("abvssmma"), "abvssmma is not valid");

        }

        public SherlockString()
        {
            _args = new string[1];
        }

        private string GetValidString(string s)
        {
            var dupeChecker = new Dictionary<char, int>();
            foreach (var curChar in s)
            {
                if (dupeChecker.ContainsKey(curChar))
                {
                    dupeChecker[curChar]++;
                }
                else
                {
                    dupeChecker.Add(curChar, 1);
                }
            }
            bool invalidString = false;
            var groups = dupeChecker.GroupBy(o => o.Value, (count, occurrences) => new { Count = count, Occurrences = occurrences.Count() });
            int groupCount = groups.Count();
            if (groupCount > 2)
            {
                invalidString = true;
            }
            else
            {
                if (groupCount == 2)
                {
                    var occurrencesOne = groups.FirstOrDefault(o => o.Occurrences == 1);
                    if (occurrencesOne == null)
                    {
                        invalidString = true;
                    }
                    else
                    {
                        if (occurrencesOne.Count > 1)
                        {
                            var occurrencesMany = groups.First(o => o.Count != occurrencesOne.Count);
                        
                            if (occurrencesMany.Count > occurrencesOne.Count && occurrencesMany.Occurrences > 1)
                            {
                                invalidString = true;
                            }
                            else
                            {
                                if (occurrencesMany.Occurrences > 1)
                                {
                                    if (occurrencesOne.Count - occurrencesMany.Count > 1)
                                    {
                                        invalidString = true; ;
                                    }
                                } else
                                {
                                    invalidString = occurrencesMany.Count > 1 && Math.Abs(occurrencesOne.Count - occurrencesMany.Count) > 1;
                                }
                            }
                        }
                    }
                }
            }
            return invalidString ? "NO" : "YES";
        }
    }
}

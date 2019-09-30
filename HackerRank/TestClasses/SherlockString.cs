using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public class SherlockString: HackerRankBase
    {
        public override object TestFunction()
        {
            string s = Args[0].ToString();
            return GetValidString(s);
        }
        protected override void DoAutoTesting()
        {
            Assert.AreEqual(GetValidString("abcd"), "YES", "abcd is valid");
            Assert.AreEqual(GetValidString("abbcd"), "YES", "abbcd is valid");
            Assert.AreEqual(GetValidString("aaaaab"), "YES", "aaaaab is valid");
            Assert.AreEqual(GetValidString("aaabbbb"), "YES", "aaabbbb is valid");
            Assert.AreEqual(GetValidString("aaaaab"), "YES", "aaaaab is valid");
            Assert.AreEqual(GetValidString("abababab"), "YES", "abababab is valid");

            Assert.AreEqual(GetValidString("abcdddd"), "NO", "abcdddd is not valid");
            Assert.AreEqual(GetValidString("abvssmma"), "NO", "abvssmma is not valid");

        }

        public SherlockString()
        {
            _args = new object[1];
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

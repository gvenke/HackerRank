using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public class SherlockAndAnagrams : HackerRankChallenge
    {

        public override object RunManualTest()
        {
            string s = _args[0];
            return sherlockAndAnagrams(s);
        }

        public SherlockAndAnagrams()
        {
            _args = new string[1];
        }

        protected override void DoAutoTesting()
        {
            Assert.AreEqual(0, sherlockAndAnagrams(null), "NULL");
            Assert.AreEqual(0, sherlockAndAnagrams(""), "EMPTY STRING");
            Assert.AreEqual(2, sherlockAndAnagrams("mom"), "mom");
            Assert.AreEqual(4, sherlockAndAnagrams("abba"), "abba");
            Assert.AreEqual(0, sherlockAndAnagrams("abcd"), "abcd");
            Assert.AreEqual(10, sherlockAndAnagrams("kkkk"), "kkkk");
            Assert.AreEqual(5, sherlockAndAnagrams("cdcd"), "cdcd");
            Assert.AreEqual(3, sherlockAndAnagrams("ifailuhkqq"), "ifailuhkqq");
        }

        private int sherlockAndAnagrams(string s)
        {
            int count = 0;
            int charSlice = 1;
            if (s != null)
            {
                while (charSlice < s.Length)
                {
                    for (var i = 0; i <= s.Length - charSlice; i++)
                    {
                        var s1 = s.Substring(i, charSlice);
                        for (var n = i + 1; n <= s.Length - charSlice; n++)
                        {
                            var s2 = s.Substring(n, charSlice);

                            if (s1 == s2)
                            {
                                count++;
                            } else
                            {
                                var ca2 = s2.ToCharArray();
                                bool isAnaGram = true;
                                foreach(var c in s1)
                                {
                                    int index = Array.IndexOf(ca2, c);

                                    if (index == -1)
                                    {
                                        isAnaGram = false;
                                        break;                                        
                                    }
                                    ca2[index] = '\u0000';
                                }
                                if (isAnaGram)
                                {
                                    count++;
                                }
                            }
                        }             
                    }
                    charSlice++;
                }
                return count;
            }
            return 0;
        }
    }
}

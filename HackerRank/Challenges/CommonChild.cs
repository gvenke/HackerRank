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
            //Assert.AreEqual(15, commonChild("WEWOUCUIDG CGTRMEZEPX ZFEJWISRSB BSYXAYDFEJ JDLEBVHHKS", "FDAGCXGKCT KWNECHMRXZ WMLRYUCOCZ HJRRJBOAJO QJZZVUYXIC"), "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHK && FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC");
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
            int innerStartIndex = 0;
            int outerStartIndex = 0;
            bool matchFound = false;
            while (outerStartIndex < s1.Length)
            {
                for (var n = outerStartIndex; n < s1.Length; n++)
                {
                    var c1 = s1[n]; 
                    for (var i = innerStartIndex; i < s2.Length; i++)
                    {
                        var c2 = s2[i];
                        if (c2 == c1)
                        {
                            matchFound = true;
                            sb.Append(c1);
                            innerStartIndex = i + 1;
                            break;
                        }
                    }
                }



                if (sb.Length > 0)
                {
                    matches.Add(sb.Length);
                    sb.Length = 0;                    
                }
                outerStartIndex++;
                innerStartIndex = 0;
            }
           // var recursematchCount = recurse ? commonChild(s2, s1, false) : 0;
            var matchCount = matches.Count == 0 ? 0 : matches.Max(o => o);

            return matchCount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
//    public class CommonChild : HackerRankChallenge
//    {

//        public CommonChild()
//        {
//            _args = new string[2];
//        }
//        protected override void DoAutoTesting()
//        {
//            Assert.AreEqual(0, commonChild("ssdds", null));
//            Assert.AreEqual(0, commonChild(null, "ssdds"));
//            Assert.AreEqual(0, commonChild("ssdds", ""));
//            Assert.AreEqual(0, commonChild("", "ssdds"));
//            Assert.AreEqual(0, commonChild("AA", "BB"), "AA && BB");
//            Assert.AreEqual(2, commonChild("HARRY", "SALLY"), "HARRY && SALLY");
//            Assert.AreEqual(3, commonChild("ABCD", "ABDC"), "ABCD && ABDC");
//            Assert.AreEqual(2, commonChild("ABCDEF", "FBDAMN"), "ABCDEF && FBDAMN");
//            Assert.AreEqual(3, commonChild("SHINCHAN", "NOHARAAA"), "SHINCHAN && NOHARAAA");
//            //Assert.AreEqual(3, commonChild("FDAGCXGKCT", "CGTRMEZEPX"), "FDAGCXGKCT && CGTRMEZEPX");
//            //Assert.AreEqual(15, commonChild("WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS", "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC"), "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHK && FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC");
//        }

//        public override object RunManualTest()
//        {
//            var s1 = _args[0];
//            var s2 = _args[1];
//            return commonChild(s1, s2);
//        }

//        private int commonChild(string s1, string s2, bool recurse = false)
//        {
//            if ((s1 == null || s2 == null) || (s1 == "" || s2 == "") || s1.Length != s2.Length)
//            {
//                return 0;
//            }
//            var matches = new List<List<Tuple<char, int>>>();
//            for (var i = 0; i < s1.Length; i++)
//            {
//                matches.Add(new List<Tuple<char, int>>());
//            }

//            //for (var i = 0; i < s2.Length; i++)
//            //{
//            //    var c = s2[i];
//            //    foreach(var curList in matches)
//            //    {
//            //        var curMatch = curList.FirstOrDefault(o => o.Item1 == c && o.Item2 )
//            //    }
//            //}
//        }
//    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public class HighValuePalidrome : HackerRankBase
    {
        public HighValuePalidrome()
        {
            _args = new object[3];
        }
        internal override void DoAutoTesting()
        {
            Assert.AreEqual("3993", HighestValuePalindrome("3943", 4, 1), "3943  should convert to 3993");
            Assert.AreEqual("3993", HighestValuePalindrome("3493", 4, 1), "3493  should convert to 3993");
            Assert.AreEqual("3443", HighestValuePalindrome("3423", 4, 2), "3423  should convert to 3443");
            Assert.AreEqual("34143", HighestValuePalindrome("34123", 5, 1), "34123  should convert to 34143");
            Assert.AreEqual("-1", HighestValuePalindrome("39821", 5, 1), "39821  should not convert");
            Assert.AreEqual("312515213", HighestValuePalindrome("310015213", 9, 2), "310015213  should convert to 312515213");
            Assert.AreEqual("912515219", HighestValuePalindrome("310015213", 9, 4), "310015213  should convert to 912515219");
            Assert.AreEqual("912595219", HighestValuePalindrome("310015213", 9, 5), "310015213  should convert to 912595219");
        }

        public override object RunManualTest()
        {
            string s = _args[0].ToString();
            int n = (int)_args[1];
            int k = (int)_args[2];

            return HighestValuePalindrome(s, n, k);
        }

        private string HighestValuePalindrome(string s, int n, int k)
        {
            char maxChar = '9';
            int changeTracker = k;
            int numberConversion;
            int indexToBrakeAt = -1;
            if (n != s.Length)
            {
                return "-1";
            }
            else if (!int.TryParse(s, out numberConversion))
            {
                return "-1";
            }

            var sb = new StringBuilder(s);
            int deadCenterIndex = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (changeTracker == 0 || indexToBrakeAt == i)
                {
                    break;
                }

                int curFromEndIndex = s.Length - 1 - i;
                char curFromStart = s[i];
                char curFromEnd = s[curFromEndIndex];
               

                if (curFromEndIndex != i)
                {
                    if (curFromStart != curFromEnd) 
                    {
                        if ((int)curFromStart > (int)curFromEnd)
                        {
                            sb.Replace(curFromEnd, curFromStart, curFromEndIndex, 1);
                        }
                        else
                        {
                            sb.Replace(curFromStart, curFromEnd, i, 1);
                        }
                        changeTracker--;
                        indexToBrakeAt = curFromEndIndex;
                    } 
                }
                else
                {
                    deadCenterIndex = i;
                }



            }

            if (changeTracker > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (changeTracker == 1)
                    {
                        if (deadCenterIndex > -1)
                        {
                            char charToReplace = s[deadCenterIndex];
                            sb.Replace(charToReplace, maxChar, deadCenterIndex, 1);
                            changeTracker--;
                        }
                    } else
                    {
                        int curFromEndIndex = s.Length - 1 - i;
                        char curFromStart = s[i];
                        char curFromEnd = s[curFromEndIndex];
                        sb.Replace(curFromEnd, maxChar, curFromEndIndex, 1).Replace(curFromStart, maxChar, i, 1);
                        changeTracker -= 2;
                    } 
                    if (changeTracker == 0)
                    {
                        break;
                    }
                }

            }

            var rv = sb.ToString();
            var rvr = new string(rv.Reverse().ToArray());
            return rv == rvr ? rv : "-1";
        }
    }
}

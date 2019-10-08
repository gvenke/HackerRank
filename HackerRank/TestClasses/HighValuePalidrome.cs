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
            _args = new string[3];
        }
        internal override void DoAutoTesting()
        {
            Assert.AreEqual("3993", HighestValuePalindrome("3943", 4, 1));
            Assert.AreEqual("3443", HighestValuePalindrome("3423", 4, 1));
            Assert.AreEqual("3993", HighestValuePalindrome("3423", 4, 2));
            Assert.AreEqual("34143", HighestValuePalindrome("34123", 5, 1));
            Assert.AreEqual("-1", HighestValuePalindrome("39821", 5, 1));

            Assert.AreEqual("312515213", HighestValuePalindrome("310015213", 9, 2));
            Assert.AreEqual("912515219", HighestValuePalindrome("310015213", 9, 4));
            Assert.AreEqual("912595219", HighestValuePalindrome("310015213", 9, 5));
            Assert.AreEqual("992299", HighestValuePalindrome("092282", 6, 3));
            Assert.AreEqual("992299", HighestValuePalindrome("932239", 6, 2));
        }

        public override object RunManualTest()
        {
            string s = _args[0].ToString();
            int n = Int32.Parse(_args[1]);
            int k = Int32.Parse(_args[2]);

            return HighestValuePalindrome(s, n, k);
        }

        private string HighestValuePalindrome(string s, int n, int k)
        {
            int diffs = 0;
            char maxChar = '9';
            int changeTracker = k;
            int numberConversion;
            bool hasCenter = false;
            if (n != s.Length)
            {
                return "-1";
            }
            else if (!int.TryParse(s, out numberConversion))
            {
                return "-1";
            }

            var sb = new StringBuilder(s);
            for (int i = 0; i < s.Length; i++)
            {

                int curFromEndIndex = s.Length - 1 - i;
                char curFromStart = s[i];
                char curFromEnd = s[curFromEndIndex];
               




                if (curFromEndIndex > i)
                {
                    if (curFromStart != curFromEnd)
                    {
                        diffs++;
                        changeTracker--;
                    }
                }
                else if (curFromEndIndex < i)
                {
                    break;
                } else
                {
                    hasCenter = true;
                }               
            }

            changeTracker = k;
            for (int i = 0; i < s.Length; i++)
            {
                int curFromEndIndex = s.Length - 1 - i;
                char curFromStart = s[i];
                char curFromEnd = s[curFromEndIndex];
                int diffsRemaining = changeTracker - diffs;
                int charGap = curFromEndIndex - i;                
                if (changeTracker == 0 || charGap < 0)
                {
                    break;
                } 
                bool twoChanges = changeTracker > 1 && ((diffsRemaining > 0 && curFromEnd != curFromStart && !hasCenter) || (diffsRemaining > 1)) && charGap > 0 && (curFromStart != maxChar && curFromEnd != maxChar);
                bool oneChange = !twoChanges && changeTracker > 0 && ((curFromEnd != curFromStart && charGap > 0) || charGap == 0);

                if (twoChanges)
                {
                    sb.Replace(curFromEnd, maxChar, curFromEndIndex, 1).Replace(curFromStart, maxChar, i, 1);
                    changeTracker -= 2;
                } else if (oneChange)
                {
                    char oldChar;
                    char newChar;
                    int newCharIndex;

                    if (charGap == 0)
                    {
                        oldChar = curFromStart;
                        newChar = maxChar;
                        newCharIndex = i;
                    } else {
                        if ((int)curFromStart > (int)curFromEnd)
                        {
                            oldChar = curFromEnd;
                            newChar = curFromStart;
                           
                            newCharIndex = curFromEndIndex;
                        } else
                        {
                            oldChar = curFromStart;
                            newChar = curFromEnd;
                            newCharIndex = i;
                        }
                    }
                    sb.Replace(oldChar, newChar, newCharIndex, 1);
                    changeTracker--;
                }

            }

            var rv = sb.ToString();
            var rvr = new string(rv.Reverse().ToArray());
            return rv == rvr ? rv : "-1";
        }
    }
}

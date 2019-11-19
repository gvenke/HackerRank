using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    public class HighValuePalidrome : HackerRankChallenge
    {
        public HighValuePalidrome()
        {
            _args = new string[3];
        }

        protected override void DoAutoTesting()
        {
            Assert.AreEqual("3993", HighestValuePalindrome("3943", 4, 1));
            Assert.AreEqual("3443", HighestValuePalindrome("3423", 4, 1));
            Assert.AreEqual("3993", HighestValuePalindrome("3423", 4, 2));
            Assert.AreEqual("34143", HighestValuePalindrome("34123", 5, 1));
            Assert.AreEqual("-1", HighestValuePalindrome("39821", 5, 1));
            Assert.AreEqual("-1", HighestValuePalindrome("39821", 6, 1));
            Assert.AreEqual("-1", HighestValuePalindrome("39*21", 5, 1));
            Assert.AreEqual("99999", HighestValuePalindrome("39821", 5, 5));
            Assert.AreEqual("312515213", HighestValuePalindrome("310015213", 9, 2));
            Assert.AreEqual("912515219", HighestValuePalindrome("310015213", 9, 4));
            Assert.AreEqual("919515919", HighestValuePalindrome("310015213", 9, 5));
            Assert.AreEqual("992299", HighestValuePalindrome("092282", 6, 3));
            Assert.AreEqual("992299", HighestValuePalindrome("932239", 6, 2));
            Assert.AreEqual("99399", HighestValuePalindrome("11331", 5, 4));
        }

        public override object RunManualTest()
        {
            string s = _args[0];
            int n = Int32.Parse(_args[1]);
            int k = Int32.Parse(_args[2]);

            return HighestValuePalindrome(s, n, k);
        }

        private string HighestValuePalindrome(string s, int n, int k)
        {
            const string invalidResult = "-1";            

            // determine if arg passed for string length matches the actual string length
            if (n != s.Length)
            {
                return invalidResult;
            }

            int diffs = 0;
            const char maxChar = '9';            
            int changeTracker = k;
            var sb = new StringBuilder(s);

            //calculate differences
            for (int i = 0; i < s.Length; i++)
            {
                int numberConversion;
                int curFromEndIndex = s.Length - 1 - i;
                char curFromStart = s[i];
                char curFromEnd = s[curFromEndIndex];

                // determine if current chars are valid numbers
                if (!int.TryParse(curFromStart.ToString(), out numberConversion) || !int.TryParse(curFromEnd.ToString(), out numberConversion))
                {
                    return invalidResult;
                }

                if (curFromEndIndex > i)
                {
                    if (curFromStart != curFromEnd)
                    {
                        diffs++;
                    }
                }
                else if (curFromEndIndex < i)
                {
                    break;
                }            
            }

            // calculate changes
            for (int i = 0; i < s.Length; i++)
            {
                int curFromEndIndex = s.Length - 1 - i;
                int charGap = curFromEndIndex - i;

                // break if you run out of changes or you pass the halfway point
                if (changeTracker == 0 || charGap < 0)
                {
                    break;
                }

                int changesToMake = 0;                
                char curFromStart = s[i];
                char curFromEnd = s[curFromEndIndex];
                int spareChanges = changeTracker - diffs;                            
                char oldChar = '0';
                char newChar = '0';
                int newCharIndex = -1;
                
                if (charGap == 0)
                {
                    if (changeTracker > 0)
                    {
                        // replace center char with "9"
                        oldChar = curFromStart;
                        newChar = maxChar;
                        newCharIndex = i;
                        changesToMake = 1;
                    }
                } else
                {
                    if (curFromStart == curFromEnd)
                    {
                        // change both chars to "9" if both chars are equal and there are changes to spare
                        if (changeTracker > 1 && spareChanges > 1 && (curFromStart != maxChar && curFromEnd != maxChar))
                        {
                            changesToMake = 2;
                        }
                    } else
                    {
                        if (changeTracker > 1)
                        {
                            if (spareChanges > 0 && (curFromStart != maxChar && curFromEnd != maxChar))
                            {
                                // change both chars to "9" if both chars are unequal (and neither is already "9") and there are changes to spare
                                changesToMake = 2;
                            } else
                            {
                                // change the low-value char to match the high one if chars are unequal and there are no spare changes
                                if (curFromStart > curFromEnd)
                                {
                                    oldChar = curFromEnd;
                                    newChar = curFromStart;
                                    newCharIndex = curFromEndIndex;
                                }
                                else
                                {
                                    oldChar = curFromStart;
                                    newChar = curFromEnd;
                                    newCharIndex = i;
                                }
                                changesToMake = 1;
                            }
                        } else
                        {
                            // change the low-value char to match the high one if chars are unequal and there are no spare changes
                            if (curFromStart > curFromEnd)
                            {
                                oldChar = curFromEnd;
                                newChar = curFromStart;
                                newCharIndex = curFromEndIndex;
                            }
                            else
                            {
                                oldChar = curFromStart;
                                newChar = curFromEnd;
                                newCharIndex = i;
                            }
                            changesToMake = 1;
                        }
                    }
                }

                // make changes
                if (changesToMake == 1)
                {
                    sb.Replace(oldChar, newChar, newCharIndex, 1);
                    diffs--;
                    changeTracker--;

                } else if (changesToMake == 2)
                {
                    sb.Replace(curFromEnd, maxChar, curFromEndIndex, 1).Replace(curFromStart, maxChar, i, 1);
                    changeTracker -= 2;
                    if (curFromEnd != curFromStart)
                    {
                        diffs--;
                    }
                }
            }

            // determine whether the result is a palidrome
            var rv = sb.ToString();
            var rvr = new string(rv.Reverse().ToArray());
            return rv == rvr ? rv : invalidResult;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class SherlockString: HackerRankBase
    {
        public override object TestFunction()
        {
            string s = Args[0].ToString();
            return GetValidString(s);
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
                                        invalidString = true;
                                    }
                                } else
                                {
                                    invalidString = occurrencesMany.Count > 1 && 
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

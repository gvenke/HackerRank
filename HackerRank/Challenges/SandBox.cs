using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HackerRank
{
    public class SandBox : HackerRankChallenge
    {
        private static string MatchMax = "";
        public override object RunManualTest()
        {

            var s1 = "ELGGYJWKTDHLXJRBJLRYEJWVSUFZKYHOIKBGTVUTTOCGMLEXWDSXEBKRZTQUVCJNGKKRMUUBACVOEQKBFFYBUQEMYNENKYYGUZSP";
            var s2 = "FRVIFOVJYQLVZMFBNRUTIYFBMFFFRZVBYINXLDDSVMPWSQGJZYTKMZIPEGMVOUQBKYEWEYVOLSHCMHPAZYTENRNONTJWDANAMFRX";

            //var s1 = "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS";
            //var s2 = "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC";

            int maxLength = GetMaxLength(s1, s2);

            return maxLength;
        }

        private int GetMaxLength(string s1, string s2)
        {
            int x = s1.Length, y = s2.Length;

            // lookup table stores solution to already computed sub-problems
            // i.e. lookup[i,j] stores the length of LCS of substring
            // X[0..i-1] and Y[0..j-1]
            int[,] lookup = new int[x + 1, y + 1];

            // first column of the lookup table will be all 0
            for (int i = 0; i <= x; i++)
                lookup[i, 0] = 0;

            // first row of the lookup table will be all 0
            for (int j = 0; j <= y; j++)
                lookup[0, j] = 0;

            // fill the lookup table in bottom-up manner
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= y; j++)
                {
                    // if current character of X and Y matches
                    if (s1[i - 1] == s2[j - 1])
                        lookup[i, j] = lookup[i - 1, j - 1] + 1;

                    // else if current character of X and Y don't match
                    else
                        lookup[i, j] = Math.Max(lookup[i - 1, j], lookup[i, j - 1]);
                }
            }

            // LCS will be last entry in the lookup table
            return lookup[x, y];
        }


        private class CharPlot
        {
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }
            public char Character { get; set; }
            public bool Plotted { get; set; }
            public int Id { get; set; }
            public List<int> ReferenceIds { get;} = new List<int>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HackerRank
{
    public class SandBox : HackerRankChallenge
    {
        public override object RunManualTest()
        {

            var s1 = "WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS";
            var s2 = "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC";

            //var s1 = "ABCD";
            //var s2 = "ABDC";
            int l = s1.Length;
            var matches = new HashSet<string>();
            var posTracker = new Dictionary<Tuple<int, int>,char>();
            for (var x = 0; x < l; x++)
            {
                var xChar = s1[x];
                for (var y = 0; y < l; y++)
                {
                    var yChar = s2[y];
                    if (xChar == yChar)
                    {
                        posTracker.Add(new Tuple<int, int>(x, y), xChar);
                    }
                }
            }
            var sb = new StringBuilder();
            foreach (var t in posTracker.Keys)
            {
                PlotGrid(t,"",matches,posTracker);
            }

            return matches.Max(o => o.Length);
        }

        private void PlotGrid(Tuple<int, int> t, string s,HashSet<string> matches, Dictionary<Tuple<int, int>, char> posTracker)
        {
            var xStartPos = t.Item1;
            var yStartPos = t.Item2;
            var curMax = matches.Count == 0 ? 0 : matches.Max(o => o.Length);
            var c = posTracker[t];
            s += c;       
            var xNewStartPos = xStartPos + 1;
            var nextMatches = posTracker.Where(o => o.Key.Item1 > xStartPos && o.Key.Item2 > yStartPos);





            if (nextMatches.Count() == 0)
            {
                if (s.Length > curMax)
                {
                    matches.Add(s);
                }
                

                return;
            }
            var minX = nextMatches.Min(o => o.Key.Item1);
            var maxX = nextMatches.Max(o => o.Key.Item1);
            var minY = nextMatches.Min(o => o.Key.Item2);
            var maxY = nextMatches.Max(o => o.Key.Item2);

            int xPlotsRemaining = maxX - minX;
            int yPlotsRemaining = maxY - minY;
            int  distanceFromCurMax = curMax - s.Length;

            if (distanceFromCurMax <= xPlotsRemaining && distanceFromCurMax <= yPlotsRemaining)
            {
                foreach (var kvp in nextMatches)
                {
                    PlotGrid(kvp.Key, s, matches, posTracker);
                }
            }


        }
    }
}

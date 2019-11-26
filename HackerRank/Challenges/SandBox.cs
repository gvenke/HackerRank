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

            //var s1 = "HARRY";
            //var s2 = "HARRY";

            int l = s1.Length;
            var matches = new HashSet<string>();
            var plots = new List<CharPlot>();
            for (var x = 0; x < l; x++)
            {
                var xChar = s1[x];
                for (var y = 0; y < l; y++)
                {
                    var yChar = s2[y];
                    if (xChar == yChar)
                    {
                        // posTracker.Add(new Tuple<int, int>(x, y), xChar);
                        plots.Add(new CharPlot { XCoordinate = x, YCoordinate = y, Character = xChar, Id = y+1 });
                    }
                }
            }
            var plotMap = plots.OrderBy(o => o.XCoordinate).ThenBy(o => o.YCoordinate);
            var sb = new StringBuilder();
            //bool plotComplete = false;

            CharPlot curPlot = plotMap.FirstOrDefault(o => !o.Plotted);
            if (curPlot == null)
            {
                return 0;
            }
            CharPlot startPlot = curPlot;
            var plotTrail = new List<CharPlot> { curPlot };
            int targetId = curPlot.Id;
            bool backTracked = false;
            while (curPlot != null)
            {
               

                var nextPlot = plotMap.FirstOrDefault(o => o.XCoordinate > curPlot.XCoordinate && o.YCoordinate > curPlot.YCoordinate && (!backTracked || o.ReferenceId != startPlot.Id));
                backTracked = false;
                // no nextplot found. 
                if (nextPlot == null)
                {
                    curPlot.Plotted = true;
                    var s = GetPlotString(plotTrail);
                    if (s.Length > MatchMax.Length) {
                        MatchMax = s;
                    }

                    // can't back up any more. Find another plot to survey
                    if (curPlot.Equals(startPlot))
                    {
                        plotTrail.Clear();
                        curPlot = plotMap.FirstOrDefault(o => !o.Plotted);
                        startPlot = curPlot;
                        plotTrail.Add(curPlot);
                    // back up to previous position
                    } else
                    {
                        plotTrail.Remove(curPlot);
                        curPlot = plotTrail.Last();
                        backTracked = true;
                    }                    
                }
                else
                {
                    nextPlot.ReferenceId = startPlot.Id;
                    curPlot = nextPlot;
                    plotTrail.Add(curPlot);
                }
            }

            return MatchMax.Length;
        }

        private string GetPlotString(IEnumerable<CharPlot> plots)
        {
            var sb = new StringBuilder();
            foreach (var p in plots)
            {
                sb.Append(p.Character);
            }
            return sb.ToString();
        }

        //private void PlotGrid(Tuple<int, int> t, string s,HashSet<string> matches, Dictionary<Tuple<int, int>, char> posTracker)
        //{
        //    var xStartPos = t.Item1;
        //    var yStartPos = t.Item2;
        //    var curMax = matches.Count == 0 ? 0 : matches.Max(o => o.Length);
        //    var c = posTracker[t];
        //    s += c;       
        //    var xNewStartPos = xStartPos + 1;
        //    var nextMatches = posTracker.Where(o => o.Key.Item1 > xStartPos && o.Key.Item2 > yStartPos);





        //    if (nextMatches.Count() == 0)
        //    {
        //        if (s.Length > curMax)
        //        {
        //            matches.Add(s);
        //        }


        //        return;
        //    }
        //    var minX = nextMatches.Min(o => o.Key.Item1);
        //    var maxX = nextMatches.Max(o => o.Key.Item1);
        //    var minY = nextMatches.Min(o => o.Key.Item2);
        //    var maxY = nextMatches.Max(o => o.Key.Item2);

        //    int xPlotsRemaining = maxX - minX;
        //    int yPlotsRemaining = maxY - minY;
        //    int  distanceFromCurMax = curMax - s.Length;

        //    if (distanceFromCurMax <= xPlotsRemaining && distanceFromCurMax <= yPlotsRemaining)
        //    {
        //        foreach (var kvp in nextMatches)
        //        {
        //            PlotGrid(kvp.Key, s, matches, posTracker);
        //        }
        //    }


        //}

        private class CharPlot
        {
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }
            public char Character { get; set; }
            public bool Plotted { get; set; }
            public int Id { get; set; }
            //public List<int> Ids { get;} = new List<int>();
            public int ReferenceId { get; set; }
        }
    }
}

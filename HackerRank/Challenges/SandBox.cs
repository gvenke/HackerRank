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
            int i;
            var sb = new StringBuilder();
            for (i=0; i<=10;i++)
            {
                sb.Append($"{i} ");
            }
            return sb.ToString();
        }
    }
}

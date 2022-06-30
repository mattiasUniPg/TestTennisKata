using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTennisKata
{
    internal class Result
    {
        public ResultTypes resPalyer1 { get; set; }
        public ResultTypes resPalyer2 { get; set; }

        public override string? ToString()
        {
            return resPalyer1 != resPalyer2 ? $"{resPalyer1} - {resPalyer2}" : $"{resPalyer1}";
        }
    }
}

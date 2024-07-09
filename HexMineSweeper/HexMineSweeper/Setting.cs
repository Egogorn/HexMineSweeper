using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexMineSweeper
{
    internal class Setting
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Size Size { get; set; }
        public int MineCount { get; set; }
        public override string ToString() { return Text; }
    }
}

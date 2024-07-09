namespace HexMineSweeper
{
    internal class Tile
    {
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public int CloseMines { get; set; }
        public Tile()
        {
            IsMine = false;
            IsFlagged = false;
            IsRevealed = false;
            CloseMines = 0;
        }
    }
}
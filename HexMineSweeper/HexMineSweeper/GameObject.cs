using System.Diagnostics;

namespace HexMineSweeper
{
    internal class GameObject
    {
        public Tile[,] Tiles {  get; set; }
        public int Mines { get; set; }
        public int Flags { get; set; }
        public Size Size { get; set; }
        public GameObject() { }
        public GameObject(Setting setting) 
        {
            Tiles = new Tile[setting.Size.Width + 2, setting.Size.Height + 2];
            Size = new Size(setting.Size.Width,setting.Size.Height);
            Mines = setting.MineCount;
            Flags = 0;
            int tileCount = (Size.Width) * (Size.Height);
            double minesToAdd = Mines;
            Random gen = new Random();
            for (int i = 0; i <= Size.Width + 1; i++)
            {
                for (int j = 0; j <= Size.Height + 1; j++)
                {
                    Tiles[i, j] = new Tile();
                    if (minesToAdd != 0 && tileCount != 0 && i >= 1 && j >= 1 && i <= Size.Width && j <= Size.Height && gen.Next(100) < (minesToAdd / tileCount) * 100)
                    {
                        Debug.WriteLine(minesToAdd);
                        Debug.WriteLine(tileCount);
                        Tiles[i, j].IsMine = true;
                        minesToAdd -= 1;
                    }
                    if (i >= 1 && j >= 1 && i <= Size.Width && j <= Size.Height) tileCount -= 1;
                }
            }
            for (int i = 1; i <= Size.Width; i++)
            {
                for (int j = 1; j <= Size.Height; j++)
                {
                    if (!Tiles[i, j].IsMine) 
                    { 
                        if (i % 2 == 0)
                        {
                            if (Tiles[i, j + 1].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i, j - 1].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i - 1, j].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i - 1, j - 1].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i + 1, j].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i + 1, j - 1].IsMine) Tiles[i, j].CloseMines += 1;
                        }
                        else
                        {
                            if (Tiles[i, j + 1].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i, j - 1].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i - 1, j].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i - 1, j + 1].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i + 1, j].IsMine) Tiles[i, j].CloseMines += 1;
                            if (Tiles[i + 1, j + 1].IsMine) Tiles[i, j].CloseMines += 1;
                        }
                    }
                }
            }
        }
        public bool IsGameWon()
        {
            for (int i = 1; i <= Size.Width; i++)
            {
                for (int j = 1; j <= Size.Height; j++)
                {
                    if (!Tiles[i, j].IsMine && !Tiles[i, j].IsRevealed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HexMineSweeper
{
    public partial class Form1 : Form
    {
        private GameObject game;
        private PictureBox[,] field;
        private LoadSaveSystem loadSaveSystem = new LoadSaveSystem();
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(640, 640);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            comboBox1.DataSource = new object[] {
                new Setting { ID = 1, Text = "Лёгкая", Size = new Size(5, 5), MineCount = 5},
                new Setting { ID = 2, Text = "Средняя", Size = new Size(6, 6), MineCount = 9},
                new Setting { ID = 3, Text = "Сложная", Size = new Size(10, 10), MineCount = 25}
            };
        }
        private void ResetField()
        {
            if (field == null) return;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j].Dispose();
                }
            }
        }
        private void DrawField()
        {
            label2.Text = String.Format("Мин осталось {0}", game.Mines - game.Flags);
            field = new PictureBox[game.Size.Width, game.Size.Width];
            double scale = 350 / game.Size.Width;
            for (int i = 1; i <= game.Size.Width; i++)
            {
                for (int j = 1; j <= game.Size.Height; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = new Size((int)Math.Round(scale), (int)Math.Round(scale));
                    pictureBox.Location = new Point((int)Math.Round((j - 1) * scale * 1.25 + scale / 1.5 * (i % 2)), (int)Math.Round(scale * 1.25 * (i - 1)));
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.Tag = (i - 1) * game.Size.Width + (j - 1);
                    pictureBox.MouseClick += click_Tile;
                    panel1.Controls.Add(pictureBox);
                    field[i - 1, j - 1] = pictureBox;
                    if (!game.Tiles[i, j].IsMine && game.Tiles[i, j].CloseMines == 0)
                    {
                        pictureBox.ImageLocation = "sprites/empty.png";
                    }
                    else if (game.Tiles[i, j].IsRevealed)
                    {
                        if (game.Tiles[i, j].CloseMines == 6) pictureBox.ImageLocation = "sprites/6.png";
                        else if (game.Tiles[i, j].CloseMines == 5) pictureBox.ImageLocation = "sprites/5.png";
                        else if (game.Tiles[i, j].CloseMines == 4) pictureBox.ImageLocation = "sprites/4.png";
                        else if (game.Tiles[i, j].CloseMines == 3) pictureBox.ImageLocation = "sprites/3.png";
                        else if (game.Tiles[i, j].CloseMines == 2) pictureBox.ImageLocation = "sprites/2.png";
                        else if (game.Tiles[i, j].CloseMines == 1) pictureBox.ImageLocation = "sprites/1.png";
                        else pictureBox.ImageLocation = "sprites/empty.png";
                    }
                    else if (game.Tiles[i, j].IsFlagged) pictureBox.ImageLocation = "sprites/flag.png";
                    else
                    {
                        pictureBox.ImageLocation = "sprites/unopened.png";
                    }
                }
            }
        }

        private void RedrawField()
        {
            label2.Text = String.Format("Мин осталось {0}", game.Mines - game.Flags);
            for (int i = 1; i <= game.Size.Width; i++)
            {
                for (int j = 1; j <= game.Size.Height; j++)
                {
                    PictureBox pictureBox = field[i - 1, j - 1];
                    if (game.Tiles[i, j].IsRevealed)
                    {
                        if (game.Tiles[i, j].IsMine)
                        {
                            pictureBox.ImageLocation = "sprites/mine.png";
                            Defeat();
                        }
                        else if (game.Tiles[i, j].CloseMines == 6) pictureBox.ImageLocation = "sprites/6.png";
                        else if (game.Tiles[i, j].CloseMines == 5) pictureBox.ImageLocation = "sprites/5.png";
                        else if (game.Tiles[i, j].CloseMines == 4) pictureBox.ImageLocation = "sprites/4.png";
                        else if (game.Tiles[i, j].CloseMines == 3) pictureBox.ImageLocation = "sprites/3.png";
                        else if (game.Tiles[i, j].CloseMines == 2) pictureBox.ImageLocation = "sprites/2.png";
                        else if (game.Tiles[i, j].CloseMines == 1) pictureBox.ImageLocation = "sprites/1.png";
                        else pictureBox.ImageLocation = "sprites/empty.png";
                    }
                    else if (game.Tiles[i, j].IsFlagged)
                    {
                        pictureBox.ImageLocation = "sprites/flag.png";
                    }
                    else
                    {
                        pictureBox.ImageLocation = "sprites/unopened.png";
                    }
                }
            }
        }
        private void Defeat()
        {
            MessageBox.Show("Вы взорвалиь :(");
            button7.Enabled = false;
            MainMenu.Visible = true;
            Game.Visible = false;
            Settings.Visible = false;
            return;
        }

        private void click_Tile(object sender, MouseEventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            int index = (int)pbox.Tag;
            int i = index / game.Size.Width + 1;
            int j = index % game.Size.Width + 1;
            if (e.Button == MouseButtons.Right)
            {
                if (game.Tiles[i, j].IsRevealed) return;
                if (game.Tiles[i, j].IsFlagged)
                {
                    game.Tiles[i, j].IsFlagged = false;
                    game.Flags -= 1;
                }
                else
                {
                    game.Flags += 1;
                    game.Tiles[i, j].IsFlagged = true;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (game.Tiles[i, j].IsFlagged) return;
                game.Tiles[i, j].IsRevealed = true;
                if (!game.Tiles[i, j].IsMine && game.Tiles[i, j].CloseMines == 0)
                {
                    if (i % 2 == 0)
                    {
                        game.Tiles[i, j + 1].IsRevealed = true;
                        game.Tiles[i, j - 1].IsRevealed = true;
                        game.Tiles[i - 1, j].IsRevealed = true;
                        game.Tiles[i - 1, j - 1].IsRevealed = true;
                        game.Tiles[i + 1, j].IsRevealed = true;
                        game.Tiles[i + 1, j - 1].IsRevealed = true;
                    }
                    else
                    {
                        game.Tiles[i, j + 1].IsRevealed = true;
                        game.Tiles[i, j - 1].IsRevealed = true;
                        game.Tiles[i - 1, j].IsRevealed = true;
                        game.Tiles[i - 1, j + 1].IsRevealed = true;
                        game.Tiles[i + 1, j].IsRevealed = true;
                        game.Tiles[i + 1, j + 1].IsRevealed = true;
                    }
                }
            }
            RedrawField();
            if (game.IsGameWon())
            {
                MessageBox.Show("Вы выиграли");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            game = new GameObject((Setting)comboBox1.SelectedItem);
            ResetField();
            DrawField();
            button7.Enabled = true;
            MainMenu.Visible = false;
            Game.Visible = true;
            Settings.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "saves\\";
            Debug.Write(AppDomain.CurrentDomain.BaseDirectory);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ResetField();
                string file = openFileDialog.FileName;
                game = loadSaveSystem.Load(file);
                DrawField();
                button7.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu.Visible = false;
            Game.Visible = false;
            Settings.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu.Visible = true;
            Game.Visible = false;
            Settings.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainMenu.Visible = false;
            Game.Visible = true;
            Settings.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "saves\\";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Json files (*.json)|*.json";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = saveFileDialog.FileName;
                loadSaveSystem.Save(game, file);
            }

        }
    }
}
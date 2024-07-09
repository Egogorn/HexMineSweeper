namespace HexMineSweeper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMenu = new Panel();
            button7 = new Button();
            label1 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            Game = new Panel();
            button8 = new Button();
            label2 = new Label();
            panel1 = new Panel();
            button6 = new Button();
            Settings = new Panel();
            comboBox1 = new ComboBox();
            button5 = new Button();
            MainMenu.SuspendLayout();
            Game.SuspendLayout();
            Settings.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.Controls.Add(button7);
            MainMenu.Controls.Add(label1);
            MainMenu.Controls.Add(button4);
            MainMenu.Controls.Add(button3);
            MainMenu.Controls.Add(button2);
            MainMenu.Controls.Add(button1);
            MainMenu.Dock = DockStyle.Fill;
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(624, 601);
            MainMenu.TabIndex = 0;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(252, 197);
            button7.Name = "button7";
            button7.Size = new Size(135, 23);
            button7.TabIndex = 5;
            button7.Text = "Продолжить";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(156, 83);
            label1.Name = "label1";
            label1.Size = new Size(328, 41);
            label1.TabIndex = 4;
            label1.Text = "Шестиугольный Сапер";
            // 
            // button4
            // 
            button4.Location = new Point(252, 313);
            button4.Name = "button4";
            button4.Size = new Size(135, 23);
            button4.TabIndex = 3;
            button4.Text = "Выход";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(252, 284);
            button3.Name = "button3";
            button3.Size = new Size(135, 23);
            button3.TabIndex = 2;
            button3.Text = "Настройки";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(252, 255);
            button2.Name = "button2";
            button2.Size = new Size(135, 23);
            button2.TabIndex = 1;
            button2.Text = "Загрузить игру";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(252, 226);
            button1.Name = "button1";
            button1.Size = new Size(135, 23);
            button1.TabIndex = 0;
            button1.Text = "Новая игра";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Game
            // 
            Game.Controls.Add(button8);
            Game.Controls.Add(label2);
            Game.Controls.Add(panel1);
            Game.Controls.Add(button6);
            Game.Dock = DockStyle.Fill;
            Game.Location = new Point(0, 0);
            Game.Name = "Game";
            Game.Size = new Size(624, 601);
            Game.TabIndex = 5;
            // 
            // button8
            // 
            button8.Location = new Point(435, 24);
            button8.Name = "button8";
            button8.Size = new Size(135, 23);
            button8.TabIndex = 3;
            button8.Text = "Сохранить игру";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(28, 22);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // panel1
            // 
            panel1.Location = new Point(70, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 500);
            panel1.TabIndex = 1;
            // 
            // button6
            // 
            button6.Location = new Point(252, 24);
            button6.Name = "button6";
            button6.Size = new Size(135, 23);
            button6.TabIndex = 0;
            button6.Text = "В меню";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button5_Click;
            // 
            // Settings
            // 
            Settings.Controls.Add(comboBox1);
            Settings.Controls.Add(button5);
            Settings.Dock = DockStyle.Fill;
            Settings.Location = new Point(0, 0);
            Settings.Name = "Settings";
            Settings.Size = new Size(624, 601);
            Settings.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(252, 173);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(135, 23);
            comboBox1.TabIndex = 1;
            // 
            // button5
            // 
            button5.Location = new Point(252, 371);
            button5.Name = "button5";
            button5.Size = new Size(135, 23);
            button5.TabIndex = 0;
            button5.Text = "Назад";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 601);
            Controls.Add(MainMenu);
            Controls.Add(Settings);
            Controls.Add(Game);
            Name = "Form1";
            Text = "Form1";
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            Game.ResumeLayout(false);
            Game.PerformLayout();
            Settings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainMenu;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label1;
        private Panel Game;
        private Panel Settings;
        private Button button5;
        private ComboBox comboBox1;
        private Button button6;
        private Panel panel1;
        private Button button7;
        private Label label2;
        private Button button8;
    }
}
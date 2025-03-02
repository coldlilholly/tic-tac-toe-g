﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe_g
{
    public partial class Form1 : Form
    {
        private int x = 12, y = 12;
        private Button[,] buttons = new Button[3, 3];
        private int player;
        public Form1()
        {
            InitializeComponent();
            this.Height = 700;
            this.Width = 900;
            player = 1;
            label1.Text = "Текущий ход: Игрок 1";
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(200, 200);
                }
            }
            setButtons();
        }
        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 206 * j, 12 + 206 * i);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 138);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "x");
                    player = 0;
                    label1.Text = "Текущий ход: Игрок 2";
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "o");
                    player = 1;
                    label1.Text = "Текущий ход: Игрок 1";
                    break;
            }
            sender.GetType().GetProperty("Enabled").SetValue(sender, false);
            checkWin();
        }
        private void DisableButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Enabled = false; // Отключаем все кнопки
                }
            }
        }
        private void checkWin()
        {
            string winner = player == 1 ? "Игрок 2" : "Игрок 1"; // Определяем победителя

            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text && buttons[0, 0].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text && buttons[1, 0].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text && buttons[2, 0].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }
            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text && buttons[0, 0].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text && buttons[0, 1].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }
            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text && buttons[0, 2].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }
            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text && buttons[2, 0].Text != "")
            {
                MessageBox.Show($"{winner} победил!");
                DisableButtons();
            }

            // Проверка на ничью
            bool isDraw = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Text == "")
                    {
                        isDraw = false; // Есть хотя бы одна пустая клетка, значит, это не ничья
                        break;
                    }
                }
                if (!isDraw) break;
            }

            if (isDraw)
            {
                MessageBox.Show("Ничья!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
            }
        }

    }
}

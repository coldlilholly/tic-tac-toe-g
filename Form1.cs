using System;
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
    }
}

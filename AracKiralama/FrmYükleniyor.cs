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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AracKiralama
{
    public partial class FrmYükleniyor : Form
    {
        private Random rand;
        public FrmYükleniyor()
        {
            
            InitializeComponent();
            rand = new Random();
            this.labelYuzde.Text = "%0";
        }
        //Timer tickine göre progressbarı dolduruyoruz
        private void timerYukleniyor_Tick(object sender, EventArgs e)
        {
            if (progressBarYukleniyor.Value < 100)
            {
                if (progressBarYukleniyor.Value <= 30)
                {
                    progressBarYukleniyor.Value += rand.Next(1, 3);
                }
                else if (progressBarYukleniyor.Value > 30 && progressBarYukleniyor.Value < 60)
                {
                    progressBarYukleniyor.Value += rand.Next(1, 5);
                }
                else
                {
                    int rand_per = rand.Next(1, 8);
                    if (rand_per + progressBarYukleniyor.Value > 100)
                    {
                        rand_per = progressBarYukleniyor.Maximum - progressBarYukleniyor.Value;
                    }
                    progressBarYukleniyor.Value += rand_per;
                }
                if (progressBarYukleniyor.Value > 100)
                {
                    progressBarYukleniyor.Value = 100;
                }
                labelYuzde.Text = "%" + progressBarYukleniyor.Value.ToString();
            }
            else
            {
                timerYukleniyor.Stop();
                FrmGiris frm = new FrmGiris();
                frm.Show();
                this.Hide();
            }
        }
        private void FrmYükleniyor_Load(object sender, EventArgs e)
        {
            timerYukleniyor.Start();
        }
    }
}

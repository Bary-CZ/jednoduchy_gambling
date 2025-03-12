using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace haleluja
{
    public partial class Form1 : Form
    {
        int cislo, vyhra, prohra, kol, winrate, penize, sance, win, konto, sancenawin, i;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            penize = Convert.ToInt32(textBox1.Text);
            label9.Text = penize.ToString();
            label11.Visible = false;
            button2.Visible = false;
            textBox1.Visible = false;
            label9.Visible = true;
            konto = penize + konto;

        }

        string pocet;
        public Form1()
        {
            InitializeComponent();
            kol = 0;
            label9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kol++;

            Random rnd = new Random();
            rnd.Next();
            cislo = rnd.Next(0, 1000);
            sance = 633;
            if (cislo >= sance)
            {
                label1.Text = ("vyhral jsi ");
                label1.ForeColor = Color.Green;
                vyhra++;
                label5.Text = vyhra.ToString();

            }
            else
            {
                label1.Text = ("prohral jsi");
                prohra++;
                label1.ForeColor = Color.Red;

            }

            label2.Text = cislo.ToString();
            if (kol > 0)
            {
                winrate = (vyhra * 100) / kol;
                label7.Text = winrate.ToString();
                label7.Text = (winrate + "%");
            }
            gamble();
            biggamble();
            sancenawin = 0;

            void gamble()
            {

                label9.Text = konto.ToString();
                if (cislo >= sance)
                {
                    rnd.Next();
                    win = rnd.Next(10, 200);
                    konto = konto + win;
                }
                else
                {
                    rnd.Next();
                    win = rnd.Next(10, 200);
                    konto = konto - win;
                    sancenawin = sancenawin + win;
                }
                if (konto <= 0)
                {
                    label11.Visible = true;
                    button2.Visible = true;
                    textBox1.Visible = true;
                    label9.Visible = false;
                    MessageBox.Show("Prohral jsi vsechny penize");
                }
                label9.Text = konto.ToString();
               
            }
            void biggamble()
            {
                sancenawin = cislo + sancenawin;
                if (sancenawin == 777 )
                {
                    rnd.Next();
                    win = rnd.Next(konto*10, konto*100);
                    MessageBox.Show("Gratuluji vyhral jsi jackpot");
                    konto = konto + win;
                    i = 1;
                    label9.Text = konto.ToString();
                }
                if (i == 1)
                {
                    sancenawin = 0;
                    i = 0;
                }
                label12.Text = sancenawin.ToString();
            }
        }
    }
}
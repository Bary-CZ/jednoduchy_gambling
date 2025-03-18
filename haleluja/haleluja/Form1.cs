using System;
using System.Drawing;
using System.Windows.Forms;

namespace haleluja
{
    public partial class Form1 : Form
    {
        int cislo, vyhra, prohra, kol, winrate, penize, sance, win, konto, sancenawin, i, j;
        int pocitadlo, unlucky;
        string pocet;
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Vítej ve hře, zadej peníze a začni hrát, pokud prohraješ všechny peníze můžeš si přidat další, hodně štěstí");
            textBox1.Text = "0";
            //label 12 jackpot odds
            label12.Visible = false;
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
        public Form1()
        {
            InitializeComponent();
            kol = 0;
            sancenawin = 0;
            label9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kol++;
            label5.Text = kol.ToString();
            Random rnd = new Random();
            rnd.Next();
            cislo = rnd.Next(0, 1000);
            sance = 700;
            if (cislo >= sance)
            {
                label1.Text = ("vyhral jsi ");
                label1.ForeColor = Color.Green;
                vyhra++;
                prohra = 0;
                pocitadlo = pocitadlo + 10;
                rnd.Next();
                sancenawin = sancenawin - rnd.Next(1, 5);
                pocitadlo = pocitadlo + rnd.Next(1, 100);

            }
            else
            {
                label1.Text = ("prohral jsi");
                prohra++;
                label1.ForeColor = Color.Red;
                rnd.Next();
                pocitadlo = pocitadlo - rnd.Next(1, 20);
                sancenawin = sancenawin + rnd.Next(1, 30);
                if (prohra == 5 & sancenawin < 0)
                {
                    sancenawin = sancenawin + rnd.Next(10, 100);
                    prohra = 0;
                    MessageBox.Show("jsi na tom špatně, upravuji šanci na JACKPOT");
                    unlucky++;
                }
                if (unlucky == 5)
                {
                    MessageBox.Show("jsi na tom velmi špatně, upravuji šanci na JACKPOT");
                    sancenawin = sancenawin + rnd.Next(150, 200);
                    unlucky = 0;
                }
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
            bigwin();

            void gamble()
            {

                label9.Text = konto.ToString();
                if (cislo >= sance)
                {
                    rnd.Next();
                    win = rnd.Next(10, 100);
                    konto = konto + win;
                    win = 1;

                }
                else
                {
                    rnd.Next();
                    win = rnd.Next(10, 67);
                    konto = konto - win;

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

                if (sancenawin >= 777)
                {
                    rnd.Next();
                    win = rnd.Next(10, 100);
                    MessageBox.Show("Gratuluji vyhral jsi jackpot");
                    konto = konto * win;
                    i = 1;
                    label9.Text = konto.ToString();
                    sancenawin = 0;
                }
                if (i == 1)
                {
                    sancenawin = 0;
                    i = 0;
                }
                // label12.Text = sancenawin.ToString();
            }
            void bigwin()
            {
                if (pocitadlo > 1000 & cislo >= sance)
                {
                    rnd.Next();
                    win = rnd.Next(1000, 10000);
                    konto = konto + win;
                    pocitadlo = 0;
                    label9.Text = konto.ToString();
                    MessageBox.Show("Gratuluji vyhral jsi velkou vyhru");
                }
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace haleluja
{
    public partial class Form1 : Form
    {
        int cislo, vyhra, prohra, kol, winrate, penize, sance, win, sancenawin, i;
        int pocitadlo, unlucky, parsedPenize;
        long konto;
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Vítej ve hře, zadej peníze a začni hrát, pokud prohraješ všechny peníze můžeš si přidat další, hodně štěstí");
            textBox1.Text = "0";
            //label 12 jackpot odds
            label12.Visible = false;
            textBox1.MaxLength = 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //penize = Convert.ToInt32(textBox1.Text);
            // Krok 1: Validace, zda je vstup celé číslo
            if (!int.TryParse(textBox1.Text, out parsedPenize)) // bugfix, error handeling na jine znaky než cela čísla
            {
                MessageBox.Show("Neplatná hodnota. Zadej celé číslo.");
                return;
            }
            // Krok 2: Validace, zda je číslo kladné
            if (parsedPenize <= 0) // bugfix, error handeling na zaporna čísla
            
            {
                MessageBox.Show("Neplatný vstup. Zadejte kladné číslo."); 
                return;
            }
            // Zbytek kódu (platné kladné číslo)
            penize = parsedPenize;
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
            cislo = rnd.Next(0, 1000);
            sance = 700; //nastavení šance na win eg. 700 = 30%
            if (cislo >= sance)
            {
                label1.Text = ("vyhral jsi ");
                label1.ForeColor = Color.Green;
                vyhra++;
                prohra = 0;
                pocitadlo = pocitadlo + 10;
                sancenawin = sancenawin - rnd.Next(5, 15);
                pocitadlo = pocitadlo + rnd.Next(1, 100);

            }
            else
            {
                label1.Text = ("prohral jsi");
                prohra++;
                label1.ForeColor = Color.Red;
                pocitadlo = pocitadlo - rnd.Next(1, 20);
                sancenawin = sancenawin + rnd.Next(20, 50);
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
                winrate = (int)((vyhra * 100f) / kol); // Přesnost na 1 desetinné místo
              //label7.Text = winrate.ToString();
                label7.Text = $"{winrate}%"; // Zobrazte jako "33%
            }
            gamble();
            biggamble();
            bigwin();

            void gamble()
            {

                label9.Text = konto.ToString();
                if (cislo >= sance)
                {
                    win = rnd.Next(10, 100);
                    konto = konto + win;
                    win = 1;

                }
                else
                {
                    win = rnd.Next(10, 67);
                    konto = konto - win;

                }
                if (konto <= 0)
                {
                    konto = 0; // Zabráňte záporným hodnotám
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
                    if (konto <= 1000)
                    {
                        konto += 1777;
                    }
                    else
                    {
                        win = rnd.Next(2, 5);
                        konto = konto * win;
                    }
                    MessageBox.Show("Gratuluji vyhral jsi jackpot");
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
                if (pocitadlo > 500 && cislo >= sance)
                {
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

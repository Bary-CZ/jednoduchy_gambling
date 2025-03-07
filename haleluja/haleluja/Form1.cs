using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace haleluja
{
    public partial class Form1 : Form
    {
        int rnd, cislo, vyhra, prohra, kol, winrate;
       
        string pocet;
        public Form1()
        {
            InitializeComponent();
            kol = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kol++;
        
        Random rnd = new Random(); 
            rnd.Next();
            cislo = rnd.Next(0,1000);
            if (cislo >= 633)
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

            //pocet vyher label5
            //winrate label7
            //
        }
    }
}

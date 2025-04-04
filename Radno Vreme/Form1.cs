using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Radno_Vreme
{
    public partial class RadnoVreme : Form
    {
        public RadnoVreme()
        {
            InitializeComponent();
        }

        void AzurirajZaradu()
        {
            numericUpDown11.Value = (numericUpDown9.Value + numericUpDown8.Value / 60 + numericUpDown7.Value / 3600) * numericUpDown10.Value;
        }

        void BekapBaze()
        {
            //bekap baze
            TextReader tr = new StreamReader("baza.txt");
            TextWriter tw = new StreamWriter("bekap.txt");
            string temp;
            //Ukupno RV
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);

            //Satnica
            temp = tr.ReadLine();
            tw.WriteLine(temp);

            //Pocetno RV (radi zastite od nestanka struje ili tehnickog kvara)
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);

            tr.Close();
            tw.Close();
        }

        void AzurirajBazu()
        {
            //bekap baze
            TextWriter tw;
            try
            {
                tw = new StreamWriter("baza.txt");
                tw.WriteLine(numericUpDown9.Value.ToString());
                tw.WriteLine(numericUpDown8.Value.ToString());
                tw.WriteLine(numericUpDown7.Value.ToString());
                tw.WriteLine(numericUpDown10.Value.ToString());
                tw.WriteLine(numericUpDown1.Value.ToString());
                tw.WriteLine(numericUpDown2.Value.ToString());
                tw.WriteLine(numericUpDown3.Value.ToString());
                tw.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = DateTime.Now.Hour;
            numericUpDown2.Value = DateTime.Now.Minute;
            numericUpDown3.Value = DateTime.Now.Second;

            AzurirajBazu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown6.Value = DateTime.Now.Hour;
            numericUpDown5.Value = DateTime.Now.Minute;
            numericUpDown4.Value = DateTime.Now.Second;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BekapBaze();
            Decimal hours = numericUpDown6.Value - numericUpDown1.Value;
            Decimal minutes = numericUpDown5.Value - numericUpDown2.Value;
            Decimal seconds = numericUpDown4.Value - numericUpDown3.Value;

            if (seconds < 0)
            {
                minutes--;
                seconds += 60;
            }
            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }
            if (hours < 0)
            {
                hours += 24;
            }

            Decimal hours2 = numericUpDown9.Value + hours;
            Decimal minutes2 = numericUpDown8.Value + minutes;
            Decimal seconds2 = numericUpDown7.Value + seconds;

            while (seconds2 >= 60)
            {
                minutes2++;
                seconds2 -= 60;
            }
            while (minutes2 >= 60)
            {
                hours2++;
                minutes2 -= 60;
            }



            numericUpDown9.Value = hours2;
            numericUpDown8.Value = minutes2;
            numericUpDown7.Value = seconds2;

            TextWriter tw = new StreamWriter("izvestaj.txt", true);
            tw.WriteLine(String.Format("{0:d2}.{1:d2}.{2:d4}  {3:00}:{4:00}:{5:00} - {6:00}:{7:00}:{8:00}  {9:0.00}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value, numericUpDown6.Value, numericUpDown5.Value, numericUpDown4.Value, Math.Round(numericUpDown11.Value, 2)));
            //tw.WriteLine(DateTime.Now.Day+"."+ DateTime.Now.Month+"."+ DateTime.Now.Year+"  "+numericUpDown1.Value+":"+numericUpDown2.Value+":"+numericUpDown3.Value+" - "+ numericUpDown6.Value + ":" + numericUpDown5.Value + ":" + numericUpDown4.Value+"  "+Math.Round(numericUpDown11.Value,2));
            tw.Close();


            //AzurirajBazu();

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            AzurirajZaradu();
            AzurirajBazu();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            AzurirajZaradu();
            AzurirajBazu();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

            AzurirajZaradu();
            AzurirajBazu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BekapBaze();
            numericUpDown11.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown7.Value = 0;
        }

        private void RadnoVreme_Load(object sender, EventArgs e)
        {
            TextReader tr;
            try
            {
                tr = new StreamReader("baza.txt");
            }
            catch
            {
                // u primeru kada ne postoji fajl "baza.txt"
                TextWriter tw = new StreamWriter("baza.txt");
                tw.Close();
                tr = new StreamReader("baza.txt");
            }
            //Ukupno RV
            numericUpDown9.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown8.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown7.Value = Convert.ToDecimal(tr.ReadLine());

            //Satnica
            numericUpDown10.Value = Convert.ToDecimal(tr.ReadLine());

            //Pocetno RV (radi zastite od nestanka struje ili tehnickog kvara)
            numericUpDown1.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown2.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown3.Value = Convert.ToDecimal(tr.ReadLine());

            tr.Close();

            //Za isplatu

            AzurirajZaradu();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            Decimal vrednost = numericUpDown11.Value + numericUpDown12.Value;
            Decimal hours = Math.Floor(vrednost / numericUpDown10.Value);
            Decimal seconds = Math.Floor(vrednost % numericUpDown10.Value) / numericUpDown10.Value * 60;
            Decimal minutes = Math.Floor(seconds);
            seconds -= minutes;
            seconds *= 60;

            numericUpDown9.Value = hours;
            numericUpDown8.Value = minutes;
            numericUpDown7.Value = seconds;
            numericUpDown12.Value = 0;

            AzurirajBazu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Izvestaj f2 = new Izvestaj();
            f2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TotalniIzvestaj f = new TotalniIzvestaj();
            f.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

/*
        public RadnoVreme()
        {
            InitializeComponent();
        }

        void AzurirajZaradu()
        {
            numericUpDown11.Value = (numericUpDown9.Value + numericUpDown8.Value / 60 + numericUpDown7.Value / 3600) * numericUpDown10.Value;
        }

        void AzurirajBazu()
        {
            //bekap baze
            TextReader tr = new StreamReader("baza.txt");
            TextWriter tw = new StreamWriter("bekap.txt");
            string temp;
            //Ukupno RV
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);

            //Satnica
            temp = tr.ReadLine();
            tw.WriteLine(temp);

            //Pocetno RV (radi zastite od nestanka struje ili tehnickog kvara)
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);
            temp = tr.ReadLine();
            tw.WriteLine(temp);

            tr.Close();
            tw.Close();

            try
            {
                tw = new StreamWriter("baza.txt");
                tw.WriteLine(numericUpDown9.Value.ToString());
                tw.WriteLine(numericUpDown8.Value.ToString());
                tw.WriteLine(numericUpDown7.Value.ToString());
                tw.WriteLine(numericUpDown10.Value.ToString());
                tw.WriteLine(numericUpDown1.Value.ToString());
                tw.WriteLine(numericUpDown2.Value.ToString());
                tw.WriteLine(numericUpDown3.Value.ToString());
                tw.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = DateTime.Now.Hour;
            numericUpDown2.Value = DateTime.Now.Minute;
            numericUpDown3.Value = DateTime.Now.Second;

            AzurirajBazu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown6.Value = DateTime.Now.Hour;
            numericUpDown5.Value = DateTime.Now.Minute;
            numericUpDown4.Value = DateTime.Now.Second;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Decimal hours = numericUpDown6.Value - numericUpDown1.Value;
            Decimal minutes = numericUpDown5.Value - numericUpDown2.Value;
            Decimal seconds = numericUpDown4.Value - numericUpDown3.Value;

            if (seconds < 0)
            {
                minutes--;
                seconds += 60;
            }
            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }
            if (hours < 0)
            {
                hours += 24;
            }

            Decimal hours2 = numericUpDown9.Value + hours;
            Decimal minutes2 = numericUpDown8.Value + minutes;
            Decimal seconds2 = numericUpDown7.Value + seconds;

            while (seconds2 >= 60)
            {
                minutes2++;
                seconds2 -= 60;
            }
            while (minutes2 >= 60)
            {
                hours2++;
                minutes2 -= 60;
            }



            numericUpDown9.Value = hours2;
            numericUpDown8.Value = minutes2;
            numericUpDown7.Value = seconds2;


            AzurirajBazu();

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            AzurirajZaradu();
            AzurirajBazu();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            AzurirajZaradu();
            AzurirajBazu();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

            AzurirajZaradu(); 
            AzurirajBazu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown7.Value = 0;
        }

        private void RadnoVreme_Load(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader("baza.txt");
            //Ukupno RV
            numericUpDown9.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown8.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown7.Value = Convert.ToDecimal(tr.ReadLine());

            //Satnica
            numericUpDown10.Value = Convert.ToDecimal(tr.ReadLine());

            //Pocetno RV (radi zastite od nestanka struje ili tehnickog kvara)
            numericUpDown1.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown2.Value = Convert.ToDecimal(tr.ReadLine());
            numericUpDown3.Value = Convert.ToDecimal(tr.ReadLine());

            tr.Close();

            //Za isplatu

            AzurirajZaradu();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {

            AzurirajBazu();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            Decimal hours = Math.Floor(numericUpDown11.Value / numericUpDown10.Value);
            Decimal seconds = Math.Floor(numericUpDown11.Value % numericUpDown10.Value)/numericUpDown10.Value*60;
            Decimal minutes = Math.Floor(seconds);
            seconds -= minutes;
            seconds *= 60;

            numericUpDown9.Value = hours;
            numericUpDown8.Value = minutes;
            numericUpDown7.Value = seconds;

            AzurirajBazu();
        }
*/
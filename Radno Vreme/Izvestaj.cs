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
    public partial class Izvestaj : Form
    {
        public Izvestaj()
        {
            InitializeComponent();
        }

        private void Izvestaj_Load(object sender, EventArgs e)
        {
            TextReader tr;
            try
            {
                tr = new StreamReader("izvestaj.txt");
            }
            catch
            {
                // u primeru kada ne postoji fajl "izvestaj.txt"
                TextWriter tw = new StreamWriter("izvestaj.txt");
                tw.Close();
                tr = new StreamReader("izvestaj.txt");
            }
            string line;
            while ((line = tr.ReadLine()) != null)
            {
                textBox1.Text += line+ Environment.NewLine;
            }
            tr.Close(); 
            textBox1.Select(0, 0);
        }
    }
}

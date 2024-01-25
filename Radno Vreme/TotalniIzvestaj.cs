using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radno_Vreme
{
    public partial class TotalniIzvestaj : Form
    {
        public TotalniIzvestaj()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            PON1_1_Green.BackColor = Color.Transparent;
        }

        private void TotalniIzvestaj_Load(object sender, EventArgs e)
        {

        }
    }
}

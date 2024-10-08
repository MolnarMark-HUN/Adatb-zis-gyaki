using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adatbázis_gyaki
{
    public partial class Form1 : Form
    {
        databasehandler datahandler = new databasehandler();
        public Form1()
        {
            InitializeComponent();

            datahandler.readall();
        }
    }
}

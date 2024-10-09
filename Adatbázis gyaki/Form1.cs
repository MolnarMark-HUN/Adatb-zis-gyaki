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
            start();
            
        }
        void start()
        {
            readinfo();
            Addbutton.Click += addbuttonclick;
            onedel.Click += deletebuttonclick;

        }
        void deleteall(object s,EventArgs e)
        {
            datahandler.deleteall();
            readinfo();
        }
        void deletebuttonclick(object s,EventArgs e)
        {
            int temp = listBox1.SelectedIndex;
            if (temp<0)
            {
                return;
            }
            datahandler.remove(datastore.kolbaszok[temp]);
            datastore.kolbaszok.RemoveAt(temp);
            readinfo();
        }
        void addbuttonclick(object s,EventArgs e)
        {
                datastore onenewkolbasz = new datastore();
                onenewkolbasz.fajta = guna2TextBox1.Text;
                onenewkolbasz.hossz = Convert.ToInt32(guna2TextBox2.Text);
                datahandler.add(onenewkolbasz);
                readinfo();
        }
        void readinfo()
        {
            listBox1.Items.Clear();
            datahandler.readall();
            foreach (datastore item in datastore.kolbaszok)
            {
                listBox1.Items.Add($"Kolbász: {item.fajta} , hossza {item.hossz}");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}

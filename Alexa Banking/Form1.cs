using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Alexa_Banking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {//exit button
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //login button
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename='"C:\Users\DivYesh Per-telz\Documents\Data.mdf"';Integrated Security=True;Connect Timeout=30");


            this.Hide();
            Main ss = new Main();
            ss.Show();
        }

        
    }
}

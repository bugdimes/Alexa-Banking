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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        //advanced exit button
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit ?", "Exit Confirmaion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                this.Show();//if no is selected then close nai thay and messagebox jatu rese
            }
            else
            {
                this.Close();//else yes click thase to close thai jase this form etle main form login varu
            }
        }


        //login button
        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\DivYesh Per-telz\Documents\Data.mdf';Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login where userid='" +textBox1.Text + "' and Password='" +textBox2.Text + "'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                //if userid and password is correct
                this.Hide();
                current ss = new current();
                ss.Show();
            }
            else
            {
                MessageBox.Show("please enter valid username and password..");
            }

        }

      
        
    }
}

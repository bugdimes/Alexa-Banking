using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexa_Banking
{
    public partial class current : Form
    {
        public current()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        //advanced logout button
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log Out ?", "Log Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                this.Show();//if no click karse to main form band nai thay e view thase
            }
            else
            {
                new Form1().Show();//else logout means form1 view thase
                this.Close();
            }
        
        }

        //account settings na form par javanu button
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();//opens account settings page
            this.Close();
        }

    }
}

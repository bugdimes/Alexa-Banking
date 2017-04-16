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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.appData.Customers);

        }

        private void button1_Click(object sender, EventArgs e)//reset button
        {
            //for textboxes
        Action<Control.ControlCollection> func = null;
        func = (controls) =>
        {
             foreach (Control control in controls)
                 if (control is TextBox)
                     (control as TextBox).Clear();
                 else
                     func(control.Controls);
         };
        func(Controls);
            //for radio button
        radioButton1.Checked = false;
        radioButton2.Checked = false;

        }

        private void button2_Click(object sender, EventArgs e)//submit button
        {
            try
            {
            //takes account no and transaction type and then add or remove form that account    
            }
            catch (Exception ex)
            {
                //erros if acoount not found or money not present
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //customersBindingSource.ResetBindings(false);
            }

        }

        private void button3_Click(object sender, EventArgs e)//cancel button
        {
            current ss = new current();
            ss.Show();
            this.Close();
        }
    }
}

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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtsearch.Text))
                    dataGridView.DataSource = customersBindingSource;
                else
                {
                    var query = from o in this.appData.Customers
                                where o.FullName.Contains(txtsearch.Text) ||  o.Address == txtsearch.Text
                                || o.Email == txtsearch.Text select o;
                    // aa jaga e bank operator 
                    //account no nakhine search kare e utility nakhvi padse
                    // right now jo o.AccountNo == txtsearch.Text
                    //o.AccountNo.Contains(txtsearch.Text) use karie to cant compare 
                    // int to string batave chhe coz e juno database accountno ne aji pan int consider kare chhe
                    //jo ke we changed it from accountno numbers to text but cant refresh 
                    //so see later
                    dataGridView.DataSource = query.ToList();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtFullName.Focus();
                this.appData.Customers.AddCustomersRow(this.appData.Customers.NewCustomersRow());
                customersBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customersBindingSource.ResetBindings(false);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel.Enabled = true;
            txtFullName.Focus();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            customersBindingSource.ResetBindings(false);
            current ss = new current();
            ss.Show();
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                customersBindingSource.EndEdit();
                customersTableAdapter.Update(this.appData.Customers);
                panel.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customersBindingSource.ResetBindings(false);
            }

        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    customersBindingSource.RemoveCurrent();
            }

        }


        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.appData.Customers);
            customersBindingSource.DataSource = this.appData.Customers;

        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}

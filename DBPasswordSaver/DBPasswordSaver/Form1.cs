using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;



namespace DBPasswordSaver
{
    public partial class Form1 : Form
    {

        BllUser bll = new BllUser();


        public Form1()
        {
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            Clear();

        }

        private void Clear()
        {
            txtEmail.Text = "";
            txtPassword.Clear();


            txtPlatform.Text = "";

            cboConfidentiality.Text = "Choose Secrecy";

            txtUsername.Text = "";
            btnSave.Text = "Save";
            txtPlatform.Focus();
            btnDelete.Visible = false;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text != "Update")
            {


                int i = bll.SavePassword(txtPlatform.Text, txtEmail.Text, txtUsername.Text, txtPassword.Text, cboConfidentiality.Text);
                if (i > 0)
                {
                    MessageBox.Show("Saved Successfully");
                    LoadGrid();
                    Clear();

                }
            }
            else
            {
                int i = bll.UpdatePassword(txtPlatform.Text, txtEmail.Text, txtUsername.Text, txtPassword.Text, cboConfidentiality.Text, id);
                if (i > 0)
                {
                    MessageBox.Show("Updated Successfully");
                    Clear();
                    LoadGrid();

                }
                else
                {
                    MessageBox.Show("Error Occured");
                }
            }

        }

        private void LoadGrid()
        {
            DataTable dt = bll.FetchUsersfromTable();
            pwdDisplay.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = bll.UserCount();
            lblTotalusers.Text = "Total Accounts: " + dt.Rows.Count.ToString();
            LoadGrid();
            btnDelete.Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = bll.SearchUsersFromDataTable(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                pwdDisplay.DataSource = dt;

            }
            else MessageBox.Show("Platorm not available ");


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = bll.SearchUserSuggestions(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                pwdDisplay.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Platform Not Available");
                txtSearch.Clear();


            }

        }
        int id = 0;
        

        private void pwdDisplay_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtPlatform.Text = pwdDisplay.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = pwdDisplay.CurrentRow.Cells[2].Value.ToString();
            txtUsername.Text = pwdDisplay.CurrentRow.Cells[3].Value.ToString();
            txtPassword.Text = pwdDisplay.CurrentRow.Cells[4].Value.ToString();
            cboConfidentiality.Text = pwdDisplay.CurrentRow.Cells[5].Value.ToString();
            id = Convert.ToInt32(pwdDisplay.CurrentRow.Cells[0].Value);
           

            btnSave.Text = "Update";
            btnDelete.Visible = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = bll.DeleteUser(id);
            LoadGrid();
            Clear();
        }
    }
}

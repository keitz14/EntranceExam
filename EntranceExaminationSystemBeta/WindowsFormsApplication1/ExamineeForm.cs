using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class ExamineeForm : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb");
        OleDbDataReader dr;
        OleDbCommand cmd;
        public ExamineeForm()
        {
            InitializeComponent();
        }
        public void lvSettings()
        {
            if (lvexaminee.Columns.Count <= 0)
            {
                lvexaminee.Columns.Add("Exam #", 100);
                lvexaminee.Columns.Add("O.R #", 100);
                lvexaminee.Columns.Add("First Name", 200);
                lvexaminee.Columns.Add("Middle Name", 200);
                lvexaminee.Columns.Add("Last Name", 200);
                lvexaminee.Columns.Add("Exam Date", 130);
            }
        }

        public void saveData()
        {
            ExamineeForm me = new ExamineeForm();
            try
            {
                if (txtORnumber.Text.Trim() != "" && txtFirstname.Text.Trim() != "" && txtMiddlename.Text.Trim() != "" && txtLastname.Text.Trim() != "" && txtAge.Text.Trim() != "" && cbSex.Text.Trim() != "" && txtAddress.Text.Trim() != "" && dtpDate.Text.Trim() != "")
                {
                    if (MessageBox.Show("Are you sure you want to save this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        conn.Open();
                        cmd = new OleDbCommand("INSERT INTO examineetbl(orNumber, Fname, Mname, Lname, Age, Sex, Address, ExamDate) VALUES ('" + txtORnumber.Text.Trim() + "', '" + txtFirstname.Text.Trim() + "', '" + txtMiddlename.Text.Trim() + "', '" + txtLastname.Text.Trim() + "', '" + txtAge.Text.Trim() + "', '" + cbSex.Text.Trim() + "', '" + txtAddress.Text.Trim() + "', '" + dtpDate.Value.ToString() + "')", conn);
                        
                        dr = cmd.ExecuteReader();
                        MessageBox.Show("Data Saved");
                        this.Hide();
                        if (me.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            loadData();
                        }
                        dr.Close();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Please Complete The Form");
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error in Saving: " + ex.Message);

            }
            finally 
            {
                conn.Close();
            }
        }   


        private void ExamineeForm_Load(object sender, EventArgs e)
        {
            lvSettings();
            loadData();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            saveData();
           
        }
        public void loadData()
        {
            try
            {
                lvexaminee.Items.Clear();
                //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb");
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM examineetbl", conn);
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lvexaminee.Items.Add(dr[0].ToString());
                        lvexaminee.Items[lvexaminee.Items.Count - 1].SubItems.Add(dr[1].ToString());
                        lvexaminee.Items[lvexaminee.Items.Count - 1].SubItems.Add(dr[2].ToString());
                        lvexaminee.Items[lvexaminee.Items.Count - 1].SubItems.Add(dr[3].ToString());
                        lvexaminee.Items[lvexaminee.Items.Count - 1].SubItems.Add(dr[4].ToString());
                        lvexaminee.Items[lvexaminee.Items.Count - 1].SubItems.Add(dr[8].ToString());
                    }
                }
                dr.Close();
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void load_SelectedData()
        {
            if (lvexaminee.Items.Count != -1)
            {
                if (lvexaminee.FocusedItem != null)
                {
                    try
                    {
                        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb");
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM examineetbl WHERE ID LIKE '" + lvexaminee.FocusedItem.Text + "'", conn);
                        OleDbDataReader dr;
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Global.GlobalId = dr[0].ToString();
                                Global.GlobalFirstname = dr[1].ToString();
                                Global.GlobalMiddlename = dr[2].ToString();
                                Global.GlobalLastname = dr[3].ToString();
                                Global.GlobalAge = dr[5].ToString();
                                Global.GlobalGender = dr[4].ToString();
                                //Global.GlobalAddress = dr[6].ToString();
                                Global.GlobalDept = dr[7].ToString();
                                Global.GlobalPosition = dr[8].ToString();
                                Global.GlobalPicpath = dr[9].ToString();
                            }
                        }
                        dr.Close();
                        conn.Close();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
        }

        private void lvexaminee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            examForm exam = new examForm();
            exam.Show();

        }
    }
}

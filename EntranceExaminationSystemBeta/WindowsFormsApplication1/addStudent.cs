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
    public partial class addStudent : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb");
        OleDbDataReader dr;
        OleDbCommand cmd;
        public addStudent()
        {
            InitializeComponent();
        }
        public void saveData()
        {
            addStudent me = new addStudent();
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
                        Student_Profile student = new Student_Profile();
                        student.Show();
                        this.Close();

                        
                        
                        
                        if (me.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            
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
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void addStudent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveData();
            
            

            
        }
    }
}

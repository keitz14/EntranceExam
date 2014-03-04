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
    public partial class Student_Profile : Form
    {
         OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb");
       // OleDbDataReader dr;
       // OleDbCommand cmd;
        
        public Student_Profile()
        {
            InitializeComponent();
        }
        public void lvSettings()
        {
            if (lvStudentprofile.Columns.Count <= 0)
            {
                lvStudentprofile.Columns.Add("Exam #", 100);
                lvStudentprofile.Columns.Add("O.R #", 100);
                lvStudentprofile.Columns.Add("First Name", 200);
                lvStudentprofile.Columns.Add("Middle Name", 200);
                lvStudentprofile.Columns.Add("Last Name", 200);
                lvStudentprofile.Columns.Add("Exam Date", 130);
            }
        }
        public void loadData()
        {
            try
            {
                lvStudentprofile.Items.Clear();
                //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb");
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM examineetbl", conn);
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lvStudentprofile.Items.Add(dr[0].ToString());
                        lvStudentprofile.Items[lvStudentprofile.Items.Count - 1].SubItems.Add(dr[1].ToString());
                        lvStudentprofile.Items[lvStudentprofile.Items.Count - 1].SubItems.Add(dr[2].ToString());
                        lvStudentprofile.Items[lvStudentprofile.Items.Count - 1].SubItems.Add(dr[3].ToString());
                        lvStudentprofile.Items[lvStudentprofile.Items.Count - 1].SubItems.Add(dr[4].ToString());
                        lvStudentprofile.Items[lvStudentprofile.Items.Count - 1].SubItems.Add(dr[8].ToString());
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Student_Profile_Load(object sender, EventArgs e)
        {
            lvSettings();
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

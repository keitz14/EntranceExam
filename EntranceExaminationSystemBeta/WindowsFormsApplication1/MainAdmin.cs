using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainAdmin : Form
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStudent add = new addStudent();
            add.Show();

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void studentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Profile student = new Student_Profile();
            student.Show();

        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            results result = new results();
            result.Show();

        }

        private void examFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            examForm exam = new examForm();
            exam.Show();

        }
    }
}

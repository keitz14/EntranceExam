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
    public partial class results : Form
    {
        public results()
        {
            InitializeComponent();
        }
        public void lvSettings1()
        {
            if (lvResult.Columns.Count <= 0)
            {
                lvResult.Columns.Add("Exam #", 50);
                lvResult.Columns.Add("O.R #", 50);
                lvResult.Columns.Add("First Name", 100);
                lvResult.Columns.Add("Middle Name", 100);
                lvResult.Columns.Add("Last Name", 100);
                lvResult.Columns.Add("Remarks", 100
                    );
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void results_Load(object sender, EventArgs e)
        {
            lvSettings1();
            //loadData();

        }
    }
}

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
    public partial class selection : Form
    {
        public selection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logIn ali = new logIn();
            ali.Show();
            ali.buttonuser.Text = "Login";
            
        }
            

        private void btnExaminee_Click(object sender, EventArgs e)
        {
            logIn ali = new logIn();
            ali.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void selection_Load(object sender, EventArgs e)
        {

        }
        }
    }

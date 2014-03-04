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
    public partial class logIn : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        public logIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Provide Textbox Fields");

            }

            else
            {
                if (buttonuser.Text == "Confirm")
                {
                    try
                    {

                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT* FROM usertbl WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
                        dr = cmd.ExecuteReader();

                        if (dr.Read() == true)
                        {
                            MessageBox.Show("Login Successful");
                            ExamineeForm exam = new ExamineeForm();
                            exam.Show();

                        }
                        else
                        {
                            MessageBox.Show("Username/password");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error Login User" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                if (buttonuser.Text == "Login")
                {

                    try
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM admintbl WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
                        dr = cmd.ExecuteReader();
                        if (dr.Read() == true)
                        {
                            MessageBox.Show("Succesful login Admin");
                            MainAdmin admin = new MainAdmin();
                            admin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username/Password");
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error Login Admin" + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }  
            }
        }

        private void logIn_Load(object sender, EventArgs e)
        {

        }
    }
}
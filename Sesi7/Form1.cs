using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sesi7
{
    public partial class Form1 : Form
    {
        Config db = new Config();
        public Form1()
        {
            InitializeComponent();
            db.Connect("userdata");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //db.ExecuteSelect("SELECT * FROM `user_info` where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "';");
            ////db.Execute("SELECT * FROM user_info;");

            //Console.WriteLine(db.Count().ToString());


            //if (db.Count() == 1)
            //{
            //    MessageBox.Show("Success Login as" + db.Results(0, " name"));
            //}
            //else
            //{
            //    MessageBox.Show("Login Failed");
            //}
            db.loginCoba(txtUsername.Text, txtPassword.Text);

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form2 formRegister = new Form2();
            formRegister.Show();
            Hide();
        }
    }
}

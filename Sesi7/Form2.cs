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
    public partial class Form2 : Form
    {
        Config db = new Config();
        public Form2()
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
            Form1 formLogin = new Form1();
            formLogin.Show();
            Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //db.SaveUser();
            db.Execute("INSERT INTO user_info(name, username, password) VALUES('" + txtNama.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "');");
            MessageBox.Show("Berhasil Register");
        }
    }
}

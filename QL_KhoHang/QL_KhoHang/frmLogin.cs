using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_KhoHang
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        KetNoiCSDL kn = new KetNoiCSDL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string str = @"select * from USERR where  Username='" + txtus.Text + "' and Password='" + txtpw.Text + "'";
            if (kn.Login(str) == true)
            {
                this.Hide();
                string a, b;
                a = kn.Get(str).Rows[0][2].ToString();
                b = kn.Get(str).Rows[0][0].ToString();
                frmTrangChu frmtc = new frmTrangChu(int.Parse(a), b);
                frmtc.FormClosed += new FormClosedEventHandler(frmTrangChu_closed);
                frmtc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công!");
            }

        }
        private void frmTrangChu_closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtus.Text = "";
            txtpw.Text = "";
            txtus.Focus();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpw.UseSystemPasswordChar = true;
            }
            else
            {
                txtpw.UseSystemPasswordChar = false;
            }
        }
    }
}

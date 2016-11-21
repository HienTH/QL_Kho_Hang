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
        string strcon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_KhoHang;Integrated Security=True";
        SqlCommand command;
        SqlConnection conn;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql = "select COUNT(*) from USERR where Quyen = 0 and Username=@username and Password=@password";
                command = new SqlCommand(sql,conn);
                command.Parameters.Add("@username", txtus.Text);
                command.Parameters.Add("@password", txtpw.Text);
                int x = (int)command.ExecuteScalar();
                if(x==1)
                {
                    frmTrangChu frmtc = new frmTrangChu();
                    frmtc.Show();
                }
                else
                {
                    string sql1 = "select COUNT(*) from USERR where Quyen = 1 and Username=@username and Password=@password";
                    command = new SqlCommand(sql1, conn);
                    command.Parameters.Add("@username", txtus.Text);
                    command.Parameters.Add("@password", txtpw.Text);
                    int y = 0;
                    y = (int)command.ExecuteScalar();
                    if(y!=0)
                    {
                        frmAdmin frmad = new frmAdmin();
                        frmad.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!!!", "Thông Báo");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
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

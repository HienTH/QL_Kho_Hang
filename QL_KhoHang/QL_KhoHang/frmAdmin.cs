using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhoHang
{
    public partial class frmAdmin : Form
    {
        KetNoiCSDL kn = new KetNoiCSDL();
        int i = 0;
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            string sql = "select * from Userr";
            dtgrvUser.DataSource = kn.Get(sql);
            lưuToolStripMenuItem.Enabled = false;
        }

        private void dtgrvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUser.Text = dtgrvUser.CurrentRow.Cells[0].Value.ToString();
            txtPass.Text = dtgrvUser.CurrentRow.Cells[1].Value.ToString();
            if (int.Parse(dtgrvUser.CurrentRow.Cells[2].Value.ToString()) == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtUser.Text = "";
            checkBox1.Checked = false;
            lưuToolStripMenuItem.Enabled = true;
            i = 1;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtUser.Text!="")
            {
                lưuToolStripMenuItem.Enabled = true;
                i = 2;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn User cần xóa !!!", "Thông báo");
                i = 0;
            }
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(i==1)//them
            {
                int k = 0;
                if(checkBox1.Checked==true)
                {
                    k = 1;
                }
                else
                {
                    k = 0;
                }
                string s = "insert into USERR values('" + txtUser.Text + "',N'" + txtPass.Text + "',N'" + k + "')";
                kn.Get(s);
                string sql = "select * from Userr";
                dtgrvUser.DataSource = kn.Get(sql);
                i = 0;
                txtPass.Text = "";
                txtUser.Text = "";
                checkBox1.Checked = false;
                lưuToolStripMenuItem.Enabled = false;
            }
            if(i==2)
            {
                string s = "delete from Userr where Username = N'" + txtUser.Text+"'";
                kn.Get(s);
                string sql = "select * from Userr";
                dtgrvUser.DataSource = kn.Get(sql);
                i = 0;
                txtPass.Text = "";
                txtUser.Text = "";
                checkBox1.Checked = false;
                lưuToolStripMenuItem.Enabled = false;
            }
        }
    }
}

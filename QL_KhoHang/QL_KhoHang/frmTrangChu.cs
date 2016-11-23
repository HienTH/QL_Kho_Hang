using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace QL_KhoHang
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu(int a, string b)
        {
            InitializeComponent();
            if(a==0)
            {
                btnUser.Enabled = false;
            }
            if(a==1)
            {
                btnUser.Enabled = true;
            }
        }
        private void btnNCC_Click(object sender, EventArgs e)
        {
            frmNCC NCC = new frmNCC();
            NCC.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            frmCN CN = new frmCN();
            CN.ShowDialog();
        }

        private void btnDSHH_Click(object sender, EventArgs e)
        {
            frmHangHoa HH = new frmHangHoa();
            HH.TopLevel = false;
            panel2.Controls.Clear();
            this.panel2.Controls.Add(HH);
            HH.Show();
//            frmHangHoa HH = new frmHangHoa();
//            HH.ShowDialog();
        }

        private void btnNH_Click(object sender, EventArgs e)
        {
            frmThongKe NX = new frmThongKe();
            NX.ShowDialog();
        }

        private void btnXH_Click(object sender, EventArgs e)
        {
            frmXuat XH = new frmXuat();
            XH.ShowDialog();
        }

        private void btnNH_Click_1(object sender, EventArgs e)
        {
            frmNhap PN = new frmNhap();
            PN.ShowDialog();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            frmHangHoa HH = new frmHangHoa();
            HH.TopLevel = false;
            panel2.Controls.Clear();
            this.panel2.Controls.Add(HH);
            HH.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmAdmin frmad = new frmAdmin();
            frmad.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\QLKH.docx");
        }

    }
}

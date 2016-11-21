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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
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
            HH.ShowDialog();
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
            
        }

    }
}

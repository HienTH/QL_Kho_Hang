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
    public partial class frmNCC : Form
    {
        KetNoiCSDL kn = new KetNoiCSDL();
        int i = 0;
        public frmNCC()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Trong()
        {
            txtMaNCC.Text = ""; txtDCNCC.Text = "";
            txtTenNCC.Text = ""; txtSDTNCC.Text = "";
        }
        private void frmNCC_Load(object sender, EventArgs e)
        {
            string sql = "select * from NHACUNGCAP";
            dtgrvNCC.DataSource = kn.Get(sql);
        }

        private void thêmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Trong();
            i = 1;
        }
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 2;
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 3;
        }
        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(i==1 && txtTenNCC.Text!="")
            {
                string sql = "insert into NHACUNGCAP values('" + txtMaNCC.Text + "',N'" + txtTenNCC.Text + "',N'" + txtDCNCC.Text + "','" + txtSDTNCC.Text + "')";
                dtgrvNCC.DataSource = kn.Get(sql);
                i = 0;
            }
            if(i==2 && txtMaNCC.Text!="" && txtTenNCC.Text!="")
            {
                string sql = "update NHACUNGCAP set TenNCC=N'" + txtTenNCC.Text + "', DiaChi=N'" + txtDCNCC.Text + "',SDT='" + txtSDTNCC.Text + "' where MaNCC='" + txtMaNCC.Text + "'";
                dtgrvNCC.DataSource = kn.Get(sql);
                i = 0;
            }
            if (i == 3 && txtMaNCC.Text != "" && txtTenNCC.Text != "")
            {
                string sql = "delete from NHACUNGCAP where MaNCC='" + txtMaNCC.Text + "'";
                dtgrvNCC.DataSource = kn.Get(sql);
                i = 0;
            }
            string sql1 = "select * from NHACUNGCAP";
            dtgrvNCC.DataSource = kn.Get(sql1);
            Trong();
        }

        private void dtgrvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNCC.Text = dtgrvNCC.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNCC.Text = dtgrvNCC.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDCNCC.Text = dtgrvNCC.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSDTNCC.Text = dtgrvNCC.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch { }
        }
    }
}

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
            txtMaNCC.Text = Ma_TuDongTang();
            txtMaNCC.Enabled = false;
            i = 1;
        }
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;
            i = 2;
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;
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
            txtMaNCC.Enabled = true;
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
        public string Ma_TuDongTang()
        {
            DataTable dt = new DataTable();
            string s = "select * from Nhacungcap";
            dt = kn.Get(s);
            string ma = "";
            int so = 0, i = 1000;
            for (int j = 1; j <= dt.Rows.Count - 1; j++)
            {
                ma = dt.Rows[j - 1][0].ToString();
                ma = ma.Remove(0, 3);
                so = Convert.ToInt32(ma);
                if (so != j) { so = j - 1; i = 0; break; }
            }
            if (i != 0)
            {
                ma = Convert.ToString(dt.Rows[dt.Rows.Count - 1][0].ToString());
                ma = ma.Remove(0, 3);
                so = Convert.ToInt32(ma);
            }

            ma = "NCC";
            so += 1;
            if (so < 10)
                ma = ma + "00";
            else if (so < 100)
                ma = ma + "0";
            ma = ma + so.ToString();
            return ma;
        }
    }
}

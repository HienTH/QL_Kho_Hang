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
    public partial class frmCN : Form
    {
        KetNoiCSDL _con = new KetNoiCSDL();
        bool isThem = false;
        public frmCN()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmCN_Load(object sender, EventArgs e)
        {
            txtMaCN.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            dgvChiNhanh.DataSource = _con.Get("select * from CHINHANH");
        }

        private void dgvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 )
            {
                txtMaCN.Text = dgvChiNhanh.CurrentRow.Cells["clmMaCN"].Value.ToString();
                txtTenCN.Text = dgvChiNhanh.CurrentRow.Cells["clmTenCN"].Value.ToString();
                txtDiaChi.Text = dgvChiNhanh.CurrentRow.Cells["clmDiaChi"].Value.ToString();
                txtSDT.Text = dgvChiNhanh.CurrentRow.Cells[4].Value.ToString();
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void dgvChiNhanh_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvChiNhanh.CurrentRow.Selected = true; //dữ liệu đc chọn cả dòng
            }
            catch
            { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string chuoi = "";
            int so = 0;
            chuoi = Convert.ToString(dgvChiNhanh.Rows[dgvChiNhanh.RowCount - 2].Cells["clmMaCN"].Value);
            chuoi = chuoi.Remove(0, 3);
            so = Convert.ToInt32(chuoi);
            if (so + 1 < 10)
            {
                chuoi = "CN00" + Convert.ToString(so + 1);
                txtMaCN.Text = chuoi;
            }
            else if (so + 1 >= 10)
            {
                chuoi = "HH00" + Convert.ToString(so + 1);
                txtMaCN.Text = chuoi;
            }
            isThem = true;
            dgvChiNhanh.Visible = false;
            groupBox2.Visible = false;
            txtTenCN.Text = "";
            txtTimTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            btnXoa.Text = "Hủy";
            btnThem.Visible = false;
            btnLammoi.Visible = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            Height = 170;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(isThem)
            {
                int n=_con.Exec("insert into CHINHANH values('" + txtMaCN.Text + "',N'" + txtTenCN.Text + "',N'" + txtDiaChi.Text + "','" + txtSDT.Text + "')");
                isThem = false;
                dgvChiNhanh.Visible = true;
                groupBox2.Visible = true;
                btnXoa.Text = "Xóa";
                btnLammoi.Visible = true;
                Height = 560;
                btnThem.Visible = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                dgvChiNhanh.DataSource = _con.Get("select * from CHINHANH");
                if(n>0)
                {
                    MessageBox.Show("Thêm Thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!");
                }
            }
            else
            {
                _con.Exec("update CHINHANH set TenCN=N'" + txtTenCN.Text + "',DiaChi=N'" + txtDiaChi.Text + "',SDT='" + txtSDT.Text + "' where  MaCN='" + txtMaCN.Text+"'");
                dgvChiNhanh.DataSource = _con.Get("select * from CHINHANH");
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            dgvChiNhanh.DataSource = _con.Get("select * from CHINHANH");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(isThem)
            {
                isThem = false;
                dgvChiNhanh.Visible = true;
                groupBox2.Visible = true;
                btnXoa.Text = "Xóa";
                btnLammoi.Visible = true;
                Height = 560;
                btnThem.Visible = true;
            }
            else
            {
                DialogResult dlrHoi;
                dlrHoi = MessageBox.Show("Bạn chắc chắn xóa chi nhánh?", "Xóa chi nhánh", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(dlrHoi==DialogResult.OK)
                {
                    try
                    {
                        int n=_con.Exec("delete CHINHANH  where  MaCN='" + txtMaCN.Text + "'");
                        dgvChiNhanh.DataSource = _con.Get("select * from CHINHANH");
                        if(n>0)
                        MessageBox.Show("Xóa thành công!");
                        else MessageBox.Show("Xóa không thành công!");
                    }
                    catch
                    { }
                }
            }
        }
    }
}

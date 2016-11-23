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
    public partial class frmNhap : Form
    {
        KetNoiCSDL kn = new KetNoiCSDL();
        int i = 0;
        public frmNhap()
        {
            InitializeComponent();
        }
        public void Trong()
        {
            txtTenHH.Text = "";
            txtThongTin.Text = "";
            txtNSX.Text = "";
            txtGN.Text = "";
            txtSL.Text = "";
        }
        public void KhoaButton()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            button2.Enabled = false;
        }
        public void MoKhoaButton()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            button2.Enabled = true;
        }
        public void Khoa()
        {
            txtTenHH.Enabled = false;
            txtThongTin.Enabled = false;
            txtNSX.Enabled = false;
            txtGN.Enabled = false;
            txtSL.Enabled = false;
        }
        public void MoKhoa()
        {
            txtTenHH.Enabled = true;
            txtThongTin.Enabled = true;
            txtNSX.Enabled = true;
            txtGN.Enabled = true;
            txtSL.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "select * from HANGHOA";
            dtgrvHH.DataSource = kn.Get(sql);
            MoKhoa();
            i = 1;
            string chuoi = "";
            int so = 0;
            chuoi = Convert.ToString(dtgrvHH.Rows[dtgrvHH.RowCount - 2].Cells[0].Value);
            chuoi = chuoi.Remove(0, 3);
            so = Convert.ToInt32(chuoi);
            if (so + 1 < 10)
            {
                chuoi = "HH0000000" + Convert.ToString(so + 1);
                txtMaHH.Text = chuoi;
            }
            else if (so + 1 >= 10)
            {
                chuoi = "HH000000" + Convert.ToString(so + 1);
                txtMaHH.Text = chuoi;
            }
            Trong();
            string sql2 = "select * from HANGHOA where MaHH = (select CHITIETPHIEUNHAP.MaHH from CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.MaPN = '" + txtMaPN.Text + "')";
            dtgrvHH.DataSource = kn.Get(sql2);
            btnLuu.Enabled = true;
            button2.Enabled = true;
        }
        private void frmNhap_Load(object sender, EventArgs e)
        {
            KhoaButton();

            Khoa();
            btnLuuPN.Enabled = false;

            dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = DateTime.Today; 
            txtMaPN.Enabled = false;
            cboTenNCC.Enabled = true;
            btnTaoMoi.Enabled = true;

            string sql = "select * from PHIEUNHAP";
            dtgrvPN.DataSource = kn.Get(sql);

            string sql1 = "select * from HANGHOA";
            dtgrvHH.DataSource = kn.Get(sql1);

            string sql3 = "select * from NHACUNGCAP";
            cboTenNCC.DataSource = kn.Get(sql3);
            cboTenNCC.ValueMember = "MaNCC";
            cboTenNCC.DisplayMember = "TenNCC";

            cboTenNCC.Text = "";
            cboTenNCC.Enabled = false;
            btnXong.Enabled = false;
        }
        private void btnXong_Click(object sender, EventArgs e)
        {
            txtMaPN.Text = "";
            cboTenNCC.Text = "";
            cboTenNCC.Enabled = false;
            btnLuuPN.Enabled = false;
            btnTaoMoi.Enabled = true;
            string sql1 = "delete from PHIEUNHAP where TongTien=" + 0;
            kn.Get(sql1);
            string sql = "select * from HANGHOA";
            dtgrvHH.DataSource = kn.Get(sql);
            string sql3 = "select * from PHIEUNHAP";
            dtgrvPN.DataSource = kn.Get(sql3);
            Trong();
            txtMaHH.Text = "";
            KhoaButton();
            btnXong.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(i==1)
            {
                if(txtTenHH.Text!="" && txtSL.Text!="" && txtSL.Text!="")
                {
                    int x = int.Parse(txtGN.Text);
                    int y = int.Parse(txtSL.Text);

                    string sql1 = "insert into HANGHOA values('" + txtMaHH.Text + "',N'" + txtTenHH.Text + "','" + txtSL.Text + "','" + txtGN.Text + "',N'" + txtNSX.Text + "',N'" + txtThongTin.Text + "')";
                    kn.Get(sql1);

                    string sql = "insert into CHITIETPHIEUNHAP values('" + txtMaPN.Text + "','" + txtMaHH.Text + "','" + txtSL.Text + "','" + txtGN.Text + "','" + x * y + "')";
                    kn.Get(sql);
                    dtgrvHH.DataSource = kn.Get("select * from HANGHOA");

                    string sql2 = "update PHIEUNHAP set TongTien=TongTien+'" + x * y + "' where MaPN='" + txtMaPN.Text + "'";
                    dtgrvPN.DataSource = kn.Get(sql2);

                    dtgrvPN.DataSource = kn.Get("select * from PHIEUNHAP");
                    Trong();

                    string sql3 = "select * from HANGHOA where MaHH in (select CHITIETPHIEUNHAP.MaHH from CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.MaPN = '" + txtMaPN.Text + "')";
                    dtgrvHH.DataSource = kn.Get(sql3);

                    txtMaHH.Text = "";
                }
                else
                {
                    MessageBox.Show("Nhập thiếu thông tin", "Thông báo");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trong();
            txtMaHH.Text = "";
            Khoa();
            btnLuu.Enabled = false;
        }

        private void btnLuuPN_Click_1(object sender, EventArgs e)
        {
            if (txtMaPN.Text != "" && cboTenNCC.Text != "")
            {
                string sql1 = "select * from PHIEUNHAP";
                string sql = "insert into PHIEUNHAP values('" + txtMaPN.Text + "',N'" + cboTenNCC.SelectedValue + "',N'" + dateTimePicker1.Text.ToString() + "','0')";
                kn.Get(sql);
                dtgrvPN.DataSource = kn.Get(sql1);

                string sql2 = "select * from HANGHOA where MaHH = (select CHITIETPHIEUNHAP.MaHH from CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.MaPN = '" + txtMaPN.Text + "')";
                dtgrvHH.DataSource = kn.Get(sql2);

                cboTenNCC.Enabled = false;
                btnTaoMoi.Enabled = false;
                btnLuuPN.Enabled = false;

                MoKhoaButton();
                btnLuu.Enabled = false;
                button2.Enabled = false;
                btnXong.Enabled = true;
            }
        }

        private void btnTaoMoi_Click_1(object sender, EventArgs e)
        {
            btnLuuPN.Enabled = true;
            cboTenNCC.Text = "";
            string sql = "select * from PHIEUNHAP";
            dtgrvPN.DataSource = kn.Get(sql);

            string chuoi = "";
            int so = 0;
            chuoi = Convert.ToString(dtgrvPN.Rows[dtgrvPN.RowCount - 2].Cells[0].Value);
            chuoi = chuoi.Remove(0, 3);
            so = Convert.ToInt32(chuoi);
            if (so + 1 < 100)
            {
                chuoi = "PN00" + Convert.ToString(so + 1);
                txtMaPN.Text = chuoi;
            }
            else if (so + 1 >= 100)
            {
                chuoi = "PN0" + Convert.ToString(so + 1);
                txtMaPN.Text = chuoi;
            }
            cboTenNCC.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            string sql = "delete from PHIEUNHAP where TongTien=" + 0;
            kn.Get(sql);
            this.Close();
        }
    }
}

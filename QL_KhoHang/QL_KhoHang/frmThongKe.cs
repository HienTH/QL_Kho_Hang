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
    public partial class frmThongKe : Form
    {
        KetNoiCSDL con = new KetNoiCSDL();

        public frmThongKe()
        {
            InitializeComponent();
        }
        private void frmNhapXuat_Load(object sender, EventArgs e)
        {
            dgvHDN.DataSource=con.Get("select MaPN,TenNCC,NgayNhap,Tongtien from PHIEUNHAP,NHACUNGCAP where PHIEUNHAP.MaNCC=NHACUNGCAP.MaNCC");
            dgvCTHD.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUNHAP");
            dgvXH.DataSource = con.Get("select MaPX,TenCN,NgayXuat,TongTien from PHIEUXUAT,CHINHANH where PHIEUXUAT.MaCN=CHINHANH.MaCN");
            dgvCTXH.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUXUAT");
            
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            con.MoKN();
            // đây là đổ dữ liệu vào bảng 
            dgvHDN.DataSource = con.Get("select MaPN,TenNCC,NgayNhap,TongTien from PHIEUNHAP,NHACUNGCAP where PHIEUNHAP.MaNCC=NHACUNGCAP.MaNCC and PHIEUNHAP.NGAYNHAP between '" + dtpTuNgay.Text.ToString() + "' AND '" + dtpDenNgay.Text.ToString() + "'");
            con.DongKN();
            if (rdb_NCC.Checked == true)
            {
                dtpTuNgay1.Enabled = false;
                dtpDenNgay1.Enabled = false;
                dgvHDN.DataSource = con.Get("select MaPN,TenNCC,NgayNhap,TongTien from PHIEUNHAP,NHACUNGCAP where PHIEUNHAP.MaNCC=NHACUNGCAP.MaNCC order by PHIEUNHAP.MaNCC");
            }
            else if(rdb_Ngay.Checked==true)
            {
                dtpTuNgay1.Enabled = false;
                dtpDenNgay1.Enabled = false;
                dgvHDN.DataSource = con.Get("select MaPN,TenNCC,NgayNhap,TongTien from PHIEUNHAP,NHACUNGCAP where PHIEUNHAP.MaNCC=NHACUNGCAP.MaNCC and DAY(NGAYNHAP)=(SELECT DAY(GETDATE()))");
            }
            else if (rdb_Thang.Checked == true)
            {
                dtpTuNgay1.Enabled = false;
                dtpDenNgay1.Enabled = false;
                dgvHDN.DataSource = con.Get("select MaPN,TenNCC,NgayNhap,TongTien from PHIEUNHAP,NHACUNGCAP where PHIEUNHAP.MaNCC=NHACUNGCAP.MaNCC and MONTH(NGAYNHAP)=(SELECT MONTH(GETDATE()))");
            }
            else if (rdb_Nam.Checked == true)
            {
                dtpTuNgay1.Enabled = false;
                dtpDenNgay1.Enabled = false;
                dgvHDN.DataSource = con.Get("select MaPN,TenNCC,NgayNhap,TongTien from PHIEUNHAP,NHACUNGCAP where PHIEUNHAP.MaNCC=NHACUNGCAP.MaNCC and YEAR(NGAYNHAP)=(SELECT YEAR(GETDATE()))");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.MoKN();
            // đây là đổ dữ liệu vào bảng 
            dgvXH.DataSource = con.Get("select MaPX,TenCN,NgayXuat,TongTien from PHIEUXUAT,CHINHANH where PHIEUXUAT.MaCN=CHINHANH.MaCN and PHIEUXUAT.NGAYXUAT between '" + dtpTuNgay1.Text.ToString() + "' AND '" + dtpDenNgay1.Text.ToString() + "'");
            con.DongKN();
            if (rdb_CN.Checked == true)
            {
                dgvXH.DataSource = con.Get("select MaPX,TenCN,NgayXuat,TongTien from PHIEUXUAT,CHINHANH where PHIEUXUAT.MaCN=CHINHANH.MaCN order by PHIEUXUAT.MACN");
            }
            else if (rdb_Ngay1.Checked == true)
            {
                dgvXH.DataSource = con.Get("select MaPX,TenCN,NgayXuat,TongTien from PHIEUXUAT,CHINHANH where PHIEUXUAT.MaCN=CHINHANH.MaCN and DAY(NGAYXUAT)=(SELECT DAY(GETDATE()))");
            }
            else if (rdb_Thang1.Checked == true)
            {
                dgvXH.DataSource = con.Get("select MaPX,TenCN,NgayXuat,TongTien from PHIEUXUAT,CHINHANH where PHIEUXUAT.MaCN=CHINHANH.MaCN and MONTH(NGAYXUAT)=(SELECT MONTH(GETDATE()))");
            }
            else if (rdb_Nam1.Checked == true)
            {
                dgvXH.DataSource = con.Get("select MaPX,TenCN,NgayXuat,TongTien from PHIEUXUAT,CHINHANH where PHIEUXUAT.MaCN=CHINHANH.MaCN and YEAR(NGAYXUAT)=(SELECT YEAR(GETDATE()))");
            }
            
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTongTien_ReadOnlyChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvHDN_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            int i = e.Row.Index; //lấy index dòng mới thêm vào
            int val =int.Parse(dgvHDN.Rows[i - 1].Cells["STT"].Value.ToString()); // lấy giá trị của trước
            dgvHDN.Rows[i].Cells["STT"].Value = val + 1; //set giá trị dòng mới thêm bằng giá trị trước đó +1            
        }

        private void dgvHDN_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvHDN.Rows.Count; i++)
            {
                dgvHDN[0, i].Value = (i < 9) ? "0" + (i + 1) : "" + (i + 1);
            }
        }

        private void dgvCTHD_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvCTHD.Rows.Count; i++)
            {
                dgvCTHD[0, i].Value = (i < 9) ? "0" + (i + 1) : "" + (i + 1);
            }
        }

        private void dgvXH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvXH.Rows.Count; i++)
            {
                dgvXH[0, i].Value = (i < 9) ? "0" + (i + 1) : "" + (i + 1);
            }
        }

        private void dgvCTXH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvCTXH.Rows.Count; i++)
            {
                dgvCTXH[0, i].Value = (i < 9) ? "0" + (i + 1) : "" + (i + 1);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            if (rdb_DTtang.Checked == true)
            {
                dgvCTHD.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUNHAP order by ThanhTien desc");
            }
            else if (rdb_DTgiam.Checked == true)
            {
                dgvCTHD.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUNHAP order by ThanhTien asc");
            }
            else if (rdb_SLtang.Checked == true)
            {
                dgvCTHD.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUNHAP order by SoLuong desc");
            }
            else if (rdb_SLgiam.Checked == true)
            {
                dgvCTHD.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUNHAP order by SoLuong asc");
            }
        }

        private void btn_Chon1_Click(object sender, EventArgs e)
        {
            if (rdb_DTtang1.Checked == true)
            {
                dgvCTXH.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUXUAT order by ThanhTien desc");
            }
            else if (rdb_DTgiam1.Checked == true)
            {
                dgvCTXH.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUXUAT order by ThanhTien asc");
            }
            else if (rdb_SLtang1.Checked == true)
            {
                dgvCTXH.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUXUAT order by SoLuong desc");
            }
            else if (rdb_SLgiam1.Checked == true)
            {
                dgvCTXH.DataSource = con.Get("select MaHH,SoLuong,DonGia,ThanhTien from CHITIETPHIEUXUAT order by SoLuong asc");
            }
        }

        private void btn_Doanhthu_Click(object sender, EventArgs e)
        {
            //txt_Doanhthu.Text = con.Get("select sum(TongTien) from PHIEUXUAT").Rows[0][0].ToString();
            long thu = 0;
            for(int i=0;i<=dgvXH.Rows.Count-1;i++)
            {
                thu += int.Parse(dgvXH.Rows[i].Cells["clmTongTien2"].Value.ToString());
            }
            txt_Doanhthu.Text = thu.ToString();
        }

        private void btn_DoanhThu1_Click(object sender, EventArgs e)
        {
           // txtTongTien.Text = con.Get("select sum(TongTien) from PHIEUNHAP").Rows[0][0].ToString();
            long chi = 0;
            for (int i = 0; i <= dgvHDN.Rows.Count - 1; i++)
            {
                chi += int.Parse(dgvHDN.Rows[i].Cells["clmTongTien"].Value.ToString());
            }
            txtTongTien.Text = chi.ToString();
        }


     }
  }


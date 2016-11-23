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
    public partial class frmXuat : Form
    {
        KetNoiCSDL _con = new KetNoiCSDL();
        private int slHang = 0;
        public frmXuat()
        {
            InitializeComponent();
        }

        private void dtgrvPN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmXuat_Load(object sender, EventArgs e)
        {
            dgvHH.DataSource = _con.Get("select * from HangHoa");
            dgvPhieuXuat.DataSource = _con.Get("select * from Phieuxuat");
            cboCN.DataSource = _con.Get("select maCN,tenCN from chinhanh");
            cboCN.ValueMember = "maCN";
            cboCN.DisplayMember = "tenCN";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dgvHH_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvHH.CurrentRow.Selected = true;
            }
            catch { }
        }

        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenHH.Text = dgvHH.CurrentRow.Cells["clmTenHH"].Value.ToString();
            txtNSX.Text = dgvHH.CurrentRow.Cells["clmNSX"].Value.ToString();
            txtSL.Text = dgvHH.CurrentRow.Cells["clmSL"].Value.ToString();
            txtThongTin.Text = dgvHH.CurrentRow.Cells["clmTT"].Value.ToString();
            string gn=dgvHH.CurrentRow.Cells["clmGiaNhap"].Value.ToString();
            txtGN.Text =gn;
            txtGiaXuat.Text = (int.Parse(gn) * 11 / 10).ToString();
            txtSLXuat.Enabled = true;
            txtSLXuat.Text = "";
            txtThanhTien.Text = "";
            btnThemHH.Enabled = false;
            int sl = 0;
            for (int i = 0; i < dgvHangXuat.RowCount - 1; i++)
            {
                if (dgvHH.CurrentRow.Cells["clmMaHH"].Value.ToString() == dgvHangXuat.Rows[i].Cells["clmMaHHX"].Value.ToString())
                {
                    sl = int.Parse(dgvHangXuat.Rows[i].Cells["clmSLX"].Value.ToString());
                    break;
                }
            }
            txtSLConLai.Text = (int.Parse(txtSL.Text) - sl).ToString();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtSLXuat_TextChanged(object sender, EventArgs e)
        {
            
            if(txtSLXuat.Text!="")
            {
                int sl = int.Parse(txtSLXuat.Text);
                if (sl > int.Parse(txtSLConLai.Text))
                {
                    MessageBox.Show("vượt quá số lượng trong kho!");
                    txtSLXuat.Text = txtSLConLai.Text;
                    txtThanhTien.Text = (int.Parse(txtSL.Text) * int.Parse(txtGiaXuat.Text)).ToString();
                }
                else
                {
                    //txtSLConLai.Text = (int.Parse(txtSL.Text) - sl).ToString();
                    txtThanhTien.Text = (sl * int.Parse(txtGiaXuat.Text)).ToString();
                    lbTTHH.Text = "("+chuyentien(txtThanhTien.Text+"000")+")";
                    btnThemHH.Enabled = true;
                }
            }
            
        }
        #region Chuyển tiền thành chữ
        private static string chuyendoi(int n)
        {
            string kq = "";
            string[] a = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            if (n / 1000 != 0) kq = kq + a[n / 1000] + " nghìn ";
            if (((n / 100) % 10) != 0) kq = kq + a[(n / 100) % 10] + " trăm ";
            else if ((n > 1000) && ((n / 10) % 10 != 0 || n % 10 != 0)) kq += " không trăm ";
            if (((n / 10) % 10) != 0 && ((n / 10) % 10) != 1) kq = kq + a[(n / 10) % 10] + " mươi ";
            else if (((n / 10) % 10) == 1) kq += " mười ";
            else if ((n / 100) % 10 != 0 && ((n / 10) % 10) == 0 && n % 10 != 0) kq += " linh ";
            if ((n % 10) == 5 && ((n / 10) % 10) != 0) kq += " lăm ";
            else kq += a[n % 10];
            return kq;
        }
        private static string chuyendoi2(int n)
        {
            string kq = "";
            string[] a = { " ", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            if (((n / 100) % 10) != 0) kq = kq + a[(n / 100) % 10] + " trăm ";
            else if (((n / 10) % 10 != 0 || n % 10 != 0)) kq += " không trăm ";
            if (((n / 10) % 10) != 0 && ((n / 10) % 10) != 1) kq = kq + a[(n / 10) % 10] + " mươi ";
            else if (((n / 10) % 10) == 1) kq += " mười ";
            else if (((n / 10) % 10) == 0 && (n % 10) != 0) kq += "linh ";
            if ((n % 10) == 5 && ((n / 10) % 10) != 0) kq += " lăm ";
            else kq += a[n % 10];
            return kq;
        }
        private static string chuyentien(string tien)
        {
            string kq = "";
            int ty, trieu, nghin, donvi;
            ty = trieu = nghin = donvi = 0;
            int dodai, i, mu;
            dodai = tien.Length;
            // printf("%d\n",dodai);    
            // chia tung loc 3 so theo hang
            for (i = dodai - 1, mu = 0; i >= 0 && mu < 3; i--, mu++)
            {
                donvi += (tien[i] - 48) * (int)Math.Pow((double)10, (double)mu);

            }
            // printf("donvi: %d\n",donvi);
            if (dodai > 3)
            {
                for (i = dodai - 4, mu = 0; i >= 0 && mu < 3; i--, mu++)
                {
                    nghin += (tien[i] - 48) * (int)Math.Pow((double)10, (double)mu);

                }
            }
            // printf("nghin: %d\n",nghin);

            if (dodai > 6)
            {
                for (i = dodai - 7, mu = 0; i >= 0 && mu < 3; i--, mu++)
                {
                    trieu += (tien[i] - 48) * (int)Math.Pow((double)10, (double)mu);
                }
            }
            //	printf("trieu: %d\n",trieu);
            if (dodai > 9)
            {
                for (i = dodai - 10, mu = 0; i >= 0; i--, mu++)
                {
                    ty += (tien[i] - 48) * (int)Math.Pow((double)10, (double)mu);
                }
            }
            //	printf("ty :%d\n",ty);
            // doc tung loc 3 so:
            if (ty > 0)
            {
                kq += chuyendoi(ty);
                kq += " tỷ, ";
            }

            if (trieu > 0 && dodai > 9)
            {
                kq += chuyendoi2(trieu);
                kq += " triệu, ";
            }
            else if (trieu > 0)
            {
                kq += chuyendoi(trieu);
                kq += " triệu, ";
            }
            if ((nghin > 0) && dodai > 6)
            {
                kq += chuyendoi2(nghin);
                kq += " nghìn, ";
            }
            else if (nghin > 0)
            {
                kq += chuyendoi(nghin);
                kq += " nghìn, ";
            }
            if ((donvi > 0) && dodai > 3)
            {
                kq += chuyendoi2(donvi);
            }
            else if (donvi > 0)
            {
                kq += chuyendoi(donvi);
            }
            else if (dodai < 3) kq += " không ";
            kq += " đồng ";
            do
            {
                kq = kq.Replace("  ", " ");

            } while (kq.IndexOf("  ") != -1);
            kq = kq.Substring(0, 1).ToUpper() + kq.Substring(1);
            return kq;
        }
        #endregion

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            int kt = 0;
            for (int i = 0; i < dgvHangXuat.RowCount - 1; i++)
            {
                if(dgvHH.CurrentRow.Cells["clmMaHH"].Value.ToString()==dgvHangXuat.Rows[i].Cells["clmMaHHX"].Value.ToString())
                {
                    kt = 1;
                     int sl = int.Parse(dgvHangXuat.Rows[i].Cells["clmSLX"].Value.ToString()) + int.Parse(txtSLXuat.Text);
                       dgvHangXuat.Rows[i].Cells["clmSLX"].Value = sl.ToString();
                       dgvHangXuat.Rows[i].Cells["clmThanhTienX"].Value = (sl * int.Parse(txtGiaXuat.Text)).ToString();
                       
                       long tt = int.Parse(txtTongTien.Text);
                       tt += long.Parse(txtThanhTien.Text);
                       txtTongTien.Text = tt.ToString();
                       break;
                }
            }
           if(kt==0) dgvHangXuat.Rows.Add(dgvHH.CurrentRow.Cells["clmMaHH"].Value.ToString(), txtTenHH.Text, txtSLXuat.Text, txtThanhTien.Text);
           txtSLConLai.Text = (int.Parse(txtSLConLai.Text) - int.Parse(txtSLXuat.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHangXuat_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            long money=0;
            slHang++;
            for(int i=0;i<dgvHangXuat.RowCount-1;i++)
            {
                money += int.Parse(dgvHangXuat.Rows[i].Cells["clmThanhTienX"].Value.ToString());
            }
            txtTongTien.Text = money.ToString();
            lbTienChu.Text = "(" + chuyentien(txtTongTien.Text + "000") + ")";
        }

        private void dgvHangXuat_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                dgvHangXuat.CurrentRow.Selected = true;
            }
            catch { }
        }

        private void dgvHangXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLưu.Visible = true;
            btnHuyHH.Enabled = true;
            btnThemHH.Enabled = false;
            for (int i = 0; i < dgvHH.RowCount - 1; i++)
            {
                if (dgvHangXuat.CurrentRow.Cells["clmMaHHX"].Value.ToString() == dgvHH.Rows[i].Cells["clmMaHH"].Value.ToString())
                {
                    txtTenHH.Text = dgvHH.Rows[i].Cells["clmTenHH"].Value.ToString();
                    txtNSX.Text = dgvHH.Rows[i].Cells["clmNSX"].Value.ToString();
                    txtSL.Text = dgvHH.Rows[i].Cells["clmSL"].Value.ToString();
                    txtThongTin.Text = dgvHH.Rows[i].Cells["clmTT"].Value.ToString();
                    string gn = dgvHH.Rows[i].Cells["clmGiaNhap"].Value.ToString();
                    txtGN.Text = gn;
                    txtGiaXuat.Text = (int.Parse(gn) * 11 / 10).ToString();
                    txtThanhTien.Text = dgvHangXuat.CurrentRow.Cells["clmThanhTienX"].Value.ToString();
                    txtSLXuat.Text = dgvHangXuat.CurrentRow.Cells["clmSLX"].Value.ToString();
                    break;
                }
            }
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
            long tt = int.Parse(txtTongTien.Text);
            tt -= long.Parse(dgvHangXuat.CurrentRow.Cells["clmThanhTienX"].Value.ToString());
            tt += long.Parse(txtThanhTien.Text);
            txtTongTien.Text = tt.ToString();
            dgvHangXuat.CurrentRow.Cells["clmThanhTienX"].Value=txtThanhTien.Text ;
            dgvHangXuat.CurrentRow.Cells["clmSLX"].Value=txtSLXuat.Text;
        }

        private void btnHuyHH_Click(object sender, EventArgs e)
        {
            dgvHangXuat.Rows.Remove(dgvHangXuat.CurrentRow);
            slHang--;
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = _con.Get("select * from CHINHANH where tenCN=N'" + cboCN.Text + "'");
                string macn = dt.Rows[0]["MaCN"].ToString();
                string mapx = taoma();
                string ngay = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
                _con.Exec("insert into PHIEUXUAT values('" + mapx + "','" + macn + "','" + ngay + "','" + txtTongTien.Text + "')");
                string mahh;
                string sl;
                int slkho;
                string thanhtien;
                string gia;
                for (int i = 0; i < dgvHangXuat.Rows.Count - 1; i++)
                {
                    mahh = dgvHangXuat.Rows[i].Cells["clmMaHHX"].Value.ToString();
                    sl = dgvHangXuat.Rows[i].Cells["clmSLX"].Value.ToString();
                    thanhtien = dgvHangXuat.Rows[i].Cells["clmThanhTienX"].Value.ToString();
                    dt = _con.Get("select * from HANGHOA where MaHH=N'" + mahh + "'");
                    gia = dt.Rows[0]["GiaNhap"].ToString();
                    slkho = int.Parse(dt.Rows[0]["SoLuong"].ToString());
                    slkho = slkho - int.Parse(sl);
                    _con.Exec("update HangHoa set SoLuong=" + slkho.ToString()+" where MaHH='"+mahh+"'");
                        //int.Parse(thanhtien) / int.Parse(sl);
                    _con.Exec("insert into CHITIETPHIEUXUAT values('" + mapx + "','" + mahh + "','" + sl + "','" + gia + "','" + thanhtien + "')");
                }
                dgvHH.DataSource = _con.Get("select * from HangHoa");
                dgvPhieuXuat.DataSource = _con.Get("select * from Phieuxuat");
                MessageBox.Show("Xuất hàng thành công!");
            }
            catch {
                MessageBox.Show("không thành công!");
            }
        }
        private string taoma()
        {
            string s;
            DataTable dt = _con.Get("select maPX from PHieuxuat");
           int ma;
           string temp = dt.Rows[dt.Rows.Count - 1][0].ToString();
           temp = temp.Remove(0, 2);
           ma = int.Parse(temp);
           ma++;
           s = "PX00" + ma.ToString();
           return s;
        }

        private void txtSLConLai_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

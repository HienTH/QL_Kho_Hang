using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QL_KhoHang
{
    public partial class frmHangHoa : Form
    {
        KetNoiCSDL kn = new KetNoiCSDL();
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            string sql = "select * from HANGHOA";
            dataGridView1.DataSource = kn.Get(sql);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaSP.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSL.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGN.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();           
                txtNSX.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMoTa.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch { }
        }
        public bool IsNumber(string pText)
        {
            Regex regex = null;
            try
            {
                regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$"); return regex.IsMatch(pText);
            }
            catch (Exception ex)
            {
                return regex.IsMatch(pText);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cboTK.Text=="Giá" && IsNumber(txtTK.Text))
            {
                string sql = "select * from HANGHOA where GiaNhap <= " + txtTK.Text;
                dataGridView1.DataSource = kn.Get(sql);
            }
            if (cboTK.Text == "Giá" && !IsNumber(txtTK.Text))
            {
                MessageBox.Show("Nhập vào là một số", "Thông báo");
            }
            if(cboTK.Text=="NSX")
            {
                string sql = "select * from HANGHOA where NSX = N'" + txtTK.Text + "'";
                dataGridView1.DataSource = kn.Get(sql);
            }
        }

        private void cboTK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTK_TextChanged(object sender, EventArgs e)
        {
            if (cboTK.Text == "")
            {
                txtTK.Text = "";
                string sql = "select * from HANGHOA";
                dataGridView1.DataSource = kn.Get(sql);
            }
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            if(txtTK.Text=="")
            {
                string sql = "select * from HANGHOA";
                dataGridView1.DataSource = kn.Get(sql);
            }
        }
    }
}

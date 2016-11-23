using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KhoHang
{
    class KetNoiCSDL
    {
        public SqlConnection con = null;
        public void MoKN()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QL_KhoHang;Integrated Security=True");
                con.Open();
            }
            catch
            {
                MessageBox.Show("Không khởi tạo được kết nối!");
            }
        }
        public void DongKN()
        {
            con.Close();
        }
        public DataTable Get(string sql)
        {
            MoKN();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKN();
            return dt;
        }
        public int Exec(string sql)
        {
            MoKN();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                int n=cmd.ExecuteNonQuery();
                DongKN();
                return n;
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.ToString());
                DongKN();
                return 0;
            }
            
            
        }
    }
}

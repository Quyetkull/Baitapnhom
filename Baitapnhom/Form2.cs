using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitapnhom
{
    public partial class Form2 : Form
    {
        public Form2()
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            //  chart1.DataSource=        }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DHFMQ88\MSSQLSERVER03;Integrated Security=SSPI;Initial Catalog=quanlichitieu");
            SqlDataAdapter adapter = new SqlDataAdapter(" select tenchitieu, sum(sotien) AS sotien from thongtinchitieu group by tenchitieu",con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            chart1.DataSource = dt;
            chart1.ChartAreas["ChartArea1"].AxisX.Title = " tên chi tiêu";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = " Số tiền";

            chart1.Series["Series1"].XValueMember = " tenchitieu";
            chart1.Series["Series1"].YValueMembers = " sotien";
        }
    }
}

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

namespace Baitapnhom
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-DHFMQ88\MSSQLSERVER03;Integrated Security=SSPI;Initial Catalog=quanlichitieu";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = " select * from thongtinchitieu";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table; // đổ dữ liệu lên bảng 
        }

        void loadgrid()
        {
            command = connection.CreateCommand();
            command.CommandText = " select * from thongtinchitieu where tenchitieu like '" +textBox3+ "' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table; // đổ dữ liệu lên bảng 
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //datagridview
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();

           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            dateTimePicker1.Text=  dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text=  dataGridView1.Rows[i].Cells[2].Value.ToString();
            int sum = 0;
            for ( i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            textBox4.Text = sum.ToString();

        }


        private void button1_Click(object sender, EventArgs e) //thêm
        {
            command = connection.CreateCommand();
            command.CommandText = " insert into thongtinchitieu values('"+textBox1.Text+"','"+dateTimePicker1.Text+ "','"+textBox2.Text+ "')"; //xli câu truy vấn
            command.ExecuteNonQuery();  //trả về kết quả câu truy vấn
            loaddata();
          
        }

        private void button2_Click(object sender, EventArgs e) //xóa
        {
            command = connection.CreateCommand();
            command.CommandText = " delete from thongtinchitieu where tenchitieu= '"+textBox1.Text+ "'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e) //sửa
        {
            command = connection.CreateCommand();
            command.CommandText = " update thongtinnhanvien set ngaythang= '"+dateTimePicker1.Text+ "', sotienchitieu= '"+textBox2.Text+ "' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Text =  "";
            textBox2.Text = "";

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            
        }
       
        private void button5_Click(object sender, EventArgs e)
        {

          
            /* command = connection.CreateCommand();
            command.CommandText = " select sum(sotien) from thongtinchitieu where sotien >0 ";
            command.ExecuteReader();
            textBox4.Text = " bình tĩnh bạn êiii";
            textBox4.Text = command.CommandText;
                */
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void button6_Click(object sender, EventArgs e) //load lại bảng dữ liệu
        {
            loaddata();
        }
    }
}

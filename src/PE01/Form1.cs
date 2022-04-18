using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace PE01
{
    public partial class FormPE01 : Form
    {
        
        public FormPE01()
        {
            InitializeComponent();
        }

        SqlConnection cnn;
        SqlCommand cmd;
        String sql = "Data Source=HP-Pien;Initial Catalog=SV;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void btnFillData_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(sql);
            cnn.Open();
            loadData();
        }
        public void loadData()
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SVINFO";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            svinfoDataGridView.DataSource = table;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            txtId.Clear();
            txtFullName.Clear();
            dateDateTimePicker.ResetText();
            txtClassCode.Clear();
            txtSubjectCode.Clear();
            btnInsert.Enabled = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(sql);
            string sqlAdd = "insert into SVINFO(Id, FullName, DateOfBirth, ClassCode, SubjectCode) values (@Id, @Name, @DateOfBirth, @ClassCode, @SubjectCode)";
            SqlCommand cmd1 = new SqlCommand(sqlAdd, cnn);
            cmd1.Parameters.AddWithValue("@Id", txtId.Text);
            cmd1.Parameters.AddWithValue("@Name", txtFullName.Text);
            cmd1.Parameters.AddWithValue("@DateOfBirth", dateDateTimePicker.Value);
            cmd1.Parameters.AddWithValue("@ClassCode", txtClassCode.Text);
            cmd1.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text);
            cnn.Open();
            cmd1.ExecuteNonQuery();
            cnn.Close();
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(sql);
            String sqlUpdate = "Update SVINFO Set FullName = @Name, DateOfBirth = @DateOfBirth, ClassCode = @ClassCode, SubjectCode = @SubjectCode Where Id = '" + txtId.Text + "'";
            SqlCommand cmd2 = new SqlCommand(sqlUpdate, cnn);
            cmd2.Parameters.AddWithValue("@Name", txtFullName.Text);
            cmd2.Parameters.AddWithValue("@DateOfBirth", dateDateTimePicker.Value);
            cmd2.Parameters.AddWithValue("@ClassCode", txtClassCode.Text);
            cmd2.Parameters.AddWithValue("@SubjectCode", txtSubjectCode.Text);
            cnn.Open();
            cmd2.ExecuteNonQuery();
            cnn.Close();
            loadData();
            btnInsert.Enabled = true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("DO YOU WANT TO EXIT?", "ERROR", MessageBoxButtons.OKCancel);
            if(h == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void svinfoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.svinfoDataGridView.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtFullName.Text = row.Cells[1].Value.ToString();
            dateDateTimePicker.Text = row.Cells[2].Value.ToString();
            txtClassCode.Text = row.Cells[3].Value.ToString();
            txtSubjectCode.Text = row.Cells[4].Value.ToString();

            txtId.Enabled = false;
            btnInsert.Enabled = false;
        }
    }
}

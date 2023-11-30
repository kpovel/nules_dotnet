using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class MainForm : Form
{
    private SqlConnection sqlConnection;
    private SqlDataAdapter sqlDataAdapter;
    private SqlCommandBuilder sqlCommandBuilder;
    private DataTable dataTable;
    private string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

    public MainForm()
    {
        InitializeComponent();
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        LoadData();
    }

    private void LoadData()
    {
        sqlDataAdapter = new SqlDataAdapter("SELECT * FROM CourseWork", sqlConnection);
        sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
        dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        dataGridView.DataSource = dataTable;
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        DataRow row = dataTable.NewRow();
        row["Student"] = studentTextBox.Text;
        row["Group"] = groupTextBox.Text;
        row["Title"] = titleTextBox.Text;
        row["Subject"] = subjectTextBox.Text;
        row["Supervisor"] = supervisorTextBox.Text;
        row["Year"] = int.Parse(yearTextBox.Text);
        row["Grade"] = int.Parse(gradeTextBox.Text);
        dataTable.Rows.Add(row);
        sqlDataAdapter.Update(dataTable);
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        int index = dataGridView.CurrentCell.RowIndex;
        dataTable.Rows[index].Delete();
        sqlDataAdapter.Update(dataTable);
    }

    private void updateButton_Click(object sender, EventArgs e)
    {
        int index = dataGridView.CurrentCell.RowIndex;
        DataRow row = dataTable.Rows[index];
        row["Student"] = studentTextBox.Text;
        row["Group"] = groupTextBox.Text;
        row["Title"] = titleTextBox.Text;
        row["Subject"] = subjectTextBox.Text;
        row["Supervisor"] = supervisorTextBox.Text;
        row["Year"] = int.Parse(yearTextBox.Text);
        row["Grade"] = int.Parse(gradeTextBox.Text);
        sqlDataAdapter.Update(dataTable);
    }
}


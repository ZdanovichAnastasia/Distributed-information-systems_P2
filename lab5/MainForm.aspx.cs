using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace lab5
{
    public partial class MainForm : System.Web.UI.Page
    {
        private string strConnectionString = "Server=localhost;Database=visit_lectures;Uid=root;pwd=1234;";
        private MySqlCommand command;
        private MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVisitData();
            }
        }

        private void CreateConnection()
        {
            MySqlConnection connection = new MySqlConnection(strConnectionString);
            command = new MySqlCommand();
            command.Connection = connection;
        }
        public void OpenConnection()
        {
            command.Connection.Open();
        }

        public void CloseConnection()
        {
            command.Connection.Close();
        }

        public void DisposeConnection()
        {
            command.Connection.Dispose();
        }

        public void BindVisitData()
        {
            try
            {
                CreateConnection();
                OpenConnection();
                command.CommandText = "SELECT * FROM visit";
                dataAdapter = new MySqlDataAdapter(command);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                visitGridView.DataSource = dataSet;
                visitGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("The Error is " + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        protected void visitGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(visitGridView.DataKeys[e.RowIndex].Values[0]);
            try
            {
                CreateConnection();
                OpenConnection();
                command.CommandText = "DELETE FROM visit WHERE idvisit = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                BindVisitData();
            }
            catch (Exception ex)
            {
                Response.Redirect("The Error is " + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        protected void visitGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != visitGridView.EditIndex)
            {
                (e.Row.Cells[5].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void visitGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            visitGridView.EditIndex = e.NewEditIndex;
            this.BindVisitData();
        }

        protected void visitGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            visitGridView.EditIndex = -1;
            BindVisitData();
        }

        protected void visitGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = visitGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(visitGridView.DataKeys[e.RowIndex].Values[0]);
            string lecture = (row.FindControl("txtlecture") as TextBox).Text;
            string student = (row.FindControl("txtstudent") as TextBox).Text;
            bool visit = (row.FindControl("chbIsVisit") as CheckBox).Checked;
            string group = (row.FindControl("txtNGroup") as TextBox).Text;
            try
            {
                CreateConnection();
                OpenConnection();
                command.CommandText = " UPDATE visit SET lecture = @Lecture, FIOstudnet = @Student, isVisit = @Visit, Ngroup = @Group WHERE idvisit = @Id";
                command.Parameters.AddWithValue("@Lecture", lecture);
                command.Parameters.AddWithValue("@Student", student);
                command.Parameters.AddWithValue("@Visit", visit);
                command.Parameters.AddWithValue("@Group", Convert.ToInt32(group));
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                visitGridView.EditIndex = -1;
                BindVisitData();
            }
            catch (Exception ex)
            {
                Response.Redirect("The Error is " + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string lecture = txtLecture.Text;
            string student = txtStudent.Text;
            bool visit = chbVisit.Checked;
            string group = txtGroup.Text;
            try
            {
                CreateConnection();
                OpenConnection();
                command.CommandText = "INSERT INTO visit (lecture, FIOstudnet, isVisit, Ngroup, date) VALUES (@Lecture, @Student, @Visit, @Group, NOW())";
                command.Parameters.AddWithValue("@Lecture", lecture);
                command.Parameters.AddWithValue("@Student", student);
                command.Parameters.AddWithValue("@Visit", visit);
                command.Parameters.AddWithValue("@Group", Convert.ToInt32(group));
                command.ExecuteNonQuery();
                BindVisitData();
                txtLecture.Text = "";
                txtStudent.Text = "";
                txtGroup.Text = "";
                chbVisit.Checked = false;
            }
            catch (Exception ex)
            {
                Response.Redirect("The Error is " + ex.Message);
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApp
{
    public partial class ToDoAppForm : Form
    {
        public ToDoAppForm()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //create columns
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            //Point our datagridview to our datasource
            toDoGridView.DataSource = todoList;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            isEditing = true;
            //Fill text fields with data from table
            titleTextBox.Text = todoList.Rows[toDoGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[toDoGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[toDoGridView.CurrentCell.RowIndex].Delete();
            } 
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todoList.Rows[toDoGridView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                todoList.Rows[toDoGridView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
            } else {
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }

            //clear fields
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }
    }
}

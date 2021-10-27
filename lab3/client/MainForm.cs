using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class MainForm : Form
    {
        private Controller controller;
       
        public MainForm(Controller controller)
        {
            InitializeComponent();
            btnReset.Visible = false;
            updateButton.Visible = false;
            this.controller = controller;
            fullTable();
        }

        public void fullTable()
        {
            List<Veg> vegs = controller.getAllVegs();
            dataGridView1.Rows.Clear();
            foreach (var veg in vegs)
            {
               dataGridView1.Rows.Add(veg.Id, veg.Name, veg.Price, veg.Quantity);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = name_tb.Text.ToString();
            if (name.Equals(""))
            {
                labelError.Text = " ";
                btnReset.Visible = false;
                name_tb.Text = "Input name";
                fullTable();
            }
            else
            {
                labelError.Text = " ";
                List<Veg> vegs = controller.searchByName(name);
                if(vegs != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var veg in vegs)
                    {
                        dataGridView1.Rows.Add(veg.Id, veg.Name, veg.Price, veg.Quantity);
                    }
                    btnReset.Visible = true;
                }
                else
                {
                    btnReset.Visible = false;
                    labelError.Text = "Not found";
                    fullTable();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String idS = id_tb.Text.ToString();
            if (idS.Equals(""))
            {
                labelError.Text = " ";
                id_tb.Text = "Input id";
            }
            else
            {
                try
                {
                    int id = Int32.Parse(idS);
                    labelError.Text = " ";
                    List<Veg> vegs = controller.searchById(id);
                    if (vegs != null)
                    {
                        InputForm inputForm = new InputForm(controller, vegs[0].Id, vegs[0].Name, vegs[0].Price.ToString(), vegs[0].Quantity);
                        inputForm.Show();
                        id_tb.Text = "";
                        updateButton.Visible = true;
                    }
                    else
                    {
                        labelError.Text = "Not found";
                    }
                }
                catch(Exception ex)
                {
                    labelError.Text = "Incorrect input";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string idS = id_tb.Text.ToString();
            if (idS.Equals(""))
            {
                labelError.Text = " ";
                name_tb.Text = "Input id";
            }
            else
            {
                try
                {
                    int id = Int32.Parse(idS);
                    labelError.Text = " ";
                    List<Veg> vegs = controller.delete(id);
                    if (vegs != null)
                    {
                        dataGridView1.Rows.Clear();
                        foreach (var veg in vegs)
                        {
                            dataGridView1.Rows.Add(veg.Id, veg.Name, veg.Price, veg.Quantity);
                        }
                    }
                    else
                    {
                        labelError.Text = "Not found";
                    }
                }
                catch (Exception ex)
                {
                    labelError.Text = "Incorrect input";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm(controller);
            inputForm.Show();
            updateButton.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            name_tb.Text = "";
            fullTable();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updateButton.Visible = false;
            fullTable();
        }
    }
}

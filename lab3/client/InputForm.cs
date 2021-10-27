using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class InputForm : Form
    {
        public int Id;
        private Controller controller;
        public InputForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            edit_btn.Visible = false;
        }

        public InputForm(Controller controller, int id, string name, string price, int quantity)
        {
            InitializeComponent();
            this.controller = controller;
            tb_name.Text = name;
            tb_price.Text = price;
            tb_quantity.Value = quantity;
            add_btn.Visible = false;
            Id = id;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                String text = $"{tb_name.Text.ToString()}|{tb_price.Text.ToString()}|{tb_quantity.Value.ToString()}";
                controller.create(text);
                this.Close();
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                String text = $"{Id.ToString()}|{tb_name.Text.ToString()}|{tb_price.Text.ToString()}|{tb_quantity.Value.ToString()}";
                controller.update(text);
                this.Close();
            }
        }

        private bool checkInput()
        {
            bool isOk = true;
            string name = tb_name.Text.ToString();
            string priceS = tb_price.Text.ToString();
            if (name.Equals(""))
            {
                tb_name.Text = "Input name";
                isOk = false;
            }
            if (priceS.Equals(""))
            {
                tb_price.Text = "Input price";
                priceError.Text = "";
                isOk = false;
            }
            else
            {
                try
                {
                    float price = float.Parse(priceS);
                    priceError.Text = "";
                }
                catch(Exception ex)
                {
                    priceError.Text = "Incorrect input";
                    isOk = false;
                }
            }
            return isOk;

        }

        private void tb_quantity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

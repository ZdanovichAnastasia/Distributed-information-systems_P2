
namespace client
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_quantity = new System.Windows.Forms.NumericUpDown();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.nameError = new System.Windows.Forms.Label();
            this.priceError = new System.Windows.Forms.Label();
            this.quantityError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(53, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(53, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(53, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // tb_quantity
            // 
            this.tb_quantity.Location = new System.Drawing.Point(204, 204);
            this.tb_quantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tb_quantity.Name = "tb_quantity";
            this.tb_quantity.Size = new System.Drawing.Size(150, 27);
            this.tb_quantity.TabIndex = 3;
            this.tb_quantity.ValueChanged += new System.EventHandler(this.tb_quantity_ValueChanged);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(204, 61);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(329, 27);
            this.tb_name.TabIndex = 4;
            // 
            // tb_price
            // 
            this.tb_price.Location = new System.Drawing.Point(204, 136);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(329, 27);
            this.tb_price.TabIndex = 5;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(227, 287);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(157, 40);
            this.add_btn.TabIndex = 6;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.Location = new System.Drawing.Point(227, 287);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(157, 40);
            this.edit_btn.TabIndex = 7;
            this.edit_btn.Text = "Edit";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // nameError
            // 
            this.nameError.AutoSize = true;
            this.nameError.ForeColor = System.Drawing.Color.Red;
            this.nameError.Location = new System.Drawing.Point(204, 95);
            this.nameError.Name = "nameError";
            this.nameError.Size = new System.Drawing.Size(0, 20);
            this.nameError.TabIndex = 8;
            // 
            // priceError
            // 
            this.priceError.AutoSize = true;
            this.priceError.ForeColor = System.Drawing.Color.Red;
            this.priceError.Location = new System.Drawing.Point(204, 170);
            this.priceError.Name = "priceError";
            this.priceError.Size = new System.Drawing.Size(0, 20);
            this.priceError.TabIndex = 9;
            // 
            // quantityError
            // 
            this.quantityError.AutoSize = true;
            this.quantityError.ForeColor = System.Drawing.Color.Red;
            this.quantityError.Location = new System.Drawing.Point(204, 238);
            this.quantityError.Name = "quantityError";
            this.quantityError.Size = new System.Drawing.Size(0, 20);
            this.quantityError.TabIndex = 10;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 364);
            this.Controls.Add(this.quantityError);
            this.Controls.Add(this.priceError);
            this.Controls.Add(this.nameError);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_quantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InputForm";
            this.Text = "InputForm";
            ((System.ComponentModel.ISupportInitialize)(this.tb_quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tb_quantity;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.Label nameError;
        private System.Windows.Forms.Label priceError;
        private System.Windows.Forms.Label quantityError;
    }
}

namespace lab4
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.visit_lecturesDataSet1 = new lab4.visit_lecturesDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.visitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.visitTableAdapter = new lab4.visit_lecturesDataSetTableAdapters.visitTableAdapter();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.idvisitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lectureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIOstudnetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVisitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.visit_lecturesDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // visit_lecturesDataSet1
            // 
            this.visit_lecturesDataSet1.DataSetName = "visit_lecturesDataSet";
            this.visit_lecturesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idvisitDataGridViewTextBoxColumn,
            this.lectureDataGridViewTextBoxColumn,
            this.fIOstudnetDataGridViewTextBoxColumn,
            this.isVisitDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.visitBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1202, 296);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // visitBindingSource
            // 
            this.visitBindingSource.DataMember = "visit";
            this.visitBindingSource.DataSource = this.visit_lecturesDataSet1;
            // 
            // visitTableAdapter
            // 
            this.visitTableAdapter.ClearBeforeFill = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(219, 342);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(217, 57);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(743, 342);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(217, 57);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // idvisitDataGridViewTextBoxColumn
            // 
            this.idvisitDataGridViewTextBoxColumn.DataPropertyName = "idvisit";
            this.idvisitDataGridViewTextBoxColumn.HeaderText = "idvisit";
            this.idvisitDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idvisitDataGridViewTextBoxColumn.Name = "idvisitDataGridViewTextBoxColumn";
            this.idvisitDataGridViewTextBoxColumn.ReadOnly = true;
            this.idvisitDataGridViewTextBoxColumn.Width = 125;
            // 
            // lectureDataGridViewTextBoxColumn
            // 
            this.lectureDataGridViewTextBoxColumn.DataPropertyName = "lecture";
            this.lectureDataGridViewTextBoxColumn.HeaderText = "lecture";
            this.lectureDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lectureDataGridViewTextBoxColumn.Name = "lectureDataGridViewTextBoxColumn";
            this.lectureDataGridViewTextBoxColumn.Width = 125;
            // 
            // fIOstudnetDataGridViewTextBoxColumn
            // 
            this.fIOstudnetDataGridViewTextBoxColumn.DataPropertyName = "FIOstudnet";
            this.fIOstudnetDataGridViewTextBoxColumn.HeaderText = "FIOstudnet";
            this.fIOstudnetDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fIOstudnetDataGridViewTextBoxColumn.Name = "fIOstudnetDataGridViewTextBoxColumn";
            this.fIOstudnetDataGridViewTextBoxColumn.Width = 125;
            // 
            // isVisitDataGridViewTextBoxColumn
            // 
            this.isVisitDataGridViewTextBoxColumn.DataPropertyName = "isVisit";
            this.isVisitDataGridViewTextBoxColumn.HeaderText = "isVisit";
            this.isVisitDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.isVisitDataGridViewTextBoxColumn.Name = "isVisitDataGridViewTextBoxColumn";
            this.isVisitDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isVisitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isVisitDataGridViewTextBoxColumn.Width = 125;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "group";
            this.groupDataGridViewTextBoxColumn.MaxInputLength = 6;
            this.groupDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            this.groupDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 450);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visit_lecturesDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private visit_lecturesDataSet visit_lecturesDataSet1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource visitBindingSource;
        private visit_lecturesDataSetTableAdapters.visitTableAdapter visitTableAdapter;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idvisitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lectureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIOstudnetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isVisitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
    }
}
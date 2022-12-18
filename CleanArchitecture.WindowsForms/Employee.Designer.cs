namespace CleanArchitecture.WindowsForms
{
    partial class Employee
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmployeeView = new System.Windows.Forms.DataGridView();
            this.EmployeePanel = new System.Windows.Forms.Panel();
            this.EmployeeDelete = new System.Windows.Forms.Button();
            this.EmployeeUpdate = new System.Windows.Forms.Button();
            this.AddEmployee = new System.Windows.Forms.Button();
            this.EmployeeGender = new System.Windows.Forms.ComboBox();
            this.EmployeeAge = new System.Windows.Forms.TextBox();
            this.EmployeeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeView)).BeginInit();
            this.EmployeePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeView
            // 
            this.EmployeeView.AllowUserToAddRows = false;
            this.EmployeeView.AllowUserToDeleteRows = false;
            this.EmployeeView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmployeeView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.EmployeeView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.EmployeeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeView.Location = new System.Drawing.Point(62, 178);
            this.EmployeeView.Name = "EmployeeView";
            this.EmployeeView.RowTemplate.Height = 25;
            this.EmployeeView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeView.Size = new System.Drawing.Size(421, 260);
            this.EmployeeView.TabIndex = 0;
            this.EmployeeView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeeView_CellEnter);
            // 
            // EmployeePanel
            // 
            this.EmployeePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmployeePanel.Controls.Add(this.EmployeeDelete);
            this.EmployeePanel.Controls.Add(this.EmployeeUpdate);
            this.EmployeePanel.Controls.Add(this.AddEmployee);
            this.EmployeePanel.Controls.Add(this.EmployeeGender);
            this.EmployeePanel.Controls.Add(this.EmployeeAge);
            this.EmployeePanel.Controls.Add(this.EmployeeName);
            this.EmployeePanel.Controls.Add(this.label3);
            this.EmployeePanel.Controls.Add(this.label2);
            this.EmployeePanel.Controls.Add(this.label1);
            this.EmployeePanel.Location = new System.Drawing.Point(62, 19);
            this.EmployeePanel.Name = "EmployeePanel";
            this.EmployeePanel.Size = new System.Drawing.Size(421, 141);
            this.EmployeePanel.TabIndex = 1;
            // 
            // EmployeeDelete
            // 
            this.EmployeeDelete.Location = new System.Drawing.Point(355, 101);
            this.EmployeeDelete.Name = "EmployeeDelete";
            this.EmployeeDelete.Size = new System.Drawing.Size(59, 23);
            this.EmployeeDelete.TabIndex = 8;
            this.EmployeeDelete.Text = "Delete";
            this.EmployeeDelete.UseVisualStyleBackColor = true;
            this.EmployeeDelete.Click += new System.EventHandler(this.EmployeeDelete_Click);
            // 
            // EmployeeUpdate
            // 
            this.EmployeeUpdate.Location = new System.Drawing.Point(355, 61);
            this.EmployeeUpdate.Name = "EmployeeUpdate";
            this.EmployeeUpdate.Size = new System.Drawing.Size(59, 23);
            this.EmployeeUpdate.TabIndex = 7;
            this.EmployeeUpdate.Text = "Update";
            this.EmployeeUpdate.UseVisualStyleBackColor = true;
            this.EmployeeUpdate.Click += new System.EventHandler(this.EmployeeUpdate_Click);
            // 
            // AddEmployee
            // 
            this.AddEmployee.Location = new System.Drawing.Point(355, 22);
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(59, 23);
            this.AddEmployee.TabIndex = 6;
            this.AddEmployee.Text = "Add";
            this.AddEmployee.UseVisualStyleBackColor = true;
            this.AddEmployee.Click += new System.EventHandler(this.AddEmployee_Click);
            // 
            // EmployeeGender
            // 
            this.EmployeeGender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmployeeGender.FormattingEnabled = true;
            this.EmployeeGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.EmployeeGender.Location = new System.Drawing.Point(139, 101);
            this.EmployeeGender.Name = "EmployeeGender";
            this.EmployeeGender.Size = new System.Drawing.Size(210, 29);
            this.EmployeeGender.TabIndex = 5;
            this.EmployeeGender.Text = "Male";
            // 
            // EmployeeAge
            // 
            this.EmployeeAge.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmployeeAge.Location = new System.Drawing.Point(139, 61);
            this.EmployeeAge.Multiline = true;
            this.EmployeeAge.Name = "EmployeeAge";
            this.EmployeeAge.Size = new System.Drawing.Size(210, 29);
            this.EmployeeAge.TabIndex = 4;
            this.EmployeeAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EmployeeAge_KeyPress);
            // 
            // EmployeeName
            // 
            this.EmployeeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmployeeName.Location = new System.Drawing.Point(139, 18);
            this.EmployeeName.Multiline = true;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(210, 29);
            this.EmployeeName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(32, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Age";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.EmployeePanel);
            this.Controls.Add(this.EmployeeView);
            this.Name = "Employee";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Employee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeView)).EndInit();
            this.EmployeePanel.ResumeLayout(false);
            this.EmployeePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DataGridView EmployeeView;
        private Panel EmployeePanel;
        private ComboBox EmployeeGender;
        private TextBox EmployeeAge;
        private TextBox EmployeeName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button AddEmployee;
        private Button EmployeeUpdate;
        private Button EmployeeDelete;
    }
}
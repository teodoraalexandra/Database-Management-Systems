namespace Lab_2
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.goal = new System.Windows.Forms.TextBox();
            this.city = new System.Windows.Forms.TextBox();
            this.fName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UPDATE = new System.Windows.Forms.Button();
            this.SAVE = new System.Windows.Forms.Button();
            this.DELETE = new System.Windows.Forms.Button();
            this.coachId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clientId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(110, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(387, 304);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(618, 116);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(387, 304);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(769, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Child table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parent table";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(397, 582);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 26);
            this.username.TabIndex = 5;
            // 
            // goal
            // 
            this.goal.Location = new System.Drawing.Point(397, 531);
            this.goal.Name = "goal";
            this.goal.Size = new System.Drawing.Size(100, 26);
            this.goal.TabIndex = 6;
            // 
            // city
            // 
            this.city.Location = new System.Drawing.Point(397, 676);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(100, 26);
            this.city.TabIndex = 7;
            // 
            // fName
            // 
            this.fName.Location = new System.Drawing.Point(397, 440);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(100, 26);
            this.fName.TabIndex = 8;
            // 
            // lName
            // 
            this.lName.Location = new System.Drawing.Point(397, 485);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(100, 26);
            this.lName.TabIndex = 9;
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Location = new System.Drawing.Point(291, 446);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(82, 20);
            this.FirstName.TabIndex = 10;
            this.FirstName.Text = "FirstName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "LastName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 588);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 682);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "City";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 537);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Goal";
            // 
            // UPDATE
            // 
            this.UPDATE.Location = new System.Drawing.Point(618, 537);
            this.UPDATE.Name = "UPDATE";
            this.UPDATE.Size = new System.Drawing.Size(186, 59);
            this.UPDATE.TabIndex = 15;
            this.UPDATE.Text = "Update";
            this.UPDATE.UseVisualStyleBackColor = true;
            this.UPDATE.Click += new System.EventHandler(this.UPDATE_Click);
            // 
            // SAVE
            // 
            this.SAVE.Location = new System.Drawing.Point(618, 452);
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(186, 59);
            this.SAVE.TabIndex = 16;
            this.SAVE.Text = "Save";
            this.SAVE.UseVisualStyleBackColor = true;
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // DELETE
            // 
            this.DELETE.Location = new System.Drawing.Point(618, 625);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(186, 59);
            this.DELETE.TabIndex = 17;
            this.DELETE.Text = "Delete";
            this.DELETE.UseVisualStyleBackColor = true;
            this.DELETE.Click += new System.EventHandler(this.DELETE_Click);
            // 
            // coachId
            // 
            this.coachId.Location = new System.Drawing.Point(397, 625);
            this.coachId.Name = "coachId";
            this.coachId.Size = new System.Drawing.Size(100, 26);
            this.coachId.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "CoachId";
            // 
            // clientId
            // 
            this.clientId.Location = new System.Drawing.Point(905, 641);
            this.clientId.Name = "clientId";
            this.clientId.Size = new System.Drawing.Size(100, 26);
            this.clientId.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(824, 644);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "clientId =";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 720);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.clientId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coachId);
            this.Controls.Add(this.DELETE);
            this.Controls.Add(this.SAVE);
            this.Controls.Add(this.UPDATE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.city);
            this.Controls.Add(this.goal);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox goal;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button UPDATE;
        private System.Windows.Forms.Button SAVE;
        private System.Windows.Forms.Button DELETE;
        private System.Windows.Forms.TextBox coachId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clientId;
        private System.Windows.Forms.Label label8;
    }
}


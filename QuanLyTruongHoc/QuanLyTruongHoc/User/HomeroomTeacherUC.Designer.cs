namespace QuanLyTruongHoc.User
{
    partial class HomeroomTeacherUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txbSchoolYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTeacherName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbClass = new System.Windows.Forms.TextBox();
            this.txbTeacherCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSearch = new System.Windows.Forms.Button();
            this.Text = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.ClassCode,
            this.TeacherCode,
            this.TeacherName,
            this.SchoolYear});
            this.dgView.Location = new System.Drawing.Point(16, 154);
            this.dgView.Name = "dgView";
            this.dgView.RowHeadersVisible = false;
            this.dgView.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgView.RowTemplate.Height = 24;
            this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgView.Size = new System.Drawing.Size(1004, 439);
            this.dgView.TabIndex = 5;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            // 
            // ClassCode
            // 
            this.ClassCode.HeaderText = "Lớp";
            this.ClassCode.MinimumWidth = 6;
            this.ClassCode.Name = "ClassCode";
            // 
            // TeacherCode
            // 
            this.TeacherCode.HeaderText = "Mã giáo viên";
            this.TeacherCode.MinimumWidth = 6;
            this.TeacherCode.Name = "TeacherCode";
            // 
            // TeacherName
            // 
            this.TeacherName.HeaderText = "Tên giáo viên";
            this.TeacherName.MinimumWidth = 6;
            this.TeacherName.Name = "TeacherName";
            // 
            // SchoolYear
            // 
            this.SchoolYear.HeaderText = "Năm học";
            this.SchoolYear.MinimumWidth = 6;
            this.SchoolYear.Name = "SchoolYear";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txbSchoolYear);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txbTeacherName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txbType);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txbClass);
            this.panel2.Controls.Add(this.txbTeacherCode);
            this.panel2.Location = new System.Drawing.Point(16, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 120);
            this.panel2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(561, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Năm học";
            // 
            // txbSchoolYear
            // 
            this.txbSchoolYear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbSchoolYear.Location = new System.Drawing.Point(647, 15);
            this.txbSchoolYear.Name = "txbSchoolYear";
            this.txbSchoolYear.Size = new System.Drawing.Size(100, 30);
            this.txbSchoolYear.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(266, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tên giáo viên";
            // 
            // txbTeacherName
            // 
            this.txbTeacherName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbTeacherName.Location = new System.Drawing.Point(398, 69);
            this.txbTeacherName.Name = "txbTeacherName";
            this.txbTeacherName.Size = new System.Drawing.Size(100, 30);
            this.txbTeacherName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(26, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại";
            // 
            // txbType
            // 
            this.txbType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbType.Location = new System.Drawing.Point(88, 70);
            this.txbType.Name = "txbType";
            this.txbType.Size = new System.Drawing.Size(100, 30);
            this.txbType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(266, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã giáo viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lớp";
            // 
            // txbClass
            // 
            this.txbClass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbClass.Location = new System.Drawing.Point(87, 15);
            this.txbClass.Name = "txbClass";
            this.txbClass.Size = new System.Drawing.Size(100, 30);
            this.txbClass.TabIndex = 2;
            // 
            // txbTeacherCode
            // 
            this.txbTeacherCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbTeacherCode.Location = new System.Drawing.Point(398, 15);
            this.txbTeacherCode.Name = "txbTeacherCode";
            this.txbTeacherCode.Size = new System.Drawing.Size(100, 30);
            this.txbTeacherCode.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.Text);
            this.panel1.Location = new System.Drawing.Point(826, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 64);
            this.panel1.TabIndex = 3;
            // 
            // btSearch
            // 
            this.btSearch.BackgroundImage = global::QuanLyTruongHoc.Properties.Resources.icons8_search_48;
            this.btSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSearch.Location = new System.Drawing.Point(138, 15);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(40, 34);
            this.btSearch.TabIndex = 9;
            this.btSearch.UseVisualStyleBackColor = true;
            // 
            // Text
            // 
            this.Text.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Text.Location = new System.Drawing.Point(12, 18);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(100, 30);
            this.Text.TabIndex = 0;
            // 
            // btAdd
            // 
            this.btAdd.Image = global::QuanLyTruongHoc.Properties.Resources.icons8_plus_48;
            this.btAdd.Location = new System.Drawing.Point(865, 99);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(40, 40);
            this.btAdd.TabIndex = 8;
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // btEdit
            // 
            this.btEdit.Image = global::QuanLyTruongHoc.Properties.Resources.icons8_edit_48;
            this.btEdit.Location = new System.Drawing.Point(924, 99);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(40, 40);
            this.btEdit.TabIndex = 7;
            this.btEdit.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Image = global::QuanLyTruongHoc.Properties.Resources.icons8_delete_48;
            this.btDelete.Location = new System.Drawing.Point(980, 99);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(40, 40);
            this.btDelete.TabIndex = 6;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // HomeroomTeacherUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.panel1);
            this.Name = "HomeroomTeacherUC";
            this.Size = new System.Drawing.Size(1037, 612);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbClass;
        private System.Windows.Forms.TextBox txbTeacherCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox Text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbSchoolYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbTeacherName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbType;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolYear;
    }
}

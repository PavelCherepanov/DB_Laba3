
namespace bd3
{
    partial class fReport2
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
            this.tmp = new System.Windows.Forms.TextBox();
            this.agr = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gr = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmp
            // 
            this.tmp.Location = new System.Drawing.Point(244, 12);
            this.tmp.Name = "tmp";
            this.tmp.Size = new System.Drawing.Size(43, 27);
            this.tmp.TabIndex = 8;
            this.tmp.Visible = false;
            // 
            // agr
            // 
            this.agr.FormattingEnabled = true;
            this.agr.Items.AddRange(new object[] {
            "МИН",
            "МАКС",
            "СУММ",
            "КОЛ-ВО",
            "СРЗНАЧ"});
            this.agr.Location = new System.Drawing.Point(15, 137);
            this.agr.Name = "agr";
            this.agr.Size = new System.Drawing.Size(151, 28);
            this.agr.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(336, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(752, 549);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gr
            // 
            this.gr.FormattingEnabled = true;
            this.gr.Items.AddRange(new object[] {
            "МИН",
            "МАКС",
            "КОЛ-ВО"});
            this.gr.Location = new System.Drawing.Point(15, 240);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(151, 28);
            this.gr.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(201, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 29);
            this.button3.TabIndex = 11;
            this.button3.Text = "Группировать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Группировка по производителю";
            // 
            // fReport2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tmp);
            this.Controls.Add(this.agr);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "fReport2";
            this.Text = "fReport2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tmp;
        private System.Windows.Forms.ComboBox agr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox gr;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}
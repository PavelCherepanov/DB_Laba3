
namespace bd3
{
    partial class Form1
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
            this.bAirplane = new System.Windows.Forms.Button();
            this.bFlight = new System.Windows.Forms.Button();
            this.bPassenger = new System.Windows.Forms.Button();
            this.bTicket = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAirplane
            // 
            this.bAirplane.Location = new System.Drawing.Point(95, 166);
            this.bAirplane.Name = "bAirplane";
            this.bAirplane.Size = new System.Drawing.Size(94, 29);
            this.bAirplane.TabIndex = 0;
            this.bAirplane.Text = "Самолеты";
            this.bAirplane.UseVisualStyleBackColor = true;
            this.bAirplane.Click += new System.EventHandler(this.bAirplane_Click);
            // 
            // bFlight
            // 
            this.bFlight.Location = new System.Drawing.Point(235, 166);
            this.bFlight.Name = "bFlight";
            this.bFlight.Size = new System.Drawing.Size(94, 29);
            this.bFlight.TabIndex = 1;
            this.bFlight.Text = "Рейсы";
            this.bFlight.UseVisualStyleBackColor = true;
            this.bFlight.Click += new System.EventHandler(this.bFlight_Click);
            // 
            // bPassenger
            // 
            this.bPassenger.Location = new System.Drawing.Point(387, 166);
            this.bPassenger.Name = "bPassenger";
            this.bPassenger.Size = new System.Drawing.Size(104, 29);
            this.bPassenger.TabIndex = 2;
            this.bPassenger.Text = "Пассажиры";
            this.bPassenger.UseVisualStyleBackColor = true;
            this.bPassenger.Click += new System.EventHandler(this.bPassenger_Click);
            // 
            // bTicket
            // 
            this.bTicket.Location = new System.Drawing.Point(536, 166);
            this.bTicket.Name = "bTicket";
            this.bTicket.Size = new System.Drawing.Size(94, 29);
            this.bTicket.TabIndex = 3;
            this.bTicket.Text = "Билеты";
            this.bTicket.UseVisualStyleBackColor = true;
            this.bTicket.Click += new System.EventHandler(this.bTicket_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Пассажиры";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Билеты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(419, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Рейсы";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(580, 254);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 7;
            this.button4.Text = "Самолеты";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bTicket);
            this.Controls.Add(this.bPassenger);
            this.Controls.Add(this.bFlight);
            this.Controls.Add(this.bAirplane);
            this.Name = "Form1";
            this.Text = "Меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAirplane;
        private System.Windows.Forms.Button bFlight;
        private System.Windows.Forms.Button bPassenger;
        private System.Windows.Forms.Button bTicket;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}


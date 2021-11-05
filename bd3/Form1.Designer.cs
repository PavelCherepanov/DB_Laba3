
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
            this.SuspendLayout();
            // 
            // bAirplane
            // 
            this.bAirplane.Location = new System.Drawing.Point(95, 166);
            this.bAirplane.Name = "bAirplane";
            this.bAirplane.Size = new System.Drawing.Size(94, 29);
            this.bAirplane.TabIndex = 0;
            this.bAirplane.Text = "Airplane";
            this.bAirplane.UseVisualStyleBackColor = true;
            this.bAirplane.Click += new System.EventHandler(this.bAirplane_Click);
            // 
            // bFlight
            // 
            this.bFlight.Location = new System.Drawing.Point(235, 166);
            this.bFlight.Name = "bFlight";
            this.bFlight.Size = new System.Drawing.Size(94, 29);
            this.bFlight.TabIndex = 1;
            this.bFlight.Text = "Flight";
            this.bFlight.UseVisualStyleBackColor = true;
            this.bFlight.Click += new System.EventHandler(this.bFlight_Click);
            // 
            // bPassenger
            // 
            this.bPassenger.Location = new System.Drawing.Point(387, 166);
            this.bPassenger.Name = "bPassenger";
            this.bPassenger.Size = new System.Drawing.Size(94, 29);
            this.bPassenger.TabIndex = 2;
            this.bPassenger.Text = "Passenger";
            this.bPassenger.UseVisualStyleBackColor = true;
            this.bPassenger.Click += new System.EventHandler(this.bPassenger_Click);
            // 
            // bTicket
            // 
            this.bTicket.Location = new System.Drawing.Point(536, 166);
            this.bTicket.Name = "bTicket";
            this.bTicket.Size = new System.Drawing.Size(94, 29);
            this.bTicket.TabIndex = 3;
            this.bTicket.Text = "Ticket";
            this.bTicket.UseVisualStyleBackColor = true;
            this.bTicket.Click += new System.EventHandler(this.bTicket_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bTicket);
            this.Controls.Add(this.bPassenger);
            this.Controls.Add(this.bFlight);
            this.Controls.Add(this.bAirplane);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAirplane;
        private System.Windows.Forms.Button bFlight;
        private System.Windows.Forms.Button bPassenger;
        private System.Windows.Forms.Button bTicket;
    }
}


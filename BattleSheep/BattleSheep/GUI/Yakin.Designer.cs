namespace BattleSheep.GUI
{
    partial class Yakin
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
            this.buttonYa = new System.Windows.Forms.Button();
            this.buttonTidak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kembali ke Menu Utama?";
            // 
            // buttonYa
            // 
            this.buttonYa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.buttonYa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonYa.ForeColor = System.Drawing.Color.Black;
            this.buttonYa.Location = new System.Drawing.Point(45, 67);
            this.buttonYa.Name = "buttonYa";
            this.buttonYa.Size = new System.Drawing.Size(92, 30);
            this.buttonYa.TabIndex = 1;
            this.buttonYa.Text = "Ya";
            this.buttonYa.UseVisualStyleBackColor = false;
            this.buttonYa.Click += new System.EventHandler(this.BackToMenu);
            // 
            // buttonTidak
            // 
            this.buttonTidak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.buttonTidak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTidak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonTidak.ForeColor = System.Drawing.Color.Black;
            this.buttonTidak.Location = new System.Drawing.Point(161, 67);
            this.buttonTidak.Name = "buttonTidak";
            this.buttonTidak.Size = new System.Drawing.Size(92, 30);
            this.buttonTidak.TabIndex = 2;
            this.buttonTidak.Text = "Tidak";
            this.buttonTidak.UseVisualStyleBackColor = false;
            this.buttonTidak.Click += new System.EventHandler(this.KeepPlay);
            // 
            // Yakin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(173)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(313, 127);
            this.Controls.Add(this.buttonTidak);
            this.Controls.Add(this.buttonYa);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Yakin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apakah Anda Yakin?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonYa;
        private System.Windows.Forms.Button buttonTidak;
    }
}
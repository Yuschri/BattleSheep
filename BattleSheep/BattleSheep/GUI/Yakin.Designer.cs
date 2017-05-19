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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kembali ke Menu Utama?";
            // 
            // buttonYa
            // 
            this.buttonYa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonYa.Location = new System.Drawing.Point(90, 87);
            this.buttonYa.Name = "buttonYa";
            this.buttonYa.Size = new System.Drawing.Size(92, 52);
            this.buttonYa.TabIndex = 1;
            this.buttonYa.Text = "Ya";
            this.buttonYa.UseVisualStyleBackColor = true;
            // 
            // buttonTidak
            // 
            this.buttonTidak.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.buttonTidak.Location = new System.Drawing.Point(210, 87);
            this.buttonTidak.Name = "buttonTidak";
            this.buttonTidak.Size = new System.Drawing.Size(92, 52);
            this.buttonTidak.TabIndex = 2;
            this.buttonTidak.Text = "Tidak";
            this.buttonTidak.UseVisualStyleBackColor = true;
            // 
            // Yakin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 177);
            this.Controls.Add(this.buttonTidak);
            this.Controls.Add(this.buttonYa);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Yakin";
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
namespace BattleSheep.GUI
{
    partial class InputNamaForm
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
            this.buttonLanjut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nama = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLanjut
            // 
            this.buttonLanjut.Enabled = false;
            this.buttonLanjut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLanjut.Location = new System.Drawing.Point(95, 127);
            this.buttonLanjut.Name = "buttonLanjut";
            this.buttonLanjut.Size = new System.Drawing.Size(84, 34);
            this.buttonLanjut.TabIndex = 0;
            this.buttonLanjut.Text = "Lanjut";
            this.buttonLanjut.UseVisualStyleBackColor = true;
            this.buttonLanjut.Click += new System.EventHandler(this.InputDifficulty);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Masukkan Nama Anda :";
            // 
            // nama
            // 
            this.nama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nama.Location = new System.Drawing.Point(37, 67);
            this.nama.Name = "nama";
            this.nama.Size = new System.Drawing.Size(206, 26);
            this.nama.TabIndex = 2;
            this.nama.TextChanged += new System.EventHandler(this.CekNama);
            this.nama.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CekNama);
            // 
            // InputNamaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.nama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLanjut);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputNamaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Nama";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLanjut;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox nama;
    }
}
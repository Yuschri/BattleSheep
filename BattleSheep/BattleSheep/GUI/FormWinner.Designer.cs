namespace BattleSheep.GUI
{
    partial class FormWinner
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menang = new System.Windows.Forms.Label();
            this.tryagain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.button1.Location = new System.Drawing.Point(76, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ya, Main Lagi";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.PlayAgain);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.button2.Location = new System.Drawing.Point(189, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Kembali ke Menu";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BackToMenu);
            // 
            // menang
            // 
            this.menang.AutoSize = true;
            this.menang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.menang.Location = new System.Drawing.Point(114, 9);
            this.menang.Name = "menang";
            this.menang.Size = new System.Drawing.Size(66, 24);
            this.menang.TabIndex = 4;
            this.menang.Text = "label1";
            // 
            // tryagain
            // 
            this.tryagain.AutoSize = true;
            this.tryagain.Location = new System.Drawing.Point(110, 49);
            this.tryagain.Name = "tryagain";
            this.tryagain.Size = new System.Drawing.Size(158, 13);
            this.tryagain.TabIndex = 3;
            this.tryagain.Text = "Apakah anda mau mengulang ?";
            // 
            // FormWinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(173)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(377, 143);
            this.ControlBox = false;
            this.Controls.Add(this.tryagain);
            this.Controls.Add(this.menang);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormWinner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Permainan Selesai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label menang;
        private System.Windows.Forms.Label tryagain;
    }
}
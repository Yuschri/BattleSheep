namespace BattleSheep.GUI
{
    partial class InputDifficulty
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
            this.buttonEasy = new System.Windows.Forms.Button();
            this.buttonMedium = new System.Windows.Forms.Button();
            this.buttonHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pilih Tingkat Kesulitan";
            // 
            // buttonEasy
            // 
            this.buttonEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonEasy.Location = new System.Drawing.Point(87, 83);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(96, 40);
            this.buttonEasy.TabIndex = 1;
            this.buttonEasy.Text = "Easy";
            this.buttonEasy.UseVisualStyleBackColor = true;
            // 
            // buttonMedium
            // 
            this.buttonMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonMedium.Location = new System.Drawing.Point(87, 146);
            this.buttonMedium.Name = "buttonMedium";
            this.buttonMedium.Size = new System.Drawing.Size(96, 40);
            this.buttonMedium.TabIndex = 2;
            this.buttonMedium.Text = "Medium";
            this.buttonMedium.UseVisualStyleBackColor = true;
            // 
            // buttonHard
            // 
            this.buttonHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonHard.Location = new System.Drawing.Point(87, 209);
            this.buttonHard.Name = "buttonHard";
            this.buttonHard.Size = new System.Drawing.Size(96, 40);
            this.buttonHard.TabIndex = 3;
            this.buttonHard.Text = "Hard";
            this.buttonHard.UseVisualStyleBackColor = true;
            // 
            // InputDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 287);
            this.Controls.Add(this.buttonHard);
            this.Controls.Add(this.buttonMedium);
            this.Controls.Add(this.buttonEasy);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputDifficulty";
            this.Text = "InputDifficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEasy;
        private System.Windows.Forms.Button buttonMedium;
        private System.Windows.Forms.Button buttonHard;
    }
}
﻿namespace BattleSheep.GUI

{
    partial class GameBoardGUI
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
            //this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            //this.TestPlace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            //this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            //this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            //this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            //this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            //this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TestPlace
            // 
            //this.TestPlace.Location = new System.Drawing.Point(12, 420);
            //this.TestPlace.Name = "TestPlace";
            //this.TestPlace.Size = new System.Drawing.Size(343, 20);
            //this.TestPlace.TabIndex = 1;
            // 
            // GameBoardGUI
            // 
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            //this.Controls.Add(this.TestPlace);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameBoardGUI";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TextBox TestPlace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
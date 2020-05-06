namespace MRK {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.bt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pT = new System.Windows.Forms.Panel();
            this.lT = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.Label();
            this.pT.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt
            // 
            this.bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt.Location = new System.Drawing.Point(12, 100);
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(300, 35);
            this.bt.TabIndex = 0;
            this.bt.Text = "START";
            this.bt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mohamed Ammar\r\nschool rektz";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pT
            // 
            this.pT.BackColor = System.Drawing.Color.Silver;
            this.pT.Controls.Add(this.lT);
            this.pT.Location = new System.Drawing.Point(0, 0);
            this.pT.Name = "pT";
            this.pT.Size = new System.Drawing.Size(324, 21);
            this.pT.TabIndex = 2;
            // 
            // lT
            // 
            this.lT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lT.Location = new System.Drawing.Point(12, 0);
            this.lT.Name = "lT";
            this.lT.Size = new System.Drawing.Size(300, 21);
            this.lT.TabIndex = 1;
            this.lT.Text = "fuck em all";
            this.lT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lst
            // 
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst.ForeColor = System.Drawing.Color.Red;
            this.lst.Location = new System.Drawing.Point(0, 138);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(324, 30);
            this.lst.TabIndex = 1;
            this.lst.Text = "idle";
            this.lst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(324, 167);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.pT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Form1";
            this.pT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pT;
        private System.Windows.Forms.Label lT;
        private System.Windows.Forms.Label lst;
    }
}


namespace Client
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this._honor = new System.Windows.Forms.Label();
            this._rank = new System.Windows.Forms.Label();
            this._level = new System.Windows.Forms.Label();
            this._name = new System.Windows.Forms.Label();
            this.mini2_btn = new System.Windows.Forms.Button();
            this.close2_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this._honor);
            this.panel1.Controls.Add(this._rank);
            this.panel1.Controls.Add(this._level);
            this.panel1.Controls.Add(this._name);
            this.panel1.Controls.Add(this.mini2_btn);
            this.panel1.Controls.Add(this.close2_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 29);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _honor
            // 
            this._honor.AutoSize = true;
            this._honor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._honor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this._honor.Location = new System.Drawing.Point(1037, 3);
            this._honor.Name = "_honor";
            this._honor.Size = new System.Drawing.Size(75, 20);
            this._honor.TabIndex = 5;
            this._honor.Text = "@Honor";
            this._honor.Click += new System.EventHandler(this._honor_Click);
            this._honor.MouseDown += new System.Windows.Forms.MouseEventHandler(this._honor_MouseDown);
            // 
            // _rank
            // 
            this._rank.AutoSize = true;
            this._rank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this._rank.Location = new System.Drawing.Point(775, 3);
            this._rank.Name = "_rank";
            this._rank.Size = new System.Drawing.Size(68, 20);
            this._rank.TabIndex = 4;
            this._rank.Text = "@Rank";
            this._rank.Click += new System.EventHandler(this._rank_Click);
            this._rank.MouseDown += new System.Windows.Forms.MouseEventHandler(this._rank_MouseDown);
            // 
            // _level
            // 
            this._level.AutoSize = true;
            this._level.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._level.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this._level.Location = new System.Drawing.Point(511, 3);
            this._level.Name = "_level";
            this._level.Size = new System.Drawing.Size(68, 20);
            this._level.TabIndex = 3;
            this._level.Text = "@Level";
            this._level.MouseDown += new System.Windows.Forms.MouseEventHandler(this._level_MouseDown);
            // 
            // _name
            // 
            this._name.AutoSize = true;
            this._name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this._name.Location = new System.Drawing.Point(249, 3);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(72, 20);
            this._name.TabIndex = 2;
            this._name.Text = "@Name";
            this._name.Click += new System.EventHandler(this._name_Click);
            this._name.MouseDown += new System.Windows.Forms.MouseEventHandler(this._name_MouseDown);
            // 
            // mini2_btn
            // 
            this.mini2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
            this.mini2_btn.BackgroundImage = global::Client.Properties.Resources.minimize;
            this.mini2_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mini2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mini2_btn.Location = new System.Drawing.Point(1228, 0);
            this.mini2_btn.Name = "mini2_btn";
            this.mini2_btn.Size = new System.Drawing.Size(31, 22);
            this.mini2_btn.TabIndex = 1;
            this.mini2_btn.UseVisualStyleBackColor = false;
            this.mini2_btn.Click += new System.EventHandler(this.mini2_btn_Click);
            // 
            // close2_btn
            // 
            this.close2_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
            this.close2_btn.BackgroundImage = global::Client.Properties.Resources.close;
            this.close2_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close2_btn.Location = new System.Drawing.Point(1256, 0);
            this.close2_btn.Name = "close2_btn";
            this.close2_btn.Size = new System.Drawing.Size(24, 23);
            this.close2_btn.TabIndex = 0;
            this.close2_btn.UseVisualStyleBackColor = false;
            this.close2_btn.Click += new System.EventHandler(this.close2_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button close2_btn;
        private System.Windows.Forms.Button mini2_btn;
        private System.Windows.Forms.Label _honor;
        private System.Windows.Forms.Label _rank;
        private System.Windows.Forms.Label _level;
        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.Button button1;
    }
}
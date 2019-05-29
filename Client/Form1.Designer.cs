namespace Client
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.panel1 = new System.Windows.Forms.Panel();
			this.mini = new System.Windows.Forms.Button();
			this.close = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.serr = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.server_field = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.error_field = new System.Windows.Forms.Label();
			this.login_btn = new System.Windows.Forms.Button();
			this.nickname_field = new System.Windows.Forms.TextBox();
			this.password_field = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.panel1.Controls.Add(this.mini);
			this.panel1.Controls.Add(this.close);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1280, 31);
			this.panel1.TabIndex = 9;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			// 
			// mini
			// 
			this.mini.BackColor = System.Drawing.Color.Transparent;
			this.mini.BackgroundImage = global::Client.Properties.Resources.minimize;
			this.mini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.mini.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.mini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.mini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.mini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mini.ForeColor = System.Drawing.Color.Transparent;
			this.mini.Location = new System.Drawing.Point(1196, 0);
			this.mini.Name = "mini";
			this.mini.Size = new System.Drawing.Size(39, 31);
			this.mini.TabIndex = 10;
			this.mini.UseVisualStyleBackColor = false;
			this.mini.Click += new System.EventHandler(this.mini_Click);
			// 
			// close
			// 
			this.close.BackColor = System.Drawing.Color.Transparent;
			this.close.BackgroundImage = global::Client.Properties.Resources.close;
			this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.close.ForeColor = System.Drawing.Color.Transparent;
			this.close.Location = new System.Drawing.Point(1238, 0);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(39, 31);
			this.close.TabIndex = 10;
			this.close.UseVisualStyleBackColor = false;
			this.close.Click += new System.EventHandler(this.close_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(951, 29);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(329, 688);
			this.dataGridView1.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label2.Location = new System.Drawing.Point(6, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Password:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Nickname:";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(19)))));
			this.groupBox1.Controls.Add(this.serr);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.server_field);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.error_field);
			this.groupBox1.Controls.Add(this.login_btn);
			this.groupBox1.Controls.Add(this.nickname_field);
			this.groupBox1.Controls.Add(this.password_field);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
			this.groupBox1.Location = new System.Drawing.Point(951, 122);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(329, 406);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Login:";
			// 
			// serr
			// 
			this.serr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
			this.serr.Enabled = false;
			this.serr.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(90)))), ((int)(((byte)(40)))));
			this.serr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.serr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.serr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
			this.serr.Location = new System.Drawing.Point(9, 358);
			this.serr.Name = "serr";
			this.serr.Size = new System.Drawing.Size(308, 34);
			this.serr.TabIndex = 20;
			this.serr.Text = "Show error";
			this.serr.UseVisualStyleBackColor = false;
			this.serr.Click += new System.EventHandler(this.serr_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label3.Location = new System.Drawing.Point(17, 180);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(289, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "insert \"http://+ip\" or \"https:// + ip\" depending on the server";
			// 
			// server_field
			// 
			this.server_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.server_field.Location = new System.Drawing.Point(9, 151);
			this.server_field.Name = "server_field";
			this.server_field.Size = new System.Drawing.Size(308, 26);
			this.server_field.TabIndex = 18;
			this.server_field.TextChanged += new System.EventHandler(this.server_field_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label4.Location = new System.Drawing.Point(6, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Server ( ip : port ):";
			// 
			// error_field
			// 
			this.error_field.AutoSize = true;
			this.error_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.error_field.ForeColor = System.Drawing.Color.Red;
			this.error_field.Location = new System.Drawing.Point(6, 279);
			this.error_field.Name = "error_field";
			this.error_field.Size = new System.Drawing.Size(22, 13);
			this.error_field.TabIndex = 16;
			this.error_field.Text = "err";
			// 
			// login_btn
			// 
			this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
			this.login_btn.Enabled = false;
			this.login_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(90)))), ((int)(((byte)(40)))));
			this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.login_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
			this.login_btn.Location = new System.Drawing.Point(9, 242);
			this.login_btn.Name = "login_btn";
			this.login_btn.Size = new System.Drawing.Size(308, 34);
			this.login_btn.TabIndex = 15;
			this.login_btn.Text = "Login";
			this.login_btn.UseVisualStyleBackColor = false;
			this.login_btn.Click += new System.EventHandler(this.button1_Click);
			// 
			// nickname_field
			// 
			this.nickname_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nickname_field.Location = new System.Drawing.Point(9, 47);
			this.nickname_field.Name = "nickname_field";
			this.nickname_field.Size = new System.Drawing.Size(308, 26);
			this.nickname_field.TabIndex = 13;
			this.nickname_field.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// password_field
			// 
			this.password_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.password_field.Location = new System.Drawing.Point(9, 100);
			this.password_field.Name = "password_field";
			this.password_field.PasswordChar = '*';
			this.password_field.Size = new System.Drawing.Size(308, 26);
			this.password_field.TabIndex = 14;
			this.password_field.TextChanged += new System.EventHandler(this.password_field_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Client.Properties.Resources.diana_background_dark;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Login to League Sandbox";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button mini;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button close;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox nickname_field;
		private System.Windows.Forms.TextBox password_field;
		private System.Windows.Forms.Button login_btn;
		private System.Windows.Forms.Label error_field;
		private System.Windows.Forms.TextBox server_field;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button serr;
	}
}


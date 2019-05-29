using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;

namespace Client
{
	public partial class Form1 : Form
	{
		// http client for the network stuff
		private static readonly HttpClient client = new HttpClient();

		//Mouse Capture
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd,
			int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();




		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			error_field.Text = ""; //RESET ERROR TEXT
			serr.Visible = false;
		}



		// Toolbar
		private void close_Click(object sender, EventArgs e)
		{
			// Exit
			Environment.Exit(0);
		}
		private void mini_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Globals.nickname != "" && Globals.password != "" && Globals.server != "") {
                bool cont = false;
                
                if (!Globals.server.StartsWith("https://") && !Globals.server.StartsWith("http://"))
                {
                    error_field.Text = "Pls use http or https:// + ip ";
                    error_field.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    cont = true;
                }
                if(cont == true) {
                    string url = Globals.server + "/api/?api=login";
					try
					{
						var responseString = url
							.PostUrlEncodedAsync(new { name = Globals.nickname, password = Globals.password })
							.ReceiveString();
						if (responseString.Result != null)
						{
							dynamic data = JObject.Parse(responseString.Result);
							string status = data.Status;
							if (status == "200")
							{
								Globals.cookie = data.id;
								error_field.Text = "Logged in!";
								error_field.ForeColor = System.Drawing.Color.Green;
								Hide();
								Form2 frm2 = new Form2();
								frm2.Show();
							}
							else
							{
								error_field.Text = "Wrong username or password";
								error_field.ForeColor = System.Drawing.Color.Red;
							}
						}
						else
						{
							error_field.Text = "Empty Response!";
							error_field.ForeColor = System.Drawing.Color.Red;
						}
					}
					catch (Exception ex)
					{
						Globals.lerr = ex.ToString();

						error_field.Text = "Theres an error try again \n or take a look on the log: ";
						error_field.ForeColor = System.Drawing.Color.Red;
						serr.Visible = true;
						serr.Enabled = true;

					}
					
				}
            }
            else
            {
                error_field.Text = "Missing Fields!";
                error_field.ForeColor = System.Drawing.Color.Red;
            }
		}

		// Nickname 
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Globals.nickname = nickname_field.Text;
			valid_login_data();
		}

		private void password_field_TextChanged(object sender, EventArgs e)
		{
			Globals.password = password_field.Text;
			valid_login_data();
		}

		// calling this ever moment text in login changed to dynamicly enable / disable the login btn
		private void valid_login_data()
		{
			// test if name and pw are really defined / != ""
			if (Globals.password != "" && Globals.nickname != "" && Globals.server != "")
			{
				login_btn.Enabled = true;
			}
			else
			{
				login_btn.Enabled = false;
			}
		}

		private void server_field_TextChanged(object sender, EventArgs e)
		{
			Globals.server = server_field.Text;
			valid_login_data();
		}

		private void serr_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Last Knows Error: \n"+Globals.lerr);
		}
	}


	// Global Vars all in one place
	public static class Globals
	{
		public static String server = ""; // Modifiable
		public static String nickname = ""; // Modifiable
		public static String password = ""; // Modifiable
		public static String cookie = ""; // Modifiable
        public static String user = ""; // Modifiable
		public static String lerr = "";
	}
}

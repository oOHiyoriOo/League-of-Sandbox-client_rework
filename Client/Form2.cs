using Flurl.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {

        //Mouse Capture
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close2_btn_Click(object sender, EventArgs e)
        {
            // Exit
            Environment.Exit(0);
        }

        private void mini2_btn_Click(object sender, EventArgs e)
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
        private void Form2_Load(object sender, EventArgs e)
        {
            // laod user information on start.
            string url = Globals.server + "/api/?api=user";
            var responseString = url
                .PostUrlEncodedAsync(new { m = "r", name = Globals.nickname})
                .ReceiveString();

            string raw_data = responseString.Result.Replace("\\n","").Replace("\\","");
            dynamic data = JObject.Parse(raw_data);
            string error = data.error;
            if(error == "False")
            {
                string level = data.level;
                string honor = data.honor;
                string rank = data.rank+" "+data.devision;
                _name.Text = Globals.nickname;
                _level.Text = "Level: "+level;
                _honor.Text = "Honor: "+honor;
                _rank.Text = "Rank: "+rank;
            }
        }

        private void _name_Click(object sender, EventArgs e)
        {

        }

        private void _name_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void _level_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void _rank_Click(object sender, EventArgs e)
        {

        }

        private void _rank_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void _honor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

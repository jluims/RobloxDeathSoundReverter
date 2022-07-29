using System.Runtime.InteropServices;
namespace RobloxDeathSoundReverter
{
    public partial class MainForm : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string? robloxDir;
        bool newOof;

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            robloxDir = RobloxUtils.GetRobloxDirectory();
            newOof = robloxDir != null ? RobloxUtils.HasNewOof(robloxDir) : false;

            if (robloxDir != null)
            {
                statusLabel.Text = "Status: " + (newOof ? "new oof" : "old oof");
            }
        }

        private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private async void changeButton_Click(object sender, EventArgs e)
        {
            if (robloxDir == null)
            {
                MessageBox.Show("Failed to find ROBLOX directory, is ROBLOX installed?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (HttpClient httpClient = new HttpClient())
            {
                string baseDir = Path.Join(robloxDir, @"content\sounds\");
                string oofDir = Path.Join(baseDir, "ouch.ogg");

                string oofUrl = "https://github.com/jluims/RobloxDeathSoundReverter/raw/main/sounds/" + (newOof ? "uuhhh" : "ouch") + ".ogg";
                byte[] oofBytes = await httpClient.GetByteArrayAsync(oofUrl);

                File.WriteAllBytes(oofDir, oofBytes);
            }

            newOof = !newOof;
            statusLabel.Text = "Status: " + (newOof ? "new oof" : "old oof");
            MessageBox.Show("OOF sound changed!", "Success", MessageBoxButtons.OK);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
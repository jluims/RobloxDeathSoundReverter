namespace RobloxDeathSoundReverter
{
    public partial class Form1 : Form
    {

        string? robloxDir;
        bool newOof;

        public Form1()
        {
            InitializeComponent();
            robloxDir = RobloxUtils.GetRobloxDirectory();
            newOof = robloxDir != null ? RobloxUtils.HasNewOof(robloxDir) : false;

            if (robloxDir != null)
            {
                statusLabel.Text = "Status: " + (newOof ? "new oof" : "old oof");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
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
    }
}
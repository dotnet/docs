using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinSound
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private Button button1;

        public Form1()  //constructor
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

        [System.Flags] 
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001, 
            SND_NODEFAULT = 0x0002, 
            SND_LOOP = 0x0008, 
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000, 
            SND_FILENAME = 0x00020000, 
            SND_RESOURCE = 0x00040004 
        }

        private void button1_Click (object sender, System.EventArgs e)
        {
            OpenFileDialog dialog1 = new OpenFileDialog(); 

            dialog1.Title = "Browse to find sound file to play";
            dialog1.InitialDirectory = @"c:\";
            dialog1.Filter = "Wav Files (*.wav)|*.wav";
            dialog1.FilterIndex = 2;
            dialog1.RestoreDirectory = true;

            if(dialog1.ShowDialog() == DialogResult.OK) 
            { 
                textBox1.Text = dialog1.FileName;
                PlaySound (dialog1.FileName, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
            } 
        }
    }
}
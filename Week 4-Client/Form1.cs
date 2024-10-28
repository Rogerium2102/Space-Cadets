using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week_4_Client.Managers;

namespace Week_4_Client
{
    public partial class Form1 : Form
    {
        private NetworkManager _NetMan;
        public Form1()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            WIKIBrowser.ScriptErrorsSuppressed = true;
            WIKIBrowser.Navigate("www.wikipedia.org");
            _NetMan = new NetworkManager();
            _NetMan.Connect("127.0.0.1");
        }

        private void WIKIBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Uri CurrentURL = WIKIBrowser.Url;
            string Path = CurrentURL.AbsolutePath;
            MessageBox.Show(Path);
        }

        private void SUBBUTSendChat_Click(object sender, EventArgs e)
        {
            if (ENTRYChat.Text != "")
            {

            }
        }
    }
}

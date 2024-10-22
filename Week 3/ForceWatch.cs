using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_3
{
    public partial class ForceWatch : Form
    {
        public ForceWatch()
        {
            InitializeComponent();
        }

        public void ShowUserWebpage(string URL)
        {
            if (!URL.Contains("www.youtube.com"))
            {
                MessageBox.Show("Link did not contain youtube -- All links must go to youtube!");
                this.Close();
            }
            webBrowser1.Navigate(URL);
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}

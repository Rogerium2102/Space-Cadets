using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Week_3.Managers;

namespace Week_3
{
    public partial class Form1 : Form
    {
        private NetworkManager _NetMan;
        private ForceWatch _ForceWatch = new ForceWatch();  
        public Form1()
        {
            InitializeComponent();
            _NetMan = new NetworkManager();
        }
        private void SUBBUTIP_Click(object sender, EventArgs e)
        {
            string IPAddress = ENTRYIPAddress.Text;
            if (!_NetMan.isValidIP(IPAddress))
            {
                DISPLAYConnectStatus.Text = "FAILED: IP is not valid!";
            }
            else
            {
                Exception ex = _NetMan.Connect(IPAddress);
                if (ex == null)
                {
                    DISPLAYConnectStatus.Text = "Success!";
                    return;
                }
                DISPLAYConnectStatus.Text = ex.ToString();
            }
        }

        private bool CheckCodeValidToSend(string code)
        {
            if (code == null || code == "")
            {
                return false;
            }
            return true;
        }

        private void SUBBUTSendCode_Click(object sender, EventArgs e)
        {
            string Text = ENTRYCode.Text;
            if (!CheckCodeValidToSend(Text))
            {
                DISPLAYSubmitStatus.Text = "MALFORMATTED CODE";
                return;
            }
            Text = Text.Replace("\n", "");
            string[] Rows = Text.Split('\r');
            string Response;
            foreach (string Row in Rows)
            {
                _NetMan.Send(Row);
                Response = _NetMan.Receive();
                if (Response != "GET" && !Response.Contains("DONE"))
                {
                    DISPLAYSubmitStatus.Text = Response;
                    _ForceWatch.Show();
                    _ForceWatch.ShowUserWebpage(Response.Split('#')[1]);
                }
                else
                {
                    if (Response == "GET")
                    {
                        continue;
                    }
                    else if (Response.Contains("DONE"))
                    {
                        Response = Response.Remove(0, 5);
                        DISPLAYResponse.Lines=Response.Split('#');
                    }
                }
            }
            _NetMan.Send("COMP");
            Response = _NetMan.Receive();
            Response = Response.Remove(0, 5);
            DISPLAYResponse.Lines = Response.Split('#');
        }
    }
}

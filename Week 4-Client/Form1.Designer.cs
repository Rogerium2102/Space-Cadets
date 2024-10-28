namespace Week_4_Client
{
    partial class Form1
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
            this.WIKIBrowser = new System.Windows.Forms.WebBrowser();
            this.DISPLAYDestination = new System.Windows.Forms.Label();
            this.DISPLAYSource = new System.Windows.Forms.Label();
            this.DISPLAYChat = new System.Windows.Forms.Label();
            this.DISPLAYChatBox = new System.Windows.Forms.TextBox();
            this.ENTRYChat = new System.Windows.Forms.TextBox();
            this.SUBBUTSendChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WIKIBrowser
            // 
            this.WIKIBrowser.Location = new System.Drawing.Point(1, 148);
            this.WIKIBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WIKIBrowser.Name = "WIKIBrowser";
            this.WIKIBrowser.Size = new System.Drawing.Size(1961, 1623);
            this.WIKIBrowser.TabIndex = 0;
            this.WIKIBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WIKIBrowser_DocumentCompleted);
            // 
            // DISPLAYDestination
            // 
            this.DISPLAYDestination.AutoSize = true;
            this.DISPLAYDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DISPLAYDestination.Location = new System.Drawing.Point(92, 18);
            this.DISPLAYDestination.Name = "DISPLAYDestination";
            this.DISPLAYDestination.Size = new System.Drawing.Size(263, 51);
            this.DISPLAYDestination.TabIndex = 1;
            this.DISPLAYDestination.Text = "Destination:";
            // 
            // DISPLAYSource
            // 
            this.DISPLAYSource.AutoSize = true;
            this.DISPLAYSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DISPLAYSource.Location = new System.Drawing.Point(92, 79);
            this.DISPLAYSource.Name = "DISPLAYSource";
            this.DISPLAYSource.Size = new System.Drawing.Size(178, 51);
            this.DISPLAYSource.TabIndex = 2;
            this.DISPLAYSource.Text = "Source:";
            // 
            // DISPLAYChat
            // 
            this.DISPLAYChat.AutoSize = true;
            this.DISPLAYChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DISPLAYChat.Location = new System.Drawing.Point(1994, 79);
            this.DISPLAYChat.Name = "DISPLAYChat";
            this.DISPLAYChat.Size = new System.Drawing.Size(130, 51);
            this.DISPLAYChat.TabIndex = 3;
            this.DISPLAYChat.Text = "Chat:";
            // 
            // DISPLAYChatBox
            // 
            this.DISPLAYChatBox.Location = new System.Drawing.Point(1994, 148);
            this.DISPLAYChatBox.Multiline = true;
            this.DISPLAYChatBox.Name = "DISPLAYChatBox";
            this.DISPLAYChatBox.ReadOnly = true;
            this.DISPLAYChatBox.Size = new System.Drawing.Size(631, 1502);
            this.DISPLAYChatBox.TabIndex = 4;
            // 
            // ENTRYChat
            // 
            this.ENTRYChat.Location = new System.Drawing.Point(1994, 1656);
            this.ENTRYChat.Name = "ENTRYChat";
            this.ENTRYChat.Size = new System.Drawing.Size(631, 31);
            this.ENTRYChat.TabIndex = 5;
            // 
            // SUBBUTSendChat
            // 
            this.SUBBUTSendChat.Location = new System.Drawing.Point(2215, 1693);
            this.SUBBUTSendChat.Name = "SUBBUTSendChat";
            this.SUBBUTSendChat.Size = new System.Drawing.Size(242, 54);
            this.SUBBUTSendChat.TabIndex = 6;
            this.SUBBUTSendChat.Text = "SEND";
            this.SUBBUTSendChat.UseVisualStyleBackColor = true;
            this.SUBBUTSendChat.Click += new System.EventHandler(this.SUBBUTSendChat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2665, 1759);
            this.Controls.Add(this.SUBBUTSendChat);
            this.Controls.Add(this.ENTRYChat);
            this.Controls.Add(this.DISPLAYChatBox);
            this.Controls.Add(this.DISPLAYChat);
            this.Controls.Add(this.DISPLAYSource);
            this.Controls.Add(this.DISPLAYDestination);
            this.Controls.Add(this.WIKIBrowser);
            this.Name = "Form1";
            this.Text = "Wiki Race!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WIKIBrowser;
        private System.Windows.Forms.Label DISPLAYDestination;
        private System.Windows.Forms.Label DISPLAYSource;
        private System.Windows.Forms.Label DISPLAYChat;
        private System.Windows.Forms.TextBox DISPLAYChatBox;
        private System.Windows.Forms.TextBox ENTRYChat;
        private System.Windows.Forms.Button SUBBUTSendChat;
    }
}


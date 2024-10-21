namespace Week_3
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
            this.ENTRYCode = new System.Windows.Forms.TextBox();
            this.ENTRYIPAddress = new System.Windows.Forms.TextBox();
            this.SUBBUTIP = new System.Windows.Forms.Button();
            this.DISPLAYConnectStatus = new System.Windows.Forms.Label();
            this.DISPLAYResponse = new System.Windows.Forms.TextBox();
            this.DISPLAYIPHeader = new System.Windows.Forms.Label();
            this.DISPLAYResponseHeader = new System.Windows.Forms.Label();
            this.DISPLAYCodeHeader = new System.Windows.Forms.Label();
            this.SUBBUTSendCode = new System.Windows.Forms.Button();
            this.DISPLAYSubmitStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ENTRYCode
            // 
            this.ENTRYCode.AcceptsReturn = true;
            this.ENTRYCode.AcceptsTab = true;
            this.ENTRYCode.Location = new System.Drawing.Point(12, 154);
            this.ENTRYCode.Multiline = true;
            this.ENTRYCode.Name = "ENTRYCode";
            this.ENTRYCode.Size = new System.Drawing.Size(400, 426);
            this.ENTRYCode.TabIndex = 0;
            // 
            // ENTRYIPAddress
            // 
            this.ENTRYIPAddress.Location = new System.Drawing.Point(202, 59);
            this.ENTRYIPAddress.Name = "ENTRYIPAddress";
            this.ENTRYIPAddress.Size = new System.Drawing.Size(200, 31);
            this.ENTRYIPAddress.TabIndex = 1;
            // 
            // SUBBUTIP
            // 
            this.SUBBUTIP.Location = new System.Drawing.Point(436, 52);
            this.SUBBUTIP.Name = "SUBBUTIP";
            this.SUBBUTIP.Size = new System.Drawing.Size(194, 45);
            this.SUBBUTIP.TabIndex = 2;
            this.SUBBUTIP.Text = "Connect";
            this.SUBBUTIP.UseVisualStyleBackColor = true;
            this.SUBBUTIP.Click += new System.EventHandler(this.SUBBUTIP_Click);
            // 
            // DISPLAYConnectStatus
            // 
            this.DISPLAYConnectStatus.AutoSize = true;
            this.DISPLAYConnectStatus.Location = new System.Drawing.Point(665, 59);
            this.DISPLAYConnectStatus.Name = "DISPLAYConnectStatus";
            this.DISPLAYConnectStatus.Size = new System.Drawing.Size(0, 25);
            this.DISPLAYConnectStatus.TabIndex = 3;
            // 
            // DISPLAYResponse
            // 
            this.DISPLAYResponse.Location = new System.Drawing.Point(612, 154);
            this.DISPLAYResponse.Multiline = true;
            this.DISPLAYResponse.Name = "DISPLAYResponse";
            this.DISPLAYResponse.ReadOnly = true;
            this.DISPLAYResponse.Size = new System.Drawing.Size(400, 426);
            this.DISPLAYResponse.TabIndex = 4;
            // 
            // DISPLAYIPHeader
            // 
            this.DISPLAYIPHeader.AutoSize = true;
            this.DISPLAYIPHeader.Location = new System.Drawing.Point(197, 22);
            this.DISPLAYIPHeader.Name = "DISPLAYIPHeader";
            this.DISPLAYIPHeader.Size = new System.Drawing.Size(120, 25);
            this.DISPLAYIPHeader.TabIndex = 5;
            this.DISPLAYIPHeader.Text = "IP address:";
            // 
            // DISPLAYResponseHeader
            // 
            this.DISPLAYResponseHeader.AutoSize = true;
            this.DISPLAYResponseHeader.Location = new System.Drawing.Point(736, 113);
            this.DISPLAYResponseHeader.Name = "DISPLAYResponseHeader";
            this.DISPLAYResponseHeader.Size = new System.Drawing.Size(115, 25);
            this.DISPLAYResponseHeader.TabIndex = 6;
            this.DISPLAYResponseHeader.Text = "Response:";
            // 
            // DISPLAYCodeHeader
            // 
            this.DISPLAYCodeHeader.AutoSize = true;
            this.DISPLAYCodeHeader.Location = new System.Drawing.Point(144, 113);
            this.DISPLAYCodeHeader.Name = "DISPLAYCodeHeader";
            this.DISPLAYCodeHeader.Size = new System.Drawing.Size(69, 25);
            this.DISPLAYCodeHeader.TabIndex = 7;
            this.DISPLAYCodeHeader.Text = "Code:";
            // 
            // SUBBUTSendCode
            // 
            this.SUBBUTSendCode.Location = new System.Drawing.Point(418, 274);
            this.SUBBUTSendCode.Name = "SUBBUTSendCode";
            this.SUBBUTSendCode.Size = new System.Drawing.Size(188, 68);
            this.SUBBUTSendCode.TabIndex = 8;
            this.SUBBUTSendCode.Text = "Send to interpreter";
            this.SUBBUTSendCode.UseVisualStyleBackColor = true;
            this.SUBBUTSendCode.Click += new System.EventHandler(this.SUBBUTSendCode_Click);
            // 
            // DISPLAYSubmitStatus
            // 
            this.DISPLAYSubmitStatus.AutoSize = true;
            this.DISPLAYSubmitStatus.Location = new System.Drawing.Point(13, 587);
            this.DISPLAYSubmitStatus.Name = "DISPLAYSubmitStatus";
            this.DISPLAYSubmitStatus.Size = new System.Drawing.Size(0, 25);
            this.DISPLAYSubmitStatus.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 620);
            this.Controls.Add(this.DISPLAYSubmitStatus);
            this.Controls.Add(this.SUBBUTSendCode);
            this.Controls.Add(this.DISPLAYCodeHeader);
            this.Controls.Add(this.DISPLAYResponseHeader);
            this.Controls.Add(this.DISPLAYIPHeader);
            this.Controls.Add(this.DISPLAYResponse);
            this.Controls.Add(this.DISPLAYConnectStatus);
            this.Controls.Add(this.SUBBUTIP);
            this.Controls.Add(this.ENTRYIPAddress);
            this.Controls.Add(this.ENTRYCode);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ENTRYCode;
        private System.Windows.Forms.TextBox ENTRYIPAddress;
        private System.Windows.Forms.Button SUBBUTIP;
        private System.Windows.Forms.Label DISPLAYConnectStatus;
        private System.Windows.Forms.TextBox DISPLAYResponse;
        private System.Windows.Forms.Label DISPLAYIPHeader;
        private System.Windows.Forms.Label DISPLAYResponseHeader;
        private System.Windows.Forms.Label DISPLAYCodeHeader;
        private System.Windows.Forms.Button SUBBUTSendCode;
        private System.Windows.Forms.Label DISPLAYSubmitStatus;
    }
}


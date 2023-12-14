namespace RandomCats.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.button3 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1262, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Random cat API [1]";
            this.toolTip1.SetToolTip(this.button1, "Retrieve multiple random cat photos from API with number 1.");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.GetRandomCat1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1262, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Random fox";
            this.toolTip1.SetToolTip(this.button2, "Get a photo of a random fox.");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.GetRandomFox_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1262, 153);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 35);
            this.button4.TabIndex = 0;
            this.button4.Text = "Random cat facts";
            this.toolTip1.SetToolTip(this.button4, "Get facts about cats.");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.GetRandomCatFacts_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(1261, 301);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 35);
            this.button5.TabIndex = 5;
            this.button5.Text = "Random cat API [2]";
            this.toolTip1.SetToolTip(this.button5, "Retrieve multiple random cat photos from API with number 2.");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.GetRandomCat2_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(1262, 342);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(170, 35);
            this.button6.TabIndex = 6;
            this.button6.Text = "Random cat gif";
            this.toolTip1.SetToolTip(this.button6, "Get random cat gif.");
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.GetRandomCatGif_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(1262, 383);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(167, 35);
            this.button7.TabIndex = 7;
            this.button7.Text = "Random cute cat";
            this.toolTip1.SetToolTip(this.button7, "Get random cute cat.");
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.GetRandomCuteCat_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(1261, 424);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(170, 35);
            this.button8.TabIndex = 8;
            this.button8.Text = "Random sad cat";
            this.toolTip1.SetToolTip(this.button8, "Get random sad cat >~~<");
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.GetRandomSadCat_Click);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(1262, 465);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(167, 35);
            this.button9.TabIndex = 9;
            this.button9.Text = "Cat says...";
            this.toolTip1.SetToolTip(this.button9, "Inserts text into the cat image.");
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.CatSays_Click);
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(1262, 506);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(170, 35);
            this.button10.TabIndex = 10;
            this.button10.Text = "Cat says... [GIF]";
            this.toolTip1.SetToolTip(this.button10, "Inserts text into a random cat GIF.");
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.CatSaysGif_Click);
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(1262, 694);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(170, 48);
            this.button11.TabIndex = 11;
            this.button11.Text = "Random cat\r\nV by breed V";
            this.toolTip1.SetToolTip(this.button11, "Get a random cat based on its breed and information about it.");
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.JustGetCatPic_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1262, 749);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 14;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.Black;
            this.webView21.ForeColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(12, 12);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1244, 758);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1262, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 44);
            this.button3.TabIndex = 15;
            this.button3.Text = "Informations";
            this.toolTip1.SetToolTip(this.button3, "Get information about the application version and author.");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Informations_Click);
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(1262, 62);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(169, 44);
            this.button12.TabIndex = 16;
            this.button12.Text = "Options";
            this.toolTip1.SetToolTip(this.button12, "Go to the options window.");
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.Options_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "100 Continue",
            "101 Switching Protocols",
            "102 Processing",
            "103 Early Hints",
            "200 OK",
            "201 Created",
            "202 Accepted",
            "203 Non-Authoritative Information",
            "204 No Content",
            "206 Partial Content",
            "207 Multi-Status",
            "300 Multiple Choices",
            "301 Moved Permanently",
            "302 Found",
            "303 See Other",
            "304 Not Modified",
            "305 Use Proxy",
            "307 Temporary Redirect",
            "308 Permanent Redirect",
            "400 Bad Request",
            "401 Unauthorized",
            "402 Payment Required",
            "406 Not Acceptable",
            "407 Proxy Authentication Required",
            "408 Request Timeout",
            "409 Conflict",
            "410 Gone",
            "411 Length Required",
            "412 Precondition Failed",
            "413 Payload Too Large",
            "414 Request-URI Too Long",
            "415 Unsupported Media Type",
            "416 Request Range Not Satisfiable",
            "417 Expectation Failed",
            "418 I’m a teapot",
            "420 Enhance Your Calm",
            "421 Misdirected Request",
            "422 Unprocessable Entity",
            "423 Locked",
            "424 Failed Dependency",
            "425 Too Early",
            "426 Upgrade Required",
            "428 Precondition Required",
            "429 Too Many Requests",
            "431 Request Header Fields Too Large",
            "444 No Response",
            "450 Blocked by Windows Parental Controls",
            "451 Unavailable For Legal Reasons",
            "497 HTTP Request Sent to HTTPS Port",
            "498 Token expired/invalid",
            "499 Client Closed Request",
            "500 Internal Server Error",
            "501 Not Implemented",
            "502 Bad Gateway",
            "503 Service Unavailable",
            "504 Gateway Timeout",
            "506 Variant Also Negotiates",
            "507 Insufficient Storage",
            "508 Loop Detected",
            "509 Bandwidth Limit Exceeded",
            "510 Not Extended",
            "511 Network Authentication Required",
            "521 Web Server Is Down",
            "522 Connection Timed Out",
            "523 Origin Is Unreachable",
            "525 SSL Handshake Failed",
            "530 Site Frozen",
            "599 Network Connect Timeout Error"});
            this.comboBox2.Location = new System.Drawing.Point(1262, 667);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(170, 21);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 18;
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(1262, 612);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(170, 48);
            this.button13.TabIndex = 17;
            this.button13.Text = "Get HTTP cats";
            this.toolTip1.SetToolTip(this.button13, "Great thing to have if you\'re creating a website and want to have cool status pag" +
        "es.");
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.GetRandomHTTPCat_Click);
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(1347, 112);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(85, 35);
            this.button14.TabIndex = 19;
            this.button14.Text = "Pinterest";
            this.toolTip1.SetToolTip(this.button14, "Open a Pinterest page with random cats. Clicking this button again will generate " +
        "different cats based on the search.");
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.Pinterest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::RandomCats.Properties.Resources._39632;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1443, 782);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random kittens";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox comboBox1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


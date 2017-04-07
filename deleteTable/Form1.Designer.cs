namespace deleteTable
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.button_Ask = new System.Windows.Forms.Button();
            this.button_Drop = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_From = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(59, 12);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(129, 22);
            this.textBox_IP.TabIndex = 0;
            // 
            // textBox_Log
            // 
            this.textBox_Log.BackColor = System.Drawing.Color.White;
            this.textBox_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Log.Location = new System.Drawing.Point(12, 71);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ReadOnly = true;
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(261, 226);
            this.textBox_Log.TabIndex = 3;
            // 
            // button_Ask
            // 
            this.button_Ask.Location = new System.Drawing.Point(194, 10);
            this.button_Ask.Name = "button_Ask";
            this.button_Ask.Size = new System.Drawing.Size(55, 22);
            this.button_Ask.TabIndex = 2;
            this.button_Ask.Text = "Ask";
            this.button_Ask.UseVisualStyleBackColor = true;
            this.button_Ask.Click += new System.EventHandler(this.button_Ask_Click);
            // 
            // button_Drop
            // 
            this.button_Drop.Location = new System.Drawing.Point(194, 38);
            this.button_Drop.Name = "button_Drop";
            this.button_Drop.Size = new System.Drawing.Size(55, 22);
            this.button_Drop.TabIndex = 3;
            this.button_Drop.Text = "Drop";
            this.button_Drop.UseVisualStyleBackColor = true;
            this.button_Drop.Click += new System.EventHandler(this.button_Drop_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(45, 40);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(45, 22);
            this.textBox_Port.TabIndex = 1;
            // 
            // textBox_From
            // 
            this.textBox_From.Location = new System.Drawing.Point(135, 40);
            this.textBox_From.Name = "textBox_From";
            this.textBox_From.Size = new System.Drawing.Size(53, 22);
            this.textBox_From.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Table IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "From:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 302);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(243, 12);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.MouseHover += new System.EventHandler(this.progressBar1_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 320);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_From);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.button_Drop);
            this.Controls.Add(this.button_Ask);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.textBox_IP);
            this.Name = "Form1";
            this.Text = "Useless Table Dropping Tool (version:X)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_Ask;
        private System.Windows.Forms.Button button_Drop;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_From;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


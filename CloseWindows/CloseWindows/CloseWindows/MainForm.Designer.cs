namespace CloseWindows
{
    partial class Mainform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.tbCommandResult = new System.Windows.Forms.TextBox();
            this.lbTimer = new System.Windows.Forms.Label();
            this.timerComputer = new System.Windows.Forms.Timer(this.components);
            this.btCloseWin = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dtTimer = new System.Windows.Forms.DateTimePicker();
            this.lbDifValue = new System.Windows.Forms.Label();
            this.timerCntDown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 35);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(56, 35);
            this.tbCommand.Margin = new System.Windows.Forms.Padding(4);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(357, 25);
            this.tbCommand.TabIndex = 1;
            // 
            // tbCommandResult
            // 
            this.tbCommandResult.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbCommandResult.ForeColor = System.Drawing.SystemColors.Window;
            this.tbCommandResult.Location = new System.Drawing.Point(56, 165);
            this.tbCommandResult.Margin = new System.Windows.Forms.Padding(4);
            this.tbCommandResult.Multiline = true;
            this.tbCommandResult.Name = "tbCommandResult";
            this.tbCommandResult.Size = new System.Drawing.Size(492, 234);
            this.tbCommandResult.TabIndex = 2;
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.ForeColor = System.Drawing.Color.Blue;
            this.lbTimer.Location = new System.Drawing.Point(56, 72);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(159, 15);
            this.lbTimer.TabIndex = 3;
            this.lbTimer.Text = "0000-00-00 00:00:00";
            // 
            // timerComputer
            // 
            this.timerComputer.Interval = 1000;
            this.timerComputer.Tick += new System.EventHandler(this.timerComputer_Tick);
            // 
            // btCloseWin
            // 
            this.btCloseWin.Location = new System.Drawing.Point(330, 75);
            this.btCloseWin.Name = "btCloseWin";
            this.btCloseWin.Size = new System.Drawing.Size(83, 29);
            this.btCloseWin.TabIndex = 4;
            this.btCloseWin.Text = "Close";
            this.btCloseWin.UseVisualStyleBackColor = true;
            this.btCloseWin.Click += new System.EventHandler(this.btCloseWin_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(467, 75);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(83, 29);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dtTimer
            // 
            this.dtTimer.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtTimer.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimer.Location = new System.Drawing.Point(56, 93);
            this.dtTimer.Name = "dtTimer";
            this.dtTimer.Size = new System.Drawing.Size(197, 25);
            this.dtTimer.TabIndex = 6;
            // 
            // lbDifValue
            // 
            this.lbDifValue.AutoSize = true;
            this.lbDifValue.ForeColor = System.Drawing.Color.Green;
            this.lbDifValue.Location = new System.Drawing.Point(56, 130);
            this.lbDifValue.Name = "lbDifValue";
            this.lbDifValue.Size = new System.Drawing.Size(67, 15);
            this.lbDifValue.TabIndex = 7;
            this.lbDifValue.Text = "取消关机";
            // 
            // timerCntDown
            // 
            this.timerCntDown.Interval = 1000;
            this.timerCntDown.Tick += new System.EventHandler(this.timerCntDown_Tick);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 430);
            this.Controls.Add(this.lbDifValue);
            this.Controls.Add(this.dtTimer);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btCloseWin);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.tbCommandResult);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Mainform";
            this.Text = "调用cmd.exe并显示指令结果";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.TextBox tbCommandResult;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Timer timerComputer;
        private System.Windows.Forms.Button btCloseWin;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DateTimePicker dtTimer;
        private System.Windows.Forms.Label lbDifValue;
        private System.Windows.Forms.Timer timerCntDown;
    }
}


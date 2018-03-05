using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CloseWindows
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timerComputer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Process CmdProcess = new Process();
            //CmdProcess.StartInfo.FileName = "cmd.exe";
            //CmdProcess.Start();

            //RunProgram(tbCommand.Text);
            /*
            string cmd = tbCommand.Text;
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态  
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动  
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息  
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息  
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出  
                p.StartInfo.CreateNoWindow = true;          //不显示程序窗口  
                p.Start();//启动程序  
                //向cmd窗口写入命令  
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;
                //获取cmd窗口的输出信息  
                StreamReader reader = p.StandardOutput;//截取输出流  
                string line = reader.ReadLine();//每次读取一行  
                tbCommandResult.AppendText(line + "\n");
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    tbCommandResult.AppendText(line + "\n");
                }
                p.WaitForExit();//等待程序执行完退出进程  
                p.Close();
            } */

            RunProgram(tbCommand.Text);
        }
        /// <summary>
        /// 打开cmd.exe
        /// </summary>
        /// <param name="cmd">要执行的命令</param>
        public void RunProgram(string cmd)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = "cmd.exe";
            CmdProcess.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
            CmdProcess.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            CmdProcess.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            CmdProcess.StartInfo.RedirectStandardError = true;//重定向标准错误输出        
            CmdProcess.StartInfo.CreateNoWindow = true;//不显示程序窗口
            CmdProcess.Start();//启动程序
            if (cmd.Length != 0)
            {
                CmdProcess.StandardInput.WriteLine(cmd);//像CMD窗口写入指令
            }
            //CmdProcess.StandardInput.WriteLine("exit");
            CmdProcess.StandardInput.AutoFlush = true;        
            //获取CMD窗口的输出信息
            StreamReader reader = CmdProcess.StandardOutput;//截取输出流 
            string line = reader.ReadLine();
            tbCommandResult.AppendText(line + "\n");
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                tbCommandResult.AppendText(line + "\n");
            }
            CmdProcess.WaitForExit();//等待程序执行完退出进程
            CmdProcess.Close();     
        }

        private void timerComputer_Tick(object sender, EventArgs e)
        {
            lbTimer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            string cmd = "shutdown -a";//取消关机
            RunProgram(cmd);
            //lbDifValue.Text = "0" + "天" + "0" + "小时" + "0" + "分" + "秒";
            lbDifValue.Text = "取消关闭计算机";
            lbDifValue.ForeColor = System.Drawing.Color.Green;
            timerCntDown.Stop();
        }
        public int num = 0;
        public int cutNum = 0;
        public int daySecond = 0;
        public int hourSecond = 0;
        public int minuteSecond = 0;
        public int second = 0;
        public int sumSecond = 0;
        private void btCloseWin_Click(object sender, EventArgs e)
        {           
            char[] chars =  DateDiff(dtTimer.Value).ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {

                if (chars[i] == Convert.ToChar("天"))
                {
                    num = i - 0;//天的位数
                    cutNum = i;//天之前的数据占得长度
                    if (chars[i-1] != 48)//不为0
                    {
                        for (int j = 0; j < i; j++)
                        {
                            num--;
                            daySecond += (chars[j]-48) * 24 * 60 * 60 * Convert.ToInt16( Math.Pow(10, num));                            
                        }
                    }
                    cutNum = cutNum + 1; //天之前的数据占得长度 +包括天字本身
                }
                else if (chars[i] == Convert.ToChar("小") && chars[i+1] == Convert.ToChar("时"))
                {
                    num = i - cutNum;//小时的位数
                    cutNum = i; //天跟小时之间的数据长度
                    if (chars[i - 1] != 48)//不为0
                    {
                        for (int j = cutNum - num; j < i; j++)
                        {
                            num--;
                            hourSecond += (chars[j] - 48) * 60 * 60 * Convert.ToInt16(Math.Pow(10, num));
                        }
                    }
                    cutNum = cutNum + 2; //天跟小时之间的数据长度 + 包括小时本身
                }
                else if (chars[i] == Convert.ToChar("分") && chars[i + 1] == Convert.ToChar("钟"))
                {
                    num = i - cutNum;//分钟的位数
                    cutNum = i; //小时跟分钟之间的数据长度
                    if (chars[i - 1] != 48)//不为0
                    {
                        for (int j = cutNum- num; j < i; j++)
                        {
                            num--;
                            minuteSecond += (chars[j] - 48) * 60 * Convert.ToInt16(Math.Pow(10, num));
                        }
                    }
                    cutNum = cutNum + 2; //小时跟分钟之间的数据长度 + 包括分钟本身
                }
                else if (chars[i] == Convert.ToChar("秒") )
                {
                    num = i - cutNum;//秒的位数
                    cutNum = i; //小时跟分钟之间的数据长度
                    for (int j = cutNum- num; j < i; j++)
                    {
                        num--;
                        minuteSecond += (chars[j] -48) * Convert.ToInt16(Math.Pow(10, num));
                    }
                }
            }
            sumSecond = daySecond + hourSecond + minuteSecond + second;//总时间
            string stdown;
            stdown = "shutdown"+ " -"+"s"+ " -"+"t "+ Convert.ToString(sumSecond) ;
            RunProgram(stdown);
            lbDifValue.Text = DateDiff(dtTimer.Value);
            lbDifValue.ForeColor = System.Drawing.Color.Red;
            daySecond = 0;
            hourSecond = 0;
            minuteSecond = 0;
            second = 0;
            sumSecond = 0;
            timerCntDown.Start();
        }
        /// <summary>
        /// 已重载.计算一个时间与当前本地日期和时间的时间间隔,返回的是时间间隔的日期差的绝对值.
        /// </summary>
        /// <param name="DateTime1">一个日期和时间</param>
        /// <returns></returns>
        private string DateDiff(DateTime DateTime1)
        {
            return this.DateDiff(DateTime1, DateTime.Now);
        }
        /// <summary>
        /// 已重载.计算两个日期的时间间隔,返回的是时间间隔的日期差的绝对值.
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days.ToString() + "天"
                        + ts.Hours.ToString() + "小时"
                        + ts.Minutes.ToString() + "分钟"
                        + ts.Seconds.ToString() + "秒";
            }
            catch
            {

            }
            return dateDiff;
        }

        private void timerCntDown_Tick(object sender, EventArgs e)
        {

        }
    }
}

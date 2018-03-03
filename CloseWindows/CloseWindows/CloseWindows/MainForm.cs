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
    }
}

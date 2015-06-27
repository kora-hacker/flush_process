using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace flush_process
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] read_command_from_config_file()
        {
            // File command_file = new File(config_file_path + config_id + ".txt");
            string[] command_line = System.IO.File.ReadAllLines(@"C:\Users\CIA003HX\Desktop\taskkill_config\in.txt");
            return command_line;
        }


        public void task_kill_thread()
        {
            string[] _command_ = read_command_from_config_file();


            // ---- Process.Start("cmd.exe", _command_[i]);
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            for (int i = 0; i < _command_.Length; i++)
            {
                // System.IO.File.AppendAllText(log_file_path, ">> " + _command_[i] + "\r\n");
                p.StandardInput.WriteLine(_command_[i]);
            }
        }


        /// <summary>
        /// 重写WndProc函数
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                if (m.WParam.ToInt32() == 102)
                {
                    //  MessageBox.Show("这里就是入口了啊");
                    Thread t = new Thread(new ThreadStart(task_kill_thread));
                    t.Start();
                }
            }

            /*switch (m.Msg)
            {
                case WM_HOTKEY:
                    {
                        //MessageBox.Show("102-a");
                        switch (m.WParam.ToInt32())
                        {
                            case 102:
                                MessageBox.Show("102-a");
                                break;
                        }
                        break;
                    }
            }*/
            base.WndProc(ref m);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            HotKey.RegisterHotKey(this.Handle, 102, HotKey.KeyModifiers.Alt, Keys.A);
        }
    }
}



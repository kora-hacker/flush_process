using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace flush_process
{
    public partial class ServiceFlushProcessMain : ServiceBase
    {

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
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
            }
            base.WndProc(ref m);
        }

        public ServiceFlushProcessMain()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.IO.File.AppendAllText(@"C:\Users\CIA003HX\Desktop\log.txt","kora.hacker@qq.com\r\n");
        }

        protected override void OnStop()
        {
            System.IO.File.AppendAllText(@"C:\Users\CIA003HX\Desktop\log.txt", "Flush Process Service is stoped!\r\n================================\r\n");
        }
    }
}

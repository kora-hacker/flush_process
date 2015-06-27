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

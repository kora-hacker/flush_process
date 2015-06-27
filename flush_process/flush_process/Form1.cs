using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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



        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            HotKey.RegisterHotKey(this.Handle, 102, HotKey.KeyModifiers.Alt, Keys.A);
        }
    }
}

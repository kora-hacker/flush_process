using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace combox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add(Keys.A);
            this.comboBox1.Items.Add(Keys.B);
            this.comboBox1.Items.Add(Keys.C);
            this.comboBox1.Items.Add(Keys.D);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HotKey.RegisterHotKey(this.Handle, 102, HotKey.KeyModifiers.Alt, Keys.A);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode + "");
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

        private void button2_Click(object sender, EventArgs e)
        {
          
            Keys key=(Keys)this.comboBox1.Items[this.comboBox1.SelectedIndex];
        }
    }
}

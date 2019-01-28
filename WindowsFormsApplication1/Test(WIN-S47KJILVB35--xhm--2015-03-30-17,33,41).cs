using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            webBrowser1.Url = new Uri("http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks);
            webBrowser1.ScriptErrorsSuppressed = false;


            button1_Click(null, null);
            timer1.Interval = 20000;
        }

        //对错误进行处理 
        void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true; // 阻止其他地方继续处理 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!timer1.Enabled)
            {
                timer1.Start();
            }
            button1.Enabled = false;
            button2.Enabled = true;
        }

        //private void Reload()
        //{
        //    System.Timers.Timer aTimer = new System.Timers.Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(aTimer_Elapsed);
        //}

        //private static void aTimer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    webBrowser1.Url = new Uri("http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks);
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            //注册捕获控件的错误的处理事件 
            this.webBrowser1.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);

            try
            {
                if (DateTime.Now.Minute == 58 || DateTime.Now.Minute == 59 || DateTime.Now.Minute == 0)
                {

                    webBrowser1.Url = new Uri("http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks);
                    //webBrowser1.Url = new Uri("http://baidu.com");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            button2.Enabled = false;
            button1.Enabled = true;

        }
    }
}

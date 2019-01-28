using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {

        List<CookieContainer> listcc = new List<CookieContainer>();

        CookieContainer cc = new CookieContainer();

        public MainForm()
        {
            InitializeComponent();
            // if (DateTime.Now > new DateTime(2016, 1, 1))
            // {
                // MessageBox.Show("请联系开发开发者");
                // this.Close();
            // }
        }

        HttpHelper webHelper = new HttpHelper();



        //对错误进行处理 
        void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true; // 阻止其他地方继续处理 
        }

        #region StartTimer

        private void button1_Click(object sender, EventArgs e)
        {
            ////注册捕获控件的错误的处理事件 
            //this.webBrowser1.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);

            if (!timer1.Enabled)
            {
                timer1.Start();
            }
            button1.Enabled = false;
            button2.Enabled = true;
        }

        #endregion



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour > 9 && DateTime.Now.Hour < 24)
            {
                if(DateTime.Now.Minute == 0||DateTime.Now.Minute == 1||DateTime.Now.Minute == 2)
                {
                    string url = "http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks;

                    string result = webHelper.GetHtml(url, cc);
                    //txtCopyrightInfo.Text = result;
                    if (result.Contains("<div class=\"jp\">"))
                    {
                        webBrowser1.Visible = false;
                        //webBrowser1.Navigate("about:blank");
                        //while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                        //{
                        //    Application.DoEvents();
                        //}

                        LoadJPResult(result);
                        Thread.Sleep(40 * 60 * 1000);
                    }
                }
            }
        }

        #region 手动添加Cookie,模拟登陆
        //手动添加Cookie,模拟登陆
        private void Login()
        {
            Uri uri = new Uri("http://c.hanyou.com");
            cc.Add(uri, new Cookie("JSESSIONID", "FBE29793BB28C08651F672DE1086AA53"));
            cc.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
            cc.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
            cc.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
        }
        #endregion

        #region StopTimmer

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            button2.Enabled = false;
            button1.Enabled = true;

        }
        #endregion

        #region 刷新排行

        private void Loadbcph()
        {
            string replacestr = "<div class=\"header\">\r\n\t\r\n    <div class=\"cross2\"></div>\r\n</div>\r\n";
            string result = "<html><head><link href='http://c.hanyou.com/redpacket/style.css' type='text/css' rel='Stylesheet'/></head><body>" + webHelper.GetHtml("http://c.hanyou.com/redpacket/rank.do?type=1", cc) + "</body></html>";

            webBrowser2.Navigate("about:blank");
            while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            this.webBrowser2.Document.Write(result.Replace(replacestr, ""));

        }
        private void Loadjrph()
        {
            string replacestr = "<div class=\"header\">\r\n\t\r\n    <div class=\"cross2\"></div>\r\n</div>\r\n";

            string result2 = "<html><head><link href='http://c.hanyou.com/redpacket/style.css' type='text/css' rel='Stylesheet'/></head><body>" + webHelper.GetHtml("http://c.hanyou.com/redpacket/rank.do?type=2", cc) + "</body></html>";


            webBrowser3.Navigate("about:blank");
            while (webBrowser3.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            this.webBrowser3.Document.Write(result2.Replace(replacestr, ""));
        }

        #endregion

        #region 加载抢到奖牌后的首页
        private void LoadJPResult(string result)
        {
            string jpcount = GetValue(result, "<div class=\"jp\">", "\r\n\t\t        <div class=\"btns\">\n");

            string re = "<div style=\"color:#666666;text-align:center;\"><h1 style=\"font-size: 44px\">恭喜您抢到" + jpcount + "块奖牌</h1><br/><h2 style=\"font-size: 35px\">" + DateTime.Now.AddMinutes(5).Hour + "点</h2></div>";

           // string re = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title>财神喜降临</title>\r\n    <link href=\"http://c.hanyou.com/redpacket/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <script type=\"text/javascript\" src=\"http://c.hanyou.com/skin/js/jquery.min.js\"></script>\r\n</head>\r\n<body>\r\n    <div class=\"csWrap1\">\r\n        <div class=\"mid\">\r\n            <div class=\"picBg\" style=\"width: 192px;\">\r\n                <img src=\"http://c.hanyou.com/redpacket/images/hb.png\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"jp\" style=\"left: 173.5px;\">" + jpcount + "</div>\r\n        <div class=\"btns\">\r\n            <div class=\"bcphBtn\">本次排行</div>\r\n            <div class=\"lsphBtn\">今日排行</div>\r\n        </div>\r\n        <div class=\"qsckk\">下次多刷点</div>\r\n        <div class=\"txt\">成为VIP有更高的几率获得更多奖牌，还可以去“吐槽”里面抢红包!</div>\r\n        <div class=\"pahang\" style=\"display: none\"></div>\r\n    </div>\r\n </body>\r\n</html>\r\n";

            this.webBrowser1.Document.Write(re);
        }
        #endregion

        #region 刷新排行
        private void button3_Click_1(object sender, EventArgs e)
        {
            Loadbcph();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Loadjrph();
        }

        #endregion

        #region 获得字符串中开始和结束字符串中间得值
        /// 获得字符串中开始和结束字符串中间得值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="s">开始</param>
        /// <param name="e">结束</param>
        /// <returns></returns>
        private string GetValue(string str, string s, string e)
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }

        #endregion


        #region 任务栏
        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void NotiIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.tabControl1.SelectTab("tabPage1");

            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);//这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。
            this.Dispose();
            this.Close();
        }

        #endregion

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();

            this.WindowState = FormWindowState.Normal;
            this.tabControl1.SelectTab("tabPage3");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Login();
            webBrowser1.Url = new Uri("http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks);
            webBrowser1.ScriptErrorsSuppressed = false;
            button1_Click(null, null);
            timer1.Interval = 59*1000;//59s
            Loadbcph(); Loadjrph();

        }

    }
}

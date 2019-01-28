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
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Test1 : Form
    {

        List<CookieContainer> listcc = new List<CookieContainer>();

        CookieContainer cc = new CookieContainer();

        public Test1()
        {
            InitializeComponent();

            Login();
            webBrowser1.Url = new Uri("http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks);
            webBrowser1.ScriptErrorsSuppressed = false;
            button1_Click(null, null);
            timer1.Interval = 10000;
            Loadbcph(); Loadjrph();
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
            if (DateTime.Now.Hour > 9 && DateTime.Now.Hour < 24 && (DateTime.Now.Minute >= 58 || DateTime.Now.Minute <= 2))
            {
                string url = "http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks;

                //foreach (CookieContainer cc in listcc)
                //{
                //    string result = webHelper.GetHtml(url, cc);
                //}

                //webBrowser1.Url = new Uri(url);

                string result = webHelper.GetHtml(url, cc);
                if (result.Contains("<div class=\"jp\">"))
                {

                    webBrowser1.Navigate("about:blank");
                    while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                    }

                    LoadJPResult(result);
                }
            }
        }

        private void Login()
        {
            #region Login
            //string url1 = "http://game.skycn.com/client_stat.xhtml";
            //string postData1 = "action=login%5Ftool%5Fsubmit&adwordId=143015&appKey=39f7beec01393c87d4906192fc4fe764&c=clientStat&cookieId=184704CED5AEFDE9C01AA76A3B9B1005%3AFG%3D1&loginflag=youyang&macId=00C2C60B95E2&pmId=10100400196&serverId=1&type=client%5Fstat&user%5Flevel=%2D1&userId=-1";

            //string url2 = "http://game.skycn.com//bplat/client/local/security_client_local_login.xhtml";
            //string postData2 = "appKey=39f7beec01393c87d4906192fc4fe764&c=login&loginName=jxyxhz&password=i8mGUEgkcUMTdU3VdSCFtQ%3D%3D";


            //string url4 = "http://c.hanyou.com/checkUserInfo.do?userId=218320559&sid=hFmD%2Fk5TLoT7jkCGGo3ihNbnNSSl%2BMGMSqLpZKwMS0lLwZjAWDBrd3nF9MoDkVKJ3hr66md2KLNpqSH3RQu0FNuaIBH0R6g6gtILHm8KBt3rrGD05ydlNg%3D%3D%00&platform=996&key=skygame";

            //string url5 = "http://c.hanyou.com/checkcomputer.do?userId=4825075&computerId=fbc716a99dfbc5f443d4b1e646e1bdda&rand=1429026008";


            //string url6 = "http://c.hanyou.com/login.do?platform=996&userId=4825075&token=23CB398B-E8FE-43BC-814F-9FABA62E1ADB";

            //string r1 = webHelper.GetHtml(url1, postData1, true, webHelper.CookieContainer);

            //string r2 = webHelper.GetHtml(url2, postData2, true, webHelper.CookieContainer);

            //string loginToken = GetValue(r2, "\"loginToken\":\"", ",\"userId\":");
            //string url3 = "http://game.skycn.com/bplat/client/local/security_client_local_login.xhtml";
            //string postData3 = "c=createOnceKey&loginToken=a98c909fa10a44919855972d27ce6bbb&random=99ee4690e33d612f&sign=79edfcf61ca460a6c230a8d562dac219c5074e5b&userId=218320559";
            ////string postData3 = "c=createOnceKey&loginToken=" + loginToken + "&random=99ee4690e33d612f&sign=79edfcf61ca460a6c230a8d562dac219c5074e5b&userId=218320559";

            //string r3 = webHelper.GetHtml(url3, postData3, true, webHelper.CookieContainer);

            //string r4 = webHelper.GetHtml(url4, webHelper.CookieContainer);

            //string r5 = webHelper.GetHtml(url5, webHelper.CookieContainer);

            //string r6 = webHelper.GetHtml(url6, webHelper.CookieContainer);


            Uri uri = new Uri("http://c.hanyou.com");
            cc.Add(uri, new Cookie("JSESSIONID", "FBE29793BB28C08651F672DE1086AA53"));
            cc.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
            cc.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
            cc.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));

            #region test
            //CookieContainer c444 = new CookieContainer();
            //string r4 = webHelper.GetHtml(url4, c444);

            //List<Cookie> listcookie = GetAllCookies(webHelper.CookieContainer);

            //WebHeaderCollection Headers = webHelper.Headers;
            //string cookiestr = c444.GetCookieHeader(new Uri(url4));

            //webHelper.CookieContainer = new CookieContainer();
            //string _SeesionID = webHelper.response.Cookies["JSESSIONID"].Value;
            //foreach (string item in Headers)
            //{
            //    string value = Headers.Get(item);
            //}

            #endregion

            #endregion

            #region 循环CookieCollection到list
            //CookieContainer cc1 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
            //Uri uri = new Uri("http://c.hanyou.com");
            ////JSESSIONID=07008F161400384DAA49AEA5EF47E23A; LAST_LOGIN_PLATFORM=996; 996_LAST_LOGIN_UID=322BDDA01B2A962DE6FDBDAFEF9C69B0; 
            ////996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
            ////jxyxhz
            //cc1.Add(uri, new Cookie("JSESSIONID", "FBE29793BB28C08651F672DE1086AA53"));
            //cc1.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
            //cc1.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
            //cc1.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));

            //listcc.Add(cc1);

            #region MyRegion
            ////jxyxhz1

            ////JSESSIONID=9A0F8BB38DBEA396F174FAC9D939FC48; LAST_LOGIN_PLATFORM=996; 996_LAST_LOGIN_UID=322BDDA01B2A962DE6FDBDAFEF9C69B0; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
            ////JSESSIONID=4C1C3FD642C634528414646F5B013DEE; LAST_LOGIN_PLATFORM=996; 996_LAST_LOGIN_UID=61E483600BB6562854E72F16702E250A; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
            //CookieContainer cc2 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
            //cc2.Add(uri, new Cookie("JSESSIONID", "9A0F8BB38DBEA396F174FAC9D939FC48"));
            //cc2.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
            //cc2.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
            //cc2.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
            //listcc.Add(cc2);

            ////jxyxhz12
            ////Cookie: JSESSIONID=4C1C3FD642C634528414646F5B013DEE; LAST_LOGIN_PLATFORM=996; 
            ////996_LAST_LOGIN_UID=C8CED5C76F97C1CB7024006056E35E67; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E

            //CookieContainer cc3 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
            //cc3.Add(uri, new Cookie("JSESSIONID", "4C1C3FD642C634528414646F5B013DEE"));
            //cc3.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
            //cc3.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
            //cc3.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
            //listcc.Add(cc3);

            ////jxyxhz123
            ////JSESSIONID=4C1C3FD642C634528414646F5B013DEE; LAST_LOGIN_PLATFORM=996;
            ////996_LAST_LOGIN_UID=C8CED5C76F97C1CB7024006056E35E67; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E

            ////Cookie: JSESSIONID=9A0F8BB38DBEA396F174FAC9D939FC48; LAST_LOGIN_PLATFORM=996;
            ////996_LAST_LOGIN_UID=0EAE0D0A2BC6C44ACBC425380E479B40; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
            //CookieContainer cc4 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
            //cc4.Add(uri, new Cookie("JSESSIONID", "9A0F8BB38DBEA396F174FAC9D939FC48"));
            //cc4.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
            //cc4.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
            //cc4.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
            //listcc.Add(cc4);
            ////jxyxhz123456
            //CookieContainer cc5 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
            //cc5.Add(uri, new Cookie("JSESSIONID", "9317B382C9F086BC9B89255CB7E07F0B"));
            //cc5.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
            //cc5.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
            //cc5.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
            //listcc.Add(cc5);

            #endregion

            #endregion

        }

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


        #region TestButtion

        private void button3_Click(object sender, EventArgs e)
        {
            string url = "http://c.hanyou.com/redpacket/rob.do?v=" + DateTime.Now.Ticks;

            foreach (CookieContainer cc in listcc)
            {
                string result = webHelper.GetHtml(url, cc);
            }
        }
        #endregion


        #region AddSessionID
        //private void button4_Click(object sender, EventArgs e)
        //{

        //    listcc = new List<CookieContainer>();

        //    Uri uri = new Uri("http://c.hanyou.com");

        //    //JSESSIONID=07008F161400384DAA49AEA5EF47E23A; LAST_LOGIN_PLATFORM=996; 996_LAST_LOGIN_UID=322BDDA01B2A962DE6FDBDAFEF9C69B0; 
        //    //996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
        //    //jxyxhz
        //    if (textBox4.Text.Trim() != "")
        //    {
        //        CookieContainer cc1 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
        //        cc1.Add(uri, new Cookie("JSESSIONID", textBox4.Text.Trim()));
        //        cc1.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
        //        cc1.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
        //        cc1.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));

        //        listcc.Add(cc1);
        //    }
        //    //jxyxhz1

        //    //JSESSIONID=9A0F8BB38DBEA396F174FAC9D939FC48; LAST_LOGIN_PLATFORM=996; 996_LAST_LOGIN_UID=322BDDA01B2A962DE6FDBDAFEF9C69B0; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
        //    //JSESSIONID=4C1C3FD642C634528414646F5B013DEE; LAST_LOGIN_PLATFORM=996; 996_LAST_LOGIN_UID=61E483600BB6562854E72F16702E250A; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
        //    if (textBox1.Text.Trim() != "")
        //    {
        //        CookieContainer cc2 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
        //        cc2.Add(uri, new Cookie("JSESSIONID", textBox1.Text.Trim()));
        //        cc2.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
        //        cc2.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
        //        cc2.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
        //        listcc.Add(cc2);
        //    }
        //    //jxyxhz12
        //    //Cookie: JSESSIONID=4C1C3FD642C634528414646F5B013DEE; LAST_LOGIN_PLATFORM=996; 
        //    //996_LAST_LOGIN_UID=C8CED5C76F97C1CB7024006056E35E67; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
        //    if (textBox2.Text.Trim() != "")
        //    {
        //        CookieContainer cc3 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
        //        cc3.Add(uri, new Cookie("JSESSIONID", textBox2.Text.Trim()));
        //        cc3.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
        //        cc3.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
        //        cc3.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
        //        listcc.Add(cc3);
        //    }
        //    //jxyxhz123
        //    //JSESSIONID=4C1C3FD642C634528414646F5B013DEE; LAST_LOGIN_PLATFORM=996;
        //    //996_LAST_LOGIN_UID=C8CED5C76F97C1CB7024006056E35E67; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E

        //    //Cookie: JSESSIONID=9A0F8BB38DBEA396F174FAC9D939FC48; LAST_LOGIN_PLATFORM=996;
        //    //996_LAST_LOGIN_UID=0EAE0D0A2BC6C44ACBC425380E479B40; 996_LAST_LOGIN_ACCOUNT=B067E640239FA0C76CCDF05C82B79A0E
        //    if (textBox3.Text.Trim() != "")
        //    {
        //        CookieContainer cc4 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
        //        cc4.Add(uri, new Cookie("JSESSIONID", textBox3.Text.Trim()));
        //        cc4.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
        //        cc4.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
        //        cc4.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
        //        listcc.Add(cc4);
        //    }
        //    if (textBox5.Text.Trim() != "")
        //    {
        //        //jxyxhz123456
        //        CookieContainer cc5 = new CookieContainer();//为 CookieCollection 对象的集合提供容器。//这里等同new 出来一个Container
        //        cc5.Add(uri, new Cookie("JSESSIONID", textBox5.Text.Trim()));
        //        cc5.Add(uri, new Cookie("LAST_LOGIN_PLATFORM", "996"));
        //        cc5.Add(uri, new Cookie("996_LAST_LOGIN_UID", "322BDDA01B2A962DE6FDBDAFEF9C69B0"));
        //        cc5.Add(uri, new Cookie("996_LAST_LOGIN_ACCOUNT", "B067E640239FA0C76CCDF05C82B79A0E"));
        //        listcc.Add(cc5);
        //    }

        //}

        #endregion


        #region C# 遍历CookieContainer里面的所有数据
        // C# 遍历CookieContainer里面的所有数据

        public static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
            StringBuilder sb = new StringBuilder();
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies)
                    {
                        lstCookies.Add(c);
                        sb.AppendLine(c.Domain + ":" + c.Name + "____" + c.Value + "\r\n");
                    }
            }
            return lstCookies;
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Test_Load(object sender, EventArgs e)
        {
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

        private void LoadJPResult(string result)
        {
            //webBrowser3.Navigate(@"d:\1.html");
            //            webBrowser3.Navigate("about:blank");
            //while (webBrowser3.ReadyState != WebBrowserReadyState.Complete)
            //{
            //    Application.DoEvents();
            //}

            //webBrowser3.Navigate(@"d:\1.html");
            //webBrowser2.Navigate(@"d:\2.html");
            //while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            //{
            //    Application.DoEvents();
            //}
            //string s = webBrowser2.DocumentText;

            string jpcount = GetValue(result, "<div class=\"jp\">", "\r\n\t\t        <div class=\"btns\">\n");

            //string re = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title>财神喜降临</title>\r\n    <link href=\"http://c.hanyou.com/redpacket/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <script type=\"text/javascript\" src=\"http://c.hanyou.com/skin/js/jquery.min.js\"></script>\r\n</head>\r\n<body>\r\n    <div class=\"csWrap1\">\r\n        <div class=\"mid\">\r\n            <div class=\"picBg\" style=\"width: 192px;\">\r\n                <img src=\"http://c.hanyou.com/redpacket/images/hb.png\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"jp\">" + jpcount + "</div>\r\n        <div class=\"btns\">\r\n            <div class=\"bcphBtn\">本次排行</div>\r\n            <div class=\"lsphBtn\">今日排行</div>\r\n        </div>\r\n        <div class=\"qsckk\">下次多刷点</div>\r\n        <div class=\"txt\">成为VIP有更高的几率获得更多奖牌，还可以去“吐槽”里面抢红包!</div>\r\n        <div class=\"pahang\" style=\"display: none\"></div>\r\n    </div>\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function () {\r\n            $(\".jp\").css(\"left\", (459 - $(\".jp\").width() - 90) / 2);\r\n\r\n        })\r\n    </script>\r\n</body>\r\n</html>\r\n";
            string re = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title>财神喜降临</title>\r\n    <link href=\"http://c.hanyou.com/redpacket/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <script type=\"text/javascript\" src=\"http://c.hanyou.com/skin/js/jquery.min.js\"></script>\r\n</head>\r\n<body>\r\n    <div class=\"csWrap1\">\r\n        <div class=\"mid\">\r\n            <div class=\"picBg\" style=\"width: 192px;\">\r\n                <img src=\"http://c.hanyou.com/redpacket/images/hb.png\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"jp\" style=\"left: 173.5px;\">" + jpcount + "</div>\r\n        <div class=\"btns\">\r\n            <div class=\"bcphBtn\">本次排行</div>\r\n            <div class=\"lsphBtn\">今日排行</div>\r\n        </div>\r\n        <div class=\"qsckk\">下次多刷点</div>\r\n        <div class=\"txt\">成为VIP有更高的几率获得更多奖牌，还可以去“吐槽”里面抢红包!</div>\r\n        <div class=\"pahang\" style=\"display: none\"></div>\r\n    </div>\r\n </body>\r\n</html>\r\n";

            this.webBrowser1.Document.Write(re);

            // txtCopyrightInfo.Text = re;

        }

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

    }
}

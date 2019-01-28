using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class HttpHelper
    {
        #region 变量定义
        private static CookieContainer cc = new CookieContainer();
        private static string contentType = "application/x-www-form-urlencoded";
        private static string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        private static string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
        private static Encoding encoding = Encoding.GetEncoding("utf-8");
        private static int delay = 1000;
        private static int maxTry = 300;
        private static int currentTry = 0;

        Uri uri;

        bool did = false;//标示是否完成请求


        HttpWebRequest httpWebRequest = null;
        HttpWebResponse httpWebResponse = null;

        #endregion
        #region 变量赋值
        /// <summary> 
        /// Cookie
        /// </summary> 
        public CookieContainer CookieContainer
        {
            get { return cc; }
            set { cc = value; }
        }

        public HttpWebResponse response
        {
            get { return httpWebResponse; }
            set { httpWebResponse = value; }
        }



        /// <summary> 
        /// 语言
        /// </summary> 
        /// <value></value> 
        public static Encoding Encoding
        {
            get
            {
                return encoding;
            }
            set
            {
                encoding = value;
            }
        }

        public static int NetworkDelay
        {
            get
            {
                Random r = new Random();
                return (r.Next(delay, delay * 2));
            }
            set
            {
                delay = value;
            }
        }

        public static int MaxTry
        {
            get
            {
                return maxTry;
            }
            set
            {
                maxTry = value;
            }
        }
        #endregion

        #region 获取HTML
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postData">post 提交的字符串</param>
        /// <param name="isPost">是否是post</param>
        /// <param name="cookieContainer">CookieContainer</param>
        /// <returns>html </returns>
        public string GetHtml(string url, string postData, bool isPost, CookieContainer cookieContainer)
        {
            if (string.IsNullOrEmpty(postData))
            {
                return GetHtml(url, cookieContainer);
            }

            Thread.Sleep(NetworkDelay);//等待

            currentTry++;

            try
            {
                byte[] byteRequest = Encoding.Default.GetBytes(postData);

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = maxTry;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = isPost ? "POST" : "GET";
                httpWebRequest.ContentLength = byteRequest.Length;

                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(byteRequest, 0, byteRequest.Length);
                stream.Close();

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                currentTry = 0;

                httpWebRequest.Abort();
                httpWebResponse.Close();

                return html;
            }
            catch (Exception e)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                //Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, postData, isPost, cookieContainer);
                }
                currentTry--;

                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                } if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
                return string.Empty;
            }
            finally
            {
                did = true;
            }
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="cookieContainer">CookieContainer</param>
        /// <returns>HTML</returns>
        public string GetHtml(string url, CookieContainer cookieContainer)
        {
            Thread.Sleep(NetworkDelay);

            currentTry++;
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = maxTry;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encoding);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();

                currentTry--;

                httpWebRequest.Abort();
                httpWebResponse.Close();

                return html;
            }
            catch (Exception e)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                //Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, cookieContainer);
                }

                currentTry--;

                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                } if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
                return string.Empty;
            }

            finally
            {
                did = true;
            }
        }
        public string GetHtml(string url, Encoding encod)
        {
            return GetHtml(url, cc, encod);
        }
        public string GetHtml(string url, CookieContainer cookieContainer, Encoding encod)
        {
            Thread.Sleep(NetworkDelay);

            currentTry++;
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = maxTry;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, encod);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();

                currentTry--;

                httpWebRequest.Abort();
                httpWebResponse.Close();

                return html;
            }
            catch (Exception e)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                //Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, cookieContainer);
                }

                currentTry--;

                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                } if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
                return string.Empty;
            }
            finally
            {
                did = true;
            }
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>HTML</returns>
        public string GetHtml(string url)
        {
            return GetHtml(url, cc);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postData">提交的字符串</param>
        /// <param name="isPost">是否是POST</param>
        /// <returns>HTML</returns>
        public string GetHtml(string url, string postData, bool isPost)
        {
            return GetHtml(url, postData, isPost, cc);
        }
        /// <summary>
        /// 获取字符流
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="cookieContainer">cookieContainer</param>
        /// <returns>Stream</returns>
        public Stream GetStream(string url)
        {
            return GetStream(url, cc);
        }
        public Stream GetStream(string url, CookieContainer cookieContainer)
        {
            //Thread.Sleep(delay); 

            currentTry++;
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;

            try
            {

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = maxTry;
                httpWebRequest.Referer = url;
                httpWebRequest.Accept = accept;
                httpWebRequest.UserAgent = userAgent;
                httpWebRequest.Method = "GET";

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                currentTry--;

                //httpWebRequest.Abort(); 
                //httpWebResponse.Close(); 

                return responseStream;
            }
            catch (Exception e)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + e.Message);
                //Console.ForegroundColor = ConsoleColor.White;

                if (currentTry <= maxTry)
                {
                    GetHtml(url, cookieContainer);
                }

                currentTry--;

                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                } if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
                return null;
            }
        }
        #endregion



        /// <summary>
        /// 获取请求返回的cookies
        /// </summary>
        public CookieCollection GetCookies(string url)
        {
            return did ? cc.GetCookies(new Uri(url)) : null;
        }

        /// <summary>
        /// 获取请求返回的HTTP标头
        /// </summary>
        public WebHeaderCollection Headers
        {
            get { return did ? httpWebResponse.Headers : null; }
        }


        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="requestUrlString"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string PostLogin(string postData, string requestUrlString, ref CookieContainer cookie)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            //向服务端请求
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUrlString);
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.96 Safari/537.36";
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            myRequest.CookieContainer = new CookieContainer();
            myRequest.AllowAutoRedirect = true;

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            //将请求的结果发送给客户端(界面、应用)
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            cookie.Add(myResponse.Cookies);
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// 请求数据代码
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="requestUrlString"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string PostRequest(string postData, string requestUrlString, CookieContainer cookie)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUrlString);
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.96 Safari/537.36";
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            myRequest.CookieContainer = cookie;
            myRequest.AllowAutoRedirect = true;

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }


    }
}

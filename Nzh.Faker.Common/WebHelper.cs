using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nzh.Faker.Common
{
    public class WebHelper
    {
        public static void WriteSession<T>(string key, T value)
        {
            if (key.IsEmpty())
                return;
            HttpContext.Current.Session[key] = value;
        }

        public static void WriteSession(string key, string value)
        {
            WriteSession<string>(key, value);
        }
        
        public static string GetSession(string key)
        {
            if (key.IsEmpty())
                return string.Empty;
            return HttpContext.Current.Session[key] as string;
        }

        public static void RemoveSession(string key)
        {
            if (key.IsEmpty())
                return;
            HttpContext.Current.Session.Contents.Remove(key);
        }

        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }
            return "";
        }

        public static void RemoveCookie(string CookiesName)
        {
            HttpCookie objCookie = new HttpCookie(CookiesName.Trim());
            objCookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }
    }
}

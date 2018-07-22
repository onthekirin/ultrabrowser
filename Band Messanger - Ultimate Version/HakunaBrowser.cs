using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CefSharp;
using CefSharp.WinForms;

namespace Band_Messanger___Ultimate_Version
{
    public class HakunaBrowser : ChromiumWebBrowser
    {
        public HakunaBrowser(string url) : base(url)
        {    
        }

        public void Click(string jsLandName)
        {
            string script = String.Format("{0}.click()", jsLandName);
            this.ExecuteScriptAsync(script);
        }

        public void SendKeys(string jsLandName, string keys)
        {
            string script = String.Format("{0}.value = {1}", jsLandName, keys);
        }

       public HtmlElement FindElement(string cssSelector, int nth = 0)
       {
            // -를 변수 이름으로 저장할 수 없어 언더바로 바꾸어준다.
            string jsLandName = cssSelector.Substring(1).Replace('-', '_');
            HtmlElement element;
            string script;
            // ex) FindElement(".confirm");
            if (cssSelector[0] == '.')
            {
                // By ClassName
                jsLandName += nth.ToString();
                script = String.Format("{0} = document.querySelectorAll('{1}')[{2}];(function(){{ return {3}.outerHTML }})()", jsLandName, cssSelector, nth.ToString(), jsLandName);
            }
            else if (cssSelector[0] == '#')
            {
                // By Id
                //
                script = String.Format("{0} = document.querySelector('{1}'); (function(){{ return {2}.outerHTML }})();", jsLandName, cssSelector, jsLandName);
            }
            else
            {
                // By TagName
                jsLandName += nth.ToString();
                script = String.Format("{0} = document.getElementsByTagName({1}); (function(){{ return {2}.outerHTML }})();", jsLandName, cssSelector, jsLandName);
            }
            System.Windows.Forms.MessageBox.Show(script);
            var response = this.EvaluateScriptAsync(script).Result;
            element = HtmlParser.Parse(response.Result.ToString());
            element.JsLandName = jsLandName;
            element.Browser = this;
            return element;
       }

        public List<HtmlElement> FindElements(string cssSelector)
        {
            if (cssSelector[0] == '.')
            {
                // By ClassName

            }
            else if (cssSelector[0] == '#')
            {
                // By Id
                throw new Exception("HakunaBrowser::FindElement : FindElements에는 #을 사용할 수 없습니다.");
            }
            else
            {
                // By TagName

            }


            return null;
        }


    }
}

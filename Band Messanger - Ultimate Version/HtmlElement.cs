using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Band_Messanger___Ultimate_Version
{
    public class HtmlElement
    {
        public string TagName { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public string InnerHTML { get; set; }
        public string OuterHTML { get; set; }
        public bool IsDisable { get; set; }
        public bool IsChecked { get; set; }
        
        public string JsLandName { get; set; }
        public HakunaBrowser Browser { get; set; }
        
        public HtmlElement(string outerHTML, string tagName, Dictionary<string,string> properties, string innerHTML, bool isChecked, bool isDisable)
        {
            OuterHTML = outerHTML;
            TagName = tagName;
            Properties = properties;
            InnerHTML = innerHTML;
            IsDisable = isDisable;
            IsChecked = isChecked;
        }

        public HtmlElement(string outerHTML, string tagName, Dictionary<string, string> properties, string innerHTML)
        {
            OuterHTML = outerHTML;
            TagName = tagName;
            Properties = properties;
            InnerHTML = innerHTML;
        }

        public HtmlElement(string html)
        {
            HtmlElement element = HtmlParser.Parse(html);
            this.TagName = element.TagName;
            this.Properties = element.Properties;
            this.InnerHTML = element.InnerHTML;
            this.IsDisable = element.IsDisable;
            this.IsChecked = element.IsChecked;
        }

        public override string ToString()
        {
            return OuterHTML;
        }

        public void Click()
        {
            Browser.Click(this.JsLandName);
        }

        public void SendKeys(string keys)
        {
            
        }
    }
}

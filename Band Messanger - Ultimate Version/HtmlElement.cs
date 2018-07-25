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
        public bool IsTypeable { get; set; }
        
        public HtmlElement(string outerHTML, string tagName, Dictionary<string,string> properties, string innerHTML, bool isChecked, bool isDisable)
        {
            OuterHTML = outerHTML;
            TagName = tagName;
            Properties = properties;
            InnerHTML = innerHTML;
            IsDisable = isDisable;
            IsChecked = isChecked;

            this.IsTypeable = ((TagName.Equals("input") && (Properties["type"].Equals("text") || Properties["type"].Equals("tel") || Properties["type"].Equals("email") || Properties["type"].Equals("password")))) || TagName.Equals("textarea");
        }

        public HtmlElement(string outerHTML, string tagName, Dictionary<string, string> properties, string innerHTML)
        {
            OuterHTML = outerHTML;
            TagName = tagName;
            Properties = properties;
            InnerHTML = innerHTML;

            this.IsTypeable = ((TagName.Equals("input") && (Properties["type"].Equals("text") || Properties["type"].Equals("tel") || Properties["type"].Equals("email") || Properties["type"].Equals("password")))) || TagName.Equals("textarea");
        }

        public HtmlElement(string html)
        {
            HtmlElement element = HtmlParser.Parse(html);
            this.TagName = element.TagName;
            this.Properties = element.Properties;
            this.InnerHTML = element.InnerHTML;
            this.IsDisable = element.IsDisable;
            this.IsChecked = element.IsChecked;
            
            this.IsTypeable = ( (TagName.Equals("input") && (Properties["type"].Equals("text") || Properties["type"].Equals("tel") || Properties["type"].Equals("email")  || Properties["type"].Equals("password")))) || TagName.Equals("textarea");
            //this.IsTypeable = true;

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
            if (!IsTypeable)
            {
                throw new Exception(String.Format("HtmlElement::SendKeys : {0} is not typeable! {1}", TagName, OuterHTML));
            }

            Browser.SendKeys(JsLandName, keys);
        }

        public void ToggleDisabled()
        {
            Browser.ToggleDisabled(JsLandName);
        }
    }
}

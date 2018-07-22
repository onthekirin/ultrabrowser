using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Band_Messanger___Ultimate_Version
{
    public static class HtmlParser
    {
        public static HtmlElement Parse(string str)
        {
            string tagName;
            Dictionary<string, string> properties = new Dictionary<string, string>();
            bool isDisable = false;
            bool isChecked = false;
            string innerHTML;
            

            Regex isHtmlElement = new Regex(@"<[\w !-_]+>");

            if(!(isHtmlElement.Match(str).Value.Length > 0))
            {
                throw new Exception("HtmlParser::Parse(string str) :: Unvalid parameter, paremeter str must be html element");
            }

            Regex tagNameRegex = new Regex(@"(?<=\<)\w+(?= )");
            tagName = tagNameRegex.Match(str).Value;

            Regex propertyRegex = new Regex("(\\S+)=[\"']?((?:.(?![\"']?\\s + (?:\\S +)=|[> \"']))+.)[\"']?");
   


               var propertyMatches = propertyRegex.Matches(str);
            foreach (Match match in propertyMatches)
            {
                string property = match.Value;
                
                string propertyName = property.Split('=')[0];
                string propertyValue = property.Split('=')[1].Replace("\'", String.Empty).Replace("\"", String.Empty);
      
                if(!properties.ContainsKey(propertyName))
                    properties.Add(propertyName, propertyValue);
            }

  
            Regex headRegex = new Regex(@"<[^\/]+>");
            string headString = headRegex.Match(str).Value;
            if(headString.IndexOf("disable") != -1)
            {
                isDisable = true;
            }

            if(headString.IndexOf("checked") != -1)
            {
                isChecked = true;
            }

            Regex innerHTMLRegex = new Regex(@"(?<=\>).*(?=\<\/)");
            innerHTML = innerHTMLRegex.Match(str).Value;

            return new HtmlElement(str, tagName, properties, innerHTML, isChecked, isDisable);
        }
    }
}

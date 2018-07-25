using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CefSharp;
using CefSharp.WinForms;

namespace Band_Messanger___Ultimate_Version
{
    public class Wait
    {
        private HakunaBrowser Browser { get; set; }
        private int TimeOut { get; set; }

        // timeout is seconds
        public Wait(HakunaBrowser browser, int timeout)
        {
            Browser = browser;
            TimeOut = timeout;
        }

        public void UntilElementExist(string cssSelector)
        {
            int delay = 0;
            string script = String.Format("(function(){{ return document.querySelector('{0}') }})()", cssSelector);

            while(Browser.EvaluateScriptAsync(script).Result.Result != null)
            {
                System.Threading.Thread.Sleep(100);
                delay += 100;
                if(delay > TimeOut * 1000)
                {
                    throw new Exception("Wait::UnitlElementExist : time out");
                }
            }

            // wait until element was rendered
            System.Threading.Thread.Sleep(500);
        }

    }
}

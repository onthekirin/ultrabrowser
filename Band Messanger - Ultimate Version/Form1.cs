using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

namespace Band_Messanger___Ultimate_Version
{
    public partial class Form : System.Windows.Forms.Form
    {
        ChromiumWebBrowser browser;
        public Form()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser("https://band.us");

            this.panel1.Controls.Add(browser);
            this.Focus();
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F12)
            {
                browser.ShowDevTools();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            // Step 01: create a simple html page (include jquery so we have access to json object
            StringBuilder htmlPage = new StringBuilder();
            htmlPage.AppendLine("");
            htmlPage.AppendLine("");
            htmlPage.AppendLine("");
            htmlPage.AppendLine("");
            htmlPage.AppendLine("Hello world 2");
            htmlPage.AppendLine("");

            // Step 02: Load the Page
            browser.LoadHtml(htmlPage.ToString(), "http://customrendering/");

            // Step 03: Define and Execute some ad-hoc JS that returns an object back to C#
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction() {");
            sb.AppendLine("     // create a JS object");
            sb.AppendLine("     var person = {firstName:'John', lastName:'Maclaine', age:23, eyeColor:'blue'};");
            sb.AppendLine("");
            sb.AppendLine("     // Important: convert object to string before returning to C#");
            sb.AppendLine("     return JSON.stringify(person);");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction();");

            var task = browser.EvaluateScriptAsync(sb.ToString());

            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;

                    if (response.Success == true)
                    {
                        // Use JSON.net to convert to object;
                        MessageBox.Show(response.Result.ToString());
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

            */

            var task = browser.EvaluateScriptAsync(@"(function(){return document.getElementsByClassName('bandlogo')[0].outerHTML})()");

            task.ContinueWith(t =>
            {
                
                if (!t.IsFaulted)
                {
                    var response = t.Result;

                    if (response.Success == true)
                    {
                        MessageBox.Show(response.Result.ToString());
                    }
                }
                
            });

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }
    }
}

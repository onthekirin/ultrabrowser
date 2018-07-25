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
        HakunaBrowser browser;
        Wait wait;
        public Form()
        {
            InitializeComponent();
            CefSettings settings = new CefSettings();
            settings.Locale = "ko";
            settings.AcceptLanguageList = "ko";
   
            

            Cef.Initialize(settings);
            browser = new HakunaBrowser("https://band.us");
            wait = new Wait(browser, 5);
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
            

            
            browser.FindElement(".login", 0).Click();
            wait.UntilElementExist(".text");
            browser.FindElement(".text", 1).Click();
            wait.UntilElementExist("#input_email");
            browser.FindElement("#input_email").SendKeys("onthekirin@gmail.com");
            browser.FindElement(".-confirm").ToggleDisabled();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }
    }
}

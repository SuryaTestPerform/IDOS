using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using PageObjectLibrary;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
 
using OpenQA.Selenium.Interactions;
namespace ActionLibrary
{
   public class IdosLogin
    {
        IWebDriver driver;
        LoginPO loginPo;
       // General general;

        public IdosLogin()
        {
            driver = BrowserHandler.Driver;
            // general = new General();
            loginPo = new LoginPO();
        }
        private void WaitFor_LoginPage()
        {
            int count = 0;
            while (count < 10)
            {
                try
                {
                    if (loginPo.elementUserName.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(5000);
                count++;
            }
        }

        public void IDOS_Login()
        {
            try
            {
                WaitFor_LoginPage();
                loginPo.elementUserName.SendKeys(DataHandler.Instance.GetParam("Username")); Thread.Sleep(500);
                loginPo.elementPassword.SendKeys(DataHandler.Instance.GetParam("Password")); Thread.Sleep(500);
                driver.SwitchTo().Frame(0); Thread.Sleep(500);
                loginPo.elementCaptcha.Click(); Thread.Sleep(500);
                driver.SwitchTo().DefaultContent();
                loginPo.elementLoginbutton.Click(); Thread.Sleep(500);
                WaitFor_VerifyPage();
                loginPo.elementVerify.Click();
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }

        private void WaitFor_VerifyPage()
        {
            int count = 0;
            while (count < 10)
            {
                try
                {
                    if (loginPo.elementVerify.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(5000);
                count++;
            }
        }



    }
}

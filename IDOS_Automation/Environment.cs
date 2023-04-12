using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using CoreLibrary;
namespace IDOS_Automation
{
   public  class Environment
    {


        [Test]
        public void ShowBizstudio_QA_Parameters()
        {
            DataHandler.Instance.InitializeParameter("URL", @"http://idosqa1.centralindia.cloudapp.azure.com:9000/signIn#logindiv");
            DataHandler.Instance.InitializeParameter("Environment", "QA");
            // DataHandler.Instance.InitializeParameter("Browser", "Edge");             
            DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "admin@abc.com");
            DataHandler.Instance.InitializeParameter("Password", "1dosP@ssw0rd");
          

        }

        [TearDown]
        public void MyTestCleanup()
        {
            DataHandler.Instance.BulkExport("xml");
            DataHandler.Instance.ClearDictionary();
        }

    }
}

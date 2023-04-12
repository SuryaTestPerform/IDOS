using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CoreLibrary;
using ActionLibrary;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using STContext = NUnit.Framework.TestContext;
using System.IO;
using System.Diagnostics;

namespace IDOS_Automation
{
    [TestFixture]
    public  class IDSO_Smoke
    {
       [Test]
       public void Smoke_Test()
        {
           // DataHandler.Instance.InitializeParameter("ResultsDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            IdosLogin login = new IdosLogin();
            login.IDOS_Login();

        }

        [SetUp]
        public void Initialize()
        {
            testContextInstance = STContext.CurrentContext;
            DataHandler.Instance.InitializeParameter("ResultsDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            DataHandler.Instance.ImportData(ConfigurationManager.AppSettings["ParametersPath"] + "Parameters.xml");
          //  DataHandler.Instance.ReadConfigAppsettingData();
            BrowserHandler.InitBrowser();
            BrowserHandler.LoadApplication();
           // GenerateReports.Start();
        }



        [TearDown]
        public void ClearInitialize()
        {
           // GenerateReports.CreateReport(testContextInstance);
            DataHandler.Instance.ClearDictionary();
        }


        private STContext testContextInstance;
        public STContext TeContext
        {
            get { return testContextInstance; }
            set
            {
                testContextInstance = value;  //  TeContext = value;  
            }
        }
    }
}

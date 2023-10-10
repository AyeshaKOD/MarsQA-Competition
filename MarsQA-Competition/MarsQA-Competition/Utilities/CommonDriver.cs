using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Runtime.InteropServices;

namespace MarsQA_Competition.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        protected ExtentReports _extent;
        protected ExtentTest _test;



        //created Hooks by setting up "setup" and "teardown" attributes 

        [OneTimeSetUp]
        public void Initialize()
        {
            

            string reportPath= "C:\\IndustryConnect\\MarsQACompetition\\MARSQA-Competition\\MarsQA-Competition\\MarsQA-Competition\\MarsQA-Competition\\Utilities\\report.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }


        [OneTimeTearDown]
        public void ClosingSteps()
        {
            driver.Close();
            _extent.Flush();
        }
    }
}
    
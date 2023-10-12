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
        protected ExtentReports extent;
        protected ExtentTest test;



        //created Hooks by setting up "setup" and "teardown" attributes 

        [OneTimeSetUp]
        public void Initialize()
        {


            
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public static String  GetReport()
        {
            string currentDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string reportPath = Path.Combine(currentDir, "Utilities");
            return reportPath;
        }


        [OneTimeTearDown]
        public void ClosingSteps()
        {
            
            extent.Flush();
            driver.Close();
        }
    }
}
    
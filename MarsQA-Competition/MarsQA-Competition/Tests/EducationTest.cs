using MarsQA_Competition.Pages;
using MarsQA_Competition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;




namespace MarsQA_Competition.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {
        
        [SetUp]
        public void SetUp()
        {
            string reportPath = GetReport(); // Get the relative path
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath + "\\EducationTestReport.html");

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            

           
            LogIn logInObject = new LogIn();
            logInObject.LogInSteps();
           


        }
        [Test]
        public void AddEducationTest()
        {
            test = extent.CreateTest("Add education details").Info("Test started");
            
            Education educationObject = new Education();
            educationObject.AddEducation();
            
            test.Log(Status.Pass, "Test passed");
        }

        [Test]
        public void EditEducationTest()
        {
            test = extent.CreateTest("Update education details").Info("Test started");
            
            Education educationObject = new Education();
            educationObject.EditEducation();
            test.Log(Status.Pass, "Update education test passed");
        }
        [Test]
        public void DeleteEducationTest()
        {
            test = extent.CreateTest("delete education details").Info("Test started");
           
            Education educationObject = new Education();
            educationObject.DeleteEducationRecords();
            test.Log(Status.Pass, "Delete education test passed");
        }

        [TearDown]
        public void CloseTest()
        {

            driver.Quit();
            
            
        }
        
    }
}


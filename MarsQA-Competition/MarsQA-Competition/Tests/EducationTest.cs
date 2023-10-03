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
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            _test.Log(Status.Info, "Log in to MarsQA");
            LogIn logInObject = new LogIn();
            logInObject.LogInSteps();
            _test.Log(Status.Pass, "Successfully logged in");


        }
        [Test]
        public void AddEducationTest()
        {
           
            _test.Log(Status.Info, "Add education details");
            Education educationObject = new Education();
            educationObject.AddEducation();
            _test.Log(Status.Pass, "Add education test passed");

        }

        [Test]
        public void EditEducationTest()
        {
           
            _test.Log(Status.Info, "Update education details");
            Education educationObject = new Education();
            educationObject.EditEducation();
            _test.Log(Status.Pass, "Update education test passed");
        }
        [Test]
        public void DeleteEducationTest()
        {
            
            _test.Log(Status.Info, "delete education details");
            Education educationObject = new Education();
            educationObject.DeleteEducationRecords();
            _test.Log(Status.Pass, "Delete education test passed");
        }

        [TearDown]
        public void CloseTest()
        {

            driver.Quit();
            
            
        }
        
    }
}


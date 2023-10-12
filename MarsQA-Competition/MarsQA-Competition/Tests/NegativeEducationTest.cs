using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsQA_Competition.Pages;
using MarsQA_Competition.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_Competition.Tests
{
    [TestFixture]
    public class NegativeEducationTest:CommonDriver
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
        public void NegativeAddEducationTest()
        {
            test = extent.CreateTest("Add same education details twice").Info("Test started");
            NegativeEducation newNegativeEducation= new NegativeEducation();
            newNegativeEducation.NegativeAddEducation();
            test.Log(Status.Pass, "Same education details can not add twice");

        }
        [Test]

        public void MissingEducationDataTest ()
        {
            test = extent.CreateTest("Add without entering relevant education details").Info("Test started");
            NegativeEducation newNegativeEducation = new NegativeEducation();
            newNegativeEducation.MissingEducationDetails();
            test.Log(Status.Pass, "Education  can be added without without giving required details");
        }
        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}

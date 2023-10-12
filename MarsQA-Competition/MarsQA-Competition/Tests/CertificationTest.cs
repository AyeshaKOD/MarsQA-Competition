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
    public class CertificationTest : CommonDriver
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
        public void AddCertificateTest()
        {
            test = extent.CreateTest("Add certification details").Info("Test started");
            Certifications certificationsObject= new Certifications();
            certificationsObject.AddNewCertification();
            test.Log(Status.Pass, "Add certificate test passed");
        }
        [Test]

        public void EditCertificationsTest ()
        {
            test = extent.CreateTest("Update certification details").Info("Test started");
            Certifications certificationsObject = new Certifications();
            certificationsObject.UpdateCertifications();
            test.Log(Status.Pass, "Update certificate test passed");

        }
        [Test]

        public void DeleteCertificationsTest ()
        {
            test = extent.CreateTest("Delete certification details").Info("Test started");
            Certifications certificationsObject = new Certifications();
            certificationsObject.DeleteCertifications();
            test.Log(Status.Pass, "Delete certificate test passed");
        }
        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}

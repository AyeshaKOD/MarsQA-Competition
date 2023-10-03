using AventStack.ExtentReports;
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
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            _test.Log(Status.Info, "Log in to MarsQA");
            LogIn logInObject = new LogIn();
            logInObject.LogInSteps();
            _test.Log(Status.Pass, "Successfully logged in");
        }
        [Test]
        public void AddCertificateTest()
        {
            _test.Log(Status.Info, "Add certification details");
            Certifications certificationsObject= new Certifications();
            certificationsObject.AddNewCertification();
            _test.Log(Status.Pass, "Add certificate test passed");
        }
        [Test]

        public void EditCertificationsTest ()
        {
            _test.Log(Status.Info, "Update certification details");
            Certifications certificationsObject = new Certifications();
            certificationsObject.UpdateCertifications();
            _test.Log(Status.Pass, "Update certificate test passed");

        }
        [Test]

        public void DeleteCertificationsTest ()
        {
            _test.Log(Status.Info, "Delete certification details");
            Certifications certificationsObject = new Certifications();
            certificationsObject.DeleteCertifications();
            _test.Log(Status.Pass, "Delete certificate test passed");
        }
        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}

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
    public class NegativeEducationTest:CommonDriver
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
        public void NegativeAddEducationTest()
        {
            _test.Log(Status.Info, "Check whether the same education details can not add twice");
            NegativeEducation newNegativeEducation= new NegativeEducation();
            newNegativeEducation.NegativeAddEducation();
            _test.Log(Status.Pass, "Same education details can not add twice");

        }
        [Test]

        public void MissingEducationDataTest ()
        {
            _test.Log(Status.Info, "Check whether the education  can be added without without giving required details");
            NegativeEducation newNegativeEducation = new NegativeEducation();
            newNegativeEducation.MissingEducationDetails();
            _test.Log(Status.Pass, "Education  can be added without without giving required details");
        }
        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}

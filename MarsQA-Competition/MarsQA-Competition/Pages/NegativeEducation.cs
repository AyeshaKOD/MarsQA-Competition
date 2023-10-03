using MarsQA_Competition.DataModel;
using MarsQA_Competition.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_Competition.Pages
{
    public class NegativeEducation : CommonDriver
    {
        private static IWebElement educationTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private static IWebElement addNewEducation => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private static IWebElement nameText => driver.FindElement(By.Name("instituteName"));
        private static IWebElement selectCountry => driver.FindElement(By.Name("country"));
        private static IWebElement titleDropdown => driver.FindElement(By.Name("title"));
        private static IWebElement degreeText => driver.FindElement(By.Name("degree"));

        private static IWebElement yearGraduated => driver.FindElement(By.Name("yearOfGraduation"));
        private static IWebElement addDetails => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        private static IWebElement editEducationIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
        private static IWebElement updateEducation => driver.FindElement(By.XPath("//*[@id=\\\"account-profile-section\\\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[\"+p+\"]/tr/td/div/input[1]"));

        public void NegativeAddEducation()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 7);
            educationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 7);
            // read  JSon reader 

            var jsonDuplicateData = File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\NegativeAddEducation.json");
                                                        
            var educationDuplicateData = JsonConvert.DeserializeObject<NegativeEducationDataModel>(jsonDuplicateData);


            addNewEducation.Click();
            Thread.Sleep(2000);

            nameText.SendKeys(educationDuplicateData.CollegeName);

            SelectElement select = new SelectElement(selectCountry);
            select.SelectByText(educationDuplicateData.Country);

            SelectElement selectTitle = new SelectElement(titleDropdown);
            selectTitle.SelectByText(educationDuplicateData.Title);

            degreeText.SendKeys(educationDuplicateData.DegreeName);

            SelectElement selectYear = new SelectElement(yearGraduated);
            selectYear.SelectByText(educationDuplicateData.YearGraduation);

            addDetails.Click();
            Thread.Sleep(3000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string actualMessage = messageBox.Text;
            if (actualMessage != null)
            {
                //verify the expected message 
                
                string expectedMessage = "This information is already exist.";

                Assert.That(actualMessage, Is.EqualTo(expectedMessage));
            }
            else
            {
                Console.WriteLine("Message Box not found");
            }
        }

        public void MissingEducationDetails()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 7);
            educationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 7);
            // read  JSon reader 

            var jsonDataMissing = File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\NegativeMissingEducationData.json");
            var missingEducationData = JsonConvert.DeserializeObject<NegativeMissingEducationData>(jsonDataMissing);

            addNewEducation.Click();
            Thread.Sleep(2000);

            nameText.SendKeys(missingEducationData.CollegeName);

            SelectElement select = new SelectElement(selectCountry);
            select.SelectByText(missingEducationData.Country);

            SelectElement selectTitle = new SelectElement(titleDropdown);
            selectTitle.SelectByText(missingEducationData.Title);

            degreeText.SendKeys(missingEducationData.DegreeName);

            SelectElement selectYear = new SelectElement(yearGraduated);
            selectYear.SelectByText(missingEducationData.YearGraduation);
            Thread.Sleep(1000);

            addDetails.Click();
            Thread.Sleep(2000);

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string actualMessage = messageBox.Text;
            if (actualMessage != null)
            {
                string expectedMessage = "Please enter all the fields";
                Assert.That(actualMessage, Is.EqualTo(expectedMessage));
            }
            else
            {
                Console.WriteLine("Message Box not found");
            }
        }
    }
}

    

    




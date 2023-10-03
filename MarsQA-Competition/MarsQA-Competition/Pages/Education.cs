using MarsQA_Competition.DataModel;
using MarsQA_Competition.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V114.Debugger;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarsQA_Competition.Pages
{
    public class Education : CommonDriver
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

        public void AddEducation()
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 7);
            educationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 7);
            // read multiple data objects from JSon reader 
            EducationsList educationData = JsonConvert.DeserializeObject<EducationsList>(File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\EducationData.json"));
            for (int i = 0; i < educationData.Educations.Count; i++)
            {

                string name = educationData.Educations[i].CollegeName.ToString();
                string countryName = educationData.Educations[i].Country.ToString();
                string titleName = educationData.Educations[i].Title.ToString();
                string dName = educationData.Educations[i].DegreeName.ToString();
                string yearPassed = educationData.Educations[i].YearGraduation.ToString();


                addNewEducation.Click();
                Thread.Sleep(2000);

                nameText.SendKeys(name);

                SelectElement select = new SelectElement(selectCountry);
                select.SelectByText(countryName);

                SelectElement selectTitle = new SelectElement(titleDropdown);
                selectTitle.SelectByText(titleName);

                degreeText.SendKeys(dName);

                SelectElement selectYear = new SelectElement(yearGraduated);
                selectYear.SelectByText(yearPassed);

                addDetails.Click();
                Thread.Sleep(3000);

                //validate add education 
                // get the table list

                IList<IWebElement> tablerows = CommonDriver.driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));


                var rowCount = tablerows.Count();
                for (int p = 1; p <= rowCount; p++)
                {
                    String currentUniversity = CommonDriver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody["+ p +"]/tr/td[2]")).Text;
                    if (currentUniversity == name)
                    {

                    Assert.IsTrue(true);
                    }
                    
                }
            }
        }

        public void EditEducation()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 7);
            educationTab.Click();

            // read multiple data objects from JSon reader
            var jsonUpdateData = File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\EditEducationData.json");
            var newdata = JsonConvert.DeserializeObject<EditEducationDataModel>(jsonUpdateData);

            // get the table list 
            IList<IWebElement> tablerows = CommonDriver.driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));


            var rowCount = tablerows.Count();
            for (int p = 1; p <= rowCount; p++)
            {

                String currentUniversity = CommonDriver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + p + "]/tr/td[2]")).Text;
                if (currentUniversity.Equals(newdata.CollegeNameToUpdate))
                {
                    // Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr[{p+1}]/td[6]/span[1]/i", 7);
                    Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + p + "]/tr/td[6]/span[1]/i", 7);
                    editEducationIcon.Click();
                    Thread.Sleep(1000);

                    nameText.Clear();
                    nameText.SendKeys(newdata.NewCollegeName);


                    SelectElement selectUpdatedCountry = new SelectElement(selectCountry);
                    selectUpdatedCountry.SelectByText(newdata.NewCountry);


                    SelectElement selectTitleDropdown = new SelectElement(titleDropdown);
                    selectTitleDropdown.SelectByText(newdata.NewTitle);

                    degreeText.Clear();
                    degreeText.SendKeys(newdata.NewDegreeName);


                    SelectElement selectYearGraduated = new SelectElement(yearGraduated);
                    selectYearGraduated.SelectByText(newdata.NewYearGraduation);
                    Thread.Sleep(2000);


                    CommonDriver.driver.FindElement(By.XPath("//tbody[" + p + "]/tr/td[1]/div[3]/input[1]")).Click();
                    Thread.Sleep(3000);
                    
                    string newUniversityName = CommonDriver.driver.FindElement(By.XPath(" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + p + "]/tr/td[2]")).Text;
                    Assert.AreEqual(newdata.NewCollegeName, newUniversityName, "Education record was not updated correctly");
                    break;

                }
            }
        }

        public void DeleteEducationRecords()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 7);
            educationTab.Click();


            //    //read JSon data 
            var jsonDeleteData = File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\DeleteEducationData.json");
            var deleteData = JsonConvert.DeserializeObject<DeleteEducationDataModel>(jsonDeleteData);
            
            if (deleteData != null)
            {


                //find the table rows 
                IList<IWebElement> tablerows = CommonDriver.driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));

                var rowCount = tablerows.Count();
                for (int p = 1; p <= rowCount; p++)
                {


                    String currentUniversity = CommonDriver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + p + "]/tr/td[2]")).Text;
                    if (currentUniversity.Equals(deleteData.CollegeNameToDelete))
                    {
                        CommonDriver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + p + "]/tr/td[6]/span[2]/i")).Click();
                        Thread.Sleep(2000);

                        if (currentUniversity != deleteData.CollegeNameToDelete)
                        {

                            Assert.IsTrue(true);
                        }
                        break;
                    }  

                }
                
            }



        }
    }
}


    

    

            


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQA_Competition.Utilities;
using MarsQA_Competition.DataModel;
using OpenQA.Selenium;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using static System.Collections.Specialized.BitVector32;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.DevTools.V114.Debugger;

namespace MarsQA_Competition.Pages
{
    public class Certifications : CommonDriver
    {
        private static IWebElement certificateTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private static IWebElement certificateAdd => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private static IWebElement certificateName => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private static IWebElement certificateFrom => driver.FindElement(By.Name("certificationFrom"));
        private static IWebElement certificateYear => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement addItem => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
         
        public void AddNewCertification()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 7);
            certificateTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 7);

            CertificationList certificateData = JsonConvert.DeserializeObject<CertificationList>(File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\AddCertification.json"));
            for (int i = 0; i < certificateData.AddCertifications.Count; i++)
            {
                String certificateIssued = certificateData.AddCertifications[i].CertificateName.ToString();
                String certificateIssuedBody = certificateData.AddCertifications[i].CertifiedBody.ToString();
                String certifiedYear = certificateData.AddCertifications[i].year.ToString();

                certificateAdd.Click();
                Thread.Sleep(3000);

                certificateName.SendKeys(certificateIssued);
                certificateFrom.SendKeys(certificateIssuedBody);

                SelectElement selectCertificateYear = new SelectElement(certificateYear);
                selectCertificateYear.SelectByText(certifiedYear);

                addItem.Click();
                Thread.Sleep(3000);

                

                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string actualMessage = messageBox.Text;
                if (actualMessage != null)
                {
                    //verify the expected message 
                    string expectedMessage = certificateIssued + " has been added to your certification";


                    Assert.That(actualMessage, Is.EqualTo(expectedMessage));
                }
                else
                {
                    Console.WriteLine("Message Box not found");
                }
            }

        }
          
        public void UpdateCertifications()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 7);
            certificateTab.Click();

            var jsonUpdateCertificate = File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\EditCertificationsData.json");
            var updateCetificateData = JsonConvert.DeserializeObject<EditCertificateDataModel>(jsonUpdateCertificate);
            

                // get the table list 
                IList<IWebElement> tablerows = CommonDriver.driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr"));

                //loop through each row 
                for (int p = 1; p < tablerows.Count; p++)
                {
                    string currentCertificateName = CommonDriver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/table[1]/tbody[" + p + "]/tr[1]/td[1]")).Text;
                    if (currentCertificateName.Equals(updateCetificateData.CertificateNameToUpdate))
                    {
                        Thread.Sleep(1000);
                        CommonDriver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + p + "]/tr/td[4]/span[1]/i")).Click();

                        certificateName.Clear();
                        certificateName.SendKeys(updateCetificateData.CertificateName);

                        certificateFrom.Clear();
                        certificateFrom.SendKeys(updateCetificateData.CertifiedBody);

                        SelectElement selectUpdatYear = new SelectElement(certificateYear);
                        selectUpdatYear.SelectByText(updateCetificateData.Year);

                        CommonDriver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + p + "]/tr/td/div/span/input[1]")).Click();
                        Thread.Sleep(2000);


                    IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                    string actualMessage = messageBox.Text;
                    if (actualMessage != null)
                    {
                        //verify the expected message 
                        string expectedMessage = updateCetificateData.CertificateName + " has been updated to your certification";


                        Assert.That(actualMessage, Is.EqualTo(expectedMessage));
                    }
                    else
                    {
                        Console.WriteLine("Message Box not found");
                    }
                    break;
                    
                }
                
                
            }
            
        }

        public void DeleteCertifications()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 7);
            certificateTab.Click();

            //read JSon data 
            
            var jsonDeleteData = File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\DeleteCertificationsData.json");
            var deletedData = JsonConvert.DeserializeObject<DeleteCertificateDataModel>(jsonDeleteData);
            
            if (deletedData != null)
            {
                //string deleteName = deleteCertificateData.CertificateNameToDelete.ToString();

                // get the table list 
                IList<IWebElement> tablerows = CommonDriver.driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr"));

                //loop through each row 
                for (int p = 1; p < tablerows.Count; p++)
                {
                    string currentCertificateName = CommonDriver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/table[1]/tbody[" + p + "]/tr[1]/td[1]")).Text;
                    if (currentCertificateName.Equals(deletedData.CertificateNameToDelete))
                    {
                        CommonDriver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + p + "]/tr/td[4]/span[2]/i")).Click();
                        Thread.Sleep(2000);                     

                    }
                        if (currentCertificateName != deletedData.CertificateNameToDelete)
                        {
                            Assert.IsTrue(true);
                        }
                    break;
                        
                    }
                   
                }
               
            }
        }
        



        
    }



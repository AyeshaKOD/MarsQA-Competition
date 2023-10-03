
using MarsQA_Competition.DataModel;
using MarsQA_Competition.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_Competition.Pages
{
    public class LogIn :CommonDriver
    {
        
        //identify elements 
       //rivate static IWebElement skillTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private static IWebElement emailTextBox => driver.FindElement(By.Name("email"));
        private static IWebElement passwordTextBox => driver.FindElement(By.Name("password"));
        private static IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

       
        public void LogInSteps()
        {
            

            //open MRS url
            driver.Navigate().GoToUrl("http://localhost:5000/");

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 3);

            try
            {
                

                signInButton.Click();
               

            }
            catch (Exception ex)
            {
                Console.WriteLine("TurnUp portal page didn not load.", ex);
               
            }


            //Login test 
            //Deserialise JSON data to a single object 
            var jsonLoginData = File.ReadAllText(@"C:\IndustryConnect\MarsQACompetition\MARSQA-Competition\MarsQA-Competition\MarsQA-Competition\MarsQA-Competition\TestData\LoginData.json");
            var loginTestData=JsonConvert.DeserializeObject<LoginDataModel> (jsonLoginData);

            emailTextBox.SendKeys(loginTestData.EmailAddress);
            passwordTextBox.SendKeys(loginTestData.Password);
            loginButton.Click();
            Thread.Sleep(2000);
            
        }
       
    }
}
    


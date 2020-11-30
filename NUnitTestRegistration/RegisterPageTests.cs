using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestRegistration
{
    public class RegisterPageTests
    {
        IWebDriver driver;
        IWebElement registerButton; /* MainContent_registerButton */
        IWebElement nameField; /* MainContent_nameField */
        IWebElement surnameField; /* MainContent_surnameField */
        IWebElement personalCode; /* MainContent_personalCodeField */
        IWebElement Gender; /* MainContent_genderSelection */
        IWebElement Address;  /*MainContent_addressField */
        IWebElement telephoneNumber; /* MainContent_telephoneField */
        IWebElement studyProgram;/* MainContent_programSelection */
        IWebElement modeOfStudy; /*MainContent_modeSelection */
        IWebElement  agreeCheck; /* MainContent_agreeCheck */

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Url = "https://localhost:44369/Register";


            registerButton = driver.FindElement(By.Id("MainContent_registerButton"));
            nameField = driver.FindElement(By.Id("MainContent_nameField"));
            surnameField = driver.FindElement(By.Id("MainContent_surnameField"));
            personalCode = driver.FindElement(By.Id("MainContent_personalCodeField"));
            Gender = driver.FindElement(By.Id("MainContent_genderSelection"));
            Address = driver.FindElement(By.Id("MainContent_addressField"));
            telephoneNumber = driver.FindElement(By.Id("MainContent_telephoneField"));
            studyProgram = driver.FindElement(By.Id("MainContent_programSelection"));
            modeOfStudy = driver.FindElement(By.Id("MainContent_modeSelection"));
            agreeCheck = driver.FindElement(By.Id("MainContent_agreeCheck"));
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUnitTestRegistration
{
    public class RegisterPageTests
    {
        IWebDriver driver;
        IWebElement registerButton; /* MainContent_registerButton */
        IWebElement nameField; /* MainContent_nameField */
        IWebElement surnameField; /* MainContent_surnameField */
        IWebElement personalCode; /* MainContent_personalCodeField */
        IWebElement genderSelect; /* MainContent_genderSelection */
        IWebElement addressField;  /*MainContent_addressField */
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
            genderSelect = driver.FindElement(By.Id("MainContent_genderSelection"));
            addressField = driver.FindElement(By.Id("MainContent_addressField"));
            telephoneNumber = driver.FindElement(By.Id("MainContent_telephoneField"));
            studyProgram = driver.FindElement(By.Id("MainContent_programSelection"));
            modeOfStudy = driver.FindElement(By.Id("MainContent_modeSelection"));
            agreeCheck = driver.FindElement(By.Id("MainContent_agreeCheck"));
        }



        [Test]
        [Order(1)]
        public void RegisterButtonClick_AllLabelsFilled_RedirectToHome()
        {
            // driver.Url real URL
            string url = driver.Url;

            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("40410059638");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("86 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            Assert.AreEqual(url, driver.Url);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        [Order(2)]
        public void RegisterButtonCLick_StudentNotExistsInList_CorrectMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("44002189111");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("86 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            IWebElement studentExists = driver.FindElement(By.Id("MainContent_studentExists"));
            Assert.AreEqual("This student not exists in our data", studentExists.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        [Order(3)]
        public void PersonalCode_notCorrectCenturyOfBirth_CorrectMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("85207118795");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("86 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();
            
            IWebElement birthdayLabel = driver.FindElement(By.Id("MainContent_birthdayLabel"));
            Assert.AreEqual("Wrong Personal Code (CenturyBirthday)!", birthdayLabel.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Order(4)]
        [Test]
        public void PersonalCode_LTUTelephoneNumberFormatIsValid_CorrectMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("35207118795");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("+3706 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            IWebElement phoneLabel = driver.FindElement(By.Id("MainContent_phoneLabel"));
            Assert.AreEqual("Lithuanian phone number is valid", phoneLabel.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Order(5)]
        [Test]
        public void PersonalCode_PerconCodeIsValid_CorrectMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("49006138556");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("+3706 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            IWebElement personalCodeLabel = driver.FindElement(By.Id("MainContent_personalCodeLabel"));
            Assert.AreEqual("All Done!", personalCodeLabel.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }



        [Test]
        [Order(6)]
        public void RegisterButtonClick_AllLabelsFilled_ValidRedirection()
        {
            // driver.Url real URL
            string url = "https://localhost:44369/";

            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("40413059638");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("86 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            Assert.AreNotEqual(url, driver.Url);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        [Order(7)]
        public void RegisterButtonCLick_StudentNotExistsInList_ValidMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("38806189205");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("86 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            IWebElement studentExists = driver.FindElement(By.Id("MainContent_studentExists"));
            Assert.AreNotEqual("This student not exists in our data", studentExists.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        [Order(8)]
        public void PersonalCode_notCorrectCenturyOfBirth_ValidMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("45207118795");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("86 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            IWebElement birthdayLabel = driver.FindElement(By.Id("MainContent_birthdayLabel"));
            Assert.AreNotEqual("Wrong Personal Code (CenturyBirthday)!", birthdayLabel.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Order(9)]
        [Test]
        public void PersonalCode_LTUTelephoneNumberFormatIsValid_ValidMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("35207118795");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("+3707 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            IWebElement phoneLabel = driver.FindElement(By.Id("MainContent_phoneLabel"));
            Assert.AreNotEqual("Lithuanian phone number is valid", phoneLabel.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Order(10)]
        [Test]
        public void PersonalCode_PerconCodeIsValid_ValidMessage()
        {
            nameField.SendKeys("Daniel");
            surnameField.SendKeys("Surname");
            personalCode.SendKeys("99999999999");
            SelectElement selectGender = new SelectElement(genderSelect);
            selectGender.SelectByIndex(2);
            addressField.SendKeys("adresas toksai ir toksai");
            telephoneNumber.SendKeys("+3706 000 0000");
            SelectElement selectProgram = new SelectElement(studyProgram);
            selectProgram.SelectByIndex(2);
            SelectElement selectMode = new SelectElement(modeOfStudy);
            selectMode.SelectByText("Full-time");
            agreeCheck.Click();
            registerButton.Click();

            IWebElement personalCodeLabel = driver.FindElement(By.Id("MainContent_personalCodeLabel"));
            Assert.AreNotEqual("All Done!", personalCodeLabel.Text);

            Thread.Sleep(5000);
            driver.Quit();
        }


    }
}

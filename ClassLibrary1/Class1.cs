using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ClassLibrary1
{
  [TestFixture]
  public class Class1
  {
    private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;
    private bool acceptNextAlert = true;

    [SetUp]
    public void SetupTest()
    {
      driver = new FirefoxDriver();
      baseURL = "https://www.katalon.com/";
      verificationErrors = new StringBuilder();
    }

    [TearDown]
    public void TeardownTest()
    {
      try
      {
        driver.Quit();
      }
      catch (Exception)
      {
        // Ignore errors if unable to close the browser
      }
      Assert.AreEqual("", verificationErrors.ToString());
    }

    [Test]
    public void TheSearchTest()
    {
      driver.Navigate().GoToUrl("http://localhost:4200/");
      driver.FindElement(By.Id("mat-input-0")).Click();
      driver.FindElement(By.Id("mat-input-0")).Clear();
      driver.FindElement(By.Id("mat-input-0")).SendKeys("Ford");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Assignment 4'])[1]/following::span[4]")).Click();
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='--'])[1]/following::span[1]")).Click();
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Make'])[1]/following::button[1]")).Click();
      Assert.AreEqual("Ford", driver.FindElement(By.LinkText("Ford")).Text);
    }
    [Test]
    public void TheAddTest()
    {
      driver.Navigate().GoToUrl("http://localhost:4200/");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Search'])[1]/following::button[1]")).Click();
      driver.FindElement(By.Id("sn")).Click();
      driver.FindElement(By.Id("sn")).Clear();
      driver.FindElement(By.Id("sn")).SendKeys("Hari");
      driver.FindElement(By.Id("address")).Clear();
      driver.FindElement(By.Id("address")).SendKeys("Old Carriage");
      driver.FindElement(By.Id("city")).Clear();
      driver.FindElement(By.Id("city")).SendKeys("Kitchener");
      driver.FindElement(By.Id("phone")).Clear();
      driver.FindElement(By.Id("phone")).SendKeys("5197211259");
      driver.FindElement(By.Id("email")).Clear();
      driver.FindElement(By.Id("email")).SendKeys("hari@abc.com");
      driver.FindElement(By.Id("make")).Clear();
      driver.FindElement(By.Id("make")).SendKeys("BMW");
      driver.FindElement(By.Id("model")).Clear();
      driver.FindElement(By.Id("model")).SendKeys("X1");
      driver.FindElement(By.Id("year")).Clear();
      driver.FindElement(By.Id("year")).SendKeys("2018");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::button[1]")).Click();
      Assert.AreEqual("BMW", driver.FindElement(By.LinkText("BMW")).Text);
    }

    [Test]
    public void TheValidationTest()
    {
      driver.Navigate().GoToUrl("http://localhost:4200/");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Search'])[1]/following::button[1]")).Click();
      driver.FindElement(By.Id("sn")).Click();
      driver.FindElement(By.Id("sn")).Clear();
      driver.FindElement(By.Id("sn")).SendKeys("Krishna");
      driver.FindElement(By.Id("address")).Clear();
      driver.FindElement(By.Id("address")).SendKeys("Orlando");
      driver.FindElement(By.Id("city")).Clear();
      driver.FindElement(By.Id("city")).SendKeys("Toronto");
      driver.FindElement(By.Id("phone")).Clear();
      driver.FindElement(By.Id("phone")).SendKeys("519-72222-2221");
      driver.FindElement(By.Id("email")).Clear();
      driver.FindElement(By.Id("email")).SendKeys("hari@gmcil.com");
      driver.FindElement(By.Id("make")).Clear();
      driver.FindElement(By.Id("make")).SendKeys("GMC");
      driver.FindElement(By.Id("model")).Clear();
      driver.FindElement(By.Id("model")).SendKeys("suv");
      driver.FindElement(By.Id("year")).Clear();
      driver.FindElement(By.Id("year")).SendKeys("2019");
      Assert.AreEqual("Enter Valid Phone Number", driver.FindElement(By.Id("phoneErr")).Text);
    }
    [Test]
    public void TheValidFormTest()
    {
      driver.Navigate().GoToUrl("http://localhost:4200/");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Search'])[1]/following::button[1]")).Click();
      driver.FindElement(By.Id("sn")).Click();
      driver.FindElement(By.Id("sn")).Clear();
      driver.FindElement(By.Id("sn")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Add Vehicle'])[1]/following::div[5]")).Click();
      driver.FindElement(By.Id("address")).Click();
      driver.FindElement(By.Id("address")).Clear();
      driver.FindElement(By.Id("address")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid Sellers Name'])[1]/following::div[2]")).Click();
      driver.FindElement(By.Id("city")).Click();
      driver.FindElement(By.Id("city")).Clear();
      driver.FindElement(By.Id("city")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid Street Address'])[1]/following::div[4]")).Click();
      driver.FindElement(By.Id("phone")).Click();
      driver.FindElement(By.Id("phone")).Clear();
      driver.FindElement(By.Id("phone")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid City'])[1]/following::div[4]")).Click();
      driver.FindElement(By.Id("email")).Click();
      driver.FindElement(By.Id("email")).Clear();
      driver.FindElement(By.Id("email")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid Phone Number'])[1]/following::div[4]")).Click();
      driver.FindElement(By.Id("make")).Click();
      driver.FindElement(By.Id("make")).Clear();
      driver.FindElement(By.Id("make")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid Email'])[1]/following::div[4]")).Click();
      driver.FindElement(By.Id("model")).Click();
      driver.FindElement(By.Id("model")).Clear();
      driver.FindElement(By.Id("model")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid Make'])[1]/following::div[4]")).Click();
      driver.FindElement(By.Id("year")).Click();
      driver.FindElement(By.Id("year")).Clear();
      driver.FindElement(By.Id("year")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.");
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid Vehicle Model'])[1]/following::div[4]")).Click();
      driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Enter Valid Vehicle Year'])[1]/following::div[4]")).Click();
      Assert.AreEqual("Enter Valid Sellers Name", driver.FindElement(By.Id("nameErr")).Text);
      Assert.AreEqual("Enter Valid Street Address", driver.FindElement(By.Id("addressErr")).Text);
      Assert.AreEqual("Enter Valid City", driver.FindElement(By.Id("cityErr")).Text);
      Assert.AreEqual("Enter Valid Phone Number", driver.FindElement(By.Id("phoneErr")).Text);
      Assert.AreEqual("Enter Valid Email", driver.FindElement(By.Id("emailErr")).Text);
      Assert.AreEqual("Enter Valid Vehicle Model", driver.FindElement(By.Id("modelErr")).Text);
      Assert.AreEqual("Enter Valid Make", driver.FindElement(By.Id("makeErr")).Text);
    }
    private bool IsElementPresent(By by)
    {
      try
      {
        driver.FindElement(by);
        return true;
      }
      catch (NoSuchElementException)
      {
        return false;
      }
    }

    private bool IsAlertPresent()
    {
      try
      {
        driver.SwitchTo().Alert();
        return true;
      }
      catch (NoAlertPresentException)
      {
        return false;
      }
    }

    private string CloseAlertAndGetItsText()
    {
      try
      {
        IAlert alert = driver.SwitchTo().Alert();
        string alertText = alert.Text;
        if (acceptNextAlert)
        {
          alert.Accept();
        }
        else
        {
          alert.Dismiss();
        }
        return alertText;
      }
      finally
      {
        acceptNextAlert = true;
      }
    }
  }
}

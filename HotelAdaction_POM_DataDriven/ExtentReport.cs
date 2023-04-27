using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;

namespace Final_POM_DataDriven
{
    public class ExtentReport
    {
        public static IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;
      
        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"..\..\TestExecutionReports\" + '_' + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);
        }

        public void inti()
         {
            driver = new ChromeDriver();
        }
    public void TakeScreenshot(Status status, string stepDetail)
        {

            string path = @"D:\TestExecutionReports\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());


        }

        public void Write(By by, string data, string detail)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Entry Failed" + ex);
            }
        }

        public void Click(By by, string detail)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Click Failed" + ex);
            }
        }
    }
}

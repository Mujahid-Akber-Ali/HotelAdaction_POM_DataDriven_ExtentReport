using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SikuliModule;
using System;
using System.Threading;
using WindowsInput;

namespace Final_POM_DataDriven
{
    [TestClass]
    public class UnitTest1 : ExtentReport
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [TestInitialize]
        public void Init()
        {
            inti();
            LogReport(TestContext.TestName);
            exParentTest = extentReports.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            extentReports.Flush();
            Thread.Sleep(6000);
            driver.Close();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "data.csv", "data#csv", DataAccessMethod.Sequential)]
        public void Failed_Test_On_CheckInDates()
        {
            string URL = TestContext.DataRow["url"].ToString();
            string USER = TestContext.DataRow["username"].ToString();
            string PASS = TestContext.DataRow["password"].ToString();
            string LOCATION = TestContext.DataRow["location"].ToString();
            string HOTEL = TestContext.DataRow["hotel"].ToString();
            string ROOM = TestContext.DataRow["Room"].ToString();
            string CHECK_IN = TestContext.DataRow["check_in"].ToString();
            string CHECH_OUT = TestContext.DataRow["check_out"].ToString();
            string ADULT = TestContext.DataRow["adult"].ToString();
            string CHILD = TestContext.DataRow["child"].ToString();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;


            exChildTest = exParentTest.CreateNode("Login");

            //driver.Url = "https://adactinhotelapp.com/";
            driver.Url = URL;


            InputSimulator sim = new InputSimulator();

            #region Other techniques to Automate

            //By JavaScript
            //js.ExecuteScript("document.getElementById('username').value='AmirImam'");


            //By JQuery
            //js.ExecuteScript("$('#username').val('AmirImam')");

            //By Selenium
            //driver.FindElement(AmirImamBy.Id("username")).SendKeys("AmirImam");
            //TakeScreenshot(Status.Pass, "Enter Username ");


            //By Sikuli
            //SikuliAction.Click(@"C:\Users\aliijmuj\Desktop\Username.png");
            //sim.Keyboard.TextEntry("AmirImam");
            #endregion


            //driver.FindElement(By.Id("password")).SendKeys("AmirImam");
            //TakeScreenshot(Status.Pass, "Enter Password ");



            //driver.FindElement(By.Id("login")).Click();
            //TakeScreenshot(Status.Pass, "Click Login ");

            #region loginPOM

            Login_Class Login = new Login_Class();
            Login.login(USER, PASS);
            #endregion

            //driver.FindElement(By.Id("location")).SendKeys("Sydney");
            //driver.FindElement(By.Id("hotels")).SendKeys("Hotel Creek");
            //driver.FindElement(By.Id("room_type")).SendKeys("Standard");

            //driver.FindElement(By.Id("room_type")).SendKeys(Keys.Tab);
            //driver.FindElement(By.Id("datepick_in")).SendKeys("10/08/2023");

            //driver.FindElement(By.Id("datepick_in")).SendKeys(Keys.Tab);
            //driver.FindElement(By.Id("datepick_out")).SendKeys("15/08/2023");


            //driver.FindElement(By.Id("adult_room")).SendKeys("1 - One");
            //driver.FindElement(By.Id("child_room")).SendKeys("2 - Two");

            //driver.FindElement(By.Id("Submit")).Click();

            exChildTest = exParentTest.CreateNode("Search");
            #region SearchPOM

            Search_Class Search = new Search_Class();
            Search.search(LOCATION, HOTEL, ROOM, CHECK_IN, "09/04/2023", ADULT, CHILD);

            var message = driver.FindElement(By.ClassName("login_title")).Text;

            Assert.AreEqual(message, "Select Hotel");
            Console.WriteLine("Failed to Proceed");
            #endregion

            //driver.FindElement(By.Id("radiobutton_0")).Click();
            //driver.FindElement(By.Id("continue")).Click();

            //driver.FindElement(By.Id("first_name")).SendKeys("Mujahid Akber Ali");
            //driver.FindElement(By.Id("last_name")).SendKeys("Akber Ali");
            //driver.FindElement(By.Id("address")).SendKeys("1-A 5/7 Nazimabad");

            //driver.FindElement(By.Id("cc_num")).SendKeys("123456789101112");
            //driver.FindElement(By.Id("cc_type")).SendKeys("VISA");
            //driver.FindElement(By.Id("cc_exp_month")).SendKeys("January");
            //driver.FindElement(By.Id("cc_exp_year")).SendKeys("2017");
            //driver.FindElement(By.Id("cc_cvv")).SendKeys("1234");
            //driver.FindElement(By.Id("book_now")).Click();




        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "data.csv", "data#csv", DataAccessMethod.Sequential)]
        public void Passed_Test_On_CheckInDates()
        {
            string URL = TestContext.DataRow["url"].ToString();
            string USER = TestContext.DataRow["username"].ToString();
            string PASS = TestContext.DataRow["password"].ToString();
            string LOCATION = TestContext.DataRow["location"].ToString();
            string HOTEL = TestContext.DataRow["hotel"].ToString();
            string ROOM = TestContext.DataRow["Room"].ToString();
            string CHECK_IN = TestContext.DataRow["check_in"].ToString();
            string CHECH_OUT = TestContext.DataRow["check_out"].ToString();
            string ADULT = TestContext.DataRow["adult"].ToString();
            string CHILD = TestContext.DataRow["child"].ToString();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            exChildTest = exParentTest.CreateNode("Login");

            //driver.Url = "https://adactinhotelapp.com/";
            driver.Url = URL;


            InputSimulator sim = new InputSimulator();

            #region loginPOM

            Login_Class Login = new Login_Class();
            Login.login(USER, PASS);
            #endregion


            exChildTest = exParentTest.CreateNode("Booking");
            #region SearchPOM

            Search_Class Search = new Search_Class();
            Search.search(LOCATION, HOTEL, ROOM, CHECK_IN, CHECH_OUT, ADULT, CHILD);
            #endregion


        }

        //With XML data file
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "New.xml", "Booking_Page_Passed_DataDriven", DataAccessMethod.Sequential)]
        public void Booking_Page_Passed_DataDriven()
        {
            string URL = TestContext.DataRow["url"].ToString();
            string USER = TestContext.DataRow["username"].ToString();
            string PASS = TestContext.DataRow["password"].ToString();
            string LOCATION = TestContext.DataRow["location"].ToString();
            string HOTEL = TestContext.DataRow["hotel"].ToString();
            string ROOM = TestContext.DataRow["Room"].ToString();
            string CHECK_IN = TestContext.DataRow["check_in"].ToString();
            string CHECH_OUT = TestContext.DataRow["check_out"].ToString();
            string ADULT = TestContext.DataRow["adult"].ToString();
            string CHILD = TestContext.DataRow["child"].ToString();
            string CreditCardNo = TestContext.DataRow["credit"].ToString();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            exChildTest = exParentTest.CreateNode("Login");

            //driver.Url = "https://adactinhotelapp.com/";
            driver.Url = URL;


            InputSimulator sim = new InputSimulator();


            #region loginPOM

            Login_Class Login = new Login_Class();
            Login.login(USER, PASS);
            #endregion


            exChildTest = exParentTest.CreateNode("Search");
            #region SearchPOM

            Search_Class Search = new Search_Class();
            Search.search(LOCATION, HOTEL, ROOM, CHECK_IN, CHECH_OUT, ADULT, CHILD);
            #endregion

            exChildTest = exParentTest.CreateNode("Selection");
            #region SelectPOM

            Select1 select1 = new Select1();
            select1.selection();

            #endregion


            exChildTest = exParentTest.CreateNode("Booking");
            #region BookingPOM

            Booking_Class Booking = new Booking_Class();
            Booking.booking(CreditCardNo);

            #endregion



        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "New.xml", "Booking_Page_Passed_DataDriven", DataAccessMethod.Sequential)]
        public void Failed_Test_Credit_lessthan16()

        {
            string URL = TestContext.DataRow["url"].ToString();
            string USER = TestContext.DataRow["username"].ToString();
            string PASS = TestContext.DataRow["password"].ToString();
            string LOCATION = TestContext.DataRow["location"].ToString();
            string HOTEL = TestContext.DataRow["hotel"].ToString();
            string ROOM = TestContext.DataRow["Room"].ToString();
            string CHECK_IN = TestContext.DataRow["check_in"].ToString();
            string CHECH_OUT = TestContext.DataRow["check_out"].ToString();
            string ADULT = TestContext.DataRow["adult"].ToString();
            string CHILD = TestContext.DataRow["child"].ToString();


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            exChildTest = exParentTest.CreateNode("Login");

            //driver.Url = "https://adactinhotelapp.com/";
            driver.Url = URL;


            InputSimulator sim = new InputSimulator();


            #region loginPOM

            Login_Class Login = new Login_Class();
            Login.login(USER, PASS);
            #endregion


            exChildTest = exParentTest.CreateNode("Search");
            #region SearchPOM

            Search_Class Search = new Search_Class();
            Search.search(LOCATION, HOTEL, ROOM, CHECK_IN, CHECH_OUT, ADULT, CHILD);
            #endregion


            exChildTest = exParentTest.CreateNode("Booking");
            #region SelectPOM

            Select1 select1 = new Select1();
            select1.selection();

            #endregion


            exChildTest = exParentTest.CreateNode("Book");
            #region BookingPOM

            Booking_Class Booking = new Booking_Class();
            Booking.booking("12345");

            #endregion

            var confirmation_message = driver.FindElement(By.ClassName("login_title")).Text;
            Assert.AreEqual(confirmation_message, "Booking Confirmation");


        }



        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "New.xml", "Booking_Page_Passed_DataDriven", DataAccessMethod.Sequential)]
        public void Continue_without_selection()

        {
            string URL = TestContext.DataRow["url"].ToString();
            string USER = TestContext.DataRow["username"].ToString();
            string PASS = TestContext.DataRow["password"].ToString();
            string LOCATION = TestContext.DataRow["location"].ToString();
            string HOTEL = TestContext.DataRow["hotel"].ToString();
            string ROOM = TestContext.DataRow["Room"].ToString();
            string CHECK_IN = TestContext.DataRow["check_in"].ToString();
            string CHECH_OUT = TestContext.DataRow["check_out"].ToString();
            string ADULT = TestContext.DataRow["adult"].ToString();
            string CHILD = TestContext.DataRow["child"].ToString();


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            LogReport("TestMethod1");

            exParentTest = extentReports.CreateTest("TestMethod1");
            exChildTest = exParentTest.CreateNode("Login");

            //driver.Url = "https://adactinhotelapp.com/";
            driver.Url = URL;


            InputSimulator sim = new InputSimulator();


            #region loginPOM

            Login_Class Login = new Login_Class();
            Login.login(USER, PASS);
            #endregion


            exChildTest = exParentTest.CreateNode("Search");
            #region SearchPOM

            Search_Class Search = new Search_Class();
            Search.search(LOCATION, HOTEL, ROOM, CHECK_IN, CHECH_OUT, ADULT, CHILD);
            #endregion

            exChildTest = exParentTest.CreateNode("Selection");
            #region SelectPOM


            driver.FindElement(By.Id("continue")).Click();
            TakeScreenshot(Status.Fail, "Failed to continue");


            var booking_message = driver.FindElement(By.ClassName("login_title")).Text;
            Assert.AreEqual(booking_message, "Book A Hotel");
            #endregion



        }
    }
}

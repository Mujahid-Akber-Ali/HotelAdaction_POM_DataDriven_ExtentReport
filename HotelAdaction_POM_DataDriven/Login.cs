using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_POM_DataDriven
{
    public class Login_Class : ExtentReport
    {
        By Username_TXT = By.Id("username");
        By Password_TXT = By.Id("password");
        By Login_BTN = By.Id("login");
        public void login(string user, string pass)
        {
            Write(Username_TXT, user, "Enter Username ");
            Write(Password_TXT, pass, "Enter Password ");
            Click(Login_BTN, "Click is Pressed ");

        }
    }
}

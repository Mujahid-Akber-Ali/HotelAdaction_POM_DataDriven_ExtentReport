using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_POM_DataDriven
{
    public class Select1 : ExtentReport
    {
        By Radio_BTN = By.Id("radiobutton_1");
        By Continue_BTN = By.Id("continue");
        public void selection()
        {
            Click(Radio_BTN, "Click is Pressed ");
            Click(Continue_BTN, "Continue is Pressed ");
        }
    }
}

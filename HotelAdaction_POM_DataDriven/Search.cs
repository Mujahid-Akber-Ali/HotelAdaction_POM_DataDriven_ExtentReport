using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_POM_DataDriven
{
    public class Search_Class : ExtentReport
    {
        By Location_TXT = By.Id("location");
        By Hotel_TXT = By.Id("hotels");
        By Room_Type_TXT = By.Id("room_type");
        By CheckIn_TXT = By.Id("datepick_in");
        By CheckOut_TXT = By.Id("datepick_out");
        By Adult_TXT = By.Id("adult_room");
        By Child_TXT = By.Id("child_room");

        public void search(string location, string hotel, string Room, string chech_in, string check_out, string adult, string child)
        {
            Write(Location_TXT, location, "Enter Location ");
            Write(Hotel_TXT, hotel, "Enter Hotel ");
            Write(Room_Type_TXT, Room, "Enter Room Type ");
            driver.FindElement(Room_Type_TXT).SendKeys(Keys.Tab);
            Write(CheckIn_TXT, chech_in, "Enter CheckIn Date ");
            driver.FindElement(CheckIn_TXT).SendKeys(Keys.Tab);
            Write(CheckOut_TXT, check_out, "Enter Checkout Date ");
            Write(Adult_TXT, adult, "Enter Adult Room Type ");
            Write(Child_TXT, child, "Enter Childern Room Type ");
            Click(By.Id("Submit"), "Submit Pressed");



        }
    }
}

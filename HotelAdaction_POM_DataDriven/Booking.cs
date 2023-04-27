using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Final_POM_DataDriven
{
    public class Booking_Class : ExtentReport
    {
        By first_TXT = By.Id("first_name");
        By last_TXT = By.Id("last_name");
        By adress_TXT = By.Id("address");
        By CVVNum_TXT = By.Id("cc_num");
        By CVVType_TXT = By.Id("cc_type");
        By EXPMON_TXT = By.Id("cc_exp_month");
        By EXPYEAR_TXT = By.Id("cc_exp_year");
        By CCCVV_TXT = By.Id("cc_cvv");
        By BOOK_TXT = By.Id("book_now");

        public void booking(string credit_card)
        {
            Write(first_TXT, "Mujahid Akber Ali", "Enter First Name ");
            Write(last_TXT, "Akber Ali", "Enter Last Name ");
            Write(adress_TXT, "1-A 5/7 Nazimabad", "Enter Adress ");
            Write(CVVNum_TXT, credit_card, "Enter CVV Num ");
            Write(CVVType_TXT, "VISA", "Enter CVV type ");
            Write(EXPMON_TXT, "January", "Enter Month Num ");
            Write(EXPYEAR_TXT, "2017", "Enter Year Num ");
            Write(CCCVV_TXT, "1234", "Enter CVV ");
            Click(BOOK_TXT, "Press Book Now");


        }
    }
}

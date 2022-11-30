using MedlicalService.Driver;
using MedlicalService.Page;

namespace MedlicalService.Tests
{
    public class LoginTest
    {
        LoginPage loginPage;
        string Message = "Login failed! Please ensure the username and password are valid.";
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }
        [Test]
        public void TC01_EnterinvalidUserName()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("Marko", "ThisIsNotAPassword");
            Assert.That(Message, Is.EqualTo(loginPage.InvalidUsername.Text));
        }
        [Test]
        public void TC02_EnterinvalidPassword()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "42411424");
            Assert.That(Message, Is.EqualTo(loginPage.InvalidUsername.Text));

        }
        [Test]
        public void TC03_Donotenteranydata()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("", "");
            Assert.That(Message, Is.EqualTo(loginPage.InvalidUsername.Text));

        }
    }
}

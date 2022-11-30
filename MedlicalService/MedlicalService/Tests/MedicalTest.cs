using MedlicalService.Driver;
using MedlicalService.Page;

namespace MedlicalService.Tests
{
    public class Tests
    {
        LoginPage loginPage;
        MedicalPage medicalPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            medicalPage = new MedicalPage();
        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }
        [Test]
        public void TC02_MakeShouldBeComplited()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "ThisIsNotAPassword");
            medicalPage.SelectOption("Hongkong CURA Healthcare Center");
            medicalPage.CheckBox.Click();
            medicalPage.MedicId.Click();
            medicalPage.Date.SendKeys("25/12/2022");
            medicalPage.Commnet.SendKeys("zakazano");
            medicalPage.BookButton.Submit();

            Assert.That("Appointment Confirmation", Is.EqualTo(medicalPage.Confirm.Text));



        }
    }
}
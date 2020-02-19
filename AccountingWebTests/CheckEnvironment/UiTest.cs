using System.Data;
using System.IO;
using AccountingWeb;
using AccountingWeb.Controllers;
using AccountingWebTests.DataModels;
using AccountingWebTests.PageObjects;
using Atata;
using NUnit.Framework;

namespace AccountingWebTests.CheckEnvironment
{
    [TestFixture]
    public class UiTest
    {
        //if you cannot run web test, please check if you use the Chrome version 80 browser.
        //if your version is less than 80, you may need to downgrade nuget package "Selenium.WebDriver.ChromeDriver" version to the appropriate version

        [SetUp]
        public void SetUp()
        {
            File.Delete(BudgetManager.DB_PATH);

            // Find information about AtataContext set-up on https://atata.io/getting-started/#set-up
            AtataContext.Configure()
                        .UseChrome()
                        //    WithArguments("start-maximized").
                        //.UseBaseUrl("http://automationpractice.com/index.php")
                        .UseBaseUrl("http://localhost:50564")
                        .UseCulture("en-us").UseNUnitTestName()
                        .AddNUnitTestContextLogging().LogNUnitError()
                        .UseAssertionExceptionType<NUnit.Framework.AssertionException>()
                        .UseNUnitAggregateAssertionStrategy().Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [Test][Ignore("")]
        public void go_to_joey_blog()
        {
            Go.ToUrl("https://dotblogs.com.tw/hatelove/1");
        }

        [Test]
        public void GoToBudget()
        {
            Go.To<BudgetPage>()
                .Date.Set("201901")
                .Budget.Set("1000")
                .Submit.ClickAndGo<ResultPage>()
                .Message.Should.StartWith("Create");
        }

        [Test]
        public void UpdateToBudget()
        {
            BudgetManager.Instance.CreateOrUpdateBudget("202002", "3000");
            Go.To<BudgetPage>()
                .Date.Set("202002")
                .Budget.Set("200")
                .Submit.ClickAndGo<ResultPage>()
                .Message.Should.StartWith("Update");
        }
    }
}
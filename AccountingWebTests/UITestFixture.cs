using Atata;
using NUnit.Framework;

namespace AccountingWebTests
{
    [TestFixture]
    public class UITestFixture
    {
        [SetUp]
        public void SetUp()
        {
            // Find information about AtataContext set-up on https://atata.io/getting-started/#set-up
            AtataContext.Configure()
                        .UseChrome()
                        //    WithArguments("start-maximized").
                        //UseBaseUrl("http://automationpractice.com/index.php")
                        .UseCulture("en-us").UseNUnitTestName()
                        .AddNUnitTestContextLogging().LogNUnitError()
                        .UseAssertionExceptionType<NUnit.Framework.AssertionException>()
                        .UseNUnitAggregateAssertionStrategy().Build();
        }

        [Test]
        public void Method()
        {
            Go.ToUrl("https://tw.yahoo.com");
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}
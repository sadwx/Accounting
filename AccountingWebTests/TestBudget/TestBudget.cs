using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWeb;
using AccountingWebTests.DataModels;
using NUnit.Framework;

namespace AccountingWebTests.TestBudget
{
    [TestFixture]
    class TestBudget
    {
        [SetUp]
        public void setup()
        {
            File.Delete(BudgetManager.DB_PATH);
            BudgetManager.Instance.CreateOrUpdateBudget("202002", "3000");
        }

        [Test]
        public void TestCreateBudget()
        {
            Assert.AreEqual("Create", BudgetManager.Instance.CreateOrUpdateBudget("199902", "10000"));
            Assert.True(BudgetManager.Instance.Budgets.Exists(b => b.YearMonth == "199902" && b.Amount == "10000"));
        }

        [Test]
        public void TestUpdateBudget()
        {
            Assert.AreEqual("Update", BudgetManager.Instance.CreateOrUpdateBudget("202002", "500"));
            Assert.True(BudgetManager.Instance.Budgets.Exists(b => b.YearMonth == "202002" && b.Amount == "500"));
        }
    }
}

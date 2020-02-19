using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = BudgetPage;

    [Url("Budget")]
    public class BudgetPage : Page<_>
    {
        [FindByName("date")]
        public TextInput<_> Date { get; private set; }

        [FindByName("budget")]
        public TextInput<_> Budget { get; private set; }

        [FindByValue("submit")]
        public Button<ResultPage, _> Submit { get; private set; }
    }
}

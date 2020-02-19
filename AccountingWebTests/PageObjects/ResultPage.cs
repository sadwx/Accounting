using Atata;

namespace AccountingWebTests.PageObjects
{
    using _ = ResultPage;
    public class ResultPage: Page<_>
    {
        public H3<_> Message { get; private set; }
    }
}
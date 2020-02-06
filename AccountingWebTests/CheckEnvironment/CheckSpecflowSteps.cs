using System;
using ExpectedObjects;
using TechTalk.SpecFlow;
using static TechTalk.SpecFlow.ScenarioContext;

#pragma warning disable 618

namespace AccountingWebTests.CheckEnvironment
{
    //you need add nuget packages:
    // 1. SpecFlow
    // 2. SpecFlow.NUnit
    // 3. SpecFlow.Tools.MsBuild.Generation

    [Binding]
    public class CheckSpecflowSteps : Steps
    {
        private Calculator _calculator;

        [BeforeScenario()]
        public void BeforeScenario()
        {
            _calculator = new Calculator();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _calculator.Add(number);
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expected)
        {
            var actual = ScenarioContext.Get<int>("result");
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var result = _calculator.Result();
            ScenarioContext.Set(result, "result");
        }
    }

    public class Calculator
    {
        private int _sum;

        public void Add(int number)
        {
            _sum += number;
        }

        public int Result()
        {
            return _sum;
        }
    }
}
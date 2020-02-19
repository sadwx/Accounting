using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AccountingWeb
{
    public class BudgetManager
    {
        public const string DB_PATH = @"D:\Lab\Accounting\Budget.json";
        private readonly List<BudgetModel> _budgets;
        private static BudgetManager _instance;

        private BudgetManager()
        {
            if (!System.IO.File.Exists(DB_PATH))
            {
                System.IO.File.WriteAllText(DB_PATH, "[]");
            }
            _budgets = JToken.Parse(System.IO.File.ReadAllText(DB_PATH)).ToObject<List<BudgetModel>>();
        }

        public List<BudgetModel> Budgets
        {
            get { return _budgets; }
        }

        public static BudgetManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BudgetManager();
                return _instance;
            }
        }

        public string CreateOrUpdateBudget(string date, string budget)
        {
            var existingBudget = _budgets.Find(b => b.YearMonth == date);
            if (existingBudget != null)
            {
                existingBudget.Amount = budget;
            }
            else
            {
                var newBudget = new BudgetModel()
                {
                    YearMonth = date,
                    Amount = budget
                };
                _budgets.Add(newBudget);
            }
            System.IO.File.WriteAllText(DB_PATH, JsonConvert.SerializeObject(_budgets));
            return existingBudget == null ? "Create" : "Update";
        }
    }
}
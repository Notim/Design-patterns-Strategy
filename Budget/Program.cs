using System;

using Budget.Taxes;
using Budget.Taxes.vendors;

namespace Budget {

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            ITax iss  = new ISS();
            ITax icms = new ICMS();
            ITax iccc = new ICCC();

            Console.WriteLine(BudgetCalculator.Calculate(new Budget {value = 2500}, iss));
            Console.WriteLine(BudgetCalculator.Calculate(new Budget {value = 2500}, icms));
            Console.WriteLine(BudgetCalculator.Calculate(new Budget {value = 2500}, iccc));
        }
    }

}
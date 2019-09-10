using System;
using System.Collections.Generic;
using System.Linq;

using Budget.Taxes;
using Budget.Taxes.vendors;

namespace Budget {

    class Program {
        static void Main(string[] args) {
            IList<ITax> listImplementations = new List<ITax> {
                new ISS(), 
                new ICMS(), 
                new ICCC() 
            };
            
            Console.WriteLine("selecione qual o metodo");
            var option = Console.ReadLine();

            var implementation = listImplementations.FirstOrDefault(x => x.isThis(option));

            Console.WriteLine(BudgetCalculator.Calculate(new Budget {value = 2500}, implementation));
        }
    }

}
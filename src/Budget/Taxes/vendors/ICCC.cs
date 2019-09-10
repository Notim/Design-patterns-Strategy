namespace Budget.Taxes.vendors {

    public class ICCC : ITax {
        
        public bool isThis(string option) {
            return option == "ICCC";
        }

        public decimal Calculates(Budget budget) {

            var value = (decimal) 0.0;
            if (budget.value <= (decimal) 1000.00) {
                value = budget.value * (decimal) 0.05;
            }

            if (budget.value > (decimal) 1000.00 && budget.value <= (decimal) 3000.00) {
                return (budget.value * (decimal) 0.07);
            }
            
            if (budget.value > (decimal) 3000.00) {
                return (budget.value * (decimal) 0.08) + 30;
            }
            
            return value;
        }

        public decimal Calculate(Budget budget) {
            return this.Calculates(budget);
        }
    }

}
namespace Budget.Taxes.vendors {

    public class ICMS : ITax {
        
        public bool isThis(string option) {
            return option == "ICMS";
        }
        
        public decimal Calculate(Budget budget) {
            return budget.value += (decimal) (0.17 * (double) budget.value);
        }
    }

}
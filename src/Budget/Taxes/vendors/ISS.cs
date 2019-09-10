namespace Budget.Taxes.vendors {

    public class ISS : ITax {

        public bool isThis(string option) {
            return option == "ISS";
        }

        public decimal Calculate(Budget budget) {
            return budget.value += (decimal) (0.10 * (double) budget.value);
        }
    }

}
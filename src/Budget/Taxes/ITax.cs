namespace Budget.Taxes {

    public interface ITax {

        bool isThis(string option);

        decimal Calculate(Budget budget);
    }

}
namespace Budget.Taxes {

    public interface ITax {
        decimal Calculate(Budget budget);
    }

}
using Investments.Entities;

namespace Investments.InvestorProfiles {

    public interface IInvestorProfileStrategy {
        decimal calculate(BankAccount Account);
    }

}
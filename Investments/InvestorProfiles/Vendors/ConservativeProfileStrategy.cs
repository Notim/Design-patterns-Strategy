using Investments.Entities;

namespace Investments.InvestorProfiles.Vendors {

    public class ConservativeProfileStrategy : IInvestorProfileStrategy {

        public decimal calculate(BankAccount Account) {
            return (decimal) 0.065 * Account.Balance;
        }
    }

}
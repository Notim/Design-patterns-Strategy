using Investments.Entities;
using Investments.InvestorProfiles;

namespace Investments {

    public static class InvestmentDirector {

        public static decimal Invest(BankAccount account, IInvestorProfileStrategy strategy) {
            
            var rendimento = strategy.calculate(account);

            rendimento += (decimal) (0.75 * (double) rendimento);

            return rendimento;
        }
    }

}
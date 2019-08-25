using System;

using Investments.Entities;

namespace Investments.InvestorProfiles.Vendors {

    public class AggressiveProfileStrategy : IInvestorProfileStrategy {

        public decimal calculate(BankAccount Account) {
            var rdn = new Random().Next(100);

            var fator = (float) 0.0;

            if (rdn <= 20) {
                fator = (float) 0.5;
            }

            if (rdn > 20 && rdn <= 30) {
                fator = (float) 0.25;
            }

            if (rdn > 30) {
                fator = (float) 0.10;
            }

            return (decimal) (fator) * Account.Balance;
        }
    }

}
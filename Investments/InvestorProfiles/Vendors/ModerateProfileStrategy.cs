using System;

using Investments.Entities;

namespace Investments.InvestorProfiles.Vendors {

    public class ModerateProfileStrategy : IInvestorProfileStrategy {

        public decimal calculate(BankAccount Account) {

            bool escolhido = new Random().Next(100) > 50;

            return (decimal) (escolhido ? 0.25 : 0.15) * Account.Balance;

        }
    }

}
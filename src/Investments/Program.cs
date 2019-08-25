using System;

using Investments.Entities;
using Investments.InvestorProfiles.Vendors;

namespace Investments {

    class Program {
        static void Main(string[] args) {
            var account = new BankAccount {
                Balance = 500000
            };
            
            var AmmountConservetive = InvestmentDirector.Invest(account, new ConservativeProfileStrategy());
            var AmmountModerate     = InvestmentDirector.Invest(account, new ModerateProfileStrategy());
            var AmmountAggressive   = InvestmentDirector.Invest(account, new AggressiveProfileStrategy());

            Console.WriteLine("Start Value: " + account.Balance.ToString("C"));
            Console.WriteLine("Application Income for Conservetive:" + AmmountConservetive.ToString("C"));
            Console.WriteLine("Application Income for Moderate:" + AmmountModerate.ToString("C"));
            Console.WriteLine("Application Income for Aggressive:" + AmmountAggressive.ToString("C"));
        }
    }

}
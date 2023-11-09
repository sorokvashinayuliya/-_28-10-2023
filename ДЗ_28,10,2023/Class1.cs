using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_28_10_2023
{
    
    public enum AccountType
    {
        Текущий_счет,
        Сберегательный_счет
    }
    class BankAccount1
    {
        private int accountNumber;
        private decimal accountBalance;
        private AccountType bankAccountType;
        public static int numberOfBankAccounts;
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }

        public AccountType BankAccountType
        {
            get
            {
                return bankAccountType;
            }
        }


        private void ChangeNumberOfBankAccounts()
        {
            numberOfBankAccounts++;
        }
        public bool WithdrawMoneyFromAccount(decimal withdrawalAmount)
        {
            if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
            {
                accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }
        public bool PutMoneyIntoAccount(decimal depositedAmoun)
        {
            if (depositedAmoun > 0)
            {
                accountBalance += depositedAmoun;
                return true;
            }

            return false;
        }
        public bool TransferringMoney(BankAccount1 withdrawalAccount, decimal withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }
        public BankAccount1(decimal accountBalance)
        {
            this.accountBalance = accountBalance;
            bankAccountType = AccountType.Текущий_счёт;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        public BankAccount1(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        public BankAccount1(decimal bankAccount, AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            this.bankAccountType = bankAccountType;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        
    }
}

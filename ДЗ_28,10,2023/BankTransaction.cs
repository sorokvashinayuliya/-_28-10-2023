using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_28_10_2023
{
    internal class BankTransaction
    {
        private int accountBalance;
        private readonly object bankAccountType;
        private int accountNumber;
        private int accountType;
        private Queue<BankTransaction> transactionList = new Queue<BankTransaction>();
        private int numberOfBankAccounts;
        private DateTime transactionDate;
        private decimal amountChange;
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public int AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }
        public int AccountType
        {
            get
            {
                return accountType;
            }
        }
        public Queue<BankTransaction> TransactionList
        {
            get
            {
                return transactionList;
            }
        }
        private void NumberOfBankAccounts()
        {
            numberOfBankAccounts++;
        }
        public bool WithdrawMoneyFromAccount(int withdrawalAmount)
        {
            if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
            {
                accountBalance -= withdrawalAmount;
                BankTransaction bankTransaction = new BankTransaction(-withdrawalAmount);
                transactionList.Enqueue(bankTransaction);
                return true;
            }

            return false;
        }
        public bool PutMoneyIntoAccount(int depositedAmount)
        {
            if (depositedAmount>0)
            {
                accountBalance += depositedAmount;
                BankTransaction bankTransaction = new BankTransaction(depositedAmount);
                transactionList.Enqueue(bankTransaction);
                return true;
            }
            return false;
        }
        public bool TransferringMoney(BankTransaction withdrawalAccount, int withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                BankTransaction bankTransaction = new BankTransaction(withdrawalAmount);
                transactionList.Enqueue(bankTransaction);
                return true;
            }
            return false;
        }
        public BankTransaction(int accountBalance)
        {
            this.accountBalance = accountBalance;
            bankAccountType = AccountType.Текущий_счёт;
            accountNumber = numberOfBankAccounts;
            NumberOfBankAccounts();
        }
        public BankTransaction(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            accountNumber = numberOfBankAccounts;
            NumberOfBankAccounts();
        }
        public BankTransaction(int accountBalance, AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            this.accountBalance = accountBalance;
            accountNumber = numberOfBankAccounts;
            NumberOfBankAccounts();
        }
        public DateTime TransactionDate
        {
            get
            {
                return transactionDate;
            }
        }
        public decimal AmountChange
        {
            get
            {
                return amountChange;
            }
        }
        public BankTransaction (decimal amountChange)
        {
            this.amountChange = amountChange;
            transactionDate = DateTime.Now;
        }
    }
}

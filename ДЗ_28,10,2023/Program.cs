using System;
using System.Collections.Generic;

namespace ДЗ_28_10_2023
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 9.1. Переделать 8.1, используя конструкторы");

            BankAccount1 firstBankAccount = new BankAccount1(123456);
            BankAccount1 secondBankAccount = new BankAccount1(AccountType.Сберегательный_счет);
            BankAccount1 thirdBankAccount = new BankAccount1(1558183858, AccountType.Сберегательный_счёт);
            Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей" +
                              $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей" +
                              $"{thirdBankAccount.BankAccountType} №{thirdBankAccount.AccountNumber:D4}, баланс: {thirdBankAccount.AccountBalance} рублей");
            Console.WriteLine("Упражнение 9.2. Добавить класс BankTransaction");
            BankTransaction fourthBankAccount = new BankTransaction(2456479, AccountType.Сберегательный_счет);
            Queue<BankTransaction> transactionList;
            int count;

            fourthBankAccount.PutMoneyIntoAccount(150);
            fourthBankAccount.PutMoneyIntoAccount(1000);
            fourthBankAccount.WithdrawMoneyFromAccount(578);

            transactionList = fourthBankAccount.TransactionList;
            count = transactionList.Count;

            for (int i = 0; i < count; i++)
            {
                BankTransaction transaction = transactionList.Dequeue();
                if (transaction.AmountChange < 0)
                {
                    Console.WriteLine($"Снятие {transaction.TransactionDate}, {-transaction.AmountChange} рублей");
                }
                else
                {
                    Console.WriteLine($"Пополнение {transaction.TransactionDate}, {transaction.AmountChange} рублей");
                }
            }
            Console.WriteLine("Упражнение 9.1. Добавить конструкторы в класс Song");
            Song firstSong = new Song("Ты неси меня, река","ЛЮБЭ");
            Song secondSong = new Song("Прорвёмся!","ЛЮБЭ");
            Song thirdSong = new Song();
            Console.WriteLine($"{firstSong.Conclusions},{secondSong.Conclusions},{thirdSong.Conclusions}");
            
        }
    }
}

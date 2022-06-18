using System;
using TDDProject.Application;

namespace ProjectManagementTDDProject
{
    class Program
    {
        private static Bank bank { get; set; }


        static void Main(string[] args)
        {
            bank = new Bank();
            Seed();

            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Witaj w banku!");
                Console.WriteLine("Dostępne konta:");

                foreach(var account in bank.Accounts)
                {
                    Console.WriteLine($"\t- Imię: {account.Owner.Name}  Nazwisko: {account.Owner.Surname}  Saldo: {account.Balance}zł  Nr konta: {account.AccountNumber}");
                }

                DisplayMenu();

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        DoCreateAccount();
                        break;
                    case ConsoleKey.D2:
                        DoDeposit();
                        break;
                    case ConsoleKey.D3:
                        DoWithdrawal();
                        break;
                    case ConsoleKey.D4:
                        DoTransfer();
                        break;
                    case ConsoleKey.D5:
                        DoDeleteAccount();
                        break;
                    case ConsoleKey.Q:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa operacja");
                        Console.WriteLine("Wcisnij dowolny klawisz...");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }


            Console.WriteLine("\nDo widzenia :)");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n\n Dostępne są operacje:");
            Console.WriteLine("1. Otwórz nowe konto");
            Console.WriteLine("2. Wpłać środki");
            Console.WriteLine("3. Wypłata środków");
            Console.WriteLine("4. Przelew");
            Console.WriteLine("5. Usuń konto");
            Console.WriteLine("Wybierz Q aby wyjść");
        }

        private static void DoCreateAccount()
        {
            Console.WriteLine("\nWprowadź imię: ");
            var name = Console.ReadLine();

            Console.WriteLine("Wprowadź nazwisko: ");
            var surname = Console.ReadLine();

            try
            {
                bank.CreateAccount(name, surname);
                var account = bank.GetAccount(name, surname);

                Console.WriteLine($"Konto zostało utworzone.\nTwój numer konta: {account.AccountNumber}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Tworzenie konta zakończone niepowodzeniem.");
            }

            Console.ReadKey();
        }

        private static void DoDeposit()
        {
            Console.WriteLine("\nPodaj numer konta: ");
            var accountNumber = Console.ReadLine();

            var account = bank.GetAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine("Konto nie zostało odnalezione");
                return;
            }

            Console.WriteLine("Podaj kwotę wpłaty");
            var deposit = Console.ReadLine();

            if (decimal.TryParse(deposit, out decimal depositParsed))
            {
                try
                {
                    bank.Deposit(accountNumber, depositParsed);

                    Console.WriteLine("Środki zostały wpłacone");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Wpłata środków na konto zakończona niepowodzeniem");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format kwoty.");
                Console.WriteLine("Wpłata środków na konto zakończona niepowodzeniem");
            }

            Console.ReadKey();
        }

        private static void DoWithdrawal()
        {
            Console.WriteLine("\nPodaj numer konta: ");
            var accountNumber = Console.ReadLine();

            var account = bank.GetAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine("Konto nie zostało odnalezione");
                return;
            }

            Console.WriteLine("Podaj kwotę wypłaty");
            var withdrawal = Console.ReadLine();

            if (decimal.TryParse(withdrawal, out decimal withdrawalParsed))
            {
                try
                {
                    bank.Withdrawal(accountNumber, withdrawalParsed);

                    Console.WriteLine("Środki zostały wypłacone");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Wypłata środków na konto zakończona niepowodzeniem");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format kwoty.");
                Console.WriteLine("Wypłata środków na konto zakończona niepowodzeniem");
            }

            Console.ReadKey();
        }

        private static void DoTransfer()
        {
            Console.WriteLine("\nPodaj źródłówy numer konta: ");
            var sourceAccountNumber = Console.ReadLine();

            var sourceAccount = bank.GetAccount(sourceAccountNumber);

            if (sourceAccount == null)
            {
                Console.WriteLine("Konto nie zostało odnalezione");
                return;
            }

            Console.WriteLine("\nPodaj docelowy numer konta: ");
            var destinationAccountNumber = Console.ReadLine();

            var destinationAccount = bank.GetAccount(destinationAccountNumber);

            if (destinationAccount == null)
            {
                Console.WriteLine("Konto nie zostało odnalezione");
                return;
            }

            Console.WriteLine("Podaj kwotę przelewu");
            var moneyToSend = Console.ReadLine();

            if (decimal.TryParse(moneyToSend, out decimal moneyToSendParsed))
            {
                try
                {
                    bank.Transfer(sourceAccountNumber, destinationAccountNumber, moneyToSendParsed);

                    Console.WriteLine("Przelew został wykonany");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Przelew zakończony niepowodzeniem");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format kwoty.");
                Console.WriteLine("Przelew zakończony niepowodzeniem");
            }

            Console.ReadKey();

        }

        private static void DoDeleteAccount()
        {
            Console.WriteLine("\nWprowadź imię: ");
            var name = Console.ReadLine();

            Console.WriteLine("Wprowadź nazwisko: ");
            var surname = Console.ReadLine();

            Console.WriteLine("\nWprowadź numer konta: ");
            var accountNumber = Console.ReadLine();

            try
            {
                bank.DeleteAccount(name, surname, accountNumber);

                Console.WriteLine("Konto zostało usunięte");
            }
            catch(AccountNotFoundException ex)
            {
                Console.WriteLine("Konto nie zostało odnalezione.");
                Console.WriteLine("Usuwanie konta zakończone niepowodzeniem.");
            }

            Console.ReadKey();
        }

        private static void Seed()
        {
            bank.CreateAccount("Gracjan", "Bryt");
            bank.CreateAccount("Jan", "Kowalski");
            bank.CreateAccount("Jan", "Nowak");

            bank.Accounts[0].Balance = 1000.00m;
            bank.Accounts[1].Balance = 700.00m;
            bank.Accounts[2].Balance = 3000.00m;
        }
    }
}

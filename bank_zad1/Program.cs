using System;
using System.Data;

namespace ProstyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                playWithAccount();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Coś poszło nie tak: {e.Message}");
                Console.ReadKey();
            }
        }

        static public void playWithAccount()
        {

            // Wywoływanie wszystkich operacji na koncie
            int choice = 0;
            while (choice != 1)
            {
                Console.WriteLine("Witaj w banku");
                Console.WriteLine("1. Utwórz nowe konto");
                Console.WriteLine("2. Wyjdź");


                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Podaj imie i nazwisko właściciela");
                            string owner_name = Console.ReadLine();
                            Console.WriteLine("Podaj stan konta");
                            string balance_input = Console.ReadLine();
                            int balance = int.Parse(balance_input);
                            BankAccount account_1 = new BankAccount(owner_name, balance);
                            int operation = 0;
                            Credit credit_1 = new Credit();
                            decimal wartosc_kredytu = 0;


                            while (operation != 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Wybierz opcje:");
                                Console.WriteLine("1. Informacje o koncie/kredycie.");
                                Console.WriteLine("2. Wpłać pieniądze.");
                                Console.WriteLine("3. Wypłać pieniądze");
                                Console.WriteLine("4. Historia transakcji");
                                Console.WriteLine("5. Weź kredyt");
                                Console.WriteLine("6. Spłać kredyt");
                                Console.WriteLine("7. Wyjdź");
                                if (int.TryParse(Console.ReadLine(), out operation))
                                {
                                    switch (operation)
                                    {
                                        case 1:
                                            operation = 0;
                                            account_1.DisplayInfo();
                                            Console.WriteLine($"Kwota kredytu wynosi: {wartosc_kredytu}");
                                            Console.WriteLine("Kliknij aby kontynuuować..");
                                            Console.ReadKey();
                                            break;
                                        case 2:
                                            Console.WriteLine("Jaka kwote chcesz wpłacić?");
                                            string deposit_input = Console.ReadLine();
                                            DateTime dep_time = DateTime.Now;
                                            int deposit_amount = int.Parse(deposit_input);
                                            account_1.MakeDeposit(deposit_amount, dep_time, "wpłata");
                                            break;
                                        case 3:
                                            Console.WriteLine("Jaka kwote chcesz wypłacić?");
                                            string withdraw_input = Console.ReadLine();
                                            DateTime wdraw_time = DateTime.Now;
                                            int withdraw_amount = int.Parse(withdraw_input);
                                            account_1.MakeWithdraw(withdraw_amount, wdraw_time, "wypłata");
                                            break;
                                        case 4:
                                            account_1.ListTransactionHistory();
                                            break;
                                        case 5:
                                            Console.WriteLine("Jaka kwote kredytu chcesz wziąć?");
                                            string how_much_credit = Console.ReadLine();
                                            int cred_amount = int.Parse(how_much_credit);

                                            wartosc_kredytu += cred_amount;
                                            credit_1.add_credit(wartosc_kredytu, cred_amount);
                                            break;
                                        case 6:
                                            Console.WriteLine("Jaka kwote kredytu chcesz spłacić?");
                                            string how_much_credit_repay = Console.ReadLine();
                                            int cred_amount_repay = int.Parse(how_much_credit_repay);

                                            if (cred_amount_repay > wartosc_kredytu)
                                            {
                                                wartosc_kredytu = 0;
                                            }
                                            else
                                            {
                                                wartosc_kredytu -= cred_amount_repay;

                                            }
                                            credit_1.repay_credit(wartosc_kredytu, cred_amount_repay);
                                            break;
                                        case 7:
                                            choice = 1;
                                            operation = 1;
                                            Console.WriteLine("Do zobaczenia wkrótce!");
                                            Console.ReadKey();
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }



                            // koniec programu
                            break;
                        case 2:
                            choice = 1;
                            break;
                        default:
                            break;
                    }
                }
            }

        }

    }
}
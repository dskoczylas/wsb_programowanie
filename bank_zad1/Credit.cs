using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class Credit
    {
        private decimal credit_amount = 0;
        public void add_credit(decimal credit_all ,decimal amount)
        {
            if ((credit_all + amount) > 1000)
            {
                Console.WriteLine("Nie możesz mieć więcej kredytu niż 1000zł!");
                Console.WriteLine("Kliknij aby kontynuuować..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Zaciągłeś kredyt o sumie: {amount}");
                Console.WriteLine($"Łączna kwota kredytu: {credit_all}");
                Console.WriteLine("Kliknij aby kontynuuować..");
                Console.ReadKey();
            }
        }
        public void repay_credit(decimal credit_all, decimal amount)
        {
                Console.WriteLine($"Spłaciłeś: {amount}");
                Console.WriteLine($"Łączna pozostała kwota kredytu: {credit_all}");
                Console.WriteLine("Kliknij aby kontynuuować..");
                Console.ReadKey();
            
        }

    }
}

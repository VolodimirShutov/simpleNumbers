using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            startProgram();
            Console.ReadLine();
        }

        static void startProgram()
        {
            //не знаю в чем подвох по сравнению с предыдущей задачей. Потому буду делать как вижу.
            List<int> simpleNumber = new FindSimpleNumbers().findSimpleNumbers(1000000);
            
            List<int> _simplePrimes =  new FindCircularPrimes().findCircularPrimes(simpleNumber);

            //ответ:
            Console.WriteLine(_simplePrimes.Count);
        }
    }
}

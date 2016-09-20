using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumbers
{
    class FindCircularPrimes
    {

        private List<int> _simpleNumbers;
        private List<int> _simplePrimes;

        public List<int> findCircularPrimes(List<int> simpleNumber)
        {
            _simpleNumbers = simpleNumber;

            lookingFor();

            return _simplePrimes;
        }

        private void lookingFor()
        {
            _simplePrimes = new List<int>();
            int counter = _simpleNumbers.Count;

            while (counter > 0)
            {
                int number = _simpleNumbers[0];

                checkNumber(number);

                counter = _simpleNumbers.Count;
            }
        }

        private void checkNumber(int number)
        {
            //разбиваем номер на цыфры
            String stringNumber = number.ToString();
            char[] charNumber = stringNumber.ToCharArray();

            bool isPrime = true;
            List<int> faunded = new List<int>();
            faunded.Add(number);
            _simpleNumbers.Remove(number);

            for (int i = 1; i < charNumber.Length; i++)
            {
                int counter = i;
                String newWord = "";
                for(int k = 0; k < charNumber.Length; k++)
                {
                    int position = i + k;
                    if (position >= charNumber.Length)
                        position -= charNumber.Length;
                    newWord += charNumber[position];
                }

                int newNumber = Int32.Parse(newWord);
                if (faunded.IndexOf(newNumber) == -1)
                {
                    if (_simpleNumbers.IndexOf(newNumber) == -1 )
                    {
                        isPrime = false;
                    }
                    else
                    {
                        faunded.Add(newNumber);
                        _simpleNumbers.Remove(newNumber);
                    }
                }
            }
            if(isPrime == true)
            {
                foreach (var item in faunded)
                    _simplePrimes.Add(item);
            }
        }

    }
}

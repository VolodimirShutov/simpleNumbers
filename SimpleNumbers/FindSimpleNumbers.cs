using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumbers
{
    class FindSimpleNumbers
    {
        private int _max;
        private List<int> NotChecked;
        private List<int> simpleNumber;


        public List<int> findSimpleNumbers(int max = 1000000)
        {
            _max = max;
            // создаю лист данных из не проверенных элементов. А так, как мы знаем, 
            //что 2 - создаем лист сразу из тех чисел, которые не делятся на 2.

            NotChecked = new List<int>();
            simpleNumber = new List<int>();
            addNewNumber(2);
            createStartList();
            serch();
            
            return simpleNumber;
        }

        private void serch()
        {
            while (NotChecked.Count != 0)
            {
                int nextNumber = NotChecked[0];
                addNewNumber(nextNumber);
                NotChecked.RemoveAt(0);
                int min = nextNumber * nextNumber;

                if (min < _max)
                {
                    checkNumber(nextNumber);
                }
                else
                {
                    allGood();
                }
            }
        }

        private void allGood()
        {
            foreach (int item in NotChecked)
            {
                addNewNumber(item);
            }
            NotChecked = new List<int>();
        }

        private void checkNumber(int nextNumber)
        {
            //проверять все числа меньше n*n нет смысла так как не простые числа таких размеров 
            //мы исключили предыдущими делителями. а значит:
            int min = nextNumber * nextNumber;

            List<int> newNotChecked = new List<int>();
            foreach (int item in NotChecked)
            {
                if (item >= min)
                {
                    int res = item % nextNumber;
                    if (res != 0 && item != nextNumber)
                    {
                        newNotChecked.Add(item);
                    }

                }
                else
                {
                    newNotChecked.Add(item);
                }

            }
            NotChecked = newNotChecked;
        }

        private void createStartList()
        {
            int number = 1;
            while (number < _max)
            {
                number += 2;
                NotChecked.Add(number);
            }
        }

        private void addNewNumber(int value)
        {
            simpleNumber.Add(value);
        }
        
    }
}

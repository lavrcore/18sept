using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _18sept
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    Calculator calc = new Calculator();
            //    Console.WriteLine("Enter the expression: ");
            //    string expression = Console.ReadLine();
            //    char sign = ' ';
            //    foreach(var item in expression)
            //    {
            //        if (item == '+' || item == '-' || item == '/' || item == '*' || item == '^'|| item == '№')
            //        {
            //            sign = item;
            //        }
            //    }

            //    try
            //    {
            //        string[] numbers = expression.Split(sign);
            //        DelegateCalc del = null;

            //        switch (sign)
            //        {
            //            case '+':
            //                del = calc.Add; // 1 способ
            //                //del = new DelegateCalc(calc.Add); // 2 способ
            //                break;
            //            case '-':
            //                del = calc.Sub;
            //                break;
            //            case '*':
            //                del = calc.Multy; break;
            //            case '/':
            //                del = calc.Divide; break;
            //            case '^':
            //                del = calc.Degree; break;
            //            case '№':
            //                del = calc.SquareRoot; break;

            //        }
            //        //del += calc.Sub;
            //        //del += calc.Add;
            //        int number1 = int.Parse(numbers[0]);
            //        //Conver.ToInt32()
            //        int number2 = int.Parse(numbers[1]);
            //        Console.WriteLine($"Result: {del(number1,number2)}");


            //    }


            //    catch(Exception)
            //    {
            //        throw;
            //    }
            //}


            //public delegate double DelegateCalc(double x, double y);
            //public class Calculator
            //{
            //    public double Add(double x, double y)
            //    {
            //        double result = x + y;
            //        return result;
            //    }
            //    public double Sub(double x, double y)
            //    {
            //        double result = x - y;
            //        return result;
            //    }
            //    public double Multy(double x, double y)
            //    {
            //        double result = x * y;
            //        return result;
            //    }
            //    public double Divide(double x, double y)
            //    {
            //        if(y != 0)
            //        {
            //            double result = x / y;
            //            return result;
            //        }
            //        throw new DivideByZeroException();
            //    }
            //    public double Degree(double x, double y)
            //    {
            //        return Math.Pow(x,y);
            //    }
            //    public double SquareRoot(double x, double y)
            //    {
            //        return Math.Pow(x,1/y);
        }

        public class Money
        {
            private int dollars;
            private int cents;

            public Money(int dollars, int cents)
            {
                this.dollars = dollars;
                this.cents = cents;
                Normalize();
            }
            private void Normalize()
            {
                if (cents >= 100)
                {
                    dollars += cents / 100;
                    cents = cents % 100;
                }
                else if(cents < 0)
                {
                    dollars -= (Math.Abs(cents) / 100 ) + 1;
                    cents = 100 - (Math.Abs(cents) % 100);
                }
            }
            public void SumDisplay()
            {
                Console.WriteLine($"Summa: {dollars} dollars {cents} cents");
            }
            public void SetValues(int dollars, int  cents)
            {
                this.dollars = dollars;
                this.cents = cents;
                Normalize();
            }
            public int GetTotalCents()
            {
                return dollars * 100 + cents;
            }
            public void Decrease(int amountDollars, int amountCents)
            {
                Money decreaseAmount = new Money(amountDollars, amountCents);
                int totalCentsAfterDecrease = this.GetTotalCents() - decreaseAmount.GetTotalCents();
                if (totalCentsAfterDecrease < 0)
                {
                    throw new InvalidOperationException("Сумма не может стать отрицательной.");
                }
                dollars = totalCentsAfterDecrease / 100;
                cents = totalCentsAfterDecrease % 100;
            }
            public class Product
            {
                public string Name { get; set; }
                public Money Price { get; set; }

                public Product(string name, Money price)
                {
                    Name = name;
                    Price = price;
                }
            
            public void DecreasePrice(int amountDollars, int amountCents)
                {
                    Price.Decrease(amountDollars, amountCents);
                }
                public void DisplayProduct()
                {
                    Console.WriteLine($"Товар: {Name}");
                    Price.SumDisplay();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            for (; ; )
            {
                Console.WriteLine("_____________________________________");
                Console.WriteLine("Choose: ");
                Console.WriteLine("1.\t Сложение двух многочленов");
                Console.WriteLine("2.\t Умножение двух многочленов");
                Console.WriteLine("3.\t Выход");
                Console.WriteLine("_____________________________________");
                choice = Console.ReadLine();
                PolyFunc PFunc = new PolyFunc();
                switch (choice)
                {
                    case "1":
                        Polynomial P1 = new Polynomial();
                        P1.Input();
                        Polynomial P2 = new Polynomial();
                        P2.Input();
                        Console.WriteLine("Результат сложения: ");
                        PFunc.Sum(P1, P2).Output();
                        P1.Clean();
                        P2.Clean();
                        break;
                    case "2":
                        Polynomial P3 = new Polynomial();
                        P3.Input();
                        Polynomial P4 = new Polynomial();
                        P4.Input();
                        Console.WriteLine("Результат умножения");
                        PFunc.Multyply(P3, P4).Output();
                        P3.Clean();
                        P4.Clean();
                        break;
                    case "3":
                        return;
                }
            }
        }

    }
}

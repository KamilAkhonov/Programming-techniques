using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab5
{
    class Polynomial
    {
        private NODE first;
        private NODE last;
        public void Add(NODE node)
        {
            if (this.first == null)
            {
                first = node;
            }
            else
            {
                this.last.Set_next(node);
            }
            last = node;
        }
        public void Input()
        {
            double Value;
            int Pow_x;
            int Pow_sin_x;
            int Pow_cos_x;
            Console.WriteLine("Введите число слагаемых: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Введите сначала коэффициент, степень при x, степень при sin(x) и при cos(x), соответсвенно: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine((i + 1) + "-ый член: ");
                Value = Convert.ToDouble(Console.ReadLine());
                Pow_x = Convert.ToInt32(Console.ReadLine());
                Pow_sin_x = Convert.ToInt32(Console.ReadLine());
                Pow_cos_x = Convert.ToInt32(Console.ReadLine());
                NODE node = new NODE(Value, Pow_x, Pow_sin_x, Pow_cos_x);
                this.Add(node);
                Console.WriteLine();
            }
        }
        public void Output()
        {
            NODE p = new NODE();
            p = this.first;
            bool f = false;
            Console.Write("P(x) = ");
            while (p != null)
            {
                if (p.Get_value() != 0)
                {
                    f = true;
                    Console.Write(p.Get_value());
                    if (p.Get_pow_x() == 1)
                    {
                        Console.Write("*x");
                    }
                    else if (p.Get_pow_x() == 0)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.Write("*x^" + p.Get_pow_x());
                    }
                    if (p.Get_pow_sin_x() == 1)
                    {
                        Console.Write("*sinx");
                    }
                    else if (p.Get_pow_sin_x() == 0)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.Write("*sinx^" + p.Get_pow_sin_x());
                    }
                    if (p.Get_pow_cos_x() == 1)
                    {
                        Console.Write("*cosx");
                    }
                    else if (p.Get_pow_cos_x() == 0)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.Write("*cosx^" + p.Get_pow_cos_x());
                    }
                }
                p = p.Get_next();
                if (p != null)
                {
                    Console.Write("+");
                }
            }
            if (!f)
            {
                Console.WriteLine("0");
            }
            Console.WriteLine("\n");
        }
        public void Delete_node(NODE node)
        {
            NODE prev;
            prev = first;
            while (prev.Get_next() != node)
            {
                prev = prev.Get_next();
            }
            if (node == this.first)
            {
                first = node.Get_next();
                node.Set_next(null);
            }
            else if (node == this.last)
            {
                last = prev;
                last.Set_next(null);
            }
            else
            {
                prev.Set_next(node.Get_next());
            }
        }
        public NODE Get_first()
        {
            return first;
        }
        public void Balance()
        {
            NODE n1 = this.Get_first();
            NODE n2;
            while (n1 != null)
            {
                n2 = n1.Get_next();
                while (n2 != null)
                {
                    if (n1.Get_pow_x() == n2.Get_pow_x() && n1.Get_pow_sin_x() == n2.Get_pow_sin_x()
                        && n1.Get_pow_cos_x() == n2.Get_pow_cos_x())
                    {
                        n1.Set_value(n1.Get_value() + n2.Get_value());
                        this.Delete_node(n2);
                    }
                    n2 = n2.Get_next();
                }
                n1 = n1.Get_next();
            }
        }
        public void Clean()
        {
            first = null;
            last = null;
        }
    }
}
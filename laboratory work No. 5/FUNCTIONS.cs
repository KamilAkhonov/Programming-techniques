using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab5
{
    class PolyFunc
    {
        public PolyFunc() { }
        public Polynomial Sum(Polynomial P1, Polynomial P2)
        {
            P1.Balance();
            P2.Balance();
            Polynomial Res = new Polynomial();
            NODE n1 = P1.Get_first();
            NODE n2;
            bool f;
            while (n1 != null)
            {
                n2 = P2.Get_first();
                f = false;
                while (n2 != null)
                {
                    if (n1.Get_pow_x() == n2.Get_pow_x() && n1.Get_pow_sin_x() == n2.Get_pow_sin_x()
                        && n1.Get_pow_cos_x() == n2.Get_pow_cos_x())
                    {
                        NODE n_new = new NODE((n1.Get_value() + n2.Get_value()), n1.Get_pow_x(), n1.Get_pow_sin_x(), n1.Get_pow_cos_x());
                        Res.Add(n_new);
                        f = true;
                        break;
                    }
                    n2 = n2.Get_next();
                }
                if (!f)
                {
                    NODE n_new = new NODE(n1.Get_value(), n1.Get_pow_x(), n1.Get_pow_sin_x(), n1.Get_pow_cos_x());
                    Res.Add(n_new);
                }
                n1 = n1.Get_next();
            }
            n2 = P2.Get_first();
            while (n2 != null)
            {
                n1 = P1.Get_first();
                f = false;
                while (n1 != null)
                {
                    if (n1.Get_pow_x() == n2.Get_pow_x() && n1.Get_pow_sin_x() == n2.Get_pow_sin_x()
                        && n1.Get_pow_cos_x() == n2.Get_pow_cos_x())
                    {
                        f = true;
                        break;
                    }
                    n1 = n1.Get_next();
                }
                if (!f)
                {
                    NODE n_new = new NODE(n2.Get_value(), n2.Get_pow_x(), n2.Get_pow_sin_x(), n2.Get_pow_cos_x());
                    Res.Add(n_new);
                }
                n2 = n2.Get_next();
            }
            return Res;
        }
        public Polynomial Multyply(Polynomial P1, Polynomial P2)
        {
            Polynomial Res = new Polynomial();
            NODE n1 = P1.Get_first();
            NODE n2;
            bool f;
            while (n1 != null)
            {
                n2 = P2.Get_first();
                f = false;
                while (n2 != null)
                {
                    NODE nNew = new NODE(n1.Get_value() * n2.Get_value(), n1.Get_pow_x() + n2.Get_pow_x(), n1.Get_pow_sin_x() + n2.Get_pow_sin_x(), n1.Get_pow_cos_x() + n2.Get_pow_cos_x());
                    Res.Add(nNew);
                    f = true;
                    n2 = n2.Get_next();
                }
                if (!f)
                {
                    NODE newNode = new NODE(n1.Get_value(), n1.Get_pow_x(), n1.Get_pow_sin_x(), n1.Get_pow_cos_x());
                    Res.Add(newNode);
                }
                n1 = n1.Get_next();
            }
            n2 = P2.Get_first();
            while (n2 != null)
            {
                n1 = P1.Get_first();
                f = false;
                while (n1 != null)
                {
                    f = true;
                    n1 = n1.Get_next();
                }
                if (!f)
                {
                    NODE newNode = new NODE(n2.Get_value(), n2.Get_pow_x(), n2.Get_pow_sin_x(), n2.Get_pow_cos_x());
                    Res.Add(newNode);
                }
                n2 = n2.Get_next();
            }
            Res.Balance();
            return Res;
        }
    }
}
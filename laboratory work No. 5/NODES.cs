using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab5
{
    class NODE
    {
        private double Value;
        private int Pow_x;
        private int Pow_sin_x;
        private int Pow_cos_x;
        private NODE next;
        public NODE() { }
        public NODE(double val, int px, int psinx, int pcosx)
        {
            Value = val;
            Pow_x = px;
            Pow_sin_x = psinx;
            Pow_cos_x = pcosx;
        }
        public double Get_value()
        {
            return Value;
        }
        public void Set_value(double val)
        {
            Value = val;
        }
        public int Get_pow_x()
        {
            return Pow_x;
        }
        public int Get_pow_cos_x()
        {
            return Pow_cos_x;
        }
        public int Get_pow_sin_x()
        {
            return Pow_sin_x;
        }
        public NODE Get_next()
        {
            return this.next;
        }
        public void Set_next(NODE node)
        {
            this.next = node;
        }
    }
}
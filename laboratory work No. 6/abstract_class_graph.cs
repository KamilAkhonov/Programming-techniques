using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw_tp_2
{
    class stack
    {
        private int[] S;
        public int S_length;

        public stack(int a)
        {
            S = new int[255];
            for (int i = 0; i < 255; i++)
            {
                S[i] = 0;
            }
            S_length = a;
        }

        public void Push(int elem)
        {
            if (S_length == 0)
            {
                S[0] = elem;
                S_length = 1;
            }
            else
            {
                S[S_length] = elem;
                S_length++;
            }
        }
        public int Pop()
        {
            int i = 0;
            if (S_length == 0)
            {
                return -1;
            }
            else
            {
                i = S[S_length - 1];
                S[S_length - 1] = 0;
                S_length--;
                return i;

            }
        }
        public int Get_this_position(int t)
        {
            return S[t];
        }
    }
    abstract class abstract_class_graph
    {
        private stack G;

        public abstract_class_graph()
        {
            G = new stack(0);
        }

        abstract public bool Search_vertex(int v, int j);

        abstract public bool Check_condition(int a, int b, stack P);

        public void Search_and_build_road(int n, int vn, int vk, int a, int b, ref int kolp, ref int[,] Rez_Matr)
        {
            int[] M = new int[100];
            int v, i, j, L, Pr, Prt, ks;
            L = 1;
            kolp = 0;
            ks = 0;
            G.Push(vn);
            M[vn] = 1;
            while (ks >= 0)
            {
                Pr = 0;
                v = G.Get_this_position(ks);
                for (j = L; j <= n; j++)
                {
                    if (Search_vertex(v, j))
                    {
                        if (j == vk)
                        {
                            Prt = 1;
                            G.Push(j);
                            if (Check_condition(a, b, G))
                                Prt = 0;
                            G.Pop();
                            if (Prt == 0)
                            {
                                for (i = 0; i <= ks; i++)
                                    Rez_Matr[kolp, i] = G.Get_this_position(i);
                                Rez_Matr[kolp, ks + 1] = vk;
                                kolp++;
                            }
                        }
                        else
                        {
                            if (M[j] == 0)
                            {
                                Pr = 1;
                                break;
                            }
                        }

                    }
                }
                if (Pr == 1)
                {
                    ks++;
                    G.S_length = ks;
                    G.Push(j);
                    L = 1;
                    M[j] = 1;
                }
                else
                {
                    L = v + 1;
                    M[v] = 0;
                    ks--;
                    G.Pop();
                }
            }

        }
    }
}

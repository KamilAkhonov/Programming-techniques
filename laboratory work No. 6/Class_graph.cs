using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw_tp_2
{
    class Class_graph : abstract_class_graph
    {
        private int[] List_adjacent_vertex;
        private int n;

        public int get_element(int i)
        {
            return List_adjacent_vertex[i];
        }
        public int get_length()
        {
            return n;
        }

        public void Input_graph(int a, int b)
        {
            if (n == 0)
            {
                List_adjacent_vertex[0] = a;
                List_adjacent_vertex[1] = b;
                n = 2;
            }
            else
            {
                List_adjacent_vertex[n] = a;
                List_adjacent_vertex[n + 1] = b;
                n += 2;
            }
        }
        public void Delete_vertex(int k)
        {
            int i = 0;
            int j = 0;
            while (j < n)
            {
                if (List_adjacent_vertex[j] == k || List_adjacent_vertex[j + 1] == k)
                {
                    i = j + 2;
                    while (i < n)
                    {
                        List_adjacent_vertex[i - 2] = List_adjacent_vertex[i];
                        List_adjacent_vertex[i - 1] = List_adjacent_vertex[i + 1];
                        i += 2;
                    }
                    List_adjacent_vertex[i - 2] = 0;
                    List_adjacent_vertex[i - 1] = 0;
                    n -= 2;
                }
                j += 2;
            }
        }
        public void Delete_edge(int a, int b)
        {
            int i = 0;
            int j = 0;
            while (j < n)
            {
                if ((List_adjacent_vertex[j] == a && List_adjacent_vertex[j + 1] == b) || (List_adjacent_vertex[j] == b && List_adjacent_vertex[j + 1] == a))
                {
                    i = j + 2;
                    while (i < n)
                    {
                        List_adjacent_vertex[i - 2] = List_adjacent_vertex[i];
                        List_adjacent_vertex[i - 1] = List_adjacent_vertex[i + 1];
                        i += 2;
                    }
                    List_adjacent_vertex[i - 2] = 0;
                    List_adjacent_vertex[i - 1] = 0;
                    n -= 2;
                }
                j += 2;
            }
        }
        public int Num_of_vertex()
        {
            int max = List_adjacent_vertex[0];
            int i = 1;
            while (i < n)
            {
                if (List_adjacent_vertex[i] >= max)
                {
                    max = List_adjacent_vertex[i];
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return max;
        }
        public Class_graph(int a)
        {
            List_adjacent_vertex = new int[100];
            n = a;
        }

        public override bool Check_condition(int a, int b, stack P)
        {
            bool flag = false;
            int i = 0;
            while ((i < P.S_length) && (!flag))
            {
                if ((P.Get_this_position(i) == a) && (P.Get_this_position(i + 1) == b))
                {
                    flag = true;
                }
                else
                {
                    i += 1;
                }
            }
            return flag;
        }
        public override bool Search_vertex(int v, int j)
        {
            int i = 0;
            bool flag = false;
            while ((!flag) && (i < n))
            {
                if ((List_adjacent_vertex[i] == v) && (List_adjacent_vertex[i + 1] == j) || (List_adjacent_vertex[i + 1] == v) && (List_adjacent_vertex[i] == j))
                {
                    flag = true;
                }
                else
                {
                    i += 2;
                }
            }
            return flag;
        }
    }
}

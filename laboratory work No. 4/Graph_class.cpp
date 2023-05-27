#include "Graph_class.h"
#include <iostream>
using namespace std;
void Array::init(int size)
{
    A_size = size;
    A = new int[size];
}

void Array::delete_arr()
{
    delete[] A;
    A_size = 0;
}

int& Array::operator[](int p)
{
    return A[p];
}

const int& Array::operator[](int p) const
{
    return A[p];
}


void Graph::change(int a, int b)
{
    Matr[a][b] = 1;
}



void Graph::allocate_memory(int m_size, int n_size)
{
    n = n_size;
    m = m_size;
    Matr = new Array[n_size];
    for (int i = 0; i < m_size; i++) 
    {
        Matr[i].init(n);
    }
}

Graph::Graph(int m_size, int n_size)
{
    allocate_memory(m_size, n_size);
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Matr[i][j] = 0;
        }
    }
}

Graph::~Graph()
{
    if (n != 0) 
    {
        for (int i = 0; i < n; i++) 
        {
            if (m != 0) 
            {
                Matr[i].delete_arr();
            }
        }
        delete[] Matr;
    }
    n = 0;
    m = 0;
}

void Graph::copy(const Graph& mat_t)
{
    allocate_memory(mat_t.m, mat_t.n);
    for (int i = 0; i < mat_t.m; i++) {
        for (int j = 0; j < mat_t.n; ++j) {
            Matr[i][j] = mat_t.Matr[i][j];
        }
    }
}

Array& Graph::operator[](int i)
{
    return Matr[i];
}

const Array& Graph::operator[](int i) const
{
    return Matr[i];
}

bool Graph::Solve_The_Task(int array_vertices[100], int t)
{
    const int num_vertices = m; //Число вершин графа
    int RezCycle[100][100];

    for (int i = 0; i < 100; i++)
    {
        for (int j = 0; j < 100; j++)
            RezCycle[i][j] = 0;
    }
    int RezLenCycle[100];
    for (int i = 0; i < 100; i++)
    {
        RezLenCycle[i] = 0;
    }
    for (int vn = 0; vn < num_vertices; vn++)
    {
        int v, i, j, L, Pr, Prt, ks;
        int RezMatr[100][100];
        int Matrix[100][100];
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                Matrix[i][j] = -1;
            }
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Matrix[i][j] = Matr[i][j];
            }
        }
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
                RezMatr[i][j] = -1;
        }
        int RezLen[100];          //Длины циклов
        for (int j = 0; j < 100; j++)
            RezLen[j] = 0;
        int kolp = 0;             //Число циклов
        int St[100];
        for (int j = 0; j < 100; j++)
            St[j] = 0;
        int M[100];
        L = 0;
        for (j = 0; j < n; j++)
            M[j] = 0;
        ks = 0;
        St[ks] = vn;
        M[vn] = 1;
        while (ks >= 0)
        {
            Pr = 0;
            v = St[ks];
            for (j = L; j < n; j++)
            {
                if (Matrix[v][j] == 1)
                {
                    //Matrix[v-1][j] = 0;
                    //Matrix[j][v-1] = 0;
                    if (j == vn)
                    {
                        Prt = -1;
                        for (i = 0; i <= ks; i++)
                        {
                            if (St[i] == t)
                            {
                                Prt = 1;
                            }
                        }
                        if (Prt < 0)
                        {
                            for (i = 0; i <= ks; i++)
                                RezMatr[kolp][i] = St[i];
                            RezMatr[kolp][ks + 1] = vn;
                            RezLen[kolp] = ks + 1;
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
                St[ks] = j;
                L = 0;
                M[j] = 1;
            }
            else
            {
                L = v + 1;
                M[v] = 0;
                ks--;
            }
        }
        i = 0;
        int max = RezLen[i];
        int index_max = 0;
        while ((RezLen[i] != 0) and (i < 100))
        {
            if (max <= RezLen[i])
            {
                max = RezLen[i];
                index_max = i;
            }
            i++;
        }
        RezLenCycle[vn] = max;
        for (int i = 0; i < 100; i++)
        {
            RezCycle[vn][i] = RezMatr[index_max][i];
        }
    }
    int d = 0;
    int max = RezLenCycle[d];
    int index_max = 0;
    while ((RezLenCycle[d] != 0) and (d < 100))
    {
        if (max < RezLenCycle[d])
        {
            max = RezLenCycle[d];
            index_max = d;
        }
        d++;
    }
    for (int i = 0; i < 100; i++)
    {
        array_vertices[i] = RezCycle[index_max][i] + 1;
    }
    if (max < 3) {
        return false;
    }
    else
    {
        return true;
    }
}
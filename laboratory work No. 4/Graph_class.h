#pragma once
class Array {
public:
    void init(int size);                                                    //������������� �������
    void delete_arr();                                                      //����������� �������
    int& operator[](int p);                                                 //����������
    const int& operator[](int p) const;                                     //����������
private:
    int A_size;                                                             //������ �������
    int* A;                                                                 //������
};

class Graph {
public:
    void change(int a, int b);
    void allocate_memory(int m_size, int n_size);                           //�������-���� ������ ��� ��������� ������������ ������
    explicit Graph(int m_size = 0, int n_size = 0);                         //����������� ���������
    ~Graph();                                                               //����������
    void copy(const Graph& mat_t);                                          //����������� �����������
    Array& operator[](int i);                                               //����������
    const Array& operator[](int i) const;                                   //����������
    bool Solve_The_Task(int array_vertices[100], int t);                    //������� ������
private:
    int m, n;                                                               //������� �������
    Array* Matr;                                                            //������� ���������
};
#include <math.h>
#include "stdio.h"
#include <fstream>
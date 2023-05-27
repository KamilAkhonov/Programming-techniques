#pragma once
class Array {
public:
    void init(int size);                                                    //инициализация массива
    void delete_arr();                                                      //уничтожение массива
    int& operator[](int p);                                                 //индексация
    const int& operator[](int p) const;                                     //индексация
private:
    int A_size;                                                             //размер массива
    int* A;                                                                 //массив
};

class Graph {
public:
    void change(int a, int b);
    void allocate_memory(int m_size, int n_size);                           //функция-член класса для выделения динамической памяти
    explicit Graph(int m_size = 0, int n_size = 0);                         //конструктор умолчания
    ~Graph();                                                               //деструктор
    void copy(const Graph& mat_t);                                          //конструктор копирования
    Array& operator[](int i);                                               //индексация
    const Array& operator[](int i) const;                                   //индексация
    bool Solve_The_Task(int array_vertices[100], int t);                    //Решение задачи
private:
    int m, n;                                                               //индексы матрицы
    Array* Matr;                                                            //матрица смежности
};
#include <math.h>
#include "stdio.h"
#include <fstream>
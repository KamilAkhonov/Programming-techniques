using namespace std;
#include <iostream>
#include "Table.h"
using namespace std;
Table::Table(int a, int b) {
    int size = a * b;
    m = a;
    n = b;
    allocate_memory(size);
}

Table::~Table() {
    delete [] T;
    m = 0;
    n = 0;
}

Table::Table(const Table& tb) {
    m = tb.m;
    n= tb.n;
    allocate_memory(m*n);
    for (int i = 0; i < (m*n); ++i) {
        T[i] = tb.T[i];
    }
}

void Table::Delete_column(int a) {
    int j = 0;
    int k = a;
    for (int i = 0; i < m * n; ++i) {
        if (k == (i + 1)){
            k += n;
            continue;
        }
        T[j] = T[i];
        j += 1;
    }
    n = n - 1;
    realloc(T, m * n));//урезание памяти после удаления столбца
}


void Table::Print() {
    cout << endl;
    cout << "---TABLE---";
    cout << "   ";
    for (int i = 0; i < m * n; ++i) {
        if (i % n == 0) {
            cout << endl;
            cout << "   ";
        }
        cout << T[i] << " ";
    }
    cout << endl;
    cout << "---TABLE---"<<endl;
}


void Table::Input_Element(){
    char s;
    int x,y;
    cout << "Input index: ";
    cin >> x >> y;
    cout << "Input volume: ";
    cin >> s;
    T[((x-1)*n + y - 1)] = s;
}

void Table::Copy(Table tb)
{
    tb.m = m;
    tb.n = n;
    tb.allocate_memory(m * n);
    for (int i = 0; i < (m * n); ++i) {
        tb.T[i] = T[i];
    }
}

void Table::allocate_memory(int size) {
    T = new char [size];
    for (int i = 0; i < size; ++i) {
        T[i] = '_';
    }
}

void Table::Delete_string(int a) {
    int j = 0;
    for (int i = 0; i < m*n; ++i) {
        if((((a - 1)*n + 1) <= (i+1)) && ((i + 1)<= ((a-1)*n + n))){
            continue;
        }
        T[j] = T[i];
        j += 1;
    }
    m = m - 1;
    realloc(T, m * n);//урезание памяти после удаления строки
}

void Table::Add_column() {
    n = n + 1;
    int j = 0;
    int data;
    int size = 0;
    realloc(T, m * n);//выделение памяти под новый столбец
    for (int i = m * (n - 1); i < m * n; ++i) {
        T[i] = '_';
    }
    for (int i = 0; i < m * n; i++) {
        if (((i+1) % n) == 0){
            data = T[i];
            T[j] = '_';
            for (int k = m * (n-1) + size; k > i+1; --k) {
                T[k] = T[k - 1];
            }
            size++;
            T[j + 1] = data;
            j = j + 2;
            i = i + 1;
            continue;
        }
        T[j] = T[i];
        j++;
    }
}

void Table::Add_string() {
    m = m + 1;
    realloc(T, m * n);//выделение памяти под новую строку
    for (int i = (m - 1)*n; i < m*n; ++i) {
        T[i] = '_';
    }
}

void Table::Input_Table() {
    cout << "Input number column: ";
    cin >> n;
    cout << endl;
    cout << "Input number string: ";
    cin >> m;
    cout << endl;
    for (int i = 0; i < m * n; ++i) {
        cin >> T[i];
    }
}
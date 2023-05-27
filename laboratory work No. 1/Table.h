#pragma once
using namespace std;

class Table {
private:
    int m, n;//Количество строк и столбцов
    char* T;//таблица
public:
    void allocate_memory(int size);
    Table(int a = 0, int b = 0);//конструктор по умолчанию
    ~Table();//десктруктор
    Table(const Table& tb);//конструктор копирования
    void Delete_column(int a);
    void Delete_string(int a);
    void Add_column();
    void Add_string();
    void Print();
    void Input_Table();
    void Input_Element();
    void Copy(Table tb);
};
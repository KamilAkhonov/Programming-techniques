#pragma once
using namespace std;

class Table {
private:
    int m, n;//���������� ����� � ��������
    char* T;//�������
public:
    void allocate_memory(int size);
    Table(int a = 0, int b = 0);//����������� �� ���������
    ~Table();//�����������
    Table(const Table& tb);//����������� �����������
    void Delete_column(int a);
    void Delete_string(int a);
    void Add_column();
    void Add_string();
    void Print();
    void Input_Table();
    void Input_Element();
    void Copy(Table tb);
};
#include <iostream>
#include "Table.h"

using namespace std;
int main() {
    Table Tab;
    Table Buf;
    int a, n;
    cout << "---------Menu---------" << endl;
    cout << "1 - Input table" << endl;
    cout << "2 - Input/change element" << endl;
    cout << "3 - Delete column" << endl;
    cout << "4 - Delete string" << endl;
    cout << "5 - Add column" << endl;
    cout << "6 - Add string" << endl;
    cout << "7 - Copy table" << endl;
    cout << "8 - Show table" << endl;
    cout << "9 - Finish the programm" << endl;
    cout << "Select an action: " << endl;
    cin >> a;
    while (a != 9) {
        switch (a) {
        case 1:
            Tab.Input_Table();
            cout << "Select an action:" << endl;
            cin >> a;
            break;
        case 2:
            Tab.Input_Element();
            cout << "Select an action:" << endl;
            cin >> a;
            break;
        case 3:
            cout << "Enter the number column to delete: " << endl;
            cin >> n;
            Tab.Delete_column(n);
            cout << "Select an action:" << endl;
            cin >> a;
            break;
        case 4:
            cout << "Enter the number string to delete: " << endl;
            cin >> n;
            Tab.Delete_string(n);
            cout << "Select an action:" << endl;
            cin >> a;
            break;

        case 5:
            Tab.Add_column();
            cout << "Column added!" << endl;
            cout << "Select an action:" << endl;
            cin >> a;
            break;
        case 6:
            Tab.Add_string();
            cout << "String added!" << endl;
            cout << "Select an action:" << endl;
            cin >> a;
            break;
        case 7:
            Tab.Copy(Buf);
            cout << "Table is copied" << endl;
            cout << "Select an action:" << endl;
            cin >> a;
            break;
        case 8:
            Tab.Print();
            cout << "Select an action:" << endl;
            cin >> a;
            break;
        default:
            a = 9;
            break;
        }
    }
    cout << "Program finished =) ";
    return 1;
}
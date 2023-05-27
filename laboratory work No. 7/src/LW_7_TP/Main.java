package LW_7_TP;

import java.util.Scanner;

class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number_of_action;
        Rational_fraction A = new Rational_fraction();
        Rational_fraction B = new Rational_fraction();
        Rational_fraction C;
        for (; ; ) {
            System.out.println("1 - Ввести рациональные дроби");
            System.out.println("2 - Вывести рациональные дроби");
            System.out.println("3 - Вывести результат сложения дробей");
            System.out.println("4 - Вывести результат перемножения дробей");
            System.out.println("5 - Завершить программу");
            System.out.print("Выберите действие ---- ");
            number_of_action = scan.nextInt();
            switch (number_of_action) {
                case 1:
                    A.InputRationalFraction();
                    B.InputRationalFraction();
                    break;
                case 2:
                    A.PrintRationalFraction();
                    B.PrintRationalFraction();
                    break;
                case 3:
                    C = A.AdditionRationalFraction(B);
                    C.PrintRationalFraction();
                    break;
                case 4:
                    C = A.MultiplicationRationalFraction(B);
                    C.PrintRationalFraction();
                    break;
                case 5:
                    System.exit(1);
            }
        }
    }
}

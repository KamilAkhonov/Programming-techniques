package LW_7_TP;

import java.lang.System;
import java.util.Scanner;

public class Rational_fraction {
    Polynom numerator;
    Polynom denominator;

    public Rational_fraction() {
        numerator = new Polynom();
        denominator = new Polynom();
    }

    public void InputRationalFraction() {
        Scanner scan = new Scanner(System.in);
        System.out.println("-+-+-+Введем числитель+-+-+-");
        System.out.print("Введите число одночленнов: ");
        int num_of_members = scan.nextInt();
        System.out.print("Введите число перед одночленном, а потом его степень: ");
        for (int i = 0; i < num_of_members; i++) {
            int value = scan.nextInt();
            int degree = scan.nextInt();
            numerator.AddNode(value, degree);
        }
        System.out.println("-+-+-+Введем знаменатель+-+-+-");
        System.out.print("Введите число одночленнов: ");
        num_of_members = scan.nextInt();
        System.out.print("Введите число перед одночленном, а потом его степень: ");
        for (int i = 0; i < num_of_members; i++) {
            int value = scan.nextInt();
            int degree = scan.nextInt();
            denominator.AddNode(value, degree);
        }
        System.out.print("Вы успешно ввели рациональную дробь!");
    }

    public void PrintRationalFraction() {
        System.out.println();
        System.out.println("*************************************");
        if (numerator.IsEmptyPolynom()) {
            System.out.print("0");
            System.out.print("-------------------------------------");
            System.out.println();
            System.out.println("*************************************");
        } else if (denominator.IsEmptyPolynom()) {
            System.out.println("Знаменатель обратился в нуль =( ");
            System.out.print("-------------------------------------");
            System.out.println();
            System.out.println("*************************************");
        } else {
            numerator.WritePolynom();
            System.out.println();
            System.out.print("-------------------------------------");
            System.out.println();
            denominator.WritePolynom();
            System.out.println();
            System.out.println("*************************************");
            System.out.println("Вы успешно напечатали рациональную дробь!");
        }

    }

    public Rational_fraction MultiplicationRationalFraction(Rational_fraction S) {
        Rational_fraction result = new Rational_fraction();
        this.denominator = this.denominator.SimplificationPolynom();
        this.numerator = this.numerator.SimplificationPolynom();
        S.denominator = S.denominator.SimplificationPolynom();
        S.numerator = S.numerator.SimplificationPolynom();
        result.numerator = this.numerator.MultiplicationPolynom(S.numerator).SimplificationPolynom();
        result.denominator = this.denominator.MultiplicationPolynom(S.denominator).SimplificationPolynom();
        return result;
    }

    public Rational_fraction AdditionRationalFraction(Rational_fraction S) {
        Rational_fraction result = new Rational_fraction();
        this.denominator = this.denominator.SimplificationPolynom();
        this.numerator = this.numerator.SimplificationPolynom();
        S.denominator = S.denominator.SimplificationPolynom();
        S.numerator = S.numerator.SimplificationPolynom();
        result.numerator = this.numerator.MultiplicationPolynom(S.denominator).
                SimplificationPolynom().AdditionPolynom(S.numerator.MultiplicationPolynom(this.denominator).
                        SimplificationPolynom()).SimplificationPolynom();
        result.denominator = this.denominator.MultiplicationPolynom(S.denominator).SimplificationPolynom();
        return result;
    }
}

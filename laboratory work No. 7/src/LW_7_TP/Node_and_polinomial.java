package LW_7_TP;

import java.lang.System;

//Узел полинома
class Node {
    //значение коэффициента перед узлом
    int value;
    //степень узла
    int degree;
    //"указатель" на следующий узел
    Node next;
    //"указатель" на предыдущий узел
    Node prev;
}

class Polynom {
    Node first;
    Node last;

    public Polynom() {
        first = null;
        last = null;
    }

    public void AddNode(int v, int d) {
        Node p = new Node();
        if (first == null) {
            p.degree = d;
            p.value = v;
            p.prev = null;
            p.next = null;
            first = last = p;
        } else {
            p.value = v;
            p.degree = d;
            p.prev = last;
            p.next = null;
            last.next = p;
            last = p;
        }
    }

    public void WritePolynom() {
        if (first == null) {
            System.out.println("0");
        } else {
            Node p = first;
            while (p != null) {
                if (p != first) {
                    if (p.value > 0) {
                        System.out.print("+");
                    }

                }
                if (p.degree == 0) {
                    System.out.print(p.value);
                } else if (p.degree == 1) {
                    System.out.print(p.value);
                    System.out.print("x");
                } else {
                    System.out.print(p.value);
                    System.out.print("x^(");
                    System.out.print(p.degree);
                    System.out.print(")");
                }
                p = p.next;
            }
        }
    }

    public Polynom MultiplicationPolynom(Polynom S) {
        Polynom result = new Polynom();
        Node p = first;
        Node p_s;
        int sum_value;
        int sum_degree;
        while (p != null) {
            p_s = S.first;
            while (p_s != null) {
                sum_value = p.value * p_s.value;
                sum_degree = p.degree + p_s.degree;
                result.AddNode(sum_value, sum_degree);
                p_s = p_s.next;
            }
            p = p.next;
        }
        return result;
    }

    public void DeleteNode(Node p) {
        Node iteration_p = first;
        Node p_s;
        boolean flag = true;
        if (iteration_p == last) {
            first = null;
            last = null;
        } else {
            while (iteration_p != null && flag) {
                if (p == iteration_p) {
                    if (p == first) {
                        p_s = p.next;
                        p_s.prev = null;
                        first = p_s;
                        flag = false;
                    } else if (p == last) {
                        p_s = p.prev;
                        p_s.next = null;
                        last = p_s;
                        flag = false;
                    } else {
                        p_s = p.next;
                        p_s.prev = p.prev;
                        p.prev.next = p_s;
                        flag = false;
                    }
                }
                iteration_p = iteration_p.next;
            }
        }
    }
    public boolean IsEmptyPolynom(){
        return this.first == null;
    }

    public Polynom SimplificationPolynom() {
        Polynom result = new Polynom();
        Node p = first;
        Node var_p;
        Node var_p_2;
        int sum;
        int current_degree;
        while (p != null) {
            current_degree = p.degree;
            sum = p.value;
            var_p = p.next;
            while (var_p != null) {
                if (current_degree == var_p.degree) {
                    sum += var_p.value;
                    var_p_2 = var_p.next;
                    this.DeleteNode(var_p);
                    var_p = var_p_2;
                } else
                    var_p = var_p.next;
            }
            if (sum != 0) {
                result.AddNode(sum, current_degree);
            }
            p = p.next;
        }
        return result;
    }

    public Polynom AdditionPolynom(Polynom S) {
        Polynom result = new Polynom();
        Node p = first;
        Node p_s;
        Node p_s_2;
        int sum;
        while (p != null) {
            sum = p.value;
            p_s = S.first;
            while (p_s != null) {
                if (p.degree == p_s.degree) {
                    sum += p_s.value;
                    p_s_2 = p_s.next;
                    S.DeleteNode(p_s);
                    p_s = p_s_2;
                } else
                    p_s = p_s.next;
            }
            if (sum != 0)
                result.AddNode(sum, p.degree);
            p = p.next;
        }
        p = S.first;
        while (p != null) {
            result.AddNode(p.value, p.degree);
            p = p.next;
        }
        return result;
    }
}
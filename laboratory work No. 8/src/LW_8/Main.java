package LW_8;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;


class Parametr {
    int t;
    boolean flagOk;
}

class Graf {
    int[][] Rez = new int[2550][2550];
    int kol = 0;
    int[][] M = new int[1000][1000];
    int[] L = new int[1000];
    Graph F = new Graph();
}

class Num_of_cycle {
    int numer;
    boolean flagOk;
}

class SolveDialog extends Dialog {
    JTextField tf3;
    List lst;

    SolveDialog(Graf g, Num_of_cycle par, Frame parent, String title) {
        super(parent, title, true);
        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent we) {
                dispose();
                setVisible(false);
            }
        });
        StringBuilder way_in_cycle;
        int i, j;
        setLayout(new FlowLayout());
        setSize(800, 400);
        lst = new List(10);
        if (g.F.size_g != 0) {
            for (i = 0; i < g.F.size_g; i++) {
                way_in_cycle = new StringBuilder(i + 1 + ")");
                j = 0;
                while (g.Rez[i][j] != 0) {
                    way_in_cycle.append(g.Rez[i][j]).append("->");
                    j++;
                }
                lst.add(way_in_cycle.toString());
            }
        } else {
            lst.add("Нет циклов");
        }

        JButton btOk, btCancel;
        JLabel lbT, lbS;
        lbT = new JLabel("№ = ");
        lbS = new JLabel("Выбрать цикл под номером ");
        tf3 = new JTextField(5);
        btOk = new JButton("ОК");
        btCancel = new JButton("Отмена");
        add(lbS);
        add(lbT);
        add(tf3);
        add(btOk);
        add(btCancel);
        add(lst);
        btOk.addActionListener(new OkListener(par, this));
        btCancel.addActionListener(new CancelListener(par));
    }

    class OkListener implements ActionListener {
        Num_of_cycle param;
        SolveDialog pd;

        OkListener(Num_of_cycle par, SolveDialog pard) {
            param = par;
            pd = pard;
        }

        public void actionPerformed(ActionEvent ae)
                throws NumberFormatException {
            int x;
            x = Integer.parseInt(tf3.getText());
            param.numer = x;
            param.flagOk = true;
            pd.dispose();
            pd.setVisible(false);
        }
    }

    class CancelListener implements ActionListener {
        Num_of_cycle param;

        CancelListener(Num_of_cycle par) {
            param = par;
        }

        public void actionPerformed(ActionEvent ae) {
            param.flagOk = false;
            dispose();
            setVisible(false);
        }
    }
}

class ParamDialog extends Dialog {
    JTextField tfT;

    ParamDialog(Parametr par, Frame parent, String title) {
        super(parent, title, true);
        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent we) {
                dispose();
                setVisible(false);
            }
        });
        setLayout(new FlowLayout());
        setSize(800, 100);
        JButton btOk, btCancel;
        JLabel lbT, lbS;
        lbT = new JLabel("t=");
        lbS = new JLabel("Найти все самые длинные циклы в графе, не прохо\n" +
                "дящие через заданную вершину");
        tfT = new JTextField(5);
        btOk = new JButton("Найти");
        btCancel = new JButton("Отмена");
        add(lbS);
        add(lbT);
        add(tfT);
        add(btOk);
        add(btCancel);
        btOk.addActionListener(new OkListener(par, this));
        btCancel.addActionListener(new CancelListener(par));
    }

    class OkListener implements ActionListener {
        Parametr param;
        ParamDialog pd;

        OkListener(Parametr par, ParamDialog pard) {
            param = par;
            pd = pard;

        }

        public void actionPerformed(ActionEvent ae)
                throws NumberFormatException {
            int x;
            x = Integer.parseInt(tfT.getText());
            param.t = x;
            param.flagOk = true;
            pd.dispose();
            pd.setVisible(false);
        }
    }

    class CancelListener implements ActionListener {
        Parametr param;

        CancelListener(Parametr par) {
            param = par;
        }

        public void actionPerformed(ActionEvent ae) {
            param.flagOk = false;
            dispose();
            setVisible(false);
        }
    }
}

// Класс главного окна приложения
class DialogDemo extends Frame {
    Graf G;
    Parametr t_task;
    Num_of_cycle Nofc;
    int[] y_vert = new int[1000];
    int[] x_vert = new int[1000];
    int num_vert = 0;
    int i = 1;

    DialogDemo(String title) {
        super(title);
        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent we) {
                System.exit(0);
            }
        });
        t_task = new Parametr();
        Nofc = new Num_of_cycle();
        G = new Graf();

        MenuBar mb = new MenuBar();
        setMenuBar(mb);
        Menu draw = new Menu("Работа");
        Menu solve = new Menu("Решение");
        MenuItem draw_cycle = new MenuItem("Выбрать цикл");
        solve.add(draw_cycle);
        MenuItem drawCycle = new MenuItem("Изобразить цикл");
        solve.add(drawCycle);
        mb.add(solve);
        MenuItem parr = new MenuItem("Заданная вершина");
        draw.add(parr);
        MenuItem Cl = new MenuItem("Очистить");
        draw.add(Cl);
        MenuItem Mark_vert = new MenuItem("Отметить вершины");
        draw.add(Mark_vert);
        MenuItem Mark_edge = new MenuItem("Отметить ребра");
        draw.add(Mark_edge);
        mb.add(draw);

        drawCycle.addActionListener(new Dcycle());
        draw_cycle.addActionListener(new DrawCcl(this));
        Cl.addActionListener(new Clean());
        Mark_vert.addActionListener(new markVert());
        Mark_edge.addActionListener(new MarkEdge());
        parr.addActionListener(new HandParr(this));
    }

    class Dcycle implements ActionListener {
        int start, finish, j, k, n;
        boolean flag = true;

        public void actionPerformed(ActionEvent ae) {
            System.out.println(Nofc.numer);
            Graphics g = getGraphics();

            for (k = 0; k < num_vert; k++) {
                for (n = 0; n < num_vert; n++) {
                    if (G.F.G[k][n] == 1) {
                        j = 0;
                        flag = true;
                        while (G.Rez[Nofc.numer - 1][j + 1] != 0 && flag) {
                            if (k == G.Rez[Nofc.numer - 1][j] && n == G.Rez[Nofc.numer - 1][j + 1] || n == G.Rez[Nofc.numer - 1][j] && j == G.Rez[Nofc.numer - 1][j + 1]) {
                                flag = false;
                            }
                            j++;
                        }
                        if (flag) {
                            g.setColor(new Color(255, 3, 230));
                            g.drawLine(x_vert[k], y_vert[k], x_vert[n], y_vert[n]);
                        }
                    }

                }
            }
            j = 0;
            g.setColor(new Color(0, 0, 0));
            while (G.Rez[Nofc.numer - 1][j + 1] != 0) {
                start = G.Rez[Nofc.numer - 1][j] - 1;
                finish = G.Rez[Nofc.numer - 1][j + 1] - 1;
                g.drawLine(x_vert[start], y_vert[start], x_vert[finish], y_vert[finish]);
                j++;
            }
            g.setColor(new Color(234, 255, 0));
            g.fillOval(x_vert[t_task.t - 1] - 15, y_vert[t_task.t - 1] - 15, 30, 30);
            g.setColor(new Color(50, 100, 131));
            String S = Integer.toString(t_task.t);
            g.drawString(S, x_vert[t_task.t - 1] - 15, y_vert[t_task.t - 1] + 20);
        }
    }

    class markVert implements ActionListener {
        int x, y;

        public void actionPerformed(ActionEvent ae) {
            addMouseListener(new MouseAdapter() {
                public void mouseClicked(MouseEvent me) {
                    x = me.getX();
                    y = me.getY();
                    y_vert[i - 1] = y;
                    x_vert[i - 1] = x;
                    num_vert++;
                    String S = Integer.toString(i);
                    i++;
                    Graphics g = getGraphics();
                    g.setColor(new Color(100, 200, 0));
                    g.fillOval(x - 15, y - 15, 30, 30);
                    g.setColor(new Color(50, 100, 131));
                    g.drawString(S, x - 15, y + 20);
                    G.F.Add_vertex(num_vert);
                    System.out.println(i);
                }
            });
        }
    }

    class Clean implements ActionListener {
        public void actionPerformed(ActionEvent ae) {
            t_task = new Parametr();
            Nofc = new Num_of_cycle();
            G = new Graf();
            y_vert = new int[1000];
            x_vert = new int[1000];
            num_vert = 0;
            i = 1;
            repaint();
        }
    }

    class MarkEdge implements ActionListener {
        int x_s, y_s, b_1, b_2, x_f, y_f;
        boolean flag_1, flag_2;

        public void actionPerformed(ActionEvent ae) {
            addMouseListener(new MouseAdapter() {
                public void mousePressed(MouseEvent me) {
                    flag_1 = false;
                    b_1 = 0;
                    x_s = me.getX();
                    y_s = me.getY();
                    while (!flag_1 && b_1 < num_vert) {
                        if (Math.pow(x_s - x_vert[b_1], 2) + Math.pow(y_s - y_vert[b_1], 2) <= 900) {
                            flag_1 = true;
                        } else
                            b_1++;
                    }
                }

                public void mouseReleased(MouseEvent me) {
                    flag_2 = false;
                    b_2 = 0;
                    x_f = me.getX();
                    y_f = me.getY();
                    while (!flag_2 && b_2 < num_vert) {
                        if (Math.pow(x_f - x_vert[b_2], 2) + Math.pow(y_f - y_vert[b_2], 2) <= 900) {
                            flag_2 = true;
                        } else
                            b_2++;
                    }
                    if (flag_1 && flag_2) {
                        Graphics g = getGraphics();
                        g.setColor(new Color(255, 3, 230));
                        g.drawLine(x_vert[b_1], y_vert[b_1], x_vert[b_2], y_vert[b_2]);
                        G.F.Add_edge(b_1 + 1, b_2 + 1);
                        System.out.println(G.F.G[b_1][b_2]);
                        System.out.println(G.F.G[b_2][b_1]);
                    }
                }

            });
        }
    }

    class HandParr implements ActionListener {
        DialogDemo mainfr;

        HandParr(DialogDemo mf) {
            mainfr = mf;
        }

        public void actionPerformed(ActionEvent ae) {
            ParamDialog d = new
                    ParamDialog(t_task, mainfr, "Условие для задачи");
            d.setVisible(true);
        }

    }

    class DrawCcl implements ActionListener {
        DialogDemo mainfr;

        DrawCcl(DialogDemo mf) {
            mainfr = mf;
        }

        public void actionPerformed(ActionEvent ae) {
            G.Rez = G.F.Search_max_cycles(num_vert, t_task.t - 1, G.kol, G.M, G.L);
            SolveDialog d = new
                    SolveDialog(G, Nofc, mainfr, "Изобразить путь");
            d.setVisible(true);
        }

    }

    public static void main(String[] args) {
        DialogDemo f = new DialogDemo("Поиск максимальных циклов в графе");
        f.setSize(1000, 800);
        f.setVisible(true);
        System.out.println("Абобус");
    }
}
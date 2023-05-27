package LW_8;

public class Graph {
    int[][] G;
    int Num_vertex;
    int size_g;
    public Graph() {
        G = new int[2550][2550];
        for (int i = 0; i < 2550; i++) {
            for (int j = 0; j < 2550; j++) {
                G[i][j] = 0;
            }
        }
        Num_vertex = 0;
    }

    public void Add_vertex(int vert) {
        Num_vertex = vert;
    }

    public void Add_edge(int a, int b) {
        G[a - 1][b - 1] = G[b - 1][a - 1] = 1;
    }

    public int[][] Search_max_cycles(int n, int t, int kolp, int[][] RezMatr, int[] Rezlen) {
        for (int d = 0; d < n; d++) {
            Stack St = new Stack(0);
            int[] M = new int[1000];
            int v, i, j, L, Pr, Prt, ks, vk, vn;
            vn = d;
            vk = vn;
            L = 0;
            for (j = 0; j < n; j++) {
                M[j] = 0;
            }
            ks = 0;
            St.Push(vn);
            M[vn] = 1;
            while (ks >= 0) {
                Pr = 0;
                v = St.Elem(ks);
                for (j = L; j < n; j++) {
                    if (G[v][j] == 1) {
                        if (j == vk) {
                            Prt = 0;
                            for (i = 0; i <= ks; i++) {
                                if (St.Elem(i) == t)
                                    Prt = 1;
                            }
                            if (Prt == 0) {
                                for (i = 0; i <= ks; i++) {
                                    RezMatr[kolp][i] = St.Elem(i) + 1;
                                    System.out.println("Тут");
                                }
                                RezMatr[kolp][ks + 1] = vk + 1;
                                Rezlen[kolp] = ks + 2;
                                kolp++;
                            }
                        } else {
                            if (M[j] == 0) {
                                Pr = 1;
                                break;
                            }
                        }
                    }
                }
                if (Pr == 1) {
                    ks++;
                    St.SM_length = ks;
                    St.Push(j);
                    L = 0;
                    M[j] = 1;
                } else {
                    L = v + 1;
                    M[v] = 0;
                    ks--;
                    St.Pop();
                }
            }
        }
        int max_length_cycle = 4;
        for (int l = 0; l < kolp; l++) {
            if (max_length_cycle < Rezlen[l]) {
                max_length_cycle = Rezlen[l];
            }
        }
        int[][] Rez = new int[2550][2550];
        int h = 0;
        for (int l = 0; l < kolp; l++) {
            if (max_length_cycle == Rezlen[l] && !Check_result(Rez,RezMatr[l],max_length_cycle,h)) {
                Rez[h] = RezMatr[l];
                h++;
            }
        }
        size_g = h;
        return Rez;
    }

    public boolean Check_result(int[][] M, int[] V, int max, int size_M) {
        if(size_M == 0)
            return false;
        else {
            int i = 0;
            int j;
            int k;
            int rez;
            boolean flag = true;
            boolean flag_1;
            while (i < size_M && flag) {
                j = 0;
                rez = 1;
                while (j < max && flag) {
                    k = 0;
                    flag_1 = true;
                    while (k < max && flag_1) {
                        if (M[i][j] == V[k]) {
                            rez++;
                            flag_1 = false;
                        }
                        k++;
                    }
                    if (rez == max+1)
                        flag = false;
                    j++;
                }
                i++;
            }
            return !flag;
        }
    }
}

from math import inf


# класс граф
class Graph_lab(object):
    def __init__(self):  # инициализация графа
        self.A = []
        self.size = 0

    def Input(self, f):  # ввод графа из файла f
        self.A = [list(map(int, row.split())) for row in f.readlines()]
        self.size = len(self.A)

    def Find_loop(self):  # поиск цикла проходящего через не более 2 вершины центра графа
        M = [0] * self.size
        for i in range(self.size):
            M[i] = [0] * self.size
        for i in range(self.size):
            for j in range(self.size):
                if self.A[i][j] == 0:
                    M[i][j] = inf
                else:
                    M[i][j] = self.A[i][j]
        RezMatr = [-1] * 100
        for i in range(100):
            RezMatr[i] = [-1] * 100
        RezLen = [-1] * 100
        St = [-1] * 100
        s = list(self.Find_center())
        vk = s[0]
        vn = s[0]
        s.remove(s[0])
        center = set(s)
        L = 0
        kolp = 0
        W = [0] * 100
        ks = 0
        St[ks] = vn
        W[vn] = 1
        while ks >= 0:
            Pr = 0
            v = St[ks]
            for j in range(L, self.size):
                if M[v][j] == 1:
                    M[v][j] = 0
                    M[j][v] = 0
                    if j == vk:
                        Prt = -1
                        for i in range(ks + 1):
                            if St[i] in center:
                                Prt += 1
                        if Prt <= 0:
                            for i in range(ks + 1):
                                RezMatr[kolp][i] = St[i]
                            RezMatr[kolp][ks + 1] = vk
                            RezLen[kolp] = ks + 2
                            kolp += 1
                    else:
                        if W[j] == 0:
                            Pr = 1
                            break
            if Pr == 1:
                ks += 1
                St[ks] = j
                L = 0
                W[j] = 1
            else:
                L = v + 1
                W[v] = 0
                ks -= 1
        rez = set()
        for i in range(len(RezMatr[0])):
            if (RezMatr[0][i] != -1) and (RezMatr[0][i + 1] != -1):
                rez.add((RezMatr[0][i], RezMatr[0][i + 1]))
                rez.add((RezMatr[0][i + 1], RezMatr[0][i]))
        return rez

    def Find_center(self):  # поиск центра графа
        M = [0] * self.size
        for i in range(self.size):
            M[i] = [0] * self.size
        for i in range(self.size):
            for j in range(self.size):
                if self.A[i][j] == 0:
                    M[i][j] = inf
                else:
                    M[i][j] = self.A[i][j]
        e = [0] * self.size
        s = []
        rad = inf
        for i in range(self.size):
            for j in range(self.size):
                for k in range(self.size):
                    M[i][j] = min(M[i][j], M[i][k] + M[k][j])
        for i in range(self.size):
            for j in range(self.size):
                e[i] = max(e[i], M[i][j])
        for i in range(self.size):
            rad = min(rad, e[i])
        for i in range(self.size):
            if e[i] == rad:
                s.append(i)
        rer = set(s)
        return rer

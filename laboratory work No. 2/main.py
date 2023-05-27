import graph_class
import networkx as nx
import matplotlib.pyplot as plt


# создание области для изображений графов
plt.figure(figsize=(30, 30))

# создание и ввод графа G
G = graph_class.Graph_lab()
f = open('InputFile')
G.Input(f)
f.close()


# создание графического графа
D = nx.Graph()
for i in range(len(G.A)):
    D.add_node(i)
for i in range(len(G.A)):
    for j in range(len(G.A)):
        if G.A[i][j]:
            D.add_edge(i, j)


# изображаем начальный граф
plt.subplot(211)
plt.subplot(211).set_title('Исходный граф')
nx.draw_circular(D, node_color="lawngreen", with_labels=True,
                 node_size=400, edge_color="deepskyblue")


# поиск центра графа и цикла в нем
center = G.Find_center()
loop = G.Find_loop()


# проверка существования цикла
if len(loop) < 3:
    print("Такого цикла не обнаружилось =(")
    exit()
else:
    # изображение графа с циклом
    node_colors = ["navy" if n in center else "lawngreen" for n in D.nodes()]
    edge_colors = ["navy" if e in loop else "deepskyblue" for e in D.edges()]
    plt.subplot(212)
    plt.subplot(212).set_title('Граф с циклом')
    nx.draw_circular(D, node_color=node_colors, with_labels=True,
                     node_size=400, edge_color=edge_colors)


# показ изображенных графов
plt.show()


print("Конец! Все завершилось успешно!")
package LW_8;

public class Stack {
    int[] SM;
    public int SM_length;

    public Stack(int a) {
        SM = new int[2550];
        for (int i = 0; i < 2550; i++) {
            SM[i] = 0;
        }
        SM_length = a;
    }

    public void Push(int elem) {
        if (SM_length == 0) {
            SM[0] = elem;
            SM_length = 1;
        } else {
            SM[SM_length] = elem;
            SM_length++;
        }
    }

    public int Pop() {
        int i;
        if (SM_length == 0) {
            return -1;
        } else {
            i = SM[SM_length - 1];
            SM[SM_length - 1] = 0;
            SM_length--;
            return i;
        }
    }

    public int Elem(int i){
        return SM[i];
    }
}

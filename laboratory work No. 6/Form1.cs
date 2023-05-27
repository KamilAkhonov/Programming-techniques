using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lw_tp_2
{
    public partial class Form1 : Form
    {
        int a, b, x, y;

        Class_graph F = new Class_graph(0);
        int[] delete_v = new int[100];
        int dv_length = 0;
        int[,] Rez_matr = new int[100, 100];

        public bool Check(int i)
        {
            bool flag = false;
            int j = 0;
            while(j < 100 && !flag)
            {
                if(delete_v[j] == i)
                {
                    flag = true;
                }
                else
                {
                    j++;
                }
            }
            return flag;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int length_lines, a, b;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\kamil\Documents\ТП\Lw_tp_2\graph.txt");
            length_lines = lines.Length;
            for (int i = 0; i < length_lines; i++)
            {
                a = Convert.ToInt32(lines[i]);
                b = a / 10;
                a = a % 10;
                F.Input_graph(b, a);
            }

            MessageBox.Show("Граф успешно загружен", "Сообщение");
        }
        private void Button2_Click(object sender, EventArgs e)
        {

            double phi;
            float[] graphix_x;
            float[] graphix_y;
            double x_i, y_i, Rad;
            Rad = 200;
            string i_name;
            int num_vertices;
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(246, 255, 143));
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            Pen myWind = new Pen(Color.Yellow, 2);
            num_vertices = F.Num_of_vertex();
            graphix_x = new float[num_vertices];
            graphix_y = new float[num_vertices];
            for (int i = 1; i <= num_vertices; i++)
            {
                phi = Math.PI * i * 2 / num_vertices;
                x_i = Rad * (1 / (Math.Sqrt(1 + Math.Pow(Math.Tan(phi), 2))));
                y_i = Math.Sqrt(Math.Pow(Rad, 2) - Math.Pow(x_i, 2));
                if ((phi > Math.PI / 2) && (phi <= Math.PI))
                {
                    x_i *= -1;
                }
                if ((phi > Math.PI) && (phi <= 1.5 * Math.PI))
                {
                    x_i *= -1;
                    y_i *= -1;
                }
                if ((phi > 1.5 * Math.PI) && (phi <= 2 * Math.PI))
                {
                    y_i *= -1;

                }
                graphix_x[i - 1] = (float)15 + (float)x_i + pictureBox1.Width / 2;
                graphix_y[i - 1] = (float)15 + (float)y_i + pictureBox1.Height / 2;

            }
            Pen p = new Pen(Color.Blue, 5);
            int j = 0;
            while (j < F.get_length())
            {
                g.DrawLine(p, graphix_x[F.get_element(j) - 1], graphix_y[F.get_element(j) - 1], graphix_x[F.get_element(j + 1) - 1], graphix_y[F.get_element(j + 1) - 1]);
                j += 2;
            }
            int l = 1;
            while (l <= num_vertices)
            {
                i_name = Convert.ToString(l);
                g.FillEllipse(myTrub, graphix_x[l - 1] - 15, graphix_y[l - 1] - 15, 30, 30);
                g.DrawString(i_name, new Font("Arial", 12), Brushes.Black, graphix_x[l - 1] - 7, graphix_y[l - 1] - 8);
                l++;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int num_vertex = F.Num_of_vertex();
            if (F.get_element(0) == 0)
            {
                F.Input_graph(1, 0);
            }
            else
            {
                F.Input_graph(num_vertex + 1, 0);
            }
            double phi;
            float[] graphix_x;
            float[] graphix_y;
            double x_i, y_i, Rad;
            Rad = 200;
            string i_name;
            int num_vertices;
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(246, 255, 143));
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            Pen myWind = new Pen(Color.Yellow, 2);
            num_vertices = F.Num_of_vertex();
            graphix_x = new float[num_vertices];
            graphix_y = new float[num_vertices];
            for (int i = 1; i <= num_vertices; i++)
            {
                phi = Math.PI * i * 2 / num_vertices;
                x_i = Rad * (1 / (Math.Sqrt(1 + Math.Pow(Math.Tan(phi), 2))));
                y_i = Math.Sqrt(Math.Pow(Rad, 2) - Math.Pow(x_i, 2));
                if ((phi > Math.PI / 2) && (phi <= Math.PI))
                {
                    x_i *= -1;
                }
                if ((phi > Math.PI) && (phi <= 1.5 * Math.PI))
                {
                    x_i *= -1;
                    y_i *= -1;
                }
                if ((phi > 1.5 * Math.PI) && (phi <= 2 * Math.PI))
                {
                    y_i *= -1;

                }
                graphix_x[i - 1] = (float)15 + (float)x_i + pictureBox1.Width / 2;
                graphix_y[i - 1] = (float)15 + (float)y_i + pictureBox1.Height / 2;

            }
            Pen p = new Pen(Color.Blue, 5);
            int j = 0;
            while (j < F.get_length())
            {
                if (F.get_element(j + 1) == 0)
                {
                    j += 2;
                }
                else
                {
                    g.DrawLine(p, graphix_x[F.get_element(j) - 1], graphix_y[F.get_element(j) - 1], graphix_x[F.get_element(j + 1) - 1], graphix_y[F.get_element(j + 1) - 1]);
                    j += 2;
                }

            }
            int l = 1;
            while (l <= num_vertices)
            {
                i_name = Convert.ToString(l);
                g.FillEllipse(myTrub, graphix_x[l - 1] - 15, graphix_y[l - 1] - 15, 30, 30);
                g.DrawString(i_name, new Font("Arial", 12), Brushes.Black, graphix_x[l - 1] - 7, graphix_y[l - 1] - 8);
                l++;
            }

        }
        public void button4_Click(object sender, EventArgs e)
        {
            int num_vertex = F.Num_of_vertex();
            int v_1, v_2;
            v_1 = Convert.ToInt32(textBox1.Text);
            v_2 = Convert.ToInt32(textBox2.Text);
            F.Input_graph(v_1, v_2);
            double phi;
            float[] graphix_x;
            float[] graphix_y;
            double x_i, y_i, Rad;
            Rad = 200;
            string i_name;
            int num_vertices;
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(246, 255, 143));
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            Pen myWind = new Pen(Color.Yellow, 2);
            num_vertices = F.Num_of_vertex();
            graphix_x = new float[num_vertices];
            graphix_y = new float[num_vertices];
            for (int i = 1; i <= num_vertices; i++)
            {
                phi = Math.PI * i * 2 / num_vertices;
                x_i = Rad * (1 / (Math.Sqrt(1 + Math.Pow(Math.Tan(phi), 2))));
                y_i = Math.Sqrt(Math.Pow(Rad, 2) - Math.Pow(x_i, 2));
                if ((phi > Math.PI / 2) && (phi <= Math.PI))
                {
                    x_i *= -1;
                }
                if ((phi > Math.PI) && (phi <= 1.5 * Math.PI))
                {
                    x_i *= -1;
                    y_i *= -1;
                }
                if ((phi > 1.5 * Math.PI) && (phi <= 2 * Math.PI))
                {
                    y_i *= -1;

                }
                graphix_x[i - 1] = (float)15 + (float)x_i + pictureBox1.Width / 2;
                graphix_y[i - 1] = (float)15 + (float)y_i + pictureBox1.Height / 2;

            }
            Pen p = new Pen(Color.Blue, 5);// цвет линии и ширина
            int j = 0;
            while (j < F.get_length())
            {
                if (F.get_element(j + 1) == 0)
                {
                    j += 2;
                }
                else
                {
                    g.DrawLine(p, graphix_x[F.get_element(j) - 1], graphix_y[F.get_element(j) - 1], graphix_x[F.get_element(j + 1) - 1], graphix_y[F.get_element(j + 1) - 1]);
                    j += 2;
                }
            }
            int l = 1;
            while (l <= num_vertices)
            {
                i_name = Convert.ToString(l);
                g.FillEllipse(myTrub, graphix_x[l - 1] - 15, graphix_y[l - 1] - 15, 30, 30);
                g.DrawString(i_name, new Font("Arial", 12), Brushes.Black, graphix_x[l - 1] - 7, graphix_y[l - 1] - 8);
                l++;
            }
            textBox1.Clear();
            textBox2.Clear();
        }
        public void button5_Click(object sender, EventArgs e)
        {
            int a, b, i, j;
            string[] lines = new string[F.get_length() / 2 + 5];
            string x, y;
            i = 0;
            j = 0;
            while (i < F.get_length())
            {
                a = F.get_element(i);
                b = F.get_element(i + 1);
                x = Convert.ToString(a);
                y = Convert.ToString(b);
                lines[j] = String.Concat(x, y);
                i += 2;
                j++;
            }
            System.IO.File.AppendAllLines(@"C:\Users\kamil\Documents\ТП\Lw_tp_2\saved_graph.txt", lines);
            MessageBox.Show("Граф успешно сохранен", "Сообщение");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public void button6_Click(object sender, EventArgs e)
        {
            int t;
            t = Convert.ToInt32(textBox3.Text);
            F.Delete_vertex(t);
            if (delete_v[0] != 0)
            {
                
                delete_v[dv_length] = t;
                dv_length += 1;
            }
            else
            {
                delete_v[0] = t;
                dv_length = 1;
            }
            double phi;
            float[] graphix_x;
            float[] graphix_y;
            double x_i, y_i, Rad;
            Rad = 200;
            string i_name;
            int num_vertices;
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(246, 255, 143));
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            num_vertices = F.Num_of_vertex();
            graphix_x = new float[num_vertices];
            graphix_y = new float[num_vertices];
            for (int i = 1; i <= num_vertices; i++)
            {
                if (Check(i))
                {
                    continue;
                }
                else
                {
                    phi = Math.PI * i * 2 / num_vertices;
                    x_i = Rad * (1 / (Math.Sqrt(1 + Math.Pow(Math.Tan(phi), 2))));
                    y_i = Math.Sqrt(Math.Pow(Rad, 2) - Math.Pow(x_i, 2));
                    if ((phi > Math.PI / 2) && (phi <= Math.PI))
                    {
                        x_i *= -1;
                    }
                    if ((phi > Math.PI) && (phi <= 1.5 * Math.PI))
                    {
                        x_i *= -1;
                        y_i *= -1;
                    }
                    if ((phi > 1.5 * Math.PI) && (phi <= 2 * Math.PI))
                    {
                        y_i *= -1;

                    }
                    graphix_x[i - 1] = (float)15 + (float)x_i + pictureBox1.Width / 2;
                    graphix_y[i - 1] = (float)15 + (float)y_i + pictureBox1.Height / 2;
                }
            }
            Pen p = new Pen(Color.Blue, 5);// цвет линии и ширина
            int j = 0;
            while (j < F.get_length())
            {
                if ((graphix_x[F.get_element(j) - 1] == 0 && graphix_y[F.get_element(j) - 1] == 0) || (graphix_x[F.get_element(j+1) - 1] == 0 && graphix_y[F.get_element(j+1) - 1] == 0))
                {
                    j += 2;
                }
                else
                {
                    g.DrawLine(p, graphix_x[F.get_element(j) - 1], graphix_y[F.get_element(j) - 1], graphix_x[F.get_element(j + 1) - 1], graphix_y[F.get_element(j + 1) - 1]);
                    j += 2;
                }
            }
            int l = 1;
            while (l <= num_vertices)
            {
                if (Check(l))
                {
                    l++;
                }
                else
                {
                    i_name = Convert.ToString(l);
                    g.FillEllipse(myTrub, graphix_x[l - 1] - 15, graphix_y[l - 1] - 15, 30, 30);
                    g.DrawString(i_name, new Font("Arial", 12), Brushes.Black, graphix_x[l - 1] - 7, graphix_y[l - 1] - 8);
                    l++;
                }
            }
        }
        public void button7_Click(object sender, EventArgs e)
        {
            int a, b;
            a = Convert.ToInt32(textBox4.Text);
            b = Convert.ToInt32(textBox5.Text);
            F.Delete_edge(a, b);
            double phi;
            float[] graphix_x;
            float[] graphix_y;
            double x_i, y_i, Rad;
            Rad = 200;
            string i_name;
            int num_vertices;
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(246, 255, 143));
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            num_vertices = F.Num_of_vertex();
            graphix_x = new float[num_vertices];
            graphix_y = new float[num_vertices];
            for (int i = 1; i <= num_vertices; i++)
            {
                phi = Math.PI * i * 2 / num_vertices;
                x_i = Rad * (1 / (Math.Sqrt(1 + Math.Pow(Math.Tan(phi), 2))));
                y_i = Math.Sqrt(Math.Pow(Rad, 2) - Math.Pow(x_i, 2));
                if ((phi > Math.PI / 2) && (phi <= Math.PI))
                {
                    x_i *= -1;
                }
                if ((phi > Math.PI) && (phi <= 1.5 * Math.PI))
                {
                    x_i *= -1;
                    y_i *= -1;
                }
                if ((phi > 1.5 * Math.PI) && (phi <= 2 * Math.PI))
                {
                    y_i *= -1;

                }
                graphix_x[i - 1] = (float)15 + (float)x_i + pictureBox1.Width / 2;
                graphix_y[i - 1] = (float)15 + (float)y_i + pictureBox1.Height / 2;
            }
            Pen p = new Pen(Color.Blue, 5);// цвет линии и ширина
            int j = 0;
            while (j < F.get_length())
            {
                g.DrawLine(p, graphix_x[F.get_element(j) - 1], graphix_y[F.get_element(j) - 1], graphix_x[F.get_element(j + 1) - 1], graphix_y[F.get_element(j + 1) - 1]);
                j += 2;
            }
            int l = 1;
            while (l <= num_vertices)
            {
                i_name = Convert.ToString(l);
                g.FillEllipse(myTrub, graphix_x[l - 1] - 15, graphix_y[l - 1] - 15, 30, 30);
                g.DrawString(i_name, new Font("Arial", 12), Brushes.Black, graphix_x[l - 1] - 7, graphix_y[l - 1] - 8);
                l++;
            }
        }
        public void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Rez_matr[i, j] = 0;
                }
            }
            //int a, b, x, y;
            int kolp = 0;
            string[] s_mas;
            string s = "";
            int h;
            x = Convert.ToInt32(textBox6.Text);
            y = Convert.ToInt32(textBox7.Text);
            a = Convert.ToInt32(textBox8.Text);
            b = Convert.ToInt32(textBox9.Text);
            F.Search_and_build_road(F.Num_of_vertex(), x, y, a, b, ref kolp, ref Rez_matr);
            s_mas = new string[kolp];
            for(int i = 0; i < kolp; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    h = Rez_matr[i, j];
                    if (h == 0)
                    {
                        break;
                    }
                    else
                    {
                        if(h == y)
                        {
                            s = String.Concat(s, Convert.ToString(h));
                        }
                        else
                        {
                            s = String.Concat(s, Convert.ToString(h), "->");
                        }
                       
                    }

                }
                s_mas[i] = String.Concat(Convert.ToString(i+1),") ",s);
                s = "";
            }
            textBox10.Lines = s_mas;

        }

        public void button9_Click(object sender, EventArgs e)
        {
            int n;
            n = Convert.ToInt32(textBox11.Text);

            double phi;
            float[] graphix_x;
            float[] graphix_y;
            double x_i, y_i, Rad;
            Rad = 200;
            string i_name;
            int num_vertices;
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(246, 255, 143));
            SolidBrush myTrub = new SolidBrush(Color.DeepPink);
            num_vertices = F.Num_of_vertex();
            graphix_x = new float[num_vertices];
            graphix_y = new float[num_vertices];
            for (int i = 1; i <= num_vertices; i++)
            {
                phi = Math.PI * i * 2 / num_vertices;
                x_i = Rad * (1 / (Math.Sqrt(1 + Math.Pow(Math.Tan(phi), 2))));
                y_i = Math.Sqrt(Math.Pow(Rad, 2) - Math.Pow(x_i, 2));
                if ((phi > Math.PI / 2) && (phi <= Math.PI))
                {
                    x_i *= -1;
                }
                if ((phi > Math.PI) && (phi <= 1.5 * Math.PI))
                {
                    x_i *= -1;
                    y_i *= -1;
                }
                if ((phi > 1.5 * Math.PI) && (phi <= 2 * Math.PI))
                {
                    y_i *= -1;

                }
                graphix_x[i - 1] = (float)15 + (float)x_i + pictureBox1.Width / 2;
                graphix_y[i - 1] = (float)15 + (float)y_i + pictureBox1.Height / 2;

            }
            Pen p = new Pen(Color.Blue, 5);// цвет линии и ширина
            int j = 0;
            while (j < F.get_length())
            {
                p = new Pen(Color.Blue, 5);
                int m = 0;
                while(Rez_matr[n-1, m+1] != 0)
                {
                    if((F.get_element(j) == a && F.get_element(j + 1) == b) || (F.get_element(j + 1) == a && F.get_element(j) == b))
                    {
                        p = new Pen(Color.Red, 5);
                        break;
                    }
                    else if((F.get_element(j) == Rez_matr[n - 1, m] && F.get_element(j + 1) == Rez_matr[n - 1, m + 1]) || (F.get_element(j + 1) == Rez_matr[n - 1, m] && F.get_element(j) == Rez_matr[n - 1, m + 1]))
                    {
                        p = new Pen(Color.Green,5);
                        break;
                    }
                    m++;
                }
                g.DrawLine(p, graphix_x[F.get_element(j) - 1], graphix_y[F.get_element(j) - 1], graphix_x[F.get_element(j + 1) - 1], graphix_y[F.get_element(j + 1) - 1]);
                j += 2;
            }
            int l = 1;
            while (l <= num_vertices)
            {
                myTrub = new SolidBrush(Color.DeepPink);
                if (l == x || l == y)
                {
                    myTrub = new SolidBrush(Color.DarkMagenta);
                }
                i_name = Convert.ToString(l);
                g.FillEllipse(myTrub, graphix_x[l - 1] - 15, graphix_y[l - 1] - 15, 30, 30);
                g.DrawString(i_name, new Font("Arial", 12), Brushes.Black, graphix_x[l - 1] - 7, graphix_y[l - 1] - 8);
                l++;
            }

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

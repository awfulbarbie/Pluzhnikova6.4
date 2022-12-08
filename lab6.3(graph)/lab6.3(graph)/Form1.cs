namespace lab6._3_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] Input(out int n, out int m) // out - ����������� ���������� �� ������;
                                               // ����������, ������������ � �������� ����������, �� ��������� ���������������� ����� ��������� � ������ ������.
                                               // ����� �������� � ��������� �������������� � ����������
            {
                try
                {
                    if (numericUpDown1.Value <= 0 || numericUpDown2.Value <= 0)
                    {
                        MessageBox.Show("������! ����������� ������� �� ����� ����� ������������� ��� ������� ��������", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
                catch
                {
                    MessageBox.Show("������! �������� ������ ����� ������", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                n = (int)numericUpDown1.Value;
                m = (int)numericUpDown2.Value;

                int[,] array = new int[n, m];
                Random rand = new Random();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = rand.Next(-100, 100);
                    }
                }

                return array;
            }

            void Print(int[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    textBox1.Text += Environment.NewLine;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        textBox1.Text += $"{array[i, j]} ";
                    }

                }
                textBox1.Text += Environment.NewLine;

            }

            void result(int[,] array)
            {
                bool[] col_array = new bool[array.GetLength(1)];    //���������� ������ � ������������, ������ ���������� �������� ������� array

                for (int i = 0; i < col_array.Length; i++)          //���� ��������� ������� ������������� �������� true
                {
                    col_array[i] = true;
                }

                for (int i = 0; i < array.GetLength(1); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (array[j, i] >= 0)                      //�������� ���� ��������� �������� ������� array,
                                                                   //���� ������� �����������, �� �������� ���. ������� ������������� �������� false
                        {
                            col_array[i] = false;
                            break;
                        }
                    }
                }

                int flag = 0;
                for (int i = 0; i < array.GetLength(1); i++)       //������� ���� ��������� �������� ������� array,
                                                                   //���� �������� col_array = true, �� �����
                {
                    if (col_array[i])
                    {
                        string output = string.Empty;               //������ ������
                        for (int j = 0; j < array.GetLength(0); j++)
                        {
                            output += array[j, i] + Environment.NewLine;
                        }

                        textBox1.Text += $"{i + 1} ������� ������� �� ������������� �����:" + Environment.NewLine + output;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    textBox1.Text += "��� ��������, � ������� ��� �������� �������� ��������������" + Environment.NewLine;
                }
            }

            {
                int n;
                int m;
                int[,] Array = Input(out n, out m);
                textBox1.Text += "�������� ������:";
                Print(Array);
                result(Array);
            }



        }
    }
}
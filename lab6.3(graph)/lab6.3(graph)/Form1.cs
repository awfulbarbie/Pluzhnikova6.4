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
            int[,] Input(out int n, out int m) // out - модификатор параметров по ссылке;
                                               // переменные, передаваемые в качестве аргументов, не требуется инициализировать перед передачей в вызове метода.
                                               // любая операция в параметре осуществляется с аргументом
            {
                try
                {
                    if (numericUpDown1.Value <= 0 || numericUpDown2.Value <= 0)
                    {
                        MessageBox.Show("Ошибка! Размерность массива не может иметь отрицательное или нулевое значение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка! Неверный формат ввода данных", "Ошибка",
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
                bool[] col_array = new bool[array.GetLength(1)];    //логический массив с размерностью, равной количеству столбцов массива array

                for (int i = 0; i < col_array.Length; i++)          //всем элементам массива присваивается значение true
                {
                    col_array[i] = true;
                }

                for (int i = 0; i < array.GetLength(1); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (array[j, i] >= 0)                      //проверка всех элементов столбцов массива array,
                                                                   //если условие выполняется, то элементу лог. массива присваивается значение false
                        {
                            col_array[i] = false;
                            break;
                        }
                    }
                }

                int flag = 0;
                for (int i = 0; i < array.GetLength(1); i++)       //перебор всех элементов столбцов массива array,
                                                                   //если элементы col_array = true, то вывод
                {
                    if (col_array[i])
                    {
                        string output = string.Empty;               //пустая строка
                        for (int j = 0; j < array.GetLength(0); j++)
                        {
                            output += array[j, i] + Environment.NewLine;
                        }

                        textBox1.Text += $"{i + 1} столбец состоит из отрицательных чисел:" + Environment.NewLine + output;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    textBox1.Text += "Нет столбцов, в которых все элементы являются отрицательными" + Environment.NewLine;
                }
            }

            {
                int n;
                int m;
                int[,] Array = Input(out n, out m);
                textBox1.Text += "Исходный массив:";
                Print(Array);
                result(Array);
            }



        }
    }
}
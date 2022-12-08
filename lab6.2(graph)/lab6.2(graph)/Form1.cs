namespace lab6._2_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] Input()
            {
                int n = 0;
                 
                    try
                    {
                        if (numericUpDown1.Value <= 0)
                        {
                            MessageBox.Show("Ошибка! Размерность массива не может иметь отрицательное или нулевое значение", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Неверный формат ввода данных", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                n = (int)numericUpDown1.Value;

                int[] array = new int[n];
                Random rand = new Random();
                    for (int i = 0; i < n; i++)
                    {
                        array[i] = rand.Next(-100, 100);
                    }

                    return array;
            }
            void Print(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    textBox1.Text += $"{array[i]} ";
                }
                textBox1.Text += Environment.NewLine;
            }


            int Value(int[] array)
            {
                int num_value = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        num_value++;
                    }
                    else
                    {
                        num_value = 0;
                    }
                }
                return num_value;
            }

            
            {
                int[] Array = Input();
                Print(Array);
                int val = Value(Array);
                if (val > 0)
                {
                    textBox1.Text += "Количество элементов, значение которых больше значения предыдущего элемента = " + val;
                }
                else
                {
                    textBox1.Text += "Таких элементов в массиве нет";
                }

            }
        }

    }
}

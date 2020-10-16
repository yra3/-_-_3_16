using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace task_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[][] array = new string[0][];
        Font standardFont;
        string NL = Environment.NewLine;
        private void button1_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("Task2 1.csv", Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Array.Resize(ref array, array.Length + 1);
                    string[] values = line.Split(';');
                    array[array.Length - 1] = new string[values.Length];
                    Array.Copy(values, array[array.Length - 1], values.Length);
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                string[] array1 = new string[array[i].Length];
                Array.Copy(array[i], array1, array[i].Length);
                array[i] = new string[array[i].Length + 1];
                Array.Copy(array1, array[i], array1.Length);
            }
            using (var sw = new StreamWriter(File.Open(@"C:\Users\User\Desktop\MOAD\Лаб3\task_16\task_16\bin\Debug\Result_2_1.csv", FileMode.Create), Encoding.Default))
            {
                string temp = "";
                string[] x1 = new string[array.Length];
                for (int l = 1; l < array.Length; l++)
                {
                    temp = "";
                    int count = 0;
                    int value = 0;
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (Convert.ToInt32(array[i][0]) == l)
                        {
                            string xx=array[i][2].Replace(":", "");
                            int xxx = Convert.ToInt32(array[i][2]);
                            value += Convert.ToInt32(array[i][2]) % 100;
                            array[i][2].Remove(array[i][2].Length - 3);
                            value += (Convert.ToInt32(array[i][2]) / 100) % 100 * 60;
                            array[i][2].Remove(array[i][2].Length - 3);
                            value+= (Convert.ToInt32(array[i][2]) / 10000) % 100 * 3600;
                            count++;
                        }
                        if (i == array.Length - 1)
                        {
                            for (int j = 0; j < array[i].Length - 1; j++)
                            {
                                temp += array[i][j] + ";";
                                if (i == 0 && j == array[i].Length - 2) temp += "Среднее время по оператору" + ";";
                                if (i > 0 && j == array[i].Length - 2) temp += (double)value/count + ";";
                            }
                            sw.WriteLine(temp.Substring(0, temp.Length - 1));
                        }
                    }
                }
            }
        }
    }
}

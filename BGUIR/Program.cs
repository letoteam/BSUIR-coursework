using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fileName = "data.txt";
        double xMin = double.MaxValue;
        double yMin = double.MaxValue;

        // Чтение данных из файла
        double[] data = ReadDataFromFile(fileName);

        // Перебор значений функции в диапазоне
        for (double x = data[0]; x <= data[1]; x += data[2])
        {
            double y = Math.Sin(x); // Функция для минимизации

            // Сравнение с минимальным значением
            if (y < yMin)
            {
                xMin = x;
                yMin = y;
            }
        }

        Console.WriteLine($"Минимум функции Sin(x) равен {yMin} при x = {xMin}");
    }

    static double[] ReadDataFromFile(string fileName)
    {
        double[] data = new double[3];

        using (StreamReader reader = new StreamReader(fileName))
        {
            for (int i = 0; i < 3; i++)
            {
                string line = reader.ReadLine();
                double value = double.Parse(line);
                data[i] = value;
            }
        }

        return data;
    }
}
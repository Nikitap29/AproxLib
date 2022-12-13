using System;

namespace AproxLib
{
    public class Approx
    {
        /// <summary>
        /// Коэффициенты
        /// </summary>
        public double[] coefs = new double[3];

        /// <summary>
        /// Вычисление коэффициентов полинома
        /// </summary>
        /// <param name="x">Переменные Х</param>
        /// <param name="y">Переменные Y</param>
        /// <returns>Возвращает массив коэффициентов</returns>
        public int CalcCoefs(double[] x, double[] y)
        {  
            var X = new Matrix(3, 1); //массив коэффициентов
            if (x.Length != y.Length) //если размер Х не равен размеру Y
                return -1;
            var n = x.Length; //размерность массивов
            var A = new Matrix(3, 3); //матрица коэффициентов
            var B = new Matrix(3, 1); //вектор свободных коэффициентов
            var sumX = 0.0; //сумма X
            var sumX2 = 0.0; //сумма Х2
            var sumX3 = 0.0; //сумма Х3
            var sumX4 = 0.0; //сумма Х4
            var sumY = 0.0; //сумма Y
            var sumXY = 0.0; //сумма XY
            var sumX2Y = 0.0; //сумма X2Y
            for (var i = 0; i < n; i++) //перебор массивов
            { //вычисляем суммы
                sumX += x[i];
                sumX2 += Math.Pow(x[i], 2);
                sumX3 += Math.Pow(x[i], 3);
                sumX4 += Math.Pow(x[i], 4);
                sumY += y[i];
                sumXY += x[i] * y[i];
                sumX2Y += Math.Pow(x[i], 2) * y[i];
            }
            //формирование матрицы
            A.array[0, 0] = n;        A.array[0, 1] = sumX;     A.array[0, 2] = sumX2;
            A.array[1, 0] = sumX;     A.array[1, 1] = sumX2;    A.array[1, 2] = sumX3;
            A.array[2, 0] = sumX2;    A.array[2, 1] = sumX3;    A.array[2, 2] = sumX4;
            //формирование вектора
            B.array[0, 0] = sumY;
            B.array[1, 0] = sumXY;
            B.array[2, 0] = sumX2Y;
            var invA = A.Inverse(); //находим обратную матрицу
            X = invA * B; //результат вычисляется как произведение
            coefs = new double[] { X.array[0, 0], X.array[1, 0], X.array[2, 0] }; //формируем результат
            return 1;
        }

        /// <summary>
        /// Расчет значений
        /// </summary>
        /// <param name="x">Входной массив</param>
        /// <returns>Возвращает аппроксимированный массив</returns>
        public double[] CalcValues(double[] x)
        {
            var res = new double[x.Length]; //результирующий массив
            if (coefs != null && coefs.Length == 3) //если коэффициенты есть и рассчитаны, то
            {
                for (var i = 0; i < x.Length; i++) //перебор входного массива
                    res[i] = coefs[0] + coefs[1] * x[i] + coefs[2] * x[i] * x[i];
            }
            return res;
        }
    }
}

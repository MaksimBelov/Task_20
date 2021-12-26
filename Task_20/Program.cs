using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_20
{
    internal class Program
    {
        delegate T MyDelegate<T>(T x);

        static void Main(string[] args)
        {
            Console.Write("Введите радиус: ");
            try
            {
                double r = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                {
                    MyDelegate<double> myDelegate = GetLength;
                    Console.WriteLine($"Длина окружности с радиусом {r} равна {myDelegate?.Invoke(r)}");
                }
                Wait();
                {
                    MyDelegate<double> myDelegate = new MyDelegate<double>(GetSquare);
                    Console.WriteLine($"Площадь круга с радиусом {r} равна {myDelegate?.Invoke(r)}");
                }
                Wait();
                {
                    MyDelegate<double> myDelegate = new MyDelegate<double>(GetVolume);
                    double V = (double)myDelegate?.Invoke(r);
                    Console.WriteLine($"Объем шара с радиусом {r} равен {V}");
                }
                Wait();
                {
                    // встроенный делегат Action
                    Action<double> action = GetLngth;
                    action(r);
                }
                Wait();
                {
                    // встроенный делегат Func
                    Func<double, double> func = GetSquare;
                    Console.WriteLine($"Площадь круга с радиусом {r} равна {func(r)}");
                }
                Wait();
                {
                    // анонимный метод
                    MyDelegate<double> myDelegate = delegate (double x)
                    {
                        return Math.Round((4 * Math.PI * Math.Pow(r, 3) / 3), 2);
                    };
                    Console.WriteLine($"Объем шара с радиусом {r} равен {myDelegate(r)}");
                }
                Wait();
                {
                    // лямбда-выражения
                    MyDelegate<double> myDelegate = x => Math.Round(2 * Math.PI * r, 2);
                    Console.WriteLine($"Длина окружности с радиусом {r} равна {myDelegate(r)}");
                }
                Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Wait();
            }
        }
        static double GetLength(double r)
        {
            return Math.Round(2 * Math.PI * r, 2);
        }

        static double GetSquare(double r)
        {
            return Math.Round((Math.PI * Math.Pow(r, 2)), 2);
        }
        static double GetVolume(double r)
        {
            return Math.Round((4 * Math.PI * Math.Pow(r, 3) / 3), 2);
        }

        static void GetLngth(double r)
        {
            Console.WriteLine($"Длина окружности с радиусом {r} равна {Math.Round(2 * Math.PI * r, 2)}");
        }

        static void Wait()
        {
            Console.WriteLine();
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

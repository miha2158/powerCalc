using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace powerCalc
{
    using static Console;

    class Program
    {

        static double CustomPow(double num, int pow, out Stopwatch s)
        {
            var powers = Convert.ToString(pow, 2);
            double result = 0;

            s = Stopwatch.StartNew();
            for (int i = 0; i < powers.Length; i++)
            {
                if (powers[i] == 1)
                    result += num;
                num *= num;
            }

            s.Stop();
            return result;

        }

        static void Main(string[] args)
        {

            while (true)
            {
                double num;
                int pow;

                try
                {
                    WriteLine("Введите число возводимое в степень");
                    num = double.Parse(ReadLine().Replace('.', ','));

                    WriteLine("\nВведите степень");
                    pow = int.Parse(ReadLine());
                }
                catch
                {
                    break;
                }

                if(pow <= 0)
                    break;

                var s = Stopwatch.StartNew();
                double result = Math.Pow(num, pow);
                s.Stop();
                WriteLine("{1}^{2} == {0} -  Math.Pow - {3}ms = {4}t\n", result, num, pow, s.ElapsedMilliseconds,
                    s.ElapsedTicks);

                CustomPow(num, pow, out s);
                WriteLine("{1}^{2} == {0} - CustomPow - {3}ms = {4}t\n", result, num, pow, s.ElapsedMilliseconds,
                    s.ElapsedTicks);
            }


            ReadKey(true);
        }
    }
}

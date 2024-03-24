using System;
using System.Collections.Generic;

namespace prefix_to_mask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual é o prefixo?");
            Console.Write("R: ");
            int prefixo = int.Parse(Console.ReadLine());

            var octectos = new List<string>() {
                "00000000",
                "00000000",
                "00000000",
                "00000000",
            };

            int octectoIndex = 0;
            int index = 0;

            for (int x = 0; x < prefixo; x++)
            {
                string s = octectos[octectoIndex].Remove(index, 1);
                s = s.Insert(index, "1");
                octectos[octectoIndex] = s;

                index++;

                if (index == 8)
                {
                    octectoIndex++;
                    index = 0;
                }
            }

            string decimal_mask = "";
            string binary_mask = "";

            for (int x = 0; x < octectos.Count; x++)
            {

                binary_mask += octectos[x];
                decimal_mask += binary_to_decimal(octectos[x]).ToString();

                if (x != octectos.Count - 1)
                {
                    binary_mask += '.';
                    decimal_mask += '.';
                }
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Prefix: /{prefixo}");
            Console.WriteLine($"Binary Mask: {binary_mask}");
            Console.WriteLine($"Decimal Mask: {decimal_mask}");
            Console.ReadKey();
        }

        static int binary_to_decimal(string binary)
        {
            int pow = 0;
            int value = 0;
            for (int x = binary.Length - 1; x >= 0; x--)
            {
                int n = int.Parse(binary[x].ToString());
                value += potencia(n * 2, pow);
                pow++;
            }

            return value;
        }

        static int potencia(int b, int exp)
        {
            if (b == 0)
            {
                return 0;
            }

            int res = 1;
            for (int x = 0; x < exp; x++)
            {
                res *= b;
            }


            return res;
        }


    }
}

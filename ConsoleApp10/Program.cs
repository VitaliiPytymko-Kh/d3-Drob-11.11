using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3_Drob_11_11
{
  
   
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
       
        public Fraction() { }
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction[] fractions = new Fraction[3];
            for (int i = 0; i < fractions.Length; i++)
            {
                Console.WriteLine($"Зазначте чисельник для дробу {i + 1}: ");
                int numerator = 0;
                while (!int.TryParse(Console.ReadLine(), out numerator) || numerator < 0)
                {
                    Console.WriteLine("Некорректный ввод. Числитель дроби должен быть неотрицательным.");
                    Console.WriteLine($"Зазначте чисельник для дробу {i + 1}: ");
                }
                Console.WriteLine($"Зазначте знаменник для дробу {i + 1}: ");
                int denominator = 0;

                while (!int.TryParse(Console.ReadLine(), out denominator) || denominator < 0)
                {
                    Console.WriteLine("Некорректный ввод. Знаменатель дроби должен быть неотрицательным.");
                    Console.WriteLine($"Зазначте знаменник для дробу {i + 1}: ");
                }

                fractions[i] = new Fraction((int)numerator, (int)denominator);
            }
           
            File.WriteAllText("fractions.json", JsonConvert.SerializeObject(fractions));
            Console.WriteLine("Serialization completed successfully.");

            string jsonFromFile = File.ReadAllText("fractions.json");
            Fraction[] fractions1 = JsonConvert.DeserializeObject<Fraction[]>(jsonFromFile);
            Console.WriteLine("Дроби з файлу: ");
            foreach (var fraction in fractions1)
            {
                Console.WriteLine($"{fraction.Numerator}/{fraction.Denominator}");
            }
            Console.ReadLine();
        }
    }
}

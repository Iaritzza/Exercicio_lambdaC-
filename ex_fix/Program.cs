using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ex_fix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Funcionarios> funcionarios = new List<Funcionarios>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter value salary: ");
            double valueSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream)
                {
                    string[] ler = sr.ReadLine().Split(",");
                    string name = ler[0];
                    string email = ler[1];
                    double salary = double.Parse(ler[2], CultureInfo.InvariantCulture);

                    funcionarios.Add(new Funcionarios (name, email, salary));
                }
            }
            Console.WriteLine($"Emails of the people with value salary more {valueSalary}");

            var names = funcionarios.Where(s => s.Salario > valueSalary).OrderBy(s => s.Email).Select(s => s.Email);
            foreach (string email in names)
            {
                Console.WriteLine(email);
            }

            
            var valorTotal = funcionarios.Where(s => s.Nome[0] == 'M').Sum(s => s.Salario);
            Console.WriteLine("Total salary people initial 'M': " + valorTotal.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}

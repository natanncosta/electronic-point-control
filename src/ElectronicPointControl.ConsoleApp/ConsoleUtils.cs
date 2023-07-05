using System;
using Ponto.Classes;

namespace Ponto.ConsoleApp
{
    public class ConsoleUtils
    {
        private EmployeeCRUD employees = new();

        public void ShowHeader(string header) => Console.WriteLine($"==== {header.ToUpper()} ====");

        public void HandleError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void HandleSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public bool EmployeeExists(string registration) => employees.Get(registration) is not null;

        public string ReadRegistration()
        {
            Console.Write("Digite a matrícula: ");
            return Console.ReadLine();
        }

        public CPF ReadCPF()
        {
            Console.Write("Digite o CPF: ");
            return new CPF() { Value = Console.ReadLine() };
        }

        public string ReadName()
        {
            Console.Write("Digite o nome: ");
            return Console.ReadLine();
        }

        public string ReadPassword()
        {
            Console.Write("Digite a senha: ");
            return Console.ReadLine();
        }

        public WorkLoad ReadWorkLoad()
        {
            WorkLoad workLoad = new WorkLoad();

            Console.Write("Digite a hora em que se deve bater o ponto para Iniciar a jornada de trabalho: ");
            workLoad.StartHour = Convert.ToDateTime(Console.ReadLine());

            Console.Write("A hora em que se deve bater o ponto para Encerrar a jornada de trabalho: ");
            workLoad.EndHour = Convert.ToDateTime(Console.ReadLine());

            return workLoad;
        }
    }
}
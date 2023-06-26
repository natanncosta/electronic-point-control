﻿using System;
using Ponto.Classes;

namespace Ponto.ConsoleApp
{
    class Program
    {
        static string menuOption;

        static EmployeeConsole employeeConsole = new();
        static CompanyConsole companyConsole = new();
        static AdminConsole adminConsole = new();

        static ConsoleUtils utils = new();

        static EmployeeCRUD employees = new EmployeeCRUD();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                utils.ShowHeader("Menu");
                ShowMainMenu();
                ReadMenuOption();
                HandleMenu();
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("[1] Fazer Login");
            Console.WriteLine("[2] Registrar-se");
            Console.WriteLine("[3] Sobre");
            Console.WriteLine("[0] Sair");
        }

        private static void HandleMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    DoLogin();
                    break;
                case "2":
                    DoSignUp();
                    break;
                case "3":
                    AboutUs();
                    break;
                case "0":
                    Exit();
                    break;
                default:
                    break;
            }
            BackToMainMenu();
        }

        private static void DoLogin()
        {
            utils.ShowHeader("login");

            Console.Write("Digite sua matrícula: ");
            string registration = Console.ReadLine();

            Employee employee = employees.GetByCPF(registration);
            if (employee == null)
            {
                utils.HandleError("Usuário não encontrado");
                return;
            }

            Console.Write("Digite sua senha: ");
            string password = Console.ReadLine();

            if (employee.PasswordIsCorrect(password))
                utils.HandleSuccess("Acesso concedido");
            else
                utils.HandleError("Senha incorreta");
        }

        private static void DoSignUp()
        {
            do
            {
                Console.Clear();
                utils.ShowHeader("Registrar-se");
                ShowSignUpMenu();
                ReadMenuOption();
                HandleSignUp();
            } while (menuOption != "4");
        }

        private static void ShowSignUpMenu()
        {
            Console.WriteLine("[1] Novo funcionário");
            Console.WriteLine("[2] Novo administrador");
            Console.WriteLine("[3] Nova empresa");
            Console.WriteLine("[4] Voltar");
        }

        private static void HandleSignUp()
        {
            switch (menuOption)
            {
                case "1":
                    NewEmployee();
                    break;
                case "2":
                    NewAdmin();
                    break;
                case "3":
                    NewCompany();
                    break;
                default:
                    break;
            }
        }

        private static void NewEmployee()
        {
            throw new NotImplementedException();
        }

        private static void NewAdmin()
        {
            throw new NotImplementedException();
        }

        private static void NewCompany()
        {
            throw new NotImplementedException();
        }

        private static void AboutUs()
        {
            throw new NotImplementedException();
        }

        private static void Exit()
        {
            Console.WriteLine("Saindo do sistema...");
            Environment.Exit(1);
        }

        static void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        static void BackToMainMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para prosseguir...");
            Console.ReadKey();
        }

        static bool ENumero(string palavra)
        {
            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] > 57 || palavra[i] < 48)
                {
                    Console.WriteLine("Use apenas números nesse campo");
                    return false;
                }
            }
            return true;
        }
        static bool ValCNPJ(string Cnpj)
        {
            try
            {
                if (Cnpj.Length < 14 || Cnpj.Length > 14)
                {
                    throw new ArgumentException("O número de caracteres inseridos não bate com a quantidade que essa informação exige"); ;
                }
                for (int i = 0; i < Cnpj.Length; i++)
                {
                    if (Cnpj[i] < 48 || Cnpj[i] > 57)
                    {
                        throw new ArgumentException("Use apenas números nessa informação");
                    }
                }
                Console.WriteLine("CNPJ válido");
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        static bool ValCPF(string Cpf)
        {
            try
            {
                if (Cpf.Length < 11 || Cpf.Length > 11)
                {
                    throw new ArgumentException("O número de caracteres inseridos não bate com a quantidade que essa informação exige"); ;
                }
                for (int i = 0; i < Cpf.Length; i++)
                {
                    if (Cpf[i] < 48 || Cpf[i] > 57)
                    {
                        throw new ArgumentException("Use apenas números nessa informação");
                    }
                }
                Console.WriteLine("CPF válido");
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
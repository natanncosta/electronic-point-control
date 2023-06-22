﻿using System;
using System.Collections.Generic;
using Ponto.Classes;

namespace Ponto.ConsoleApp
{
    class Program
    {
        static string ler;
        static int Opt;
        static int OptMenu;
        static Empresa empresa;
        //Inventando Dados para um Adm inicial...---------------------------------------------------------------
        static Endereco enderecoRoot = new Endereco ("Adm", "Administralândia", "Sim", "Bairro", "Rua", 1);
        static Administrador administrador = new Administrador("12345678900", "Galo", "Cinza", enderecoRoot);
        //------------------------------------------------------------------------------------------------------
        static CrudFuncionario funcionarios = new CrudFuncionario("", "", "", enderecoRoot);//Tive que colocar esses dados só pra poder usar o Crud
        static void Main(string[] args)
        {
            administrador.ChaveAdministrador = "root";
            //Funcionario Teste-----------------------------------------------------------------------------------
            Endereco endereco1 = new Endereco("SC", "Lages", "Casa", "Petropoles", "Rua 31 de Março", 55);
            Funcionario funcionarioC = new Funcionario("12345678901","lucas","almeida", endereco1);
            funcionarios.Cadastrar(funcionarioC);
            //----------------------------------------------------------------------------------------------------
            Console.WriteLine("Informe o Nome da Empresa: ");
            string empresaNome = Console.ReadLine();
            do
            {
                Console.Write("Informe o CNPJ da Empresa: ");
                ler = Console.ReadLine();
            } while (ValCNPJ(ler) == false);
            string cnpj = ler;
            Console.Write("Informe o UF onde a Empresa está localizada: ");
            string uf = Console.ReadLine();
            Console.Write("Informe a Cidade onde a Empresa está localizada: ");
            string cidade = Console.ReadLine();
            Console.Write("Informe o Complemento da Empresa: ");
            string complemento = Console.ReadLine();
            Console.Write("Informe o Bairro onde a Empresa está localizada: ");
            string bairro = Console.ReadLine();
            Console.Write("Informe a Rua onde a Empresa está localizada: ");
            string rua = Console.ReadLine();
            do
            {
                Console.Write("Informe o Número do Complemento da Empresa: ");
                ler = Console.ReadLine();
            } while (ENumero(ler) == false);
            int numero = Convert.ToInt32(ler);
            Endereco endereco = new Endereco(uf,cidade,complemento,bairro,rua,numero);
            empresa = new Empresa(empresaNome,cnpj,endereco);
            do
            {
                do
                {
                    Console.WriteLine("-----------Menu-----------");
                    Console.WriteLine("[1] Exibir Informações da Empresa");
                    Console.WriteLine("[2] Menu Funcionário");
                    Console.WriteLine("[3] Menu Administrador");
                    Console.WriteLine("[4] Sair");
                    Console.WriteLine("--------------------------");
                    Console.Write("Informe o Número da Opção desejada: ");
                    ler = Console.ReadLine();
                } while (ENumero(ler) == false);
                Opt = Convert.ToInt32(ler);
                switch (Opt)
                {
                    case 1:
                        cnpj = empresa.CNPJ;
                        Console.WriteLine("-----------Dados da Empresa-----------");
                        Console.WriteLine($"CNPJ: {cnpj[0]}{cnpj[1]}.{cnpj[2]}{cnpj[3]}{cnpj[4]}.{cnpj[5]}{cnpj[6]}{cnpj[7]}/{cnpj[8]}{cnpj[9]}{cnpj[10]}{cnpj[11]}-{cnpj[12]}{cnpj[13]}");
                        Console.WriteLine($"Nome: {empresa.Nome}");
                        Console.WriteLine($"UF: {empresa.Endereco.Uf}");
                        Console.WriteLine($"Cidade: {empresa.Endereco.Cidade}");
                        Console.WriteLine($"Bairro: {empresa.Endereco.Bairro}");
                        Console.WriteLine($"Rua: {empresa.Endereco.Rua}");
                        Console.WriteLine($"Complemento: {empresa.Endereco.Complemento}");
                        Console.WriteLine($"Número do Complemento: {empresa.Endereco.NumeroCasa}");
                        Console.WriteLine("---------------------------------------");
                    break;
                    case 2:
                        do
                        {
                            do
                            {
                                Console.WriteLine("-----------Menu Funcionário-----------");
                                Console.WriteLine("[1] Exibir Informações do Funcionário");
                                Console.WriteLine("[2] Marcar Ponto");
                                Console.WriteLine("[3] Voltar");
                                Console.WriteLine("--------------------------");
                                Console.Write("Informe o Número da Opção desejada: ");
                                ler = Console.ReadLine();
                            } while (ENumero(ler) == false);
                            OptMenu = Convert.ToInt32(ler);
                            switch (OptMenu)
                            {
                                case 1:
                                    do
                                    {
                                        Console.Write("Informe o CPF do Funcionário que deseja Consultar: ");
                                        ler = Console.ReadLine();
                                    } while (ValCPF(ler) == false);
                                    if (funcionarios.ConsultarCPF(ler) == null)
                                    {
                                        Console.WriteLine("Funcionário Não Encontrado");
                                    }
                                    else
                                    {
                                        Funcionario funcionario = funcionarios.ConsultarCPF(ler);
                                        string cpf = funcionario.Cpf;
                                        Console.WriteLine("-----------Dados do Funcionário-----------");
                                        Console.WriteLine($"CPF: {cpf[0]}{cpf[1]}{cpf[2]}.{cpf[3]}{cpf[4]}{cpf[5]}.{cpf[6]}{cpf[7]}{cpf[8]}-{cpf[9]}{cpf[10]}");
                                        Console.WriteLine($"Nome: {funcionario.Nome} {funcionario.Sobrenome}");
                                        Console.WriteLine($"UF: {funcionario.Endereco.Uf}");
                                        Console.WriteLine($"Cidade: {funcionario.Endereco.Cidade}");
                                        Console.WriteLine($"Bairro: {funcionario.Endereco.Bairro}");
                                        Console.WriteLine($"Rua: {funcionario.Endereco.Rua}");
                                        Console.WriteLine($"Complemento: {funcionario.Endereco.Complemento}");
                                        Console.WriteLine($"Número do Complemento: {funcionario.Endereco.NumeroCasa}");
                                        Console.WriteLine($"Nome de Usuário: {funcionario.Usuario}");
                                        Console.WriteLine($"Senha: {funcionario.Senha}");
                                        Console.WriteLine("------------------------------------------");
                                    }  
                                break;
                                case 2:
                                    bool registrarPonto = false;
                                    bool usuarioExistente = false;
                                    bool senhaCerta = false;
                                    do 
                                    {
                                        registrarPonto = false;
                                        usuarioExistente = false;
                                        senhaCerta = false;
                                        Console.Write("Informe o Nome do Usuário: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Usuario == ler)
                                            {
                                                usuarioExistente = true;
                                                Console.Write("Informe a Senha do Usuário: ");
                                                ler = Console.ReadLine();
                                                if (funcionario.Senha == ler)
                                                {
                                                    senhaCerta = true;
                                                    registrarPonto = true;
                                                    funcionario.MarcarPonto();
                                                }
                                            }
                                        }
                                        if (usuarioExistente == false)
                                        {
                                            Console.WriteLine("Usuário Não Encontrado");
                                        } 
                                        else if (senhaCerta == false)
                                        {
                                            Console.WriteLine("Senha Incorreta");
                                        }
                                    } while (registrarPonto == false);
                                break;
                                case 3:
                                    Console.WriteLine("Voltando...");
                                break;
                                default:
                                    Console.WriteLine("Opção Inválida");
                                break;
                            }
                        } while(OptMenu != 4);
                    break;
                    case 3:
                        bool AdmCadastrado = false;
                        do
                        {
                            do
                            {
                                Console.WriteLine("-----------Menu Administrador-----------");
                                Console.WriteLine("[1] Cadastrar");
                                Console.WriteLine("[2] Editar");
                                Console.WriteLine("[3] Excluir");
                                Console.WriteLine("[4] Exibir todos os Funcionários");
                                Console.WriteLine("[5] Voltar");
                                Console.WriteLine("----------------------------------------");
                                Console.Write("Informe o Número da Opção desejada: ");
                                ler = Console.ReadLine();
                            } while (ENumero(ler) == false);
                            OptMenu = Convert.ToInt32(ler);
                            Console.WriteLine("Caso Não Tenha um Administrador Cadastrado use essa chave de administrador: root");
                            switch (OptMenu)
                            {
                                case 1:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                            {
                                                AdmCadastrado = true;
                                            }
                                            }
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                    
                                break;
                                case 2:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                                {
                                                    AdmCadastrado = true;
                                                    bool FuncionarioExistente = false;
                                                    do
                                                    {
                                                        Console.Write("Informe o CPF do Funcionário que deseja excluir: ");
                                                        ler = Console.ReadLine();
                                                    } while (ValCPF(ler) == false);
                                                    foreach (KeyValuePair<string, Funcionario> par1 in funcionarios.ConsultarTodos())
                                                    {
                                                        if (par1.Key == ler)
                                                        {
                                                            FuncionarioExistente = true;
                                                        }
                                                    }
                                                    if (FuncionarioExistente == true)
                                                    {
                                                        Console.WriteLine("Tem certeza que deseja Excluir esse Funcionário? S/N");
                                                        ler = Console.ReadLine();
                                                        if (ler.ToLower() == "s")
                                                        {
                                                            funcionarios.Excluir(ler);
                                                            Console.WriteLine("Funcionário Excluído");
                                                        }
                                                    } 
                                                    else
                                                    {
                                                        Console.WriteLine("Funcionário Não Encontrado");
                                                    }
                                                }
                                            }  
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                break;
                                case 3:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                                {
                                                    AdmCadastrado = true;
                                                }
                                            }
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                break;
                                case 4:
                                    do
                                    {
                                        AdmCadastrado = false;
                                        Console.Write("Informe uma Chave de Admnistrador: ");
                                        ler = Console.ReadLine();
                                        foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                        {
                                            Funcionario funcionario = par.Value;
                                            if (funcionario.Tipo == "Adm")
                                            {
                                                Administrador funcionarioAdm = (Administrador)funcionario;
                                                if (funcionarioAdm.ChaveAdministrador == ler)
                                                {
                                                    AdmCadastrado = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (ler == "root")
                                        {
                                            AdmCadastrado = true;
                                        }
                                    } while (AdmCadastrado == false);
                                    Console.WriteLine("Exibindo Todos os Funcionários...");
                                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                                    Console.WriteLine("CPF             | Nome Completo             | Endereço");
                                    foreach (KeyValuePair<string, Funcionario> par in funcionarios.ConsultarTodos())
                                    {
                                        Funcionario funcionario = par.Value;
                                        string cpf = funcionario.Cpf;
                                        Console.Write($"{cpf[0]}{cpf[1]}{cpf[2]}.{cpf[3]}{cpf[4]}{cpf[5]}.{cpf[6]}{cpf[7]}{cpf[8]}-{cpf[9]}{cpf[10]} | ");
                                        Console.Write($"{funcionario.Nome} {funcionario.Sobrenome}  | ");
                                        Console.Write($"{funcionario.Endereco.Uf} - ");
                                        Console.Write($"{funcionario.Endereco.Cidade} - ");
                                        Console.Write($"{funcionario.Endereco.Bairro} - ");
                                        Console.Write($"{funcionario.Endereco.Rua} - ");
                                        Console.Write($"{funcionario.Endereco.Complemento} - ");
                                        Console.WriteLine($"{funcionario.Endereco.NumeroCasa}");
                                    }
                                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                                break;
                                case 5:
                                    Console.WriteLine("Voltando...");
                                break;
                                default:
                                    Console.WriteLine("Opção Inválida");
                                break;
                            }
                        } while (OptMenu != 4);
                    break;
                    case 4:
                        Console.WriteLine("Saindo...");
                    break;
                    default:
                        Console.WriteLine("Opção Inválida");
                    break;
                }
            } while (Opt != 4);
        }
        static bool ENumero (string palavra)
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
                    throw new ArgumentException("O número de caracteres inseridos não bate com a quantidade que essa informação exige");;
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
            } catch (ArgumentException e)
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
                    throw new ArgumentException("O número de caracteres inseridos não bate com a quantidade que essa informação exige");;
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
            } catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        static void ConsultarTodos()
        {

        }
    }
}

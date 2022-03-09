using System;
using System.IO;
namespace Matriz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sair = 1, vazia = 0;
            string nome;
            string[,] matriz = new string[4, 5];

            string Menu()
            {
                Console.WriteLine("\n-------------Menu-------------");
                Console.WriteLine(" 1 - Cadastrar Contato ");
                Console.WriteLine(" 2 - Imprimir Todos os contatos");
                Console.WriteLine(" 3 - Imprimir Por linha");
                Console.WriteLine(" 4 - Imprimir Por coluna");
                Console.WriteLine(" 5 - Pesquisar por nome ");
                Console.WriteLine(" 6 - Ordenacao alfabetica por escolha de linha ");
                Console.WriteLine(" 7 - Salvar arquivo");
                Console.WriteLine(" 8 - Efetua a leitura do arquivo salvo");          
                Console.WriteLine(" 9 - Salvar e sair");

                string opcao = Console.ReadLine();
                return opcao;
            }

            void Cadastrar()
            {
                for (int linhas = 1; linhas < matriz.GetLength(0); linhas++)
                {
                    for (int colunas = 1; colunas < matriz.GetLength(1); colunas++)
                    {
                        Console.WriteLine("\n---------------Registrar nome-------------------\n");
                        Console.Write("Digite um  nome : ");
                        nome = Console.ReadLine().ToUpper();
                        matriz[linhas, colunas] = nome;

                    }
                }
                vazia++;
                
            }

            void Gravar()
            {
                if (vazia > 0)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter("C:\\Users\\Nayron\\OneDrive\\Área de Trabalho\\Arquivos\\Matriz.txt"); 
                                                                                                                                           
                        Console.WriteLine("Os  Nomes cadastrados são : \n");
                        for (int linha = 1; linha < matriz.GetLength(0); linha++)
                        {
                            for (int coluna = 1; coluna < matriz.GetLength(1); coluna++)
                            {
                               sw.Write("Matriz [" + linha + "," + coluna + "]= " + matriz[linha, coluna] + "\t ");
                               
                            }
                            sw.WriteLine();
                        }

                        sw.Close(); 

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception : " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Arquivo gravado com sucesso!!");
                    }
                }
                else
                {
                    Console.Write("Nenhum nome cadastrado");
                }

            }

            void Ler()
            {             
              
                String line;
                bool erro = false;          
                    try
                    {
                        StreamReader sr = new StreamReader("C:\\Users\\Nayron\\OneDrive\\Área de Trabalho\\Arquivos\\Matriz.txt");
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine(line);
                            line = sr.ReadLine();
                        erro = true;
                    }

                        sr.Close();
                        Console.WriteLine("\nFim da leitura do Arquivo");
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error : " + e.Message);
                  
                    }
               
                    finally
                     {
                    if (erro)
                    {
                        Console.WriteLine("Leitura efetuada com sucesso!");

                    }
                }
            }
       
            void Imprimir()
            {

                if (vazia > 0)
                {

                    Console.WriteLine("Os  Nomes cadastrados são : \n");
                    for (int linha = 1; linha < matriz.GetLength(0); linha++)
                    {
                        for (int coluna = 1; coluna < matriz.GetLength(1); coluna++)
                        {

                            Console.Write("Matriz [" + linha + "," + coluna + "]= " + matriz[linha, coluna] + "\t");

                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.Write("Não tem nome cadastrado");
                }

            }

            void ImprimirLinha()
            {
                if (vazia > 0)
                {
                    Console.WriteLine("\n---------------Impressão por linha-------------------\n");
                    Console.Write("Digite  o numero de uma linha de  1 a 3 : \n");
                    int linha = int.Parse(Console.ReadLine());

                

                    Console.WriteLine("Os  Nomes cadastrados são na Linha" + linha + " : \n");

                    if (linha < 4)
                    {
                        for (int coluna = 1; coluna < matriz.GetLength(1); coluna++)
                        {

                            Console.Write("Matriz [" + linha + "," + coluna + "]= " + matriz[linha, coluna] + "\t");

                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("------Por favor digite de 1 a 3 --------- ");
                    }
                }
                else
                {
                    Console.Write("\nNenhum nome cadastrado");
                }

            }

            void ImprimirColuna()
            {

                if (vazia > 0)
                {

                    Console.WriteLine("\n---------------Impressão por Coluna-------------------\n");
                    Console.Write("Digite  o numero de uma linha de  1 a 3 : \n");
                    int coluna = int.Parse(Console.ReadLine());

                    coluna = coluna - 1;

                    Console.WriteLine("Os  Nomes cadastrados são na coluna" + coluna + " : \n");

                    for (int linha = 1; linha < matriz.GetLength(0); linha++)
                    {

                        Console.Write("Matriz [" + linha + "," + coluna + "]= " + matriz[linha, coluna] + "\t");

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.Write("\nNenhum nome cadastrado");
                }
            }

            void Pesquisar()
            {
                Console.WriteLine("\n---------------Pesquisar por nome-------------------\n");
                Console.Write("Digite  o nome que deseja buscar : \n");
                nome = Console.ReadLine().ToUpper();


                bool erro = true;
                for (int linha = 1; linha < matriz.GetLength(0); linha++)
                {
                    for (int coluna = 1; coluna < matriz.GetLength(1); coluna++)
                    {
                        if (nome.CompareTo(matriz[linha, coluna]) == 0)
                        {
                            Console.WriteLine("\n O" + nome + "  esta na linha :  " + linha + "  e na coluna   : " + coluna + "\n");
                            erro = false;
                        }
                    }
                    ;
                }
                if (erro)
                {
                    Console.Write(" " + nome + "  nao existe  na matriz .\n");
                }

            }

            void Ordenar()
            {
                if (vazia > 0)
                {
                    Console.WriteLine("\n---------------Ordenacao por linha-------------------\n");
                    Console.Write("Digite  o numero de uma linha de  1 a 3 : \n");
                    int linha = int.Parse(Console.ReadLine());
               
                    if (linha < 3)
                    {
                        for (int comparar = 1; comparar < matriz.GetLength(1); comparar++)
                        {
                            for (int coluna = 1; coluna < matriz.GetLength(1); coluna++)
                            {

                                if (matriz[linha, coluna].CompareTo(matriz[linha, comparar]) == 1)
                                {

                                    string suporte = matriz[linha, coluna];

                                    matriz[linha, coluna] = matriz[linha, comparar];

                                    matriz[linha, comparar] = suporte;

                                }

                            }
                        }


                        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                        {
                            Console.Write("Matriz [" + linha + "," + coluna + "]= " + matriz[linha, coluna] + "\t");

                        }

                    }


                    else
                    {
                        Console.WriteLine("------Por favor digite de 1 a 3 --------- ");
                    }
                }
                else
                {
                    Console.Write("\nNão tem nome cadastrado");
                }
              
            }

            do
            {
                switch (Menu())
                {

                    case "1":
                        Console.Clear();
                        Cadastrar();
                        break;
                    case "2":                     
                        Imprimir();
                        break;
                    case "3":
                        Console.Clear();
                        ImprimirLinha();
                        break;
                    case "4":
                        Console.Clear();
                        ImprimirColuna();
                        break;
                    case "5":
                        Console.Clear();
                        Pesquisar();
                        break;
                    case "6":
                        Ordenar();
                        break;                  
                    case "7":
                        Gravar();
                        break;
                    case "8":
                        Ler();
                        break;
                    case "9":
                        Gravar();
                        sair = 0;
                        break;

                    default:
                        Console.WriteLine("\n------------OPS! Opção invalida---------------\n");
                        break;
                }
            } while (sair != 0);

        }
    }
}

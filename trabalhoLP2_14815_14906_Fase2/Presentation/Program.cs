using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using BR;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {

            User d = new User();

            Start(d);

        }


        #region Additional Methods

        static public bool Login(User d)
        {

            Console.WriteLine("*****LOGIN*****\n\n");

            bool temp = true;

            Console.WriteLine("Introduza o seu nome:");
            d.Name = Console.ReadLine();

            Console.WriteLine("Introduza a sua password:");
            d.Password = Console.ReadLine();

            Console.WriteLine("Introduza o seu ID:");
            d.ID = Int32.Parse(Console.ReadLine());

                if (BR.Users.C(d) == true)
                {

                    Console.WriteLine("Login efetuado com sucesso!");
                    temp = true;
                    Console.Clear();
                    Menu(d);

                }

                else
                {

                    temp = false;
                    d = new User();
                    Console.WriteLine("\nLogin não efetuado! Os dados não correspondem a nenhum utilizador!");
                    Console.ReadKey();
                    Console.Clear();
                    Program.Login(d);

                }

            return temp;

        }

        // Apresenta o menu ao utilizador
        // "d" -> utilizador temporário "d"
        static public void Menu(User d)
        {

            int option = -1;

            Console.WriteLine("MENU:\n\n");
            Console.WriteLine("\t1-Fazer convocatória;\n");
            Console.WriteLine("\t2-Mostrar as convocatórias já feitas por si;\n");
            Console.WriteLine("\t3-Mostrar os seus dados;\n");
            Console.WriteLine("\t4-Apagar uma convocatória;\n");
            Console.WriteLine("\t5-Logout da sua conta;\n\n");
            Console.WriteLine("Escolha a opção:");
            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {

                default:
                    Console.Clear();
                    Console.WriteLine("Escolha entre as opções disponíveis! Pressione uma tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(d);
                    break;

                case 1:
                    Console.Clear();
                    CallUp(d);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(d);
                    break;

                case 2: //Mostra as convocatórias feitas pelo utilizador
                    Console.Clear();
                    ShowCall(d);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(d);
                    break;

                case 3: //Mostra os dados do utilizador
                    Console.Clear();
                    ShowData(d);
                    Console.ReadKey();
                    Console.Clear();
                    Menu(d);
                    break;

                case 4: //Apaga uma das possíveis convocatórias realizadas
                    Console.Clear();
                    DeleteCall(d);
                    break;

                case 5: //Sai da conta do utilizador atual, remove os dados do utilizador temporário "d" e volta ao início do programa 
                    d = new User();
                    Console.Clear();
                    Program.Start(d);
                    break;

            }

        }

        // Método que inicia o programa
        // "d" -> Utilizador temporário "d"
        static public void Start(User d)
        {

            Console.WriteLine("Já tem conta criada?\n\n");
            Console.WriteLine("1-Sim, desejo fazer o Login;\n");
            Console.WriteLine("2-Não, desejo criar uma conta;\n");
            Console.WriteLine("3-Desejo sair do programa.\n\n");
            Console.WriteLine("Opção:");

            int option = Int32.Parse(Console.ReadLine());

            switch (option)
            {

                default:
                    Console.WriteLine("Introduza uma opção válida! Pressione qualquer tecla para continuar;");
                    Console.ReadKey();
                    Console.Clear();
                    Start(d);
                    break;

                case 1: //Faz a verificação do login
                    Console.Clear();

                    bool s = Program.Login(d);

                    if (s == true) //Caso Login = true, mostra o menu ao utilizador
                    {

                        Console.Clear();
                        Program.Menu(d);

                    }

                    break;

                case 2: //Regista um utilizador
                    Console.Clear();
                    UserRegister();
                    Console.Clear();

                    //Após o registo, faz o Login
                    bool x = Program.Login(d);

                    if (x == true)
                    {

                        Console.Clear();
                        Program.Menu(d);

                    }

                    break;

                case 3: //Sai do programa
                    System.Environment.Exit(1);
                    break;

            }

        }

        // Método para registar um utilizador

        static public void UserRegister()
        {

            User d = new User(); //Utilizador que será usado para o registo

            //Pedir os dados ao utilizador
            Console.WriteLine("Introduza o seu primeiro nome:");
            string name = Console.ReadLine();
            d.Name = name;

            Console.WriteLine("Introduza a sua password:");
            string password = Console.ReadLine(); //Lê a password do utilizador e atribui-a ao objeto temporário
            d.Password = password;

        }

        // Mostra os dados do Utilizador
        // "d" -> Utilizador temporário "d"
        static public void ShowData(User d)
        {

            Console.WriteLine("Nome:{0} \n", d.Name);
            Console.WriteLine("ID de Utilizador:{0} \n", d.ID);
            Console.WriteLine("Password:{0} \n", d.Password);
            Console.ReadKey();
            Console.Clear();

        }

        // Faz a convocatória
        // "d" -> Utilizador temporário "d"
        static public void CallUp(User d)
        {

            Call c = new Call();

            c.ID = d.UserID;

            Console.WriteLine("Dia do Jogo:");
            c.Day = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Mês do Jogo:");
            c.Month = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ano do Jogo:");
            c.Year = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Hora do jogo:");
            c.Hour = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Localização (Fora ou Casa):");
            c.Hour = Char.Parse(Console.ReadLine());

            Console.WriteLine("Adversário:");
            c.Hour = Char.Parse(Console.ReadLine());

            //A fazer na fase 3
            //Console.WriteLine("ID da convocatória(4 dígitos):");
            //c.ID = Int32.Parse(Console.ReadLine());

            DateTime CallDate = new DateTime(c.Year, c.Month, c.Day, c.Hour, 0, 0); //Utilizado para criar uma data para a convocatória para ser comparada com a data atual

            bool s = BR.Calls.CallUp(d, CallDate, c);

            if (s == true)
            {

                Console.WriteLine("ID atribuído à convocatória: {0}.\n NÃO O ESQUECER, SENÃO NÃO PODERÁ FAZER ALTERAÇÕES À CONVOCATÓRIA!\n", c.ID);
                Console.WriteLine("Convocatória adicionada com sucesso!");
                Console.ReadKey();
                Console.Clear();

            }

            else
            {

                Console.WriteLine("A convocatória é inválida!");
                Console.ReadKey();
                Console.Clear();

            }

        }

        // Mostra as convocatórias feitas pelo utilizador
        // "d" -> Utilizador temporário "d"
        static public void ShowCall(User d)
        {

            bool s = BR.Calls.ShowCall(d);

            if (s == true)
            {

                Console.WriteLine("Não tem convocatórias feitas!");
                Console.ReadKey();
                Console.Clear();

            }

        }

        // Apaga uma convocatória feita pelo utilizador temporário "d" 
        // "d" -> Utilizador temporário "d"
        static public void DeleteCall(User d)
        {

            bool s = BR.Calls.DeleteCall(d);

            if (s == false)
            {

                Console.WriteLine("Não existem convocatórias feitas!");
                Console.ReadKey();
                Console.Clear();

            }

            else
            {

                Console.WriteLine("A convocatória foi apagada com sucesso!");
                Console.ReadKey();
                Console.Clear();

            }

        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using BO;

namespace DL
{

    public class Calls : File
    {

        #region Constant

        const string DATAFILE = "Calls.dat";

        #endregion

        #region Var

        private static List<Call> CallList;

        #endregion

        #region Constructors

        // Class Default Constructor

        static Calls()
        {

            CallList = new List<Call>();

            Calls x = new Calls();
            x.LoadFile();

        }

        #endregion

        #region Public Methods

        // A desenvolver na fase 2

        // Verifica se já existe uma convocatória para o dia de jogo pretendido
        static public bool CheckCall(int day){

            bool temp = true;

            foreach (Call t in CallList) //Percorre a lista de convocatórias recebida como parâmetro
            {

                if (day == t.Day)
                {
                    temp = true;
                    break; //Usado para parar de percorrer a lista de convocatórias
                }

                else //Break não é usado, para continuar a percorrer a lista até ao fim
                {
                    temp = false;
                }

            }

            return temp; //Devolve "true" se já houver convocatória nesse dia, "false" se não houver
        }

        // Realiza convocatória
        static public bool CallUp(User d, DateTime CallDate, Call r){
            
            Calls x = new Calls();

            bool temp = false;

            CallDate = new DateTime(r.Year, r.Month, r.Day, r.Hour, 0, 0); //Utilizado para criar uma data para a convocatória para ser comparada com a data atual

            int tmp = DateTime.Compare(CallDate, DateTime.Now); //Utilizado para comparar a data da convocatória com a atual

            if (tmp < 0 || tmp == 0) //Menor que 0, a data da convocatória é anterior à data atual; Estritamente igual a 0, a data da convocatória é igual à data atual, que quando o programa foi aberto já não é a mesma
            {

                temp = false;

            }

            else //Se a data for válida
            {

                Random rnd = new Random();

                int pid = rnd.Next(0000, 9999);
                r.ID = pid; //Atribui um valor aleatório de 4 dígitos ao ID da convocatória

                if (CallList.Count == 0) //Se não houver nenhuma convocatória feita, adiciona a nova convocatória à lista e ao ficheiro
                {

                    temp = true;
                    CallList.Add(r);
                    x.WriteFile();

                }

                else //Se já houverem convoactórias feitas
                {

                    bool s = CheckCall(r.Day); //Verificação para ver se existem convocatórias

                    if (s == true)
                    {

                        temp = false;

                    }

                }

            }

            return temp;
        }


        // Mostra as convocatórias feitas pelo utilizador temporário "d"
        // "d" -> Utilizador temporário "d"
        // false - não existem convocatórias feitas;
        // true - as convocatórias foram mostradas com sucesso;
        static public bool ShowCall(User d)
        {

            bool temp = false;

            if (CallList.Count == 0)
            {

                temp = false;
                

            }

            else
            {

                foreach (Call t in CallList)
                {

                    if (t.ID == d.UserID)
                    {

                        temp = true;
                        Console.WriteLine("Data da Convocatória:{0}/{1}/{2} || {3}h || ID da convocatória:{5} \n\n", t.Dia, t.Mes, t.Ano, t.Hora, t.Minutos, t.ID);

                    }

                }

            }

            return temp;

        }


        // Apaga uma convocatória feita pelo Utilizador temporário "d"
        // "d" -> Utilizaqdor temporário "d"</param>
        // false - Convocatória não foi apagada;
        // true - Convocatória apagada com sucesso;

        static public bool DeleteCall(User d)
        {
            bool temp = false;

            Calls x = new Calls();

            if (CallList.Count == 0) //Se não existirem convocatórias feitas
            {

                temp = false;

            }

            else //Se existirem convocatórias feitas
            {

                Console.WriteLine("Introduza o ID da convocatória que deseja apagar:");
                int id = Int32.Parse(Console.ReadLine());

                foreach (Call t in CallList) //Percorre a lista de convocatórias até encontrar igual
                {

                    if (t.id == d.UserID && t.ID == id) //Encontrar a convocatória
                    {

                        Console.WriteLine("Data da convocatória:{0}/{1}/{2} || {3}h || ID da convocatória:{4} \n\n\n", t.Dia, t.Mes, t.Ano, t.Hora, t.ID);

                        Console.WriteLine("Estes são os dados da convocatória que pretende eliminar. Tem a certeza que a pretende apagá-la?\n\n");
                        Console.WriteLine("\t1-Sim;\n");
                        Console.WriteLine("\t2-Não;\n\n");

                        Console.WriteLine("Opção:");
                        int option = Int32.Parse(Console.ReadLine());

                        switch (option)
                        {

                            default:
                                Console.WriteLine("\nIntroduza uma opção válida!");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case 1:
                                temp = true;
                                CallList.Remove(t);
                                x.WriteFile();
                                break;

                            case 2:
                                Console.WriteLine("\nSerá redirecionado para o Menu!");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                        }

                        break; //Usado para parar de percorrer a lista de convocatórias

                    }

                }

            }

            return temp;
        }

        #endregion

        #region Private Methods

        // Carrega ficheiro que contém objecto (que por sua vez contém os dados da lista) guardado de forma persistente para a aplicação
        protected override void LoadFile()
        {
            // Declaração de variáveis locais
            string FilePath;
            Stream stream;

            // Definir caminho absoluto de onde o ficheiro de texto será carregado
            FilePath = Environment.CurrentDirectory + "//" + DATAFILE;

            // Se o ficheiro alvo não existir, ignorar o resto das iterações do presente método
            if (File.Exists(FilePath) == false) return;

            // Inicializar stream de leitura através da abertura do ficheiro onde os dados estão guardados  
            stream = File.Open(FilePath, FileMode.Open);

            // Inicializar classe responsável por serializar dados em binário
            var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            // Carregar binário "desserializado" para o objecto que contém os dados
            CallList = (List<Call>)serializer.Deserialize(stream);

            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();
        }

        // Guarda objecto que contém a lista em binário
        protected override void WriteFile()
        {
            // Declaração de variáveis locais
            string FilePath;
            Stream stream;

            // Definir caminho absoluto onde o ficheiro de texto será criado e escrito
            FilePath = Environment.CurrentDirectory + "//" + DATAFILE;

            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(FilePath);

            // Inicializar classe responsável por serializar os dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            // Serializar objecto que contém os dados em binário
            serializador.Serialize(stream, CallList);

            // Fechar stream de escrita de modo a libertar os recursos do sistema
            stream.Close();
        }

        #endregion

    }
}

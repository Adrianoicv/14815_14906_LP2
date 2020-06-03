using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using BO;

namespace DL
{
    public class Users : File
    {

        #region Constant

        const string DATAFILE = "Users.dat";

        #endregion

        #region Var

        private static List<User> UserList;

        #endregion

        #region Constructors

        /// <summary>
        /// Class Default Constructor
        /// </summary>
        static Users()
        {

            UserList = new List<User>();

            Users x = new Users();
            x.LoadFile();

        }

        #endregion

        #region Public Methods

        static public bool CheckUser(int id)
        {

            bool temp = true;

            foreach (User c in UserList) //Percorre a lista de utilizadores recebida como parâmetro
            {

                if (id == c.UserID)
                {

                    temp = true;
                    break; //Usado para parar de percorrer a lista de utilizadores

                }

                else //Break não é usado para continuar a percorrer a lista até ao fim, caso os ID's comparados não sejam iguais
                {

                    temp = false;

                }

            }

            return temp;
        }

        // Verifica se já existe Login

        static public bool CheckUserLogin(User d)
        {                  

            bool temp = true;  

            foreach (User u in UserList)
            {
               temp = d.ID == u.ID && d.Name == u.Name && d.Password == u.Password ? true : false;
            }

            return temp;

        }

        // Regista um utilizador na lista e escreve-o no ficheiro de texto "Users.dat"

        static public bool UserRegister(User d){
            
            Users x = new Users();

            if (CheckUser(d.Nif) == true)
                return false;

            if (UserList.Count == 0)
                d.UserID = 1;

            else
            {

                int prev = UserList[UserList.Count - 1].UserID;
                d.UserID = prev + 1; //Adiciona o valor de UserID ao novo utilizador, incrementando o do último por 1

            }

            UserList.Add(d);
            x.WriteFile();
            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Carrega ficheiro que contém objecto (que por sua vez contém os dados da lista) guardado de forma persistente para a aplicação
        /// </summary>
        protected override bool LoadFile()
        {

            // Declaração de variáveis locais
            string FilePath;
            Stream stream;

            // Definir caminho absoluto de onde o ficheiro de texto será carregado
            FilePath = Environment.CurrentDirectory + "\\" + DATAFILE;

            // Se o ficheiro alvo não existir, ignorar o resto das iterações do presente método
            if (File.Exists(FilePath) == false) return false;

            // Inicializar stream de leitura através da abertura do ficheiro onde os dados estão guardados  
            stream = File.Open(FilePath, FileMode.Open);

            // Inicializar classe responsável por serializar dados em binário
            var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            // Carregar binário "desserializado" para o objecto que contém os dados
            UserList = (List<User>)serializer.Deserialize(stream);

            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();

        }

        /// <summary>
        /// Guarda objecto que contém a lista em binário
        /// </summary>
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
            var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            // Serializar objecto que contém os dados em binário
            serializer.Serialize(stream, UserList);

            // Fechar stream de escrita de modo a libertar os recursos do sistema
            stream.Close();

        }

        #endregion

    }
}
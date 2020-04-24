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
        /// Class Default ConstructorC
        /// </summary>
        static Users()
        {

            UserList = new List<User>();

            Users x = new Users();
            x.LoadFile();

        }

        #endregion

        #region Public Methods

        //A desenvolver na fase 2
        //static public bool CheckUser(User d)


        // Verifica se já existe Login

        static public bool CheckUserLogin(User d)
        {                    

            foreach (User u in UserList)
            {
               bool aux = d.Name == c.Name && d.Password == c.Password ?  true :  false;
            }

            return aux;

        }

        // Regista um utilizador na lista e escreve-o no ficheiro de texto "Users.dat"

        //A desenvolver na fase 2
        static public bool UserRegister(User d);

        // Altera os dados do Utilizador

        //A desenvolver na fase 2
        static public bool AlterData(User d, string name, string password);

        #endregion

        #region Private Methods

        //A desenvolver na fase 2
        protected override bool LoadFile();
        protected override void WriteFile();

        #endregion

    }
}
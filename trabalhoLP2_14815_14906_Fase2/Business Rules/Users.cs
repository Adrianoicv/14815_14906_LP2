using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DL;
using BO;

namespace BR
{
    public class Users
    {

        #region Public Methods


        // Compara o o nome e a password introduzidos pelo utilizador no login com os das listas


        // name - Nome introduzido pelo utilizador no login
        // password - Password introduzida pelo utilizador no login

        /// true = já existe;
        /// false = não existe;

        static public bool CheckUserLogin(User d)
        {

            return DL.Users.CheckUserLogin(d);

        }

        // Regista um utilizador na lista e escreve-o no ficheiro de texto "Users.dat"

        // 0 - já existe;
        // 1 - foi registado com sucesso;

        static public bool UserRegister(User d)
        {

            return DL.Users.UserRegister(d);

        }

        static public bool CheckUser(User d)
        {
            return DL.Users.CheckUser(d.ID);
        }

        #endregion

    }
}

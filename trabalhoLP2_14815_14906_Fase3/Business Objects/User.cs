using System;
using System.Collections.Generic;
using System.Linq;

namespace BO
{

    public class User
    {

        #region Var
        string name, password;
        int UserID;

        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }

        public string Password { get => password; set => password = value; }

        public int UserID { get => userid; set => userid = value; }

        #endregion

        #region Contructors

        /// <summary>
        /// Default Class constructor
        /// </summary>
        public User()
        {

            this.Name = default(string);
            this.Password = default(string);

        }

        // name = Nome do Utilizador
        // pasword = Password do Utilizador

        public User(string name, string password)
        {

            this.Name = name;
            this.Password = password;

        }

        #endregion

    }
}
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

        // Tudo a desenvolver na fase 2

        #region Additional Methods

        static public bool Login(User d);
        static public void Menu(User d);
        static public void Start(User d);
        static public void UserRegister();
        static public void AlterData(User d);
        static public void ShowData(User d);
        static public void CallUp(User d);
        static public void ShowCall(User d);
        static public void DeleteCall(User d);

        #endregion

    }
}
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
        static public bool CheckCall();

        // Realiza convocatória
        static public bool CallUp();

        static public bool ShowCall();

        static public bool DeleteCall();

        #endregion

        #region Private Methods

        // A desenvolver na fase 2

        protected override void LoadFile();
        protected override void WriteFile();

        #endregion

    }
}

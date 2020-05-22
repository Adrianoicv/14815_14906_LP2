using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DL;

namespace BR
{
    public class Calls
    {

        #region Public Methods

        // Faz a convocatória com o utilizador temporário "d"
 
        // 0 - Já existe convocatória;
        // 1 - Convocatória feita com sucesso;

        static public bool CallUp(User d, DateTime GameDate, Call y)
        {

            return DL.Calls.CallUp(d, GameDate, y);

        }

        // Mostra as convocatórias feitas

        // 0 - Não existem convocatórias feitas;
        // 1 - Mostra as convocatórias;
        static public bool ShowCall(User d)
        {

            return DL.Calls.ShowCall(d);

        }


        // Apaga uma convocatória feita

        // 0 - convocatória não foi apagada;
        // 1 - convocatória apagada com sucesso;

        static public bool DeleteCall(User d)
        {

            return DL.Calls.DeleteCall(d);

        }

        #endregion

    }
}
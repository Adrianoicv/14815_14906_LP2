using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{

    public class Call
    {

        #region Var

        int GameDay, GameMonth, GameYear, GameHour, GameLocation, GameOpponent;

        #endregion

        #region Properties

        public int Day { get => GameDay; set => GameDay = value; }
        public int Month { get => GameMonth; set => GameMonth = value; }
        public int Year { get => GameYear; set => GameYear = value; }
        public int Hour { get => GameHour; set => GameHour = value; }
        public char Location { get => GameLocation; set => GameLocation = value; }
        public char Opponent { get => GameOpponent; set => GameOpponent = value; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Class Constructor
        /// </summary>
        public Call()
        {

            this.Day = default(int);
            this.Month = default(int);
            this.Year = default(int);
            this.Hour = default(int);
            this.Location = default(char);
            this.Opponent = default(char);

        }

        // day - Dia do jogo da convocatória
        // month - Mês do jogo da convocatória
        // year - Ano do jogo da convocatória
        // hour - Hora do jogo da convocatória
        // location - Localização do jogo da convocatória
        // opponent - Adversário do jogo da convocatória

        public Call(int day, int month, int year, int hour, char location, char opponent)
        {

            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.Hour = hour;
            this.Location = location;
            this.Opponent = opponent;

        }

        #endregion

    }
}

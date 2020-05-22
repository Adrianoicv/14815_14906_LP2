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

        int GameDay, GameMonth, GameYear, GameHour, CallID;
        char GameLocation, GameOpponent;

        #endregion

        #region Properties

        public int Day { get => GameDay; set => GameDay = value; }
        public int Month { get => GameMonth; set => GameMonth = value; }
        public int Year { get => GameYear; set => GameYear = value; }
        public int Hour { get => GameHour; set => GameHour = value; }
        public char Location { get => GameLocation; set => GameLocation = value; }
        public char Opponent { get => GameOpponent; set => GameOpponent = value; }
        public int ID
        {
        get { return CallID; }
            set
            {
                if ((value.ToString()).Length == 4)
                {

                    CallID = value;

                }

            }

        }

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
            this.ID = default(int);

        }

        // day - Dia do jogo da convocatória
        // month - Mês do jogo da convocatória
        // year - Ano do jogo da convocatória
        // hour - Hora do jogo da convocatória
        // location - Localização do jogo da convocatória
        // opponent - Adversário do jogo da convocatória
        // ID - ID da convocatória

        public Call(int day, int month, int year, int hour, char location, char opponent, int id)
        {

            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.Hour = hour;
            this.Location = location;
            this.Opponent = opponent;
            this.ID = id;

        }

        #endregion

    }
}

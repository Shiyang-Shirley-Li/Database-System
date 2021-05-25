using System;
/// <summary>
/// Author: Shiyang(Shirley) Li
/// Date:03/17/2021
/// Course: CS 5530, University of Utah, School of Computing
/// Copyright: CS 5530 and Shiyang(Shirley) Li - This work may not be copied for use in Academic Coursework.
/// 
/// This file is to represent one instance of a Chess game, such as the players, round, result, moves, event name and date, ...
/// </summary>
namespace ChessTools
{

    public class ChessGame
    {
        public String EventName;
        public String EventSite;
        public String Round;
        public String WhitePlayerName;
        public String BlackPlayerName;
        public int WhiteElo;
        public int BlackElo;
        public String Result;
        public String EventDate;
        public String Moves;

        /// <summary>
        /// Constructor for ChessGame
        /// </summary>
        /// <param name="EventName"></param>
        /// <param name="EventSite"></param>
        /// <param name="Round"></param>
        /// <param name="WhitePlayerName"></param>
        /// <param name="BlackPlayerName"></param>
        /// <param name="WhiteElo"></param>
        /// <param name="BlackElo"></param>
        /// <param name="Result"></param>
        /// <param name="EventDate"></param>
        /// <param name="Moves"></param>
        public ChessGame(String EventName, String EventSite, String Round, String WhitePlayerName,
            String BlackPlayerName, int WhiteElo, int BlackElo, String Result, String EventDate, String Moves)
        {
            this.EventName = EventName;
            this.EventSite = EventSite;
            this.Round = Round;
            this.WhitePlayerName = WhitePlayerName;
            this.BlackPlayerName = BlackPlayerName;
            this.WhiteElo = WhiteElo;
            this.BlackElo = BlackElo;
            this.Result = Result;
            this.EventDate = EventDate;
            this.Moves = Moves;
        }
    }
}

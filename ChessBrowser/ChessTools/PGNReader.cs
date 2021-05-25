using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// Author: Shiyang(Shirley) Li
/// Date:03/17/2021
/// Course: CS 5530, University of Utah, School of Computing
/// Copyright: CS 5530 and Shiyang(Shirley) Li - This work may not be copied for use in Academic Coursework.
/// 
/// This file is to provide methods to return (for example) a List<ChessGame> given a path to a PGN file
/// </summary>
namespace ChessTools
{

    public class PGNReader
    {
        /// <summary>
        /// This function reads the PGN file
        /// Given a file path, parses the PGN file, reads the file line by line,
        /// writes the file into a list
        /// </summary>
        /// <param name="filePath">the file path of PGN file</param>
        /// <returns>A list of Chess Games</returns>
        public List<ChessGame> ReadPGNFile(String filePath)
        {
            List<ChessGame> chessGames = new List<ChessGame>();
            String[] lines = File.ReadAllLines(filePath);

            int blankLineNum = 0;
            String eventName = "";
            String eventSite = "";
            String round = "";
            String whitePlayer = "";
            String blackPlayer = "";
            int whiteElo = 0;
            int blackElo = 0;
            String result = "";
            String eventDate = "";
            String moves = "";

            foreach (String line in lines)
            {
                int startIndex = line.IndexOf(" ") + 2; //2 due to /"
                int endIndex = (line.Length - 2) - startIndex;

                if (line.StartsWith("[Event "))
                {
                    eventName = line.Substring(startIndex, endIndex);

                }
                else if (line.StartsWith("[Site "))
                {
                    eventSite = line.Substring(startIndex, endIndex);
                }
                else if (line.StartsWith("[Round "))
                {
                    round = line.Substring(startIndex, endIndex);
                }
                else if (line.StartsWith("[White "))
                {
                    whitePlayer = line.Substring(startIndex, endIndex);
                }
                else if (line.StartsWith("[Black "))
                {
                    blackPlayer = line.Substring(startIndex, endIndex);
                }
                else if (line.StartsWith("[WhiteElo "))
                {
                    whiteElo = Int32.Parse(line.Substring(startIndex, endIndex));
                }
                else if (line.StartsWith("[BlackElo "))
                {
                    blackElo = Int32.Parse(line.Substring(startIndex, endIndex));
                }
                else if (line.StartsWith("[Result "))
                {
                    result = line.Substring(startIndex, endIndex);
                    if (result.Equals("1-0"))
                    {
                        result = "W";
                    }
                    else if (result.Equals("0-1"))
                    {
                        result = "B";
                    }
                    else
                    {
                        result = "D";
                    }
                }
                else if (line.StartsWith("[EventDate "))
                {
                    eventDate = line.Substring(startIndex, endIndex);
                    if (eventDate.Contains("?"))
                    {
                        eventDate = "0000-00-00";
                    }
                }
                if (line == String.Empty)
                {
                    blankLineNum++;
                }
                if (blankLineNum == 1)//first blank line means next line is moves;
                {
                    moves += line;//moves can be more than one line
                }
                else if (blankLineNum == 2)//second blank line means next line is next game
                {
                    chessGames.Add(new ChessGame(eventName, eventSite, round, whitePlayer, blackPlayer,
                        whiteElo, blackElo, result, eventDate, moves));

                    //reinitialize for next chess game
                    blankLineNum = 0;
                    eventName = "";
                    eventSite = "";
                    round = "";
                    whitePlayer = "";
                    blackPlayer = "";
                    whiteElo = 0;
                    blackElo = 0;
                    result = "";
                    eventDate = "";
                    moves = "";
                }
            }
            return chessGames;
        }
    }
}

/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        //Creates an empty map/disctionary
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row

        
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // If the player ID is already in the dictionary yet, add it with the corresponding point
            if (!players.ContainsKey(playerId))
            {
                players[playerId] = points;
            }

            // If the player is already in the dictionary, update its points
            else
            {
                players[playerId] += points;
            }
        }

        var sortedPlayers = players.OrderByDescending(pair => pair.Value).ToArray();

        var topPlayers = sortedPlayers.Take(10);
        foreach (var topPlayer in topPlayers)
        {
            Console.WriteLine(topPlayer);
        }

        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");
        

        // var topPlayers = new string[10];
        


    }
}
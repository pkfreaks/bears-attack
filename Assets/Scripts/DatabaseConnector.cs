using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;

public class DatabaseConnector 
{
    public static readonly string ConnectionString = "URI=file:" + Application.dataPath + "/Database/Database.db";

    public IList<Character> LoadCharacters()
    {
        IList<Character> characters = new List<Character>();
        using (IDbConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            using (IDbCommand command = connection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Character";
                command.CommandText = sqlQuery;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var character = new Character(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            Convert.ToBoolean(reader.GetInt32(2)),
                            Convert.ToBoolean(reader.GetInt32(3)),
                            reader.GetInt32(3));

                        characters.Add(character);
                    }
                    connection.Close();
                    reader.Close();
                }
            }
        }
        return characters;
    }

    public void SetActiveCharacter(Character character)
    {
        using (IDbConnection connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Character SET isActive = 0";
                command.ExecuteNonQuery();
            }

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Character SET isActive = 1 WHERE id = " + character.ID;
                command.ExecuteNonQuery();
            }
        }
    }
}

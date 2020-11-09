using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class dbConn : MonoBehaviour
{
    private string conn;

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    public int topRanks;

    public void Start()
    {
        highScores.Clear();

        conn = "URI=file:" + Application.dataPath + "/db/db.db";

        ShowScores();
    }

    //Update ranking after click Ranking button - needed?
    /*
    public void EnterRanking()
    {
        highScores.Clear();

        Debug.Log(highScores.Count);

        conn = "URI=file:" + Application.dataPath + "/db/db.db";

        ShowScores();
    }
    */
    public void ReadScores() 
    {
        
        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();

            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM SCORES";
                dbcmd.CommandText = sqlQuery;

                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3)));
                    }
                    dbconn.Close();
                    reader.Close();
                }
            }
        }
        highScores.Sort();
    }

    private void ShowScores()
    {
        ReadScores();
        for (int i = 0; i < topRanks; i++)
        {
            if (i <= highScores.Count - 1)
            {

                GameObject tmpObject = Instantiate(scorePrefab);

                HighScore tmpScore = highScores[i];

                tmpObject.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());

                tmpObject.transform.SetParent(scoreParent);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
using System.IO;

public class dbConn : MonoBehaviour
{
    private string conn;

    private List<HighScore> highScores = new List<HighScore>();
    private List<Character> fetchedCharacters = new List<Character>();
    private Character currentCharacter;

    public RawImage playerModel;
    public RawImage previewPlayerModel;
    public GameObject scorePrefab;

    public List<Texture2D> textures;
    private int currentTexture = 0;

    public Transform scoreParent;

    public int topRanks;

    public void Start()
    {
        highScores.Clear();

        conn = "URI=file:" + Application.dataPath + "/db/db.db";

        ShowScores();
    }

    public void LoadPreviousAsset()
    {
        currentTexture -= 1;
        if (currentTexture < 0) { currentTexture = textures.Count - 1; }
        loadAsset();
    }

    private void loadAsset()
    {
        Debug.Log(currentTexture);
        previewPlayerModel.texture = textures[currentTexture];
    }

    public void LoadNextAsset()
    {
        currentTexture += 1;
        if (currentTexture >= textures.Count) { currentTexture = 0 ; }
        loadAsset();
    }

    private void ReadScores() 
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

                GameObject scoreView = Instantiate(scorePrefab);

                HighScore currentScore = highScores[i];

                scoreView.GetComponent<HighScoreManager>().SetScore(currentScore.Name, currentScore.Score.ToString(), "#" + (i + 1).ToString());

                scoreView.transform.SetParent(scoreParent);
            }
        }
    }
}

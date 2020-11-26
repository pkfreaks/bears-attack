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
    private int texture = 0;

    public Transform scoreParent;

    public int topRanks;

    public void Start()
    {
        highScores.Clear();

        conn = "URI=file:" + Application.dataPath + "/db/db.db";

        ShowScores();
        fetchCharacters();
        setCurrentActiveCharacter(currentCharacter);
    }

    public void LoadPreviousAsset()
    {
        texture -= 1;
        if (texture < 0) { texture = textures.Count - 1; }
        loadAsset();
    }

    private void loadAsset()
    {
        previewPlayerModel.texture = textures[texture];
    }

    public void LoadNextAsset()
    {
        texture += 1;
        if (texture >= textures.Count) { texture = 0 ; }
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

    private void fetchCharacters()
    {
        using (IDbConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();

            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Character";
                dbcmd.CommandText = sqlQuery;

                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var character = new Character(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(3));

                        if (character.isActive && character.isUnlocked) {
                            currentCharacter = character;
                        }

                        fetchedCharacters.Add(character);
                    }
                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    private void setCurrentActiveCharacter(Character character)
    {
        var filePath = Application.dataPath + "Assets/Images/Player models/" + character.Name + ".png";
        Texture2D t = Resources.Load<Texture2D>("Images/Player models/" + character.Name + ".png");

        if (File.Exists(filePath))
        {
            Texture2D tex2D;
            byte[] FileData;

            FileData = File.ReadAllBytes(filePath);
            tex2D = new Texture2D(2, 2);

            if (tex2D.LoadImage(FileData))
            {
                playerModel = GameObject.Find("Main Player Image").GetComponent<RawImage>();
                previewPlayerModel = GameObject.Find("Preview Player Image").GetComponent<RawImage>();

                playerModel.texture = tex2D;
                previewPlayerModel.texture = tex2D;
            }
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class HighScore
{ 
    public int Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }
    public string Date { get; set; }

    public HighScore(int id, int score, string name, string date)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
        this.Date = date;
    }
}
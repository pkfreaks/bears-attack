using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class HighScore : IComparable<HighScore>
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

    public int CompareTo(HighScore other)
    {
        if (other.Score < this.Score)
        {
            return -1;
        }
        else if (other.Score > this.Score)
        {
            return 1;
        }
        else if (other.ID < this.ID)
        {
            return -1;
        }
        else if (other.ID > this.ID)
        {
            return 1;
        }

        return 0;
    }
}
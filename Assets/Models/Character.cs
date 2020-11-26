using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Character : IComparable<Character>
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool isUnlocked { get; set; }
    public bool isActive { get; set; }
    public int price { get; set; }

    public Character(int id, string name, int isUnlocked, int isActive, int price)
    {
        this.ID = id;
        this.Name = name;
        this.isUnlocked = Convert.ToBoolean(isUnlocked);
        this.isActive = Convert.ToBoolean(isActive);
        this.price = price;
    }

    public int CompareTo(Character other)
    {
        if (other.price < this.price)
        {
            return -1;
        }
        else if (other.price > this.price)
        {
            return 1;
        }

        return 0;
    }
}
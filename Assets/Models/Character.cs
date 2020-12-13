using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Character : IComparable<Character>
{
    public int ID { get; set; }
    public string Name { get; set; }
    public bool Unlocked { get; set; }
    public bool Active { get; set; }
    public int Price { get; set; }

    public Character(int id, string name, bool unlocked, bool active, int price)
    {
        this.ID = id;
        this.Name = name;
        this.Unlocked = unlocked;
        this.Active = active;
        this.Price = price;
    }

    public int CompareTo(Character other)
    {
        if (other.Price < this.Price)
        {
            return -1;
        }
        else if (other.Price > this.Price)
        {
            return 1;
        }

        return 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Vector2 Position { get; set; }
    public int Health { get; set; }

    public Player(Vector2 position, int health)
    {
        Position = position;
        Health = health;
    }
}

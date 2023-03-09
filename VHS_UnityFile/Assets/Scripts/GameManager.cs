using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    // Static instance variable to hold the single instance of the class
    private static GameManager instance = null;

    // Public property to get the instance of the class
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    // Private constructor to prevent direct instantiation of the class
    private GameManager()
    {
        // Create an instance of the Player class
    }

    // Public property to hold the instance of the Player class
    public Player Player { get; private set; }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public int health;
    public float maxSpeed;
    public int defense;
    public int shield;
    public float damage;

    public int level;
    public float experience;
    public int gunLevel;
    public float statScore;
    public string description;

    public string[] shipType = { "Destructor", "Fragata", "Crucero" };
    
    public int shipTypeID;

    public Vector3 respawn;

    public enum Team
    {
        Alliance,
        Rebel
    }
    public Team team;

    void Start ()
    {
        transform.position = respawn;
    }

    void Update ()
    {
        /*
        if (shipTypeID == 0)
        {
            health = 170;
            maxSpeed = 40;
            defense = 140;
            shield = 70;
            damage = 120;
        }
        if (shipTypeID == 1)
        {
            health = 70;
            maxSpeed = 140;
            defense = 60;
            shield = 50;
            damage = 80;
        }
        if (shipTypeID == 2)
        {
            health = 160;
            maxSpeed = 80;
            defense = 180;
            shield = 60;
            damage = 100;
        }*/
    }
}

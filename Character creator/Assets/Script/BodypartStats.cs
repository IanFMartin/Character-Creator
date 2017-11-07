using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodypartStats : ScriptableObject
{
    public  int life;
    public  int shield;
    public  int force;

    public void infoOfVar (int l, int s, int f)
    {
        life = l;
        shield = s;
        force = f;
    }
}

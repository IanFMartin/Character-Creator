using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Transform headTrasnform;

    [HideInInspector]
    public BodypartStats totalStats;
    [HideInInspector]
    public BodypartStats bodyStats;
    [HideInInspector]
    public BodypartStats headStats;
    [HideInInspector]
    public BodypartStats arm1Stats;
    [HideInInspector]
    public BodypartStats arm2Stats;
    [HideInInspector]
    public BodypartStats leg1Stats;
    [HideInInspector]
    public BodypartStats leg2Stats;

    [HideInInspector]
    public int totalLife;
    [HideInInspector]
    public int totalShield;
    [HideInInspector]
    public int totalForce;

    [HideInInspector]
    public int bodyLife;
    [HideInInspector]
    public int bodyShield;
    [HideInInspector]
    public int bodyForce;

    [HideInInspector]
    public int headLife;
    [HideInInspector]
    public int headShield;
    [HideInInspector]
    public int headForce;

    [HideInInspector]
    public int arm1Life;
    [HideInInspector]
    public int arm1Shield;
    [HideInInspector]
    public int arm1Force;

    [HideInInspector]
    public int arm2Life;
    [HideInInspector]
    public int arm2Shield;
    [HideInInspector]
    public int arm2Force;

    [HideInInspector]
    public int leg1Life;
    [HideInInspector]
    public int leg1Shield;
    [HideInInspector]
    public int leg1Force;

    [HideInInspector]
    public int leg2Life;
    [HideInInspector]
    public int leg2Shield;
    [HideInInspector]
    public int leg2Force;

    /*
    private void Start()
    {
        totalLife = totalStats.life;
        totalShield = totalStats.shield;
        totalForce = totalStats.force;

        headLife = headStats.life;
        headShield = headStats.shield;
        headForce = headStats.force;

        bodyLife = bodyStats.life;
        bodyShield = bodyStats.shield;
        bodyForce = bodyStats.force;

        arm1Life = arm1Stats.life;
        arm1Shield = arm1Stats.shield;
        arm1Force = arm1Stats.force;

        arm2Life = arm2Stats.life;
        arm2Shield = arm2Stats.shield;
        arm2Force = arm2Stats.force;

        leg1Life = leg1Stats.life;
        leg1Shield = leg1Stats.shield;
        leg1Force = leg1Stats.force;

        leg2Life = leg2Stats.life;
        leg2Shield = leg2Stats.shield;
        leg2Force = leg2Stats.force;
    }*/
}

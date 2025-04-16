using System;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    private Monster theMonster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.theMonster = new Monster("Goblin");
        Fight f = new Fight(this.theMonster);
        f.startFight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

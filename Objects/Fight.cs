using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    private Monster theMonster;

    public Fight(Monster m)
    {
        this.theMonster = m;
        int roll = Random.Range(0, 20) + 1;
        if(roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = m;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = m;
        }
    }

    public void startFight()
    {
        while(true)
        {
            int attackRoll = Random.Range(0, 20) + 1;
            if (attackRoll >= this.defender.getAC())
            {
                int damage = Random.Range(1, 6);
                this.defender.takeDamage(damage);

                if (this.defender.isDead())
                {
                    Debug.Log(this.attacker.getName() + " killed " + this.defender.getName());
                    break;
                }
            }
            else
            {
                Debug.Log(this.attacker.getName() + " missed " + this.defender.getName());
            }
            Inhabitant temp = this.attacker;
            this.attacker = this.defender;
            this.defender = temp;
        }
    }
}

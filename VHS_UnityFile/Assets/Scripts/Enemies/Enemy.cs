using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public string enemyType;

    public virtual void Attack()
    {
        Debug.Log("Enemy attacks for " + damage + " damage.");
    }
}

public class Zombie : Enemy
{
    public override void Attack()
    {
        Debug.Log("Zombie attacks for " + damage + " damage with its claws.");
    }
}

public class Vampire : Enemy
{
    public override void Attack()
    {
        Debug.Log("Vampire attacks for " + damage + " damage with its fangs.");
    }
}

public class Boss : Enemy
{
    public int specialAttackDamage;

    public override void Attack()
    {
        Debug.Log("Boss attacks for " + damage + " damage with its weapons.");
    }

    public void SpecialAttack()
    {
        Debug.Log("Boss uses a special attack for " + specialAttackDamage + " damage.");
    }
}


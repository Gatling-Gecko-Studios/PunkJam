using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public enum States
{
    idle,
    chase,
    attack,
    death
}

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Navigation")]
    private States currentState;
    public States startState;
    private NavMeshAgent agent;
    public GameObject target;
    public float movementSpeed;

    [Header("CoolTastic Values")]
    public int health;
    public int damage;
    public float attackRange;
    public float attackCooldown;

    private bool canAttack;

    void Start()
    {
        canAttack = true;
        agent = GetComponent<NavMeshAgent>();
        currentState = startState;
        agent.speed = movementSpeed;
        agent.stoppingDistance = attackRange;
    }

    void Update()
    {
        switch (currentState)
        {
            case States.idle:
                break;

            case States.chase:
                agent.SetDestination(target.transform.position);
                if (InAttackRange())
                {
                    currentState = States.attack;
                    agent.isStopped = true;
                }
                break;

            case States.attack:
                Attack();

                if(!InAttackRange())
                {
                    currentState = States.chase;
                    agent.isStopped = false;
                }
                break;

            case States.death:
                break;
        }
    }

    private bool InAttackRange()
    {
        if (Vector3.Distance
            (
                new Vector3(transform.position.x, 0, transform.position.z), 
                new Vector3(target.transform.position.x, 0, target.transform.position.z)
            ) <= attackRange)
        {
            return true;
        }
        else { return false; }
    }

    private void Attack()
    {
        if(canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCooldown());
            RaycastHit hit;
            if(Physics.Raycast(new Vector3(transform.position.x, 1, transform.position.z), transform.forward, out hit))
            {
                //insert damage code here
                //TODO: check for player layer specifically to avoid damaging other zombies
                Debug.Log("Hit object: " + hit.transform.gameObject.name + " for " + damage + " damage.");
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}

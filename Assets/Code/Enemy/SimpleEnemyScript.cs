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

public class SimpleEnemyScript : MonoBehaviour
{
    [Header("Navigation")]
    private States currentState;
    public States startState;
    private NavMeshAgent agent;
    private GameObject target;
    public float movementSpeed;

    [Header("CoolTastic Values")]
    public int health;
    public int damage;
    public float attackRange;
    public float attackCooldown;

    private bool canAttack;

    [SerializeField] private Animator animator;

    private RagdollStateController ragdollController;

    void Start()
    {
        canAttack = true;
        agent = GetComponent<NavMeshAgent>();
        currentState = startState;
        agent.speed = movementSpeed;
        agent.stoppingDistance = attackRange;
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        ragdollController = GetComponent<RagdollStateController>();
    }

    void Update()
    {
        if (health == 0) return;
        switch (currentState)
        {
            case States.idle:
                break;

            case States.chase:
                agent.SetDestination(target.transform.position);
                animator.SetBool("Chase", true);
                animator.SetBool("Die", false);
                animator.SetBool("Attack", false);
                if (InAttackRange())
                {
                    currentState = States.attack;
                    agent.isStopped = true;
                }
                break;

            case States.attack:
                Attack();
                animator.SetBool("Chase", false);
                animator.SetBool("Die", false);
                animator.SetBool("Attack", true);
                if (!InAttackRange())
                {
                    currentState = States.chase;
                    agent.isStopped = false;
                }
                break;

            case States.death:
                animator.SetBool("Chase", false);
                animator.SetBool("Die", true);
                animator.SetBool("Attack", false);
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
                if(hit.transform.gameObject.tag == "Player")
                {
                    Debug.Log("Hit object: " + hit.transform.gameObject.name + " for " + damage + " damage.");
                    PlayerHealth playerHealth = hit.transform.gameObject.GetComponent<PlayerHealth>();
                    playerHealth.TakeDamage(damage);
                }
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void TakeDamage(int damage, Vector3 direction)
    {
        if (health - damage <= 0)
        {
            Die(direction);
        }
        else
        {
            health -= damage;
        }
    }

    private void Die(Vector3 direction)
    {
        health = 0;
        ragdollController.EnableRagdollAndApplyForce(direction, 30f);
        GetComponent<Collider>().enabled = false;
        Debug.Log("Zombie died, LOL");
    }
}

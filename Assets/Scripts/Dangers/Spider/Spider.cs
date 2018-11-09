using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TakeDamage))]
public class Spider : Enemy
{
    [Header("Spider Variables")]
    public float moveSpeed = 1.5f;
    public float meleeDistance = 2f;
    public float seekRadius = 10f;
    public float turnSpeed = 1;
    public float attackCoolDown = 1;
    public int addExp = 1;
    public Transform wanderMarker;
    public Transform home;
    public float allowedDisFromHome;


    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public Rigidbody rigidbody;
    [HideInInspector]
    public TakeDamage takeDamage;

    private State currentState = State.Wander;
    private float disToTarget;
    private float cooldown;
    private float homeRadius;

    private void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody>();
        takeDamage = GetComponent<TakeDamage>();
    }
    // Update is called once per frame
    void Update()
    {

        if (currentState == State.Attack)
        {
            anim.SetTrigger("Attack");
        }
        else
        {
            anim.ResetTrigger("Attack");
        }
        if (currentState == State.Seek || currentState == State.Wander)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (health <= 0)
        {
            currentState = State.Die;
        }
        switch (currentState)
        {
            case State.Wander:
                Wander();
                break;
            case State.Seek:
                Seek();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Die:
                Die();
                break;
            default:
                Debug.Log("Something went wrong with the spider.");
                break;
        }
        disToTarget = Vector3.Distance(transform.position, target.position);
        homeRadius = Vector3.Distance(transform.position, home.position);
        if (takeDamage.damageTake != 0)
        {
            health -= takeDamage.damageTake;
        }
    }
    void Wander()
    {
        Vector3 tempMarker = wanderMarker.position += new Vector3Int(Random.Range(-1, 1), 0, Random.Range(-1, 1));

        Vector3 MoveDirection;
        MoveDirection = (tempMarker - transform.position).normalized * (moveSpeed/2);
        rigidbody.velocity = new Vector3(MoveDirection.x, rigidbody.velocity.y, MoveDirection.z);

        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(wanderMarker.position.x, transform.position.y, wanderMarker.position.z) - transform.position);
        float str = Mathf.Min(turnSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);

        if (disToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    void Seek()
    {
        Vector3 MoveDirection;
        MoveDirection = (target.position - transform.position).normalized * moveSpeed;
        rigidbody.velocity = new Vector3(MoveDirection.x, rigidbody.velocity.y, MoveDirection.z);

        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position);
        float str = Mathf.Min(turnSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);

        if (disToTarget > seekRadius)
        {
            currentState = State.Wander;
        }
        if (disToTarget < meleeDistance)
        {
            currentState = State.Attack;
        }
    }

    void Attack()
    {
        if (disToTarget <= meleeDistance)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                CharacterHandler.curHealth -= damage;
                cooldown = attackCoolDown;
                target.gameObject.GetComponent<CharacterHandler>().healTimer = target.gameObject.GetComponent<CharacterHandler>().startHealTime;
            }
        }
        if (disToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    public override void Die()
    {
        anim.SetTrigger("Die");
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHandler>().curExp += addExp;
        addExp -= addExp;
        if (addExp <= 0) { addExp = 0; }
        Destroy(gameObject, 1);
        
    }

    public enum State
    {
        Wander,
        Seek,
        Attack,
        Die
    }
}

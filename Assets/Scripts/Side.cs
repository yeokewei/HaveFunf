using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    // Start is called before the first frame update //import game object
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2;
    public GameObject prefabToSpawn3;
    public GameObject prefabToSpawn4;
    public GameObject prefabToSpawn5;

    public AudioSource source;
    public AudioClip evilSound;

    private string currentAnimation;
    private Animator animator;

    //Animation states
    const string ATTACK = "goblinAttack";
    const string IDLE = "goblinIdle";
    const string LEFT = "leftAnimation";
    const string RIGHT = "rightAnimation";

    public float moveSpeed = 5.0f;
    // public float minX = -5.0f;
    // public float maxX = 5.0f;
    // positions left right and middle
    public float leftPosition = -3.7f;
    public float rightPosition = 2f;
    public float middlePosition = 0.0f;

    public float minDelay = 1.0f;
    public float maxDelay = 3.0f;
    public float attackCooldown = 2.0f;

    private float nextMoveTime;
    private float nextAttackTime;
    private float targetX;
    private float fixedY;
    private float fixedZ;

    private string caseCurrent;

    private List<string> cases = new List<string>();
    // private HashSet<string> pickedCases = new HashSet<string>();

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetRandomNextMoveTime();
        targetX = transform.position.x;
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
        cases.Add("Left");
        cases.Add("Right");
        cases.Add("Middle");
        caseCurrent = "Middle";
    }

    private void Update()
    {
        if (Time.time >= nextMoveTime)
        {
            // Pick a random case from the list of cases
            string caseToPick = cases[Random.Range(0, cases.Count)];

            // Check if the case has already been picked
            while (caseToPick == caseCurrent)
            {
                caseToPick = cases[Random.Range(0, cases.Count)];
            }

            // // The case has not been picked yet, so pick it
            // pickedCases.Add(caseToPick);

            // Print the case
            Debug.Log(caseToPick);
            caseCurrent = caseToPick;

            // switch case to pick
            switch (caseToPick)
            {
                case "Left":
                    targetX = leftPosition;
                    break;
                case "Right":
                    targetX = rightPosition;
                    break;
                case "Middle":
                    targetX = middlePosition;
                    break;
            }

            nextMoveTime = Time.time + Random.Range(minDelay, maxDelay);
            // UpdateDirection();
        }

        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = nextMoveTime + attackCooldown;
        }

        Move();
    }

    private void Move()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, fixedY, fixedZ), step);
        if (transform.position.x < targetX)
        {
            ChangeAnimationState(RIGHT);
        }
        else
        {
            ChangeAnimationState(LEFT);
        }
    }

    private void Attack()
    {
        Debug.Log("Enemy attacks!");
        ChangeAnimationState(ATTACK);

        GameObject[] prefabs = { prefabToSpawn, prefabToSpawn2, prefabToSpawn3, prefabToSpawn4, prefabToSpawn5 };
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject randomPrefab = prefabs[randomIndex];
        GameObject spawnedPrefab = Instantiate(randomPrefab, transform.position, Quaternion.identity);

        source.PlayOneShot(evilSound);
    }

    // private void UpdateDirection()
    // {
    //     if (transform.position.x < targetX)
    //     {
    //         movingRight = true;
    //     }
    //     else
    //     {
    //         movingRight = false;
    //     }
    // }

    private void SetRandomNextMoveTime()
    {
        nextMoveTime = Time.time + Random.Range(minDelay, maxDelay);
    }
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;

    }
}
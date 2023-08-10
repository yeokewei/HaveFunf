using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    // Start is called before the first frame update //import game object
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2;


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

    public float minDelay = 3.0f;
    public float maxDelay = 7.0f;
    public float attackCooldown = 4.0f;

    private float nextMoveTime;
    private float nextAttackTime;
    private float targetX;
    private float fixedY;
    private float fixedZ;

    private string caseCurrent;

    private List<string> cases = new List<string>();
    // private HashSet<string> pickedCases = new HashSet<string>();

    public float attackDuration = 1.5f; // Wait duration in seconds

    private bool isAttacking = false;
    private float attackTimer = 0.0f;


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
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                isAttacking = false;
                attackTimer = 0.0f;
            }
        }
        else
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
                //delay between attacks
            }
            else
            {
                if (transform.position.x != targetX)
                {
                    Move();
                    if (transform.position.x < targetX)
                    {
                        ChangeAnimationState(RIGHT);
                    }
                    else if (transform.position.x > targetX)
                    {
                        ChangeAnimationState(LEFT);
                    }
                }
                else
                {
                    Debug.Log("Enemy is idle");
                    ChangeAnimationState(IDLE);
                }
            }

        }
    }

    private void Move()
    {

        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, fixedY, fixedZ), step);

    }

    private void Attack()
    {
        isAttacking = true;
        Debug.Log("Enemy attacks!");
        ChangeAnimationState(ATTACK);

        GameObject[] prefabs = { prefabToSpawn, prefabToSpawn2 };
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject randomPrefab = prefabs[randomIndex];

        // Vector3 originalVector = transform.position; // Set your desired position values
        // Quaternion rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f); // Example rotation of 180 degrees around local Y-axis

        // // Rotate the vector by applying the rotation
        // Vector3 rotatedVector = rotation * originalVector;
        GameObject spawnedPrefab = Instantiate(randomPrefab, transform.position, Quaternion.identity);
        source.PlayOneShot(evilSound);

    }


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
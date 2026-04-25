using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class EnemyMovement : MonoBehaviour
{
    // Reference to the player's transform.
    public Transform player;
    public AudioSource audioSource;

    // Reference to the NavMeshAgent component for pathfinding.
    private NavMeshAgent navMeshAgent;

    private Animator anim;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the NavMeshAgent component attached to this object.
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim.SetFloat("speed_f", 1);
    }

    // Update is called once per frame.
    void Update()
    {
        // If there's a reference to the player...
        if (player != null)
        {
            // Set the enemy's destination to the player's current position.
            navMeshAgent.SetDestination(player.position);
        }
    }
}
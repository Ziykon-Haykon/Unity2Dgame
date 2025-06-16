using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Platformer2D.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamingPosition;
    private Vector3 startPosition;


    private enum State
    {
        Roaming,
    }



    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false; // Disable automatic rotation to control it manually
        navMeshAgent.updateUpAxis = false; // Disable automatic up-axis updates
        state = startingState;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                roamingTime -= Time.deltaTime;

                if (roamingTime <= 0)
                {
                    Roaming();
                    roamingTime = roamingTimerMax;
                }

                break;
        }
    }

    private void Roaming()
    {
        startPosition = transform.position;
        roamingPosition = GetRoamingPosition();
        ChangeFacingDirection(transform.position, roamingPosition);
        navMeshAgent.SetDestination(roamingPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return startPosition + Utils.GetRandomDirection() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }

    private void ChangeFacingDirection(Vector3 sourcePosition, Vector3 targetPosition)
    {
        if (targetPosition.x > sourcePosition.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Facing right
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Facing left
        }
    }

}

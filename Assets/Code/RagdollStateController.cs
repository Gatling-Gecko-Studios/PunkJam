using UnityEngine;
using UnityEngine.AI;

public class RagdollStateController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform ragdollRoot;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Rigidbody[] rigidbodies;
    [SerializeField] private CharacterJoint[] joints;

    private void Awake()
    {
        rigidbodies = ragdollRoot.GetComponentsInChildren<Rigidbody>();
        joints = ragdollRoot.GetComponentsInChildren<CharacterJoint>();
    }

    private void Start()
    {
         EnableAnimator();
    }

    public void EnableRagdoll()
    {
        animator.enabled = false;
        agent.enabled = false;
        foreach (CharacterJoint joint in joints)
        {
            joint.enableCollision = true;
        }
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.detectCollisions = true;
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }

    public void DisableAllRigidbodies()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.detectCollisions = false;
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    public void EnableAnimator()
    {
        animator.enabled = true;
        agent.enabled = true;
        foreach (CharacterJoint joint in joints)
        {
            joint.enableCollision = false;
        }
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }


    public void EnableRagdollAndApplyForce(Vector3 forceDirection, float forceMagnitude)
    {
        EnableRagdoll();

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }
}

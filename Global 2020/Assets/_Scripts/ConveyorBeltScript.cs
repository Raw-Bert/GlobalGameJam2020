using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour
{

    [Range(-10, 10)] public float speed = 1;
    public float centerWidth = 1;
    public bool play;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }


    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        play = true;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>

    private void OnCollisionStay(Collision other)
    {

        var otherRB = other.gameObject.GetComponent<Rigidbody>();
        var otherTrans = other.transform;
        if (otherRB)
        {
            //if (InRange(otherTrans.position * new Vector3(1, 0, 1) - transform.position * new Vector3(1, 0, 1), centerWidth / 2 * transform.forward, centerWidth / 2 * -transform.forward))
            //{
            //    play = false;
            //}

            otherRB.constraints = RigidbodyConstraints.FreezeRotation;
            otherRB.velocity = new Vector3();
            if (play)
            {
                otherRB.velocity = otherRB.velocity + (speed * transform.forward);


            }

        }
    }

    private void OnCollisionExit(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().constraints = 0;
    }


    private Vector3 multiVec3(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    //public static  bool operator<=(Vector3 a,Vector3 b)=> a.magnitude >= 

    //public static Vector3 operator *(Vector3 a, Vector3 b)
    //{
    //
    //    return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    //}

    private bool InRange(Vector3 check, Vector3 low, Vector3 high)
    {

        return (low - check).magnitude <= (high - check).magnitude;
    }

}

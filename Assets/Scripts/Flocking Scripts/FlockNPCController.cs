using UnityEngine;
using System.Collections;

public class FlockNPCController : MonoBehaviour {
    public FlockController controller;
    public bool tooClose = false;
    private Vector3 distFromPlayer, playerHeading = Vector3.zero;

    IEnumerator Start()
    {
        while (true)
        {
            if (controller)
            {
                Vector3 tempVec = Steer() * Time.deltaTime;
                if(distFromPlayer.magnitude < controller.minDistFromPlayer)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else
                {
                    //CharacterController controllerCH = GetComponent<CharacterController>();
                    //controllerCH.Move(tempVec * 10);
                    GetComponent<Rigidbody>().velocity += tempVec;
                }
                float speed = GetComponent<Rigidbody>().velocity.magnitude;
                if(speed > controller.MaxVelocity)
                {
                    //Quering GetComponent every time is that an efficient way? In this case we could define a start function and assign the rigid body to one variable 
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * controller.MaxVelocity; 
                }
                else if(speed < controller.MinVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * controller.MinVelocity;
                }
                float waitTime = Random.Range(0.3f, 0.5f);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    Vector3 Steer()
    {
        distFromPlayer = controller.transform.position - transform.position;
        if(distFromPlayer.magnitude > controller.maxDistFromPlayer)
        {
            //print("Hello");
            //distFromPlayer = -distFromPlayer;
        }
        //playerHeading = controller.transform.forward;
        Transform player = controller.transform;
        //playerHeading = player.GetComponent<Rigidbody>().velocity;
        return distFromPlayer + playerHeading;
    }

    void OnCollisionEnter(Collision col)
    {
        print(col);
    }
}

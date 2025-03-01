using UnityEngine;
using System.Collections;

public class EggMover : MonoBehaviour 
{
    void Awake()
    {
        //rigidbody.AddForce(new Vector3(0, -100f, 0), ForceMode.Force);
    }

	void Update () 
	{
//        float fallSpeed = 2 * Time.deltaTime;
//        transform.position -= new Vector3(0, fallSpeed, 0);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
	}
}

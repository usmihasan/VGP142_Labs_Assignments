using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{
    bool canSeeEnemy = false;

    public float sightDistance = 100f;

    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Vector3 offsetOnY = transform.position;
        //offsetOnY.y += 0.2f;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, sightDistance))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                //gameObject.SetActive(false);
                mesh.enabled = false;
            }
            else
            {
                //mesh.enabled = true;
            }
        }

        Vector3 dir = transform.TransformDirection(Vector3.forward) * sightDistance;

        Debug.DrawRay(transform.position, dir, Color.red);
    }
}

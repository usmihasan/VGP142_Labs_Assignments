using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum CollectibleType
    {
        AXE_OS,
        AXE_DS,
        SWORD_OH,
        SWORD_DH,
        HAMMER,

    }

    public CollectibleType currentCollectible;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Character ch = collision.gameObject.GetComponent<Character>();

            switch (currentCollectible)
            {
                case CollectibleType.AXE_OS:
                    Debug.Log("One-side axe collected");
                    break;
                case CollectibleType.AXE_DS:
                    Debug.Log("Double-sided axe collected");
                    break;
                case CollectibleType.SWORD_OH:
                    Debug.Log("One-handed sword collected");
                    break;
                case CollectibleType.SWORD_DH:
                    Debug.Log("Double-handed sword collected");
                    break;
                case CollectibleType.HAMMER:
                    Debug.Log("Hammer collected");
                    break;
            }

            Destroy(gameObject);

        }
    }
}



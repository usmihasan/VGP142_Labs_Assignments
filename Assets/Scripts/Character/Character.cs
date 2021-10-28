using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    CharacterController controller;

    [Header("Player Settings")]
    [Space(2)]
    [Tooltip("Speed Value between 1 and 6")]
    [Range(1.0f, 6.0f)]
    public float speed = 10;
    public float gravity = 9.81f;
    public float jumpSpeed = 10.0f;


    enum ControllerType { SimpleMove, Move }
    [SerializeField] ControllerType type;

    Vector3 moveDirection;

    [Header("Weapon Settings")]
    [Space(2)]
    public float projectileForce;
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        /*if (projectileForce <= 0)
            projectileForce = 10.0f;*/

        try
        {
            controller = GetComponent<CharacterController>();

            controller.minMoveDistance = 0.0f;

            if (speed <= 0)
            {
                speed = 6.0f;
                throw new UnassignedReferenceException("Speed not set on " + name + "defaulting to " + speed);
            }


        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch (UnassignedReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            Debug.LogWarning("Always get called");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case ControllerType.SimpleMove:
                controller.SimpleMove(transform.forward * Input.GetAxis("Vertical") * speed);
                break;

            case ControllerType.Move:

                if (controller.isGrounded)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDirection *= speed;

                    moveDirection = transform.TransformDirection(moveDirection);

                    if (Input.GetButtonDown("Jump"))
                        moveDirection.y = jumpSpeed;
                }

                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);

                break;
        }


        if (Input.GetButtonDown("Fire1"))
            Fire();
    }

    void Fire()
    {
        if (projectilePrefab && projectileSpawnPoint)
        {
            Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            temp.AddForce(projectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);

            Destroy(temp.gameObject, 2.0f);
        }
    }

    [ContextMenu("Reset Stats")]
    void ResetStats()
    {
        speed = 6.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
            GameManager.Instance.GoToEndScene();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Finish")
            GameManager.Instance.GoToEndScene();
    }
}

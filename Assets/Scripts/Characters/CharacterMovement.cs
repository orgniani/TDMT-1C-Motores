using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float maxSpeed = 8f;
    public Vector2 direction;
    public Vector2 lastDirection;

    public Vector2 currentPosition;

    [SerializeField] private CharacterShooting attack;

    [SerializeField] private SpeedHandler speedHandler;

    public SpeedHandler SpeedHandler
    {
        //getter
        get
        {
            return speedHandler;
        }

        //setter
        set
        {
            speedHandler = value;
        }
    }

    private void Start()
    {

        lastDirection.Set(-1, 0);
    }


    private void Update()
    {
        if (attack == null)
            Debug.LogError($"{name}: CharacterShooting in CharacterMovement is null.");

        if (attack.canShoot)
        {
            transform.position = transform.position + speed * Time.deltaTime * new Vector3(direction.x, direction.y);
            currentPosition = transform.position;
        }

    }

    public void SetDirection(Vector2 direction)
    {
        //MAKE THIS LOOK BETTER
        //THIS DOES NOT GO HERE!!! should be controlled by events maybe??
        if (speedHandler != null)
        {
            speed = speedHandler.HandleSpeed(speed, maxSpeed);
        }

        this.direction = direction;
        if(direction != Vector2.zero)
        {
            lastDirection = direction;
        }
    }
}
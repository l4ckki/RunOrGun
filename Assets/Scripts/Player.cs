using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody p_rb;
    private Touch touch;
    private Vector3 touchPos;
    private Vector3 direction;
    public static bool isFight;
    [SerializeField] static public float zForce;
    private float moveSpeed;
    public Text speedText;
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        p_rb = gameObject.GetComponent<Rigidbody>();
    }


    private void Start()
    {
        isFight = false;
        zForce = 350f;
    }

    private void Update()
    {
        speedText.text = "Speed" + swerveSpeed;
    }

    private void FixedUpdate()
    {
        if (isFight == false)
        {
            Move();
        }

        else
        {
            StopMove();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Boss boss = other.gameObject.GetComponent<Boss>();

        if (boss)
        {
            isFight = true;
        }
    }



    private void Move()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount * Time.deltaTime, 0, 0);

        p_rb.velocity = new Vector3(0f, 0f, zForce) * Time.deltaTime;
    }


    private void StopMove()
    {
        p_rb.velocity = Vector3.zero;
        p_rb.angularVelocity = Vector3.zero;
    }


    public void AddSpeed()
    {
        swerveSpeed++;
        maxSwerveAmount = swerveSpeed * 2;

    }


}   

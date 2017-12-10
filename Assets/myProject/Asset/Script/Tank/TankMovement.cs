using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
    public float m_speed = 12f;
    public float m_TurnSpeed = 180f;

    private Rigidbody m_MyRigedbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
	// Use this for initialization
    void Awake()
    {
        m_MyRigedbody = GetComponent<Rigidbody>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");	
	}

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_speed * Time.deltaTime;
        m_MyRigedbody.MovePosition(m_MyRigedbody.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0,turn,0);
        m_MyRigedbody.MoveRotation(m_MyRigedbody.rotation * turnRotation);
    }
}

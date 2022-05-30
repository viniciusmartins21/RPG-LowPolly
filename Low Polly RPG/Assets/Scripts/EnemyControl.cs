using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Rigidbody _rb;
    public GameObject player;
    Vector3 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        


        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance > 0.5f)
        {
            Move();

            //Rotação para olhar para o Player
            Quaternion lookPlayer = Quaternion.LookRotation(direction);
            _rb.MoveRotation(lookPlayer);
        }
            
    }


    //Funçoes de movimento
    void Move()
    {
        direction = player.transform.position - transform.position;

        _rb.MovePosition(_rb.position + direction.normalized * speed * Time.deltaTime);
    }
}

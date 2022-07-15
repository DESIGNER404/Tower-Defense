using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed, RotationSpeed;
    [HideInInspector] public Transform[] Points;
    [HideInInspector] public int HP;

    private Transform currentPoint;
    private int index;
    private Vector3 direction;
    private Resources rs;

    void Start()
    {
        rs = FindObjectOfType<Resources>();
        index = 0;
        currentPoint = Points[index];
    }

    void Update()
    {
        direction = currentPoint.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, RotationSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Speed * Time.deltaTime);
        
        
        if (transform.position == currentPoint.position)
        {
            index++;


            if (index >= Points.Length)
            {
                rs.MissEnemy();
                Destroy(gameObject);
            }
            else
            {
                currentPoint = Points[index];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            HP -= other.GetComponent<Bullet>().Damage;

            if(HP <= 0)
            {
                rs.Kill();
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float Radius, FireDelay;
    public int Damage;
    public GameObject BulletPrefab;
    public LayerMask EnemyLayer;
    

    private float _timeToFier;
    private Transform _gun, _enemy, _firePoint;

    void Start()
    {
        _timeToFier = FireDelay;
        _gun = transform.GetChild(0);
        _firePoint = _gun.GetChild(0);
    }

    void Update()
    {
        if (_timeToFier > 0)
        {
            _timeToFier -= Time.deltaTime;
        }
        else if (_enemy)
        {
            Fire();
        }

        if (_enemy)
        {
            Vector3 lookAt = _enemy.position;
            lookAt.y = _gun.position.y;
            _gun.rotation = Quaternion.LookRotation(lookAt - _gun.position, Vector3.up);

            if(Vector3.Distance(transform.position, _enemy.position)> Radius)
            {
                _enemy = null;
            }
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);

            if(colliders.Length > 0)
            {
                _enemy = colliders[0].transform;
            }
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(BulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.transform.LookAt(_enemy.GetChild(0));
        bullet.GetComponent<Bullet>().Damage = Damage;

        _timeToFier = FireDelay;
    }
}

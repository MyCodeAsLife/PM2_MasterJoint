using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _joint;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _projectilePoint;

    private Projectile _projectilePrefab;
    private float _maxSpring = 100f;
    private float _minSpring = 1f;

    private void Start()
    {
        const string PathToProjectile = "Prefabs/Projectile";
        _projectilePrefab = Resources.Load<Projectile>(PathToProjectile);
        StartCoroutine(Gunning());
    }

    private void Fire()
    {
        _joint.spring = _maxSpring;
        _rigidbody.WakeUp();
    }

    private void Pull()
    {
        _joint.spring = _minSpring;
        _rigidbody.WakeUp();
    }

    private void LoadProjectile()
    {
        Instantiate(_projectilePrefab, _projectilePoint.position, Quaternion.identity);
    }

    private IEnumerator Gunning()
    {
        const float Seconds = 1.3f;

        var delay = new WaitForSeconds(Seconds);
        bool isWork = true;

        while (isWork)
        {
            Fire();
            yield return delay;

            Pull();
            yield return delay;

            LoadProjectile();
            yield return delay;
        }
    }
}

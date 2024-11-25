using UnityEngine;
using UnityEngine.InputSystem;

public class Gunner
{
    private Rigidbody _rigidbody;
    private SpringJoint _joint;
    private ProjectilePool _projectilePool;
    private Transform _projectilePoint;
    private Projectile _projectile;

    private bool _canShoot;
    private bool _isReload;
    private float _maxSpring = 100f;
    private float _minSpring = 1f;
    private float _reloadTime;
    private float _currentTime;

    public Gunner(Rigidbody rigidbody, SpringJoint joint, ProjectilePool pool, Transform projectilePoint)
    {
        _rigidbody = rigidbody;
        _joint = joint;
        _projectilePool = pool;
        _projectilePoint = projectilePoint;
        _reloadTime = 1.4f;
        _canShoot = true;
        _isReload = false;

        LoadProjectile();
    }

    public void Tick()
    {
        if (_canShoot == false && _isReload == true)
            CounDown();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (_canShoot)
        {
            _canShoot = false;
            _projectile.StartLifeTime();
            SetSpring(_maxSpring);
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (_isReload == false)
        {
            _isReload = true;
            SetSpring(_minSpring);
        }
    }

    private void SetSpring(float power)
    {
        _joint.spring = power;
        _rigidbody.WakeUp();
    }

    private void LoadProjectile()
    {
        _projectile = _projectilePool.Get();
        _projectile.transform.position = _projectilePoint.position;
        _projectile.gameObject.SetActive(true);
    }

    private void CounDown()
    {
        _currentTime += Time.deltaTime;

        if (_reloadTime < _currentTime)
        {
            _currentTime = 0;
            _canShoot = true;
            _isReload = false;
            LoadProjectile();
        }
    }
}

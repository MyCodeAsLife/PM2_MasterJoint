using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SpringJoint _joint;
    [SerializeField] private ProjectilePool _pool;
    [SerializeField] private Transform _projectilePoint;

    private PlayerInputController _controller;
    private Gunner _gunner;

    private void Awake()
    {
        _controller = new PlayerInputController();
        _gunner = new Gunner(_rigidbody, _joint, _pool, _projectilePoint);
    }

    private void OnEnable()
    {
        _controller.SubscribeOnShoot(_gunner.Shoot);
        _controller.SubscribeOnReload(_gunner.Reload);
    }

    private void OnDisable()
    {
        _controller.UnSubscribeOnShoot(_gunner.Shoot);
        _controller.UnSubscribeOnReload(_gunner.Reload);
    }

    private void Update()
    {
        _gunner.Tick();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] Projectile _prefab;

    private List<Projectile> _usedProjectiles = new();
    private List<Projectile> _freeProjectiles = new();

    private void Awake()
    {
        const string PathToProjectile = "Prefabs/Projectile";
        _prefab = Resources.Load<Projectile>(PathToProjectile);
    }

    private void OnDisable()
    {
        ReturnAll();
    }

    public Projectile Get()
    {
        Projectile projectile;

        if (_freeProjectiles.Count <= 0)
            Create();

        projectile = _freeProjectiles[0];
        _freeProjectiles.RemoveAt(0);
        _usedProjectiles.Add(projectile);

        return projectile;
    }

    public void Return(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _usedProjectiles.Remove(projectile);
        _freeProjectiles.Add(projectile);
    }

    public void ReturnAll()
    {
        for (int i = 0; i < _usedProjectiles.Count; i++)
        {
            _usedProjectiles[i].gameObject.SetActive(false);
            _freeProjectiles.Add(_usedProjectiles[i]);
        }

        _usedProjectiles.Clear();
    }

    private void Create()
    {
        var projectile = Instantiate(_prefab);
        projectile.LifeTimeEnded += OnLifeTimeEnded;
        _freeProjectiles.Add(projectile);
    }

    private void OnLifeTimeEnded(Projectile projectile)
    {
        Return(projectile);
    }
}

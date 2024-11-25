using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _lifeTime;

    public event Action<Projectile> LifeTimeEnded;

    private void Start()
    {
        _lifeTime = 3f;
    }

    public void StartLifeTime()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        var delay = new WaitForSeconds(_lifeTime);

        yield return delay;
        LifeTimeEnded(this);
    }
}

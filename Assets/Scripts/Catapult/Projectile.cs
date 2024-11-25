using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _lifeTime;

    private void Start()
    {
        _lifeTime = 5f;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        var delay = new WaitForSeconds(_lifeTime);
        bool isWork = true;

        while (isWork)
        {
            yield return delay;
            Destroy(this.gameObject);
        }
    }
}

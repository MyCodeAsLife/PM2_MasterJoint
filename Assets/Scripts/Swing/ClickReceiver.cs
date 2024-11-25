using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class ClickReceiver : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        const float Force = 5f;
        _rigidbody.velocity = Vector3.left * Force;
    }
}

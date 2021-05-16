using UnityEngine;

public class TriggerCollider : MonoBehaviour
{

    public bool triggerPulled = false;

    private void OnTriggerEnter(Collider other)
    {
        triggerPulled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        triggerPulled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerPulled = false;
    }
}

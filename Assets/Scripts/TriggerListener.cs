using UnityEngine;

public class TriggerListener : MonoBehaviour
{

    public bool triggerPulled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "IndexFingerTip")
        {
            triggerPulled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "IndexFingerTip") {
            triggerPulled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerPulled = false;
    }
}

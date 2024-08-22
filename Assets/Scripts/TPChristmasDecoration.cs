using UnityEngine;
using Valve.VR.InteractionSystem;

public class TPChristmasDecoration : MonoBehaviour
{
    public Transform Point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Interactable>())
        {
            other.transform.position = Point.position;
        }
    }
}

using UnityEngine;

public class CarGone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject car;

    void OnTriggerEnter(Collider other)
    {
        car.SetActive(false);
    }
}

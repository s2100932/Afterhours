using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    public Values values;

    bool state = true;

    void Start()
    {
        this.camera1.SetActive(state);
        camera2.SetActive(!state);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            values.increaseSanity(10);
            if (values.sanity >= 150)
            {
                values.setSanity();
            }

            state = !state;
            camera1.SetActive(state);
            camera2.SetActive(!state);
        }
    }
}
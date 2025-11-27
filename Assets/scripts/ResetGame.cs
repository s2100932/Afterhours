using UnityEngine;

public class ResetGame : MonoBehaviour
{   
    public GameObject Camera2;
    public GameObject Camera4;
    public GameObject Camera6;
    public GameObject Camera8;
    public GameObject Camera10;

    public Values values;
    void Awake()
    {
        values.resetSanity();
    }
    
    void CameraOff()
    {
        Camera2.SetActive(false);
        Camera4.SetActive(false);
        Camera6.SetActive(false);
        Camera8.SetActive(false);
        Camera10.SetActive(false);

    }

    void Start()
    {
        CameraOff();
    }

}

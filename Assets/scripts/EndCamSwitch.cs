using UnityEngine;

public class EndCamSwitch : MonoBehaviour
{

     public GameObject Prevcamera;
    public GameObject Endcamera;

    public Values values;
  

   bool state =true;
   void Start()
    {
        Prevcamera.SetActive(!state);
       this.Endcamera.SetActive(state);
    }

    void OnTriggerEnter(Collider SharedCollider)
    { 
        values.increaseSanity(10);
        if (values.sanity >= 150)
        {
            values.setSanity();
        }
        Prevcamera.SetActive(false);
        this.Endcamera.SetActive(true);
    }

}             

using UnityEngine;

public class _3CameraSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public Collider previous;
    public Collider next;
    public Collider current;
    public MoveControls getCollider;
   
  public Values values;

   bool On =true;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            camera2.SetActive(On);
            camera3.SetActive(!On);
    }

    void OnTriggerEnter(Collider collider)
    {
        On = !On;
       current = this.gameObject.GetComponent<Collider>();
        if (current == this.gameObject.GetComponent<Collider>())
        {
            previous = camera1.GetComponent<Collider>();
            next = camera3.GetComponent<Collider>();
            camera2.SetActive(true);
            camera1.SetActive(false);
            camera3.SetActive(false);
        }
    }
    
    void OnTriggerExit(Collider collider)
    {
        values.increaseSanity(10);
        if (values.sanity >= 150)
        {
            values.setSanity();
        }


        if (getCollider.ColliderHit == previous && current==this.gameObject.GetComponent<Collider>())
        {
            camera1.SetActive(!On);
            camera2.SetActive(On);
        }else if(getCollider.ColliderHit == next && current == this.gameObject.GetComponent<Collider>())
        {
             camera3.SetActive(!On);
            camera2.SetActive(On);
        }
    }

  

}



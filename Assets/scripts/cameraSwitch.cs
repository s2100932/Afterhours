using UnityEngine;

public class cameraSwitch : MonoBehaviour
{

  public GameObject camera1;
    public GameObject camera2;

  public Values values;

   bool state =true;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.camera1.SetActive(state);
         camera2.SetActive(!state);
    }

  void OnTriggerExit(Collider collider)
  {
    values.increaseSanity(10);
    if (values.sanity >= 150)
    {
      values.setSanity();
    }
    state = !state;
    camera2.SetActive(!state);
    this.camera1.SetActive(state);
  }

    void OnTriggerEnter(Collider collider)
    {
   this.camera1.SetActive(true);
    camera2.SetActive(false);
    }

}

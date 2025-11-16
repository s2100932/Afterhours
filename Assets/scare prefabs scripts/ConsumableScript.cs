using UnityEngine;
using UnityEngine.UIElements;

public class ConsumableScript : MonoBehaviour
{
    public Values values;
    private int Charges=3;
    private KeyCode ConsumeHotkey=KeyCode.E;
   
    void Update()
    {
        ConsumableUse();
    }

    void ConsumableUse()
    {
        if (Input.GetKeyDown(ConsumeHotkey)&&Charges!=0)
        {
            values.increaseSanity(-30);
            --Charges;
        }
        else if(Input.GetKeyDown(ConsumeHotkey)&& Charges<=0)
        {
            Debug.Log("Charges Insufficient");
        }
    }
}

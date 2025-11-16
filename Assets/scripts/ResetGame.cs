using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public Values values;
    void Awake()
    {
        values.resetSanity();
    }


}

using UnityEngine;

[CreateAssetMenu(fileName = "Values", menuName = "Scriptable Objects/Values")]
public class Values : ScriptableObject
{
    public float sanity=0.0f;
  public void increaseSanity(float adjustedSanity)
{
    sanity = Mathf.Clamp(sanity + adjustedSanity, 0f, 150f);
}


    public void resetSanity()
    {
        sanity = 0.0f;
    }

    public void setSanity()
    {
        sanity = 200f;
    }
}

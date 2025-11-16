using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public StaticContro staticControl;

    void OnTriggerEnter(Collider other)
    {
        if (staticControl != null)
            staticControl.OnWallTriggerEnter(other);
    }
}

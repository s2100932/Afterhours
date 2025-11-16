using System.Collections;
using UnityEngine;

public class StaticContro : MonoBehaviour
{
    public Material Staticfx;
    public float alphaStatic = 1f; // Starting opacity
    public float fadeTime = 5f;    // Time to fade out
    public Values values;
    public Collider wall;

    void Start()
    {
        Staticfx = GetComponent<MeshRenderer>().material;

    }

    void OnEnable()
    {
        alphaStatic = 1f;
         Staticfx.SetFloat("_StaticOpacity", alphaStatic);
        StartCoroutine(InitialFade());
    }

    void Update()
    {
        Staticfx.SetFloat("_StaticOpacity", values.sanity / 100f);
    }

    IEnumerator InitialFade()
    {
        while (alphaStatic > 0)
        {    
            alphaStatic -= Time.deltaTime / fadeTime;
            alphaStatic = Mathf.Clamp01(alphaStatic);
            Staticfx.SetFloat("_StaticOpacity", alphaStatic);
            yield return null;
        }
    }

    IEnumerator SanityStatic()
    {
        values.increaseSanity(10);
        yield return null;
    }

    public void OnWallTriggerEnter(Collider other)
    {
        StartCoroutine(SanityStatic());
    }
}

using System.Collections;
using UnityEngine;

public class DestructionEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEffect());
    }

    private IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(this.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }
}

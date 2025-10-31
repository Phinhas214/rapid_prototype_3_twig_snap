using UnityEngine;

public class Twig : MonoBehaviour
{
    private bool broken = false;
    private AudioSource audioSource;

    void Start() => audioSource = GetComponent<AudioSource>();

    void OnTriggerEnter(Collider other)
    {
        if (broken) return;
        if (other.CompareTag("Player"))
        {
            Debug.Log("collision with Player");
            broken = true;
            audioSource.Play();
            TwigCounter.Instance.AddTwig();

            // Optional: hide the twig mesh after it breaks
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}

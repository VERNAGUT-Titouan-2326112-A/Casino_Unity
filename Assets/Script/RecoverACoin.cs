using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource; 
    public TextMeshProUGUI counterText;  
    private static int score = 500;             

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        counterText.text = "" +score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collectSound);
           score += 50;
           counterText.text = "" + score;
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject);
        }
    }
}
    
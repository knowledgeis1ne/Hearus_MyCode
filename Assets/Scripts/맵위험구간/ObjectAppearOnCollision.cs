using System.Collections;
using UnityEngine;

public class ObjectAppearOnCollision : MonoBehaviour
{
    public GameObject raft;
    [SerializeField] public Transform respawnPosition;
    public ParticleSystem particleEffect; 
    public Transform particlePosition; 
    public AudioSource audioSource;
    public Renderer rend;
    public bool isFadingIn = false;
    public float fadeSpeed = 0.5f;
    public bool isPlayerInside = false;

    private void Start()
    {
        rend = raft.GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0f);
        raft.SetActive(false);

        if (particleEffect != null)
        {
            particleEffect.Stop();
            particleEffect.gameObject.SetActive(false);
        }    
    }

     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player"))
         {
            isFadingIn = !isFadingIn;

            StartCoroutine(FadeObject(isFadingIn));

            if (!isFadingIn && raft.activeSelf)
            {
                raft.SetActive(false);
                PlayEffects();
                ResetPosition();
            }

            if (isFadingIn && !raft.activeSelf)
            {
                raft.SetActive(true);
                PlayEffects();
                ResetPosition();
            }
            isPlayerInside = true;
         }
     }

     IEnumerator FadeObject(bool fadeIn)
     {
        float startAlpha = fadeIn ? 0 : 1;
        float endAlpha = fadeIn ? 1 : 0;
        float timeCounter=0;

         while (timeCounter < fadeSpeed)
         {
             timeCounter += Time.deltaTime;
             float alphaValue=Mathf.Lerp(startAlpha,endAlpha,timeCounter/fadeSpeed);

             Color currentColor=rend.material.color;
             currentColor.a=alphaValue;

             rend.material.color=currentColor;

           yield return null; 
       }      
   }

    void PlayEffects()
    {
        if(particleEffect != null) 
        {
            particleEffect.gameObject.SetActive(true); 
            particleEffect.transform.position = particlePosition.position;
            particleEffect.Play(); 

            StartCoroutine(StopParticleAfterTime(particleEffect.main.duration));
        }

        if(audioSource != null) 
            audioSource.Play(); 
    }

    IEnumerator StopParticleAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (particleEffect != null)
        {
            particleEffect.Stop();
            particleEffect.gameObject.SetActive(false);
        }
    }

   void ResetPosition() 
   {  
        raft.transform.position = respawnPosition.transform.position; 
   }
   
   void DeactivateRaftIfOutsideTrigger(Transform playerTransform)
    {  
        Vector3 directionFromPlayerToTrigger = (transform.position - playerTransform.position).normalized; 
        bool isOnRightSideOfTrigger = (Vector3.Dot(directionFromPlayerToTrigger, transform.right) > 0); 

        if (!isPlayerInside && isOnRightSideOfTrigger) 
        {     
            ResetPosition();    
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            DeactivateRaftIfOutsideTrigger(other.transform);
        }
    }
}
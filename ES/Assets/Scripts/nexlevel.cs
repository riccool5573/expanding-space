using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nexlevel : MonoBehaviour
{
    public GUITexture overlay;
    public float fadeTime;

    // Start is called before the first frame update
    private void Awake()
    {
        overlay.pixelInset = new Rect(0, 0, Screen.width, Screen.height);

        StartCoroutine(FadeToClear());

    }
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FadeToClear()
    {
        overlay.gameObject.SetActive(true);
        overlay.color = Color.black;
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;
        while(progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.black, Color.clear, progress);
            progress += rate * Time.deltaTime;
            Debug.Log("got here");

            yield return null;
        }

        overlay.color = Color.clear;
        overlay.gameObject.SetActive(false);
    }
}

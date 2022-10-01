using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    int i = 0; // Don't ask :C
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if ( i == 1)
            {
                StartCoroutine("LoadScene");
            }
            else
            {
                i = 1;
            }
        }
    }

    IEnumerator LoadScene()
    {
        anim.SetTrigger("Fade");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}

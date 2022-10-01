using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimController : MonoBehaviour
{
    public List<SpriteRenderer> sprites;
    float fadeTime = 5f;

    private void Start()
    {
        foreach (SpriteRenderer image in sprites)
            StartCoroutine(FadeIn(image));
    }

    private YieldInstruction fadeInstruction = new YieldInstruction();
    IEnumerator FadeOut(SpriteRenderer image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }

    IEnumerator FadeIn(SpriteRenderer image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }
}

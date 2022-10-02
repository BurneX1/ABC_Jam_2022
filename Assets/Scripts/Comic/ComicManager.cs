using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicManager : MonoBehaviour
{
    public Comic[] comics;

    public int currentComicIndex;
    public int currentPage;
    public int maxComicPages;
    public Image currentComicImage;
    public Text currentComicText;

    public Button nextBtn;

    private void Awake()
    {
        maxComicPages = comics[currentComicIndex].comicImages.Length;
    }

    private void Start() => Set(0);

    public void Set(int index)
    {
        currentComicImage.sprite = comics[currentComicIndex].comicImages[index];
        currentComicText.text = comics[currentComicIndex].comicTexts[index];
        currentComicText.fontSize = comics[currentComicIndex].textsSizes[index];
    }

    public void NextPage()
    {
        ChangeScene cs = FindObjectOfType<ChangeScene>();
        currentPage++;
        if (currentPage >= maxComicPages) cs.Change("03_MainMenu");
        else StartCoroutine(fadePages(cs));
    }

    private IEnumerator fadePages(ChangeScene cs)
    {
        cs.FadeCanvasGroup(cs.gameObject.GetComponent<CanvasGroup>(), 0, 1, .5f);
        yield return new WaitUntil(() => cs.gameObject.GetComponent<CanvasGroup>().alpha == 1);
        Set(currentPage);
        yield return new WaitForSeconds(.5f);
        cs.FadeCanvasGroup(cs.gameObject.GetComponent<CanvasGroup>(), 1, 0, .5f);   
    }
}

[System.Serializable] public struct Comic
{
    public Sprite[] comicImages;
    [TextArea] public string[] comicTexts;
    public int[] textsSizes;
}
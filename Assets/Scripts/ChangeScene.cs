using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private float duration;
    private CanvasGroup canvasGroup;

    void Awake() => canvasGroup = GetComponent<CanvasGroup>();

    void Start() => FadeCanvasGroup(canvasGroup, 1, 0, duration);

    public void Change(string sceneName) => StartCoroutine(TransitionLoadScene(sceneName));

    public void Reload() => Change(SceneManager.GetActiveScene().name);

    private IEnumerator TransitionLoadScene(string sceneName)
    {
        GetComponent<Image>().raycastTarget = true;
        FadeCanvasGroup(canvasGroup, 0, 1, duration);
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(sceneName);
    }

    public void FadeCanvasGroup(CanvasGroup canvasGroup, float initialAlpha, float finalAlpha, float time)
    {
        canvasGroup.alpha = initialAlpha;
        canvasGroup.DOFade(finalAlpha, time);
    }

    public void Quit() => Application.Quit();

    private void OnApplicationQuit() => SaveSystem.Save();
}

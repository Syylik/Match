using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    private static int sceneToLoad;
    private static Animator anim;
    private static string fadeTrigger = "fade";
    private static string fullFadeTrigger = "fullFade";

    private void Awake() => anim = GetComponent<Animator>();

    public static void ShowFullFade() => anim.SetTrigger(fullFadeTrigger);

    public static void SetScene(int loadScene)
    {
        anim.SetTrigger(fadeTrigger);
        sceneToLoad = loadScene;
    }
    public void LoadScene() => SceneManager.LoadScene(sceneToLoad);
}

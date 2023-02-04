using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] private Slider progress;
    [SerializeField] private TextMeshProUGUI finishText;

    // Start is called before the first frame update
    void Start()
    {
        finishText.gameObject.SetActive(false);
        StartCoroutine(DoLoading());
    }

    private IEnumerator DoLoading()
    {
        var op = SceneManager.LoadSceneAsync("MainScene");
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            yield return null;
            progress.value = op.progress;
            if (op.progress >= 0.9f)
            {
                progress.gameObject.SetActive(false);
                finishText.gameObject.SetActive(true);

                if (Keyboard.current.anyKey.isPressed ||
                    Mouse.current.leftButton.isPressed)
                {
                    op.allowSceneActivation = true;
                    Debug.LogFormat("Activate!");
                    yield break;
                }
            }
        }
    }
}

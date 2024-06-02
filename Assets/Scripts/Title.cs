using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private VisualElement root;
    private Button startButton;

    private void Awake()
    {
        root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        root.style.visibility = Visibility.Visible;

        startButton   = root.Q<Button>("StartButton");
        startButton  .RegisterCallback<ClickEvent>(startGame);
    }

    private void OnDisable()
    {
        startButton  .UnregisterCallback<ClickEvent>(startGame);
    }

    private void startGame(ClickEvent e)
    {
        SceneManager.LoadScene(2);
    }
}

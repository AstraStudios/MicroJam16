using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Title : MonoBehaviour
{
    private VisualElement root;
    private Button startButton;
    private Button creditsButton;

    private void Awake()
    {
        root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        root.style.visibility = Visibility.Visible;

        startButton   = root.Q<Button>("StartButton");
        creditsButton = root.Q<Button>("CreditsButton");
        startButton  .RegisterCallback<ClickEvent>(startGame);
        creditsButton.RegisterCallback<ClickEvent>(credits);
    }

    private void OnDisable()
    {
        startButton  .UnregisterCallback<ClickEvent>(startGame);
        creditsButton.UnregisterCallback<ClickEvent>(credits);
    }

    private void startGame(ClickEvent e)
    {
        print("start");
    }

    private void credits(ClickEvent e)
    {
        print("credits");
    }
}

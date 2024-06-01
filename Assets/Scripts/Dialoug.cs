using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialoug : MonoBehaviour
{
    [SerializeField] private List<string> dialougs = new List<string>(){"hello", "world"};
    [SerializeField] private int active_dialoug_message_index = 0;

    private VisualElement root;
    private Label dialougText;

    private void Awake()
    {
        ////////////// get display stuff ////////////
        root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        root.style.visibility = Visibility.Visible;

        dialougText = root.Q<Label>("DialougText");
        /////////////////////////////////////////////

        NextMessageOrEnd();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextMessageOrEnd();
        }
    }

    private void NextMessageOrEnd()
    {
        List<string> active_dialoug = dialougs;

        // exit dialoug if out of messages
        if (active_dialoug_message_index >= active_dialoug.Count)
        {
            //root.style.visibility = Visibility.Hidden; // use if not destroying
            Destroy(gameObject);
            return;
        }

        dialougText.text = active_dialoug[active_dialoug_message_index];

        active_dialoug_message_index += 1;
    }
}

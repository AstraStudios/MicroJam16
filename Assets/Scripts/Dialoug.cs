using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialoug : MonoBehaviour
{
    [SerializeField] private List<string> dialougs = new List<string>(){"hello", "world"};
    [SerializeField] private List<string> names    = new List<string>(){"Computer Uno", "Computer Dos"};
    [SerializeField] private int active_dialoug_message_index = 0;

    [SerializeField] bool enabledAtStart = false;

    private VisualElement root;
    private Label dialougText;
    private Label nameText;

    private void Awake()
    {
        ////////////// get display stuff ////////////
        root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        root.style.visibility = Visibility.Visible;

        dialougText = root.Q<Label>("DialougText");
        nameText    = root.Q<Label>("NameText");
        /////////////////////////////////////////////

        root.style.visibility = Visibility.Hidden;
        this.enabled = enabledAtStart;
    }

    // this is enabled by the DialougTrig script
    private void Start()
    {
        root.style.visibility = Visibility.Visible;

        Time.timeScale = 0;
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
        // exit dialoug if out of messages
        if (active_dialoug_message_index >= dialougs.Count)
        {
            //root.style.visibility = Visibility.Hidden; // use if not destroying
            Destroy(gameObject);
            Time.timeScale = 1;
            return;
        }

        dialougText.text = dialougs[active_dialoug_message_index];
        nameText.text    = names   [active_dialoug_message_index];

        active_dialoug_message_index += 1;
    }
}

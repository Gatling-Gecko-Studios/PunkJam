using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DayUI : MonoBehaviour
{
    public VisualElement root;

    [Header("Class buttons")]
    public Button gravesClassButton;
    public Button decorationsClassButton;
    public Button wallsClassButton;

    [Header("Class Containers")]
    public VisualElement gravesButtonsBackground;
    public VisualElement decorationsButtonsBackground;
    public VisualElement wallsButtonsBackground;

    [Header("Check Day")]
    public bool dayOne;
    public bool dayTwo;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        gravesClassButton = root.Q<Button>("GravesClassButton");
        decorationsClassButton = root.Q<Button>("DecorationsClassButton");
        wallsClassButton = root.Q<Button>("WallsClassButton");

        gravesButtonsBackground = root.Q<VisualElement>("GravesButtonsBackground");
        decorationsButtonsBackground = root.Q<VisualElement>("DecorationsButtonsBackground");
        wallsButtonsBackground = root.Q<VisualElement>("WallsButtonsBackground");
    }

    // Start is called before the first frame update
    void Start()
    {
        gravesClassButton.clicked += () => OpenGraves();
        decorationsClassButton.clicked += () => OpenDecorations();
        wallsClassButton.clicked += () => OpenWalls();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDay();
    }

    private void OpenGraves()
    {
        gravesButtonsBackground.style.display = DisplayStyle.Flex;
        decorationsButtonsBackground.style.display = DisplayStyle.None;
        wallsButtonsBackground.style.display = DisplayStyle.None;
    }

    private void OpenDecorations()
    {
        gravesButtonsBackground.style.display = DisplayStyle.None;
        decorationsButtonsBackground.style.display = DisplayStyle.Flex;
        wallsButtonsBackground.style.display = DisplayStyle.None;
    }

    private void OpenWalls()
    {
        gravesButtonsBackground.style.display = DisplayStyle.None;
        decorationsButtonsBackground.style.display = DisplayStyle.None;
        wallsButtonsBackground.style.display = DisplayStyle.Flex;
    }

    private void CheckDay()
    {
        if (dayOne)
        {
            root.Query(className: "lock-layer-one").ForEach((element) =>
            {
                element.style.display = DisplayStyle.None;
            });
        }

        if (dayTwo)
        {
            root.Query(className: "lock-layer-two").ForEach((element) =>
            {
                element.style.display = DisplayStyle.None;
            });
        }
    }
}

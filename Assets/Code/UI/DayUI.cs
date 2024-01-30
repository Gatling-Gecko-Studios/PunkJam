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

    [Header("Resources buttons")]
    public Button coffinButton;
    public Button graveButton;
    public Button tombButton;

    public Button decOneButton;
    public Button decTwoButton;
    public Button fountainButton;

    public Button brickWallButton;
    public Button gardenFenceButton;
    public Button ironFenceButton;

    [Header("Class Containers")]
    public VisualElement gravesButtonsBackground;
    public VisualElement decorationsButtonsBackground;
    public VisualElement wallsButtonsBackground;

    [Header("Clock Containers")]
    public VisualElement clockImageContainer;

    [Header("Money Value Label")]
    public Label moneyValueLabel;

    [Header("Check Day")]
    public bool dayOne;
    public bool dayTwo;

    [Header("Hour")]
    public int hour;

    [Header("Money")]
    public int moneyValue;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        gravesClassButton = root.Q<Button>("GravesClassButton");
        decorationsClassButton = root.Q<Button>("DecorationsClassButton");
        wallsClassButton = root.Q<Button>("WallsClassButton");
        coffinButton = root.Q<Button>("CoffinButton");
        graveButton = root.Q<Button>("GraveButton");
        tombButton = root.Q<Button>("TombButton");
        decOneButton = root.Q<Button>("DecorationOneButton");
        decTwoButton = root.Q<Button>("DecorationTwoButton");
        fountainButton = root.Q<Button>("FountainButton");
        brickWallButton = root.Q<Button>("BrickWallButton");
        gardenFenceButton = root.Q<Button>("GardenFenceButton");
        ironFenceButton = root.Q<Button>("IronFenceButton");

        gravesButtonsBackground = root.Q<VisualElement>("GravesButtonsBackground");
        decorationsButtonsBackground = root.Q<VisualElement>("DecorationsButtonsBackground");
        wallsButtonsBackground = root.Q<VisualElement>("WallsButtonsBackground");
        clockImageContainer = root.Q<VisualElement>("ClockImageContainer");

        moneyValueLabel = root.Q<Label>("MoneyValueLabel");
    }

    // Start is called before the first frame update
    void Start()
    {
        gravesClassButton.clicked += () => OpenGraves();
        decorationsClassButton.clicked += () => OpenDecorations();
        wallsClassButton.clicked += () => OpenWalls();

        coffinButton.clicked += () => PlaceCoffin();
        graveButton.clicked += () => PlaceGrave();
        tombButton.clicked += () => PlaceTomb();
        decOneButton.clicked += () => PlaceDecOne();
        decTwoButton.clicked += () => PlaceDecTwo();
        fountainButton.clicked += () => PlaceFountain();
        brickWallButton.clicked += () => PlaceBrickWall();
        gardenFenceButton.clicked += () => PlaceGardenFence();
        ironFenceButton.clicked += () => PlaceIronFence();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDay();
        CheckHour();
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        moneyValueLabel.text = moneyValue.ToString();
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

    private void PlaceCoffin()
    {
        Debug.Log("Place Coffin");
    }

    private void PlaceGrave()
    {
        Debug.Log("Place Grave");
    }

    private void PlaceTomb()
    {
        Debug.Log("Place Tomb");
    }

    private void PlaceDecOne()
    {
        Debug.Log("Place Decoration One");
    }

    private void PlaceDecTwo()
    {
        Debug.Log("Place Decoration Two");
    }

    private void PlaceFountain()
    {
        Debug.Log("Place Fountain");
    }

    private void PlaceBrickWall()
    {
        Debug.Log("Place Brick Wall");
    }

    private void PlaceGardenFence()
    {
        Debug.Log("Place Garden Fence");
    }

    private void PlaceIronFence()
    {
        Debug.Log("Place Iron Fence");
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

    private void CheckHour()
    {
        if(hour == 1)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 2)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 3)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 4)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 5)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 6)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 7)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 8)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 9)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 10)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 11)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }

        if (hour == 12)
        {
            clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + hour + "white");
        }
    }
}

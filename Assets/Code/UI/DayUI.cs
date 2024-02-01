using System.Collections;
using System.Collections.Generic;
using Code.GridSystem;
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
    public float moneyValue;

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

        coffinButton.clicked += () => InitCoffin();
        graveButton.clicked += () => InitGrave();
        tombButton.clicked += () => InitTomb();
        decOneButton.clicked += () => InitDecOne();
        decTwoButton.clicked += () => InitDecTwo();
        fountainButton.clicked += () => InitFountain();
        brickWallButton.clicked += () => InitBrickWall();
        gardenFenceButton.clicked += () => InitGardenFence();
        ironFenceButton.clicked += () => InitIronFence();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDay();
        CheckHour();
        moneyValue = MoneyManager.currentMoney;
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

    private void InitCoffin()
    {
        Debug.Log("init coffin");
        BuildingSystem.current.HoldPlaceableObject(BuildingSystem.current.CoffinPrefab);
    }

    private void InitGrave()
    {
        BuildingSystem.current.HoldPlaceableObject(BuildingSystem.current.GraveStonePrefab);

    }

    private void InitTomb()
    {
        BuildingSystem.current.HoldPlaceableObject(BuildingSystem.current.CryptPrefab);
    }

    private void InitDecOne()
    {
        BuildingSystem.current.HoldPlaceableObject(BuildingSystem.current.BushPrefab);
    }

    private void InitDecTwo()
    {
        Debug.Log("Place DecorationTwo");
    }

    private void InitFountain()
    {
        BuildingSystem.current.HoldPlaceableObject(BuildingSystem.current.FountainPrefab);
    }

    private void InitBrickWall()
    {
        BuildingSystem.current.HoldPlaceableObject(BuildingSystem.current.BrickWallPrefab);

    }

    private void InitGardenFence()
    {
        Debug.Log("Place Garden Fence");
    }

    private void InitIronFence()
    {
        BuildingSystem.current.HoldPlaceableObject(BuildingSystem.current.IronFencePrefab);

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
        clockImageContainer.style.backgroundImage = Resources.Load<Texture2D>("Clock/" + GameManager.Instance.hour + "white");
    }
}

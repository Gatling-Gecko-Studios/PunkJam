using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    GameObject player;
    public static GameManager Instance { get; private set; }
    public float timer;
    public int hour;
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject dayUI;
    public PlayerInputActions playerInputActions;
    public GameObject mainCamera;

    private bool FPSMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerInputActions = new PlayerInputActions();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        ToggleWeaponHolder(false); //disable weaponholder on start
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TranslateTimeToHour();
    }

    private void TranslateTimeToHour()
    {
        // Total duration of the day in seconds
        float totalDayDuration = 180f;

        // Calculate the duration of each hour
        float hourDuration = totalDayDuration / 11f;

        // Calculate the current hour based on the timer
        hour = Mathf.FloorToInt(timer / hourDuration) + 1;

        // Ensure the hour wraps around from 12 back to 1
        hour = (hour % 11 == 0) ? 11 : hour;
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    public void SetFPSMode(bool value)
    {
        FPSMode = value;
        ToggleWeaponHolder(value);
    }

    public bool GetFPSMode()
    {
        return FPSMode;
    }

    private void ToggleWeaponHolder(bool value)
    {
        if (weaponHolder != null)
        {
            weaponHolder.SetActive(value);
            dayUI.SetActive(!value);
            player.GetComponent<Renderer>().enabled = !value;
        }
        else
        {
            Debug.LogWarning("you didnt set the weaponholder on the gamemanager you dummy");
        }
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}

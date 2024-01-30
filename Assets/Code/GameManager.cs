using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] GameObject weaponHolder;
    public PlayerInputActions playerInputActions;

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
        ToggleWeaponHolder(false); //disable weaponholder on start
    }

    // Update is called once per frame
    void Update()
    {

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
        }
        else
        {
            Debug.LogWarning("you didnt set the weaponholder on the gamemanager you dummy");
        }
    }
}

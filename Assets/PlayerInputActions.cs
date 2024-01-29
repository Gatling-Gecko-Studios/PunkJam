//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Day"",
            ""id"": ""4bbda948-2c1b-4ac6-b141-096b5f8fd829"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c45bd692-7959-4422-ba85-20fb2d595032"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""bd87bd90-03e1-4aa1-b659-caa8b24fee2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TogglePerspective"",
                    ""type"": ""Button"",
                    ""id"": ""e5c507dd-8a47-45d9-af8a-156f8e73590f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bed0ec74-6b30-456a-9a73-910b28c91106"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1cbd91d8-ef15-4169-8374-45991332ffc8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""10ec7b5f-24b4-4b6a-bb03-4bcdac1c84d5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d14aef0f-9ee6-482e-9c1d-3abafd82f4da"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""76ef6eb9-18fd-4319-9328-23106e15f010"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a3955c21-4ec4-4af4-af08-9ef86f17ff31"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ca79732-f2f4-4d2c-a82f-55098709854a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePerspective"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Night"",
            ""id"": ""c7df5e17-e142-4033-8640-b25327a0ff52"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""0412d935-eefc-4d5e-94c3-c69bdc83b5b7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d728fb82-f5e9-44be-8394-c0a773ab91ae"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InGameUI"",
            ""id"": ""2a1c0c0a-2763-410b-bdbe-207ec7a90cda"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""7088a04d-c4b6-4b31-925d-870ef299c2f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""63d4a53f-8211-4e70-9ef7-69ced7b75bbe"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuUI"",
            ""id"": ""63136b75-8371-478b-9282-2eda882ecb97"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""a646cecf-72b8-4774-b80b-31f0d0e6d37d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d76fa0ac-66ea-4eb9-96ac-e4066aa8737d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Day
        m_Day = asset.FindActionMap("Day", throwIfNotFound: true);
        m_Day_Move = m_Day.FindAction("Move", throwIfNotFound: true);
        m_Day_Interact = m_Day.FindAction("Interact", throwIfNotFound: true);
        m_Day_TogglePerspective = m_Day.FindAction("TogglePerspective", throwIfNotFound: true);
        // Night
        m_Night = asset.FindActionMap("Night", throwIfNotFound: true);
        m_Night_Look = m_Night.FindAction("Look", throwIfNotFound: true);
        // InGameUI
        m_InGameUI = asset.FindActionMap("InGameUI", throwIfNotFound: true);
        m_InGameUI_Newaction = m_InGameUI.FindAction("New action", throwIfNotFound: true);
        // MenuUI
        m_MenuUI = asset.FindActionMap("MenuUI", throwIfNotFound: true);
        m_MenuUI_Newaction = m_MenuUI.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Day
    private readonly InputActionMap m_Day;
    private List<IDayActions> m_DayActionsCallbackInterfaces = new List<IDayActions>();
    private readonly InputAction m_Day_Move;
    private readonly InputAction m_Day_Interact;
    private readonly InputAction m_Day_TogglePerspective;
    public struct DayActions
    {
        private @PlayerInputActions m_Wrapper;
        public DayActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Day_Move;
        public InputAction @Interact => m_Wrapper.m_Day_Interact;
        public InputAction @TogglePerspective => m_Wrapper.m_Day_TogglePerspective;
        public InputActionMap Get() { return m_Wrapper.m_Day; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DayActions set) { return set.Get(); }
        public void AddCallbacks(IDayActions instance)
        {
            if (instance == null || m_Wrapper.m_DayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DayActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @TogglePerspective.started += instance.OnTogglePerspective;
            @TogglePerspective.performed += instance.OnTogglePerspective;
            @TogglePerspective.canceled += instance.OnTogglePerspective;
        }

        private void UnregisterCallbacks(IDayActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @TogglePerspective.started -= instance.OnTogglePerspective;
            @TogglePerspective.performed -= instance.OnTogglePerspective;
            @TogglePerspective.canceled -= instance.OnTogglePerspective;
        }

        public void RemoveCallbacks(IDayActions instance)
        {
            if (m_Wrapper.m_DayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDayActions instance)
        {
            foreach (var item in m_Wrapper.m_DayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DayActions @Day => new DayActions(this);

    // Night
    private readonly InputActionMap m_Night;
    private List<INightActions> m_NightActionsCallbackInterfaces = new List<INightActions>();
    private readonly InputAction m_Night_Look;
    public struct NightActions
    {
        private @PlayerInputActions m_Wrapper;
        public NightActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Night_Look;
        public InputActionMap Get() { return m_Wrapper.m_Night; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NightActions set) { return set.Get(); }
        public void AddCallbacks(INightActions instance)
        {
            if (instance == null || m_Wrapper.m_NightActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_NightActionsCallbackInterfaces.Add(instance);
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(INightActions instance)
        {
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(INightActions instance)
        {
            if (m_Wrapper.m_NightActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(INightActions instance)
        {
            foreach (var item in m_Wrapper.m_NightActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_NightActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public NightActions @Night => new NightActions(this);

    // InGameUI
    private readonly InputActionMap m_InGameUI;
    private List<IInGameUIActions> m_InGameUIActionsCallbackInterfaces = new List<IInGameUIActions>();
    private readonly InputAction m_InGameUI_Newaction;
    public struct InGameUIActions
    {
        private @PlayerInputActions m_Wrapper;
        public InGameUIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_InGameUI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_InGameUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameUIActions set) { return set.Get(); }
        public void AddCallbacks(IInGameUIActions instance)
        {
            if (instance == null || m_Wrapper.m_InGameUIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InGameUIActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IInGameUIActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IInGameUIActions instance)
        {
            if (m_Wrapper.m_InGameUIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInGameUIActions instance)
        {
            foreach (var item in m_Wrapper.m_InGameUIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InGameUIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InGameUIActions @InGameUI => new InGameUIActions(this);

    // MenuUI
    private readonly InputActionMap m_MenuUI;
    private List<IMenuUIActions> m_MenuUIActionsCallbackInterfaces = new List<IMenuUIActions>();
    private readonly InputAction m_MenuUI_Newaction;
    public struct MenuUIActions
    {
        private @PlayerInputActions m_Wrapper;
        public MenuUIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MenuUI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MenuUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuUIActions set) { return set.Get(); }
        public void AddCallbacks(IMenuUIActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuUIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuUIActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IMenuUIActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IMenuUIActions instance)
        {
            if (m_Wrapper.m_MenuUIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuUIActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuUIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuUIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuUIActions @MenuUI => new MenuUIActions(this);
    public interface IDayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnTogglePerspective(InputAction.CallbackContext context);
    }
    public interface INightActions
    {
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IInGameUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IMenuUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}

# SharedVariableSystem

**A Unity system for decoupling logic using ScriptableObject-based shared variables.**

This system lets you store and update values globally using ScriptableObjects, enabling cleaner, more modular code without tight coupling between components.

---

## 🚀 Getting Started

### 1. Create a Shared Variable

To create a shared variable:

* In Unity, go to `Assets > Create > Shared Variables`
* Select the type of variable you want (e.g., `float`, `vector3`, `bool`, etc.)

> 💡 You can extend the system to support custom types — see [Extending the System](#-extending-the-system) below.

---

### 2. Set the Variable in a Script

Attach a reference to the shared variable and update it from any script:

```csharp
using UnityEngine;
using SharedVariableSystem;

public class Player : MonoBehaviour
{
    public SharedVariableField<Vector3> playerPosition;

    private void Update()
    {
        playerPosition.Value = transform.position;
    }
}
```

In the Unity Editor, assign the `SharedVariableVector3` ScriptableObject to the `playerPosition` field.

---

### 3. React to Changes in Another Script

You can respond to value changes either **via code** or **via UnityEvents**.

---

#### 🧩 A. Using Code (Event Subscription)

```csharp
using UnityEngine;
using SharedVariableSystem;

public class CameraController : MonoBehaviour
{
    public SharedVariable<Vector3> playerPosition;

    private void OnEnable()
    {
        playerPosition.OnValueChanged += OnPlayerPositionChanged;
    }

    private void OnDisable()
    {
        playerPosition.OnValueChanged -= OnPlayerPositionChanged;
    }

    private void OnPlayerPositionChanged(Vector3 position)
    {
        // Move the camera to follow the player
    }
}
```

Make sure to assign the same `SharedVariableVector3` ScriptableObject in the Inspector.

---

#### 🎛️ B. Using UnityEvents (With a Listener Component)

Use a built-in `SharedVariableListener` component (e.g., `SharedVariableListenerVector3`) to connect value changes to methods via the Unity Inspector:

```csharp
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void OnPlayerPositionChanged(Vector3 position)
    {
        // Move the camera to follow the player
    }
}
```

In the Unity Editor:

1. Add a `SharedVariableListenerVector3` component to your GameObject.
2. Assign the shared variable to the listener.
3. In the UnityEvent, drag the GameObject with `CameraController` and select `OnPlayerPositionChanged`.

---

## 🔧 Extending the System

To support new types:

1. Create a new subclass of `SharedVariable<T>` (e.g., `SharedVariableColor`).
2. Optionally, create a `SharedVariableListener<T>` variant (e.g., `SharedVariableListenerColor`) for UnityEvent usage.
3. Add a `CreateAssetMenu` attribute to expose it in the Unity Editor.

---

## ✅ Benefits

* Fully decouples MonoBehaviours — no need for singletons or `GetComponent`.
* Encourages event-driven programming using either C# or UnityEvents.
* Easily extensible for custom variable types.
* Editor-friendly, drag-and-drop workflow.

---

## 📁 Folder Structure

```
SharedVariableSystem/
├── Editor/
│   └── SharedVariableFieldDrawer.cs
├── SharedVariableListeners/
│   ├── SharedVariableListener.cs
│   ├── SharedVariableListenerFloat.cs
│   ├── SharedVariableListenerInt.cs
│   └── ...
├── SharedVariables/
│   ├── SharedVariable.cs
│   ├── SharedVariableFloat.cs
│   ├── SharedVariableInt.cs
│   └── ...
└── README.md
```

---

## 🧪 Example Use Cases

* Share the player's position across systems (camera, UI, effects).
* Sync game state flags (e.g., isPaused, isGameOver).
* Drive animations or logic based on shared health, score, or time.

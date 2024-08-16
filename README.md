# SOLID Principles and Design Patterns

This Unity project showcases the implementation of various design patterns and SOLID principles, demonstrating clean and maintainable code practices. Below is an overview of the key components in the project.

## Overview

This project includes examples of:

- **Dependency Inversion Principle (DIP)**
- **Open/Closed Principle (OCP)**
- **Interface Segregation Principle (ISP)**
- **Single Responsibility Principle (SRP)**
- **Liskov Substitution Principle (LSP)**
- **Design Patterns** such as Strategy, Decorator, and more.

## Key Components

### Movement System

#### `IMovementInputGetter` Interface

An interface that defines input for movement, with `Horizontal` and `Vertical` properties.

```csharp
public interface IMovementInputGetter
{
    float Horizontal { get; }
    float Vertical { get; }
}
```

#### `ConstantMovement` Class

A simple implementation of `IMovementInputGetter` that provides constant movement input.

```csharp
public class ConstantMovement : MonoBehaviour, IMovementInputGetter
{
    public float Horizontal => 1f;
    public float Vertical => 1f;
}
```

#### `KeyboardMovement` Class

A more flexible implementation that gets movement input from the keyboard.

```csharp
public class KeyboardMovement : MonoBehaviour, IMovementInputGetter
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    private void Update() => GetInput();

    private void GetInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
    }
}
```

#### Mover Classes

These classes demonstrate the Dependency Inversion Principle (DIP).

`Mover_Bad`
A poor implementation that violates DIP by directly depending on concrete input handling.
```csharp
public class Mover_Bad : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        Vector3 movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        }.normalized;

        movement = movement * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
```

`Mover_Good`
An improved version that adheres to DIP by depending on the IMovementInputGetter interface.
```charp
public class Mover_Good : MonoBehaviour
{
    private IMovementInputGetter movementInputGetter = null;
    [SerializeField] private float speed = 5f;

    private void Awake() => movementInputGetter = GetComponent<IMovementInputGetter>();

    private void Update()
    {
        Vector3 movement = new Vector3
        {
            x = movementInputGetter.Horizontal,
            y = 0f,
            z = movementInputGetter.Vertical
        }.normalized;

        movement *= speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
```

`Damage System`
Demonstrates the Interface Segregation Principle (ISP) with IDamageable and ICharacter interfaces.
```charp
public interface ICharacter 
{
    string Name { get; }
}

public interface IDamageable 
{
    int Health { get; }
    int MaxHealth { get; }
    void DealDamage(int damageToDeal);
}
```

`Targeting System`
The Open/Closed Principle (OCP) is showcased through different implementations of the `ITargetGetter` interface.

`ITargetGetter` Interface
Defines a method to get targets for a character or object.
```charp
public interface ITargetGetter 
{
    List<Transform> GetTargets(Transform transform);
}
```

`AllTargetting` Class
Gets all transforms in the scene.
```charp
public class AllTargetting : MonoBehaviour, ITargetGetter
{
    public List<Transform> GetTargets(Transform transform)
    {
        return FindObjectsOfType<Transform>().ToList();
    }
}
```

`InRadiusTargetting` Class
Gets targets within a specified radius
```charp
public class InRadiusTargetting : MonoBehaviour, ITargetGetter
{
    [SerializeField] private float radius = 5f;

    public List<Transform> GetTargets(Transform transform)
    {
        var targets = new List<Transform>();
        Collider[] collidersInRadius = Physics.OverlapSphere(transform.position, radius);

        foreach (var collider in collidersInRadius)
        {
            targets.Add(collider.transform);
        }

        return targets;
    }
}
```
`Item System`
Showcasing inheritance and polymorphism with `Item`, `Weapon`, and `Consumable` classes.

`Item` Abstract Class
Defines common properties for all items.
```charp
public abstract class Item : MonoBehaviour
{
    [SerializeField] private string itemName = "New Item Name";
    [SerializeField] private string description = "New Item Description";

    public string Name => itemName;
    public string Description => description;

    public abstract void DisplayText();
}
```
`Weapon` Class
A concrete item class that represents a weapon.
```charp
public class Weapon : Item
{
    [SerializeField] private int damage = 10;

    public int Damage => damage;

    public override void DisplayText()
    {
        Debug.Log($"{Name} : When You Swing Me I Deal {Damage} damage!");
    }
}
```

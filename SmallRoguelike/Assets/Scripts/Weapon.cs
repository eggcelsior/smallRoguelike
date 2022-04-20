using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string name_;
    [TextArea(3, 10)]
    public string description;
    public int rarity;
    public Sprite sprite;

    public float damage;
    public float swingSpeed;
}

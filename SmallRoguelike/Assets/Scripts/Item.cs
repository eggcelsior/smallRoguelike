using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string name_;
    [TextArea(3, 10)]
    public string description;
    public int rarity;
    public int id;
    public Sprite sprite;
}

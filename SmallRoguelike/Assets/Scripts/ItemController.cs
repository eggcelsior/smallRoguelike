using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Canvas canvas;
    public Transform uiLocator;

    public Item item;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI descriptionField;
    public Image itemImage;
    public Image rarityImage;

    public Sprite rarity1;
    public Sprite rarity2;
    public Sprite rarity3;

    // Start is called before the first frame update
    void Start()
    {
        nameField.text = item.name_;
        descriptionField.text = item.description;
        itemImage.sprite = item.sprite;
        switch (item.rarity)
        {
            case 1:
                rarityImage.sprite = rarity1;
                break;
            case 2:
                rarityImage.sprite = rarity2;
                break;
            case 3:
                rarityImage.sprite = rarity3;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canvas.transform.position != uiLocator.transform.position)
        {
            canvas.transform.position = uiLocator.transform.position;
        }
    }
}

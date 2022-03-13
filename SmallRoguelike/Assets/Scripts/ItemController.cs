using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Canvas canvas;
    public Transform uiLocator;

    public GameObject canvasGO;
    public GameObject uiLocaterGO;

    public Item item;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI descriptionField;
    public Image itemImage;
    public Image rarityImage;
    private SpriteRenderer itemSR;

    public Sprite rarity1;
    public Sprite rarity2;
    public Sprite rarity3;

    private bool openCanvas;

    // Start is called before the first frame update
    void Start()
    {
        openCanvas = false;

        itemSR = GetComponent<SpriteRenderer>();
        gameObject.transform.name = gameObject.transform.name + " " + Random.Range(1f, 1000000f).ToString();

        canvasGO.SetActive(false);
        uiLocaterGO.SetActive(false);
        
        nameField.text = item.name_;
        descriptionField.text = item.description;
        itemImage.sprite = item.sprite;
        itemSR.sprite = itemImage.sprite;
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
    private void OnMouseDown()
    {
        Debug.Log("Clicked on entity " + gameObject.transform.name);
        canvasGO.SetActive(true);
        uiLocaterGO.SetActive(true);
        StartCoroutine(clicked(1f));
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(openCanvas == true)
            {
                canvasGO.SetActive(false);
                uiLocaterGO.SetActive(false);
                Debug.Log("Closed Canvas of " + gameObject.transform.name);
                openCanvas = false;
                //Play a fancy animation if you want lmao or not
            }
        }
    }
    private IEnumerator clicked(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        openCanvas = true;
    }
}

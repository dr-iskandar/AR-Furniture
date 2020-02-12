using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject detailContainer, categoryContainer;

    public Image productImage;
    public TMP_Text productName;
    public TMP_Text productDescription;

    public Sprite currentProductImage;
    public TMP_Text currentProductName;

    public GameObject[] product;

    public GameObject placementObject;

    public void DetailProduct()
    {
        productImage.sprite = currentProductImage;
        productName.text = currentProductName.text;
        detailContainer.SetActive(true);
    }

    public void changeProductDescription(TMP_Text productdescription)
    {
        productDescription.text = productdescription.text;
    }

    public void changeProductName(string productname)
    {
        currentProductName.text = productname;
    }

    public void changeProductImage(Sprite productimage)
    {
        currentProductImage = productimage;
    }

    public void ShowCategory()
    {

    }

    public void addToCard()
    {

    }

    public void viewInAR()
    {
        for (int i = 0; i < product.Length; i++)
        {
            product[i].SetActive(false);

            if (product[i].name == productName.text)
            {
                product[i].SetActive(true);
                placementObject =  product[i];
            }
        }
    }

    public void Back()
    {
        placementObject.GetComponent<PlacementObject>().showPlane();
    }
}

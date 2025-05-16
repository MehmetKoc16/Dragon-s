using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondİmageConfig : MonoBehaviour
{
    [SerializeField] Sprite fullSprite;
    [SerializeField] GameObject emptySprite;
    [SerializeField] Transform diamondAmount;
    private void Start()
    {
      for(int i = 0;i<diamondAmount.childCount;i++)
        {
            Instantiate(emptySprite,transform);
        }
    }

    void Update()
    {
        for(int i = 0; i < FindObjectOfType<PlayerMoment>().GetDiamondAmount(); i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = fullSprite;
        }
    }
}

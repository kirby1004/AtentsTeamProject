using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShopBuyCheck : MonoBehaviour
{
    public ShopItem myItem;

    public Button BuyButton;
    public Button CancelButton;

    public TMP_Text myItemname;

    // Start is called before the first frame update
    void Start()
    {

        CancelButton.onClick.AddListener(() => {
            BuyButton.onClick.RemoveAllListeners();
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        RefreshWindow();
    }
    private void OnDisable()
    {
        myItem = null;

    }
    public void RefreshWindow()
    {
        myItemname.text = myItem.myItem.name;
        BuyButton.onClick.AddListener(() =>
        {
            if (Gamemanager.Inst.CheckMoney(myItem.myCost))
            {
                myItem.BuyItem(myItem.myItem, true);
                Gamemanager.Inst.GetMoney(-myItem.myCost);
                BuyButton.onClick.RemoveAllListeners();

                ShopManager.Inst.BuyCheckWindow.SetActive(false);
            }
            else
            {
                BuyButton.onClick.RemoveAllListeners();
                ShopManager.Inst.FailWindow.SetActive(true);
                ShopManager.Inst.FailWindow.GetComponentInChildren<Button>().onClick
                .AddListener(() => { CancelButton.onClick?.Invoke(); });    
            }
        });
    }
}

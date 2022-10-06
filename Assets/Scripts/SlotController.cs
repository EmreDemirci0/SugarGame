using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{

    [SerializeField] Image checkedSugarImage;
    [SerializeField] public static SlotController firstSugar;
    [SerializeField] public static SlotController secondSugar;

    void Start() {
        checkedSugarImage.gameObject.SetActive(false);
    }

    public void whichSugar(int index) {
        checkedSugarImage.transform.position = transform.position;
        checkedSugarImage.gameObject.SetActive(true);
        if (firstSugar == null)
            firstSugar = this;
        else        {
            secondSugar = this;
            if (firstSugar != secondSugar){
                float farkX = Mathf.Abs(firstSugar.transform.localPosition.x - secondSugar.transform.localPosition.x);
                float farkY = Mathf.Abs(firstSugar.transform.localPosition.y - secondSugar.transform.localPosition.y);
                if (farkX + farkY == 60){//change grid layout grup break down   
                    //swaping
                    Sprite temp;
                    temp = firstSugar.GetComponent<Image>().sprite;
                    firstSugar.GetComponent<Image>().sprite = secondSugar.GetComponent<Image>().sprite;
                    secondSugar.GetComponent<Image>().sprite = temp;
                    SugarController.Instance.SugarwinPointStart();
                }
                else {   
                    //not swaping
                    firstSugar = secondSugar;
                    secondSugar = null;
                }
                SugarController.Instance.SugarwinPointStart();
            }
        }
    }
}




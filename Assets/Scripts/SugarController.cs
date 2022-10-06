using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarController : MonoBehaviour
{
    public List<Sprite> sugarsTips;
    [SerializeField] List<GameObject> sugars;
    [SerializeField] GameObject Panel;
    [SerializeField] TMPro.TextMeshProUGUI ScoreText;

    int score;

    private static SugarController _instance;
    public static SugarController Instance
    {
        get
        {   //Singleton
            if (_instance == null)
            {
                _instance = FindObjectOfType<SugarController>();
                if (_instance == null)
                {
                    _instance = new GameObject("SugarC New").AddComponent<SugarController>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        //if i have SugarController script Destroy it
        if (_instance != null) Destroy(this);
        for (int i = 0; i < 16; i++)
        {  //create sugars
            Panel.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = sugarsTips[Random.Range(0, sugarsTips.Count)];

        }
    }

    private void Start()
    {
        //sugar matching
        SugarwinPointStart();
        Debug.LogWarning("Objeler Patlatýlýnca onlarýn yerine 3 adet yeni obje Spawnlanýyor.");

    }
    void EarnScore(int amount)
    {
        score += amount;
        ScoreText.text = score.ToString();
    }
    public void SugarwinPointStart()
    {

        #region horizontalCrush

        for (int i = 1; i < 15; i++)
        {
            //If 3 pieces of sugar come together
            if (sugars[i - 1].GetComponent<Image>().sprite ==
               sugars[i + 1].GetComponent<Image>().sprite &&
                sugars[i].GetComponent<Image>().sprite ==
                sugars[i + 1].GetComponent<Image>().sprite &&
                !(i % Mathf.Sqrt(sugars.Count) == Mathf.Sqrt(sugars.Count) - 1) &&
                !(i % Mathf.Sqrt(sugars.Count) == 0)) {

                sugars[i - 1].GetComponent<Image>().sprite = sugarsTips[Random.Range(0, sugarsTips.Count)];
                sugars[i].GetComponent<Image>().sprite = sugarsTips[Random.Range(0, sugarsTips.Count)];
                sugars[i + 1].GetComponent<Image>().sprite = sugarsTips[Random.Range(0, sugarsTips.Count)];
                EarnScore(5);
            }
        }
        #endregion
        #region VerticalCrush

        for (int i = 4; i < 12; i++)
        {
            //If 3 pieces of candy are stacked on top of each other
            if (sugars[i].GetComponent<Image>().sprite ==
             sugars[i + 4].GetComponent<Image>().sprite &&
             sugars[i].GetComponent<Image>().sprite ==
             sugars[i - 4].GetComponent<Image>().sprite)
            {
                sugars[i - 4].GetComponent<Image>().sprite = sugarsTips[Random.Range(0, sugarsTips.Count)];
                sugars[i].GetComponent<Image>().sprite = sugarsTips[Random.Range(0, sugarsTips.Count)];
                sugars[i + 4].GetComponent<Image>().sprite = sugarsTips[Random.Range(0, sugarsTips.Count)];
                EarnScore(5);
            }

        }
        #endregion



    }

}
// if (i > 3)   //will open soon
// {   //BUG 
//alpha of matching sugars drops
//(sugars[i].GetComponent<Image>().color) = new Color(255, 255, 255, .51f);
//(sugars[i - 1].GetComponent<Image>().color) = new Color(255, 255, 255, .51f);
//(sugars[i + 1].GetComponent<Image>().color) = new Color(255, 255, 255, .51f);

//sugars[i - 1].GetComponent<Image>().sprite = SugarController.Instance.Panel.GetComponent<RectTransform>().GetChild(i - 1 - 4).GetComponent<Image>().sprite;
// sugars[i].GetComponent<Image>().sprite = SugarController.Instance.Panel.GetComponent<RectTransform>().GetChild(i - 4).GetComponent<Image>().sprite;
// sugars[i + 1].GetComponent<Image>().sprite = SugarController.Instance.Panel.GetComponent<RectTransform>().GetChild(i + 1 - 4).GetComponent<Image>().sprite;

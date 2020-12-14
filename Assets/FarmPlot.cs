using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : MonoBehaviour
{
    bool playerNear = false;
    [SerializeField] Sprite _baseSprite;
    [SerializeField] Sprite _ratSprite;
    [SerializeField] Sprite _barnSprite;
    [SerializeField] Sprite _carrotSprite;
    [SerializeField] Sprite _waterSprite;
    [SerializeField] Sprite _wheatSprite;
    [SerializeField] Sprite _cheeseSprite;
    [SerializeField] Sprite _tomatoSprite;

    ArrayList spriteList = new ArrayList();
    ArrayList nameList = new ArrayList();
    int spriteListIter = 0;
    int nameListIter = 0;
    void Start()
    {
        spriteList.Add(_baseSprite);
        spriteList.Add(_carrotSprite);
        spriteList.Add(_wheatSprite);
        spriteList.Add(_ratSprite);
        spriteList.Add(_cheeseSprite);
        spriteList.Add(_tomatoSprite);
        spriteList.Add(_waterSprite);
        spriteList.Add(_barnSprite);
        nameList.Add("base");
        nameList.Add("carrot");
        nameList.Add("wheat");
        nameList.Add("rat");
        nameList.Add("cheese");
        nameList.Add("tomato");
        nameList.Add("water");
        nameList.Add("barn");
    }

    void Update()
    {
        if(playerNear){
            if(Input.GetButtonDown("Submit")){
                spriteListIter++;
                nameListIter++;
                ChangeSprite((Sprite) spriteList[spriteListIter]);
                this.name = (string) nameList[nameListIter];
                if(spriteListIter == 7){
                    nameListIter = 0;
                    spriteListIter = 0;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playerNear = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerNear = false;
    }

    public void ChangeSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

}

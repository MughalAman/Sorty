using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject[] Blocks = null;

    [SerializeField]
    private GameObject leftBox, middleBox, rightBox = null;
    
    [SerializeField]
    private SpriteRenderer leftBoxSr, middleBoxSr, rightBoxSr = null;

    [SerializeField]
    private Color[] spriteColors;

    public TextMeshProUGUI ScoreText;

    public bool GameOver = true;
    public bool IsPlaying = false;

    public float SpawnTime = 1f;

    public float DropSpeed = 10f;

    public int Score = 0;

    // Update is called once per frame
    void Update()
    {
        //update the score | make a system for this 
        ScoreText.text = "Score: " + Score.ToString();
        if(Input.GetKey(KeyCode.Space))
        {
            GameOver = false;
        }

        if(GameOver == false)
        {
            if(IsPlaying == false)
            {
                StartCoroutine(SpawnBlocks());
            }
        }
    }

   public IEnumerator SpawnBlocks()
    {
        IsPlaying = true;
        while (GameOver == false)
        {
            //spawn a cube to a random spot.
            Instantiate(Blocks[Random.Range(0, Blocks.Length)], new Vector2(Random.Range(-8.23f, 8.23f), 6), Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
        }
    }


    public void ChangeBoxes()
    {
        //Swap boxes color and position
        leftBoxSr.color = spriteColors[Random.Range(0, spriteColors.Length)];
        middleBoxSr.color = spriteColors[Random.Range(0, spriteColors.Length)];
        rightBoxSr.color = spriteColors[Random.Range(0, spriteColors.Length)];

        leftBox.transform.position = new Vector2(Random.Range(-8, 8.22f), leftBox.transform.position.y);
        middleBox.transform.position = new Vector2(Random.Range(-8, 8.22f), middleBox.transform.position.y);
        rightBox.transform.position = new Vector2(Random.Range(-8, 8.22f), rightBox.transform.position.y);
        
    }
}

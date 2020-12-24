using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    //Variables
    [SerializeField]
    private Rigidbody2D rb;

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void Update()
    {
        if(GameObject.Find("GameSystem").GetComponent<GameSystem>().GameOver == true)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    { 
      transform.Translate(Vector3.down * GameObject.Find("GameSystem").GetComponent<GameSystem>().DropSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if collided objects tag is same as the cubes tag = color then increase score, increase dropping speed and destroy the cube.
        if(col.tag == this.tag+"Box")
        {
            GameObject.Find("GameSystem").GetComponent<GameSystem>().Score += 1;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().DropSpeed += 0.05f;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().SpawnTime -= 0.05f;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().ChangeBoxes();
            Destroy(this.gameObject);
        }
        else
        {
            //Reset scene
            
            /*
            GameObject.Find("GameSystem").GetComponent<GameSystem>().Score = 0;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().DropSpeed = 3f;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().SpawnTime = 4f;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().GameOver = true;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().IsPlaying = false;
            GameObject.Find("GameSystem").GetComponent<GameSystem>().StopAllCoroutines();
            Destroy(this.gameObject);
            */
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}

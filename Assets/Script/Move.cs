using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        float speed = GetComponent<Unit>().Speed; //獲取Unit組件中的Speed值
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed); //向左移動
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed); //向右移動
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);  //向上移動
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed); //向下移動
        }
    }
}

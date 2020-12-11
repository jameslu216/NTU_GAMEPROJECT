using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    public string UnitName;
    public int HP = 100;
    public float Speed = 3;
    public int Atk = 10;
    public int Team = 0;
	void Start () {
	
	}
	
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BulletMove>().Team != Team)//如果Team值不同則受到傷害
        {
            HP -= 10; //生命值-10
            Destroy(col.gameObject);
            if (HP < 0)
            {
                Destroy(gameObject); //摧毀物件
            }
        }
    }
}

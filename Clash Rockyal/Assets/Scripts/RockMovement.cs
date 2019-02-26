using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockMovement : MonoBehaviour {

    public const float SPEED = 3;
    public float speed = 53;
    private float size;
    public Text sizeText;

    private void Start()
    {
        if(transform.position.z < -5)
        {
            speed = SPEED;
        } else
        {
            speed = -SPEED;
        }
    }
    // Use this for initialization
    void Update () {
        transform.position += new Vector3(0f, 0f, Time.deltaTime * speed);
    }

    public void SetRockSize(float s)
    {
        size = s;
        sizeText.text = ""+s;
    }

    public float GetSize()
    {
        return size;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            RockMovement enemy = other.GetComponent<RockMovement>();
            float enemySize = enemy.GetSize();
            if (enemySize == size)
            {
                Destroy(gameObject);
            } else if(enemySize>size){
                enemy.SetRockSize(enemySize - size);
                Destroy(gameObject);
            }
        }
    }

}

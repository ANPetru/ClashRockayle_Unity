using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMovement : MonoBehaviour {


    private bool dragging = false;
    private float distance;
    private RockSpawner rockSpawner;
    private GameManager gm;
    private Vector3 initPos;
    public Card card;
    public Text sizeText;

    private void Start()
    {
        initPos = transform.position;
        gm = GameManager.GetInstance();
        rockSpawner = gm.GetRockSpawner();
    }

    public void SetCard(Card c)
    {
        card = c;
        sizeText.text = ""+c.health;

    }


    private void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

    }


    private void OnMouseUp()
    {
        dragging = false;
        if(rockSpawner.SpawnCard(transform,card))
        {
            gm.GetCardSpawner().DrawNewCard(card);
            Destroy(gameObject);
        } else
        {
            transform.position = initPos;
        }
        
    }

    private void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            transform.position = new Vector3(rayPoint.x, transform.position.y, (rayPoint.z>-9)?-9:rayPoint.z);

        }
    }

   
}

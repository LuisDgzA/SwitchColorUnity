using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    public string currentColor;
    // Start is called before the first frame update

    private void Start()
    {
        SetRandomColor();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
           
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collider.gameObject);
            return;
        }
        if(currentColor != collider.tag)
        {
            Debug.Log("Game over!!");
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        string[] colors = { "Cyan", "Yellow" ,"Magenta", "Pink"};

        Color[] colorValues = {colorCyan, colorYellow, colorMagenta, colorPink};

        //if(currentColor == colors[index])
        //{
        //    SetRandomColor();
        //}
        currentColor = colors[index];
        spriteRenderer.color = colorValues[index];
    }
}

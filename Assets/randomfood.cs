using NUnit.Framework.Internal;
using UnityEngine;


public class randomfood : MonoBehaviour
{
    public BoxCollider2D gridArea;
   

    private void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position=new Vector3(Mathf.Round(x), Mathf.Round(y),0.0f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        RandomizePosition();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == true)
        {
            
            RandomizePosition();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

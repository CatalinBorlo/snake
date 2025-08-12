using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class snake : MonoBehaviour
{
    public Vector3 lastposition;
    public GameObject gameoverscreen;
    public Logic logic_;
    private Vector2 position;
    private Vector2 direction;
    private List<Transform> segments = new List<Transform>();
    public Transform prefab;
    public int InitialSize = 4;
    //private static bool ok=false;
    public GameObject startscreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if(ok==false)
        //{
            startscreen.SetActive(true);
        //}
        
        if (startscreen.activeSelf==false)
        {
            direction = Vector2.right;
        }
        
        logic_ = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        
        //ResetState();
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down && gameoverscreen.activeSelf==false && startscreen.activeSelf==false)
            {
                direction = Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up && gameoverscreen.activeSelf == false && startscreen.activeSelf == false)
            {
                direction = Vector2.down;
            }
            if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left && gameoverscreen.activeSelf == false && startscreen.activeSelf == false)
            {
                direction = Vector2.right;
            }
            if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right && gameoverscreen.activeSelf == false && startscreen.activeSelf == false)
            {
                direction = Vector2.left;
            }
        
    }
    private void FixedUpdate()
    {
        lastposition=transform.position;
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x) + direction.x,
                Mathf.Round(this.transform.position.y) + direction.y,
                0.0f);
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.prefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
    public void ResetState()
    {
        //ok = true;
        startscreen.SetActive(false);
        this.enabled= true;
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        for (int i = 1; i < this.InitialSize; i++)
        {
            segments.Add(Instantiate(this.prefab));
        }
        this.transform.position = new Vector3(-21, 0, 0);
        direction = Vector2.right;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            logic_.Addscore();
        }
        else
        {
            if (other.tag == "Obstacle")
            {
                gameoverscreen.SetActive(true);
                transform.position = lastposition;
                this.enabled = false;
                direction = Vector2.zero;
                if(gameoverscreen==false)
                {
                    
                    ResetState();
                }
                
            }
        }
    }
}


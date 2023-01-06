using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MyCube : MonoBehaviour
{
    public float speed;
    public float force;
    public GameObject myCube;
    public Rigidbody rb;
    bool alive = true;
    public TextMeshProUGUI pointText;
    int point;

    void Start()
    {
        myCube.GetComponent<Rigidbody>();
        myCube.GetComponent<Transform>();


    }

    void Update()
    {
        LeftRight();
        if (alive)
        {
            rb.AddForce(new Vector3(0, 0, 1) * force * Time.deltaTime);
           
        }

    

        if (transform.position.y < -10)
        {
            Reset();
        }

        
    }

    void LeftRight()
    {
        Vector3 position = new Vector3(1, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += speed * Time.deltaTime * position;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += speed * Time.deltaTime * position * -1;
        }

    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            Invoke("Reset", 0.5f);
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Scene2");
        }       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            point++;
            pointText.text = "      " + point;
        }
    }
}

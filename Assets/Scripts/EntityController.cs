using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 30.0f;
    [SerializeField] private float xRange = 5.5f;
    [SerializeField] private float zRange = 5.5f;
    [SerializeField] private GameObject marker;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text message;

    // ENCAPSULATION
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // ENCAPSULATION
    private bool _selected;
    public bool Selected
    {
        get { return _selected; }
        set { _selected = value; }
    }

    // ENCAPSULATION
    private string messageText;
    public string MessageText
    {
        get { return messageText; }
        set { messageText = value; }
    }
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _selected = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.back * verticalInput * Time.deltaTime * speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaySomething();
        }
    }

    // POLYMORPHISM
    // ABSTRACTION
    protected abstract void SaySomething();

    public virtual string GetName()
    {
        return _name;
    }

    // ABSTRACTION
    public void ShowMarker(bool show)
    {
        marker.SetActive(show);
    }

    // ABSTRACTION
    public void ShowPanel(bool show)
    {
        message.text = messageText;
        panel.SetActive(show);
        StartCoroutine("DisablePanel");
    }

    IEnumerator DisablePanel()
    {
        yield return new WaitForSeconds(4);
        panel.SetActive(false);
    }
}

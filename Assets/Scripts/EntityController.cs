using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    private float moveInput;
    private float rotateInput;
    public float moveSpeed = 30.0f;
    public float rotateSpeed = 200.0f;
    [SerializeField] private float xRange = 5.5f;
    [SerializeField] private float zRange = 5.5f;
    [SerializeField] private GameObject marker;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text message;
    private Animator entityAnimator;

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
        entityAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moveInput = Input.GetAxis("Vertical"); 
        rotateInput = Input.GetAxis("Horizontal");

        if (moveInput != 0)
        {
            entityAnimator.SetFloat("Speed_f", 1f);
        }
        else
        {
            entityAnimator.SetFloat("Speed_f", 0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaySomething();
        }
    }

    void LateUpdate()
    {
        transform.Translate(Vector3.forward * moveInput * Time.deltaTime * moveSpeed);
        transform.Rotate(0f, rotateInput * Time.deltaTime * rotateSpeed, 0f);

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

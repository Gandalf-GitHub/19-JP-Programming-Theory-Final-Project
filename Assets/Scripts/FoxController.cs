using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FoxController : EntityController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Fox";
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Selected)
        {
            base.Update();
        }
       
    }

    // POLYMORPHISM
    protected override void SaySomething()
    {
        MessageText = $"Hello there!, my name is {Name}!";
        ShowPanel(true);
    }
}

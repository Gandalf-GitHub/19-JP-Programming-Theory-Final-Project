using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : EntityController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Human";
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Selected)
        {
            base.Update();
        }
       
    }

    protected override void SaySomething()
    {
        MessageText = $"Good day!, I am {Name}!";
        ShowPanel(true);
    }
}

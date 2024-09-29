using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 currentTarget;
    private void Start()
    {
        //
    }
    public override void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}

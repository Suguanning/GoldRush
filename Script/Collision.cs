using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;

    [Space]

    [Header("LeftCollision")]
    public Vector2 leftOffsetUp;
    public Vector2 leftOffset;
    public Vector2 leftOffsetDown;


    [Space]

    [Header("RightCollision")]
    public Vector2 rightOffsetUp;
    public Vector2 rightOffset;
    public Vector2 rightOffsetDown;


    [Space]

    [Header("BottomCollision")]
    public Vector2 bottomOffset, rightBottom, leftBottom;


    [Space]

    [Header("Collision")]
    public float collisionRadius = 0.25f;
    private Color debugCollisionColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer)||
            Physics2D.OverlapCircle((Vector2)transform.position + rightBottom, collisionRadius, groundLayer)||
            Physics2D.OverlapCircle((Vector2)transform.position + leftBottom, collisionRadius, groundLayer);

        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer) 
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffsetUp, collisionRadius, groundLayer)
        || Physics2D.OverlapCircle((Vector2)transform.position + leftOffsetDown, collisionRadius, groundLayer)
        || Physics2D.OverlapCircle((Vector2)transform.position + rightOffsetUp, collisionRadius, groundLayer)
        || Physics2D.OverlapCircle((Vector2)transform.position + rightOffsetDown, collisionRadius, groundLayer) ;

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer)
                    || Physics2D.OverlapCircle((Vector2)transform.position + rightOffsetUp, collisionRadius, groundLayer)
        || Physics2D.OverlapCircle((Vector2)transform.position + rightOffsetDown, collisionRadius, groundLayer);


        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer)
                        || Physics2D.OverlapCircle((Vector2)transform.position + leftOffsetUp, collisionRadius, groundLayer)
        || Physics2D.OverlapCircle((Vector2)transform.position + leftOffsetDown, collisionRadius, groundLayer);

        wallSide = onRightWall ? -1 : 1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftBottom, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightBottom, collisionRadius);

        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffsetUp, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffsetDown, collisionRadius);


        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffsetUp, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffsetDown, collisionRadius);
    }
}

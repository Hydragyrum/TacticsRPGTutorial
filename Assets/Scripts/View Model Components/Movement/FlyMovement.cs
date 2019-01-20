using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : Movement
{
    public override IEnumerator Traverse(Tile tile)
    {
        // Distance between Start and End Tiles
        float diffX = tile.pos.x - unit.tile.pos.x;
        float diffY = tile.pos.y - unit.tile.pos.y;
        float dist = Mathf.Sqrt((diffX * diffX) + (diffY * diffY));
        unit.Place(tile);

        // Fly up high enough to avoid clipping
        float y = Tile.stepHeight * 10;
        float duration = (y - jumper.position.y) * 0.5f;
        Tweener tweener = jumper.MoveToLocal(new Vector3(0, y, 0), duration, EasingFunctions.EaseInOutQuad);
        while (tweener != null)
        {
            yield return null;
        }

        // Face the direction of the target tile
        Directions dir;
        Vector3 toTile = (tile.centre - transform.position);
        if (Mathf.Abs(toTile.x) > Mathf.Abs((toTile.z)))
        {
            dir = toTile.x > 0 ? Directions.East : Directions.West;
        }
        else
        {
            dir = toTile.z > 0 ? Directions.North : Directions.South;
        }

        yield return StartCoroutine(Turn(dir));

        // Move to correct tile
        duration = dist * 0.5f;
        tweener = transform.MoveTo(tile.centre, duration, EasingFunctions.EaseInOutQuad);
        while (tweener != null)
        {
            yield return null;
        }
        
        // Land
        duration = (y - tile.centre.y) * 0.5f;
        tweener = jumper.MoveToLocal(Vector3.zero, 0.5f, EasingFunctions.EaseInOutQuad);
        while (tweener != null)
        {
            yield return null;
        }
    }
}
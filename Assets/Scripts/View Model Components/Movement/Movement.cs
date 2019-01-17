using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public int range;
    public int jumpHeight;
    protected Unit unit;
    protected Transform jumper;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        jumper = transform.Find("Jumper");
    }

    public virtual List<Tile> GetTilesInRange(Board board)
    {
        List<Tile> retValue = board.Search(unit.tile, ExpandSearch);
        Filter(retValue);
        return retValue;
    }

    protected virtual bool ExpandSearch(Tile from, Tile to)
    {
        return (from.distance + 1) <= range;
    }

    protected virtual void Filter(List<Tile> tiles)
    {
        for (int i = tiles.Count - 1; i >= 0; --i)
        {
            if (tiles[i].content != null)
            {
                tiles.RemoveAt(i);
            }
        }
    }

    public abstract IEnumerator Traverse(Tile tile);

    protected virtual IEnumerator Turn(Directions dir)
    {
        TransformLocalEulerAnglesTweener t =
            (TransformLocalEulerAnglesTweener) transform.RotateToLocal(dir.ToEuler(), 0.25f, EasingFunctions.EaseInOutQuad)

        if (Mathf.Approximately(t.startValue.y, 0.0f) && Mathf.Approximately(t.endValue.y, 270.0f))
        {
            t.startValue = new Vector3(t.startValue.x, 360.0f, t.startValue.z);
        }
        else if (Mathf.Approximately(t.startValue.y, 270.0f) && Mathf.Approximately(t.endValue.y, 0.0f))
        {
            t.endValue = new Vector3(t.startValue.x, 360.0f, t.startValue.z);
        }

        unit.dir = dir;

        while (t != null)
        {
            yield return null;
        }
    }
}
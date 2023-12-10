using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static Vector3 Clamp(Vector3 vector, Vector2 clampVectorX,Vector2 clampVectorZ)
    {
        float x = Mathf.Clamp(vector.x, clampVectorX.x, clampVectorX.y);
        float y = Mathf.Clamp(vector.y, float.NegativeInfinity, float.PositiveInfinity);
        float z = Mathf.Clamp(vector.z, clampVectorZ.x, clampVectorZ.y);

        return new Vector3(x, y, z);    
    }
}

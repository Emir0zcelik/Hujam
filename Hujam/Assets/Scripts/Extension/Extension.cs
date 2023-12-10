using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static Vector3 Clamp(Vector3 vector, Vector3 clampVector)
    {
        float x = Mathf.Clamp(vector.x, -clampVector.x, clampVector.x);
        float y = Mathf.Clamp(vector.y, -clampVector.y, clampVector.y);
        float z = Mathf.Clamp(vector.z, -clampVector.z, clampVector.z);

        return new Vector3(x, y, z);    
    }
}

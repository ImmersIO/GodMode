using UnityEngine;

public class RealWorldObject : MonoBehaviour
{
    public LatLong OriginCoord;
    public LatLong ObjCoord;
    public float ObjDrawRadius;
    public Transform OriginTransform;
    public Transform ObjTransform;

    [System.Serializable]
    public struct LatLong
    {
        //NOTE: Use Radians for the values in this struct
        //TODO: Doubles instead of floats
        public float Lat;
        public float Long;
    }

    void Update()
    {
        Compass compass = Input.compass;
        float heading = compass.magneticHeading;
        float target = getTargetBearing(this.OriginCoord.Lat, this.OriginCoord.Long, this.ObjCoord.Lat, this.ObjCoord.Long);
        float diffDeg = Mathf.DeltaAngle(heading, target);
        float diffRad = Mathf.Deg2Rad * diffDeg;
        this.ObjTransform.position = new Vector3(this.OriginTransform.position.x + this.ObjDrawRadius * Mathf.Cos(diffRad), this.ObjTransform.position.y, this.OriginTransform.position.z + this.ObjDrawRadius * Mathf.Sin(diffRad));

        /*
        x = cx + r * cos(a)
        y = cy + r * sin(a)
        */
    }

    //NOTE: Params are Radians, return value is degrees
    //TODO: Figure out how to do this math with doubles instead of floats
    private static float getTargetBearing(float aLat, float aLong, float bLat, float bLong)
    {
        float y = Mathf.Sin(bLong - aLong) * Mathf.Cos(bLat);
        float x = Mathf.Cos(aLat) * Mathf.Sin(bLat) - Mathf.Sin(aLat) * Mathf.Cos(bLat) * Mathf.Cos(bLong - aLong);
        return Mathf.Rad2Deg * Mathf.Atan2(y, x);

        /*
        var y = Mathf.sin(λ2 - λ1) * Math.cos(φ2);
        var x = Math.cos(φ1) * Math.sin(φ2) -
                Math.sin(φ1) * Math.cos(φ2) * Math.cos(λ2 - λ1);
        var brng = Math.atan2(y, x).toDegrees();
        */
    }
}

public static class Utils
{ 
    public static float GetOppostieAngle(float angle)
    {
        angle -= 180;

        return NormalizeAngle(angle);
    }

    public static float NormalizeAngle(float angle)
    {
        if (angle >= 360)
        {
            return angle - 360;
        }
        else if (angle < 0)
        {
            return angle + 360;
        }
        else
        {
            return angle;
        }
    }
}

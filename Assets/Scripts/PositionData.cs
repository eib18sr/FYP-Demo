using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionData
{
    public int ResponseCode { get; private set; }
    public string Identifier { get; private set; }
    public string Latitude { get; private set; }
    public string Longitude { get; private set; }
    public PositionData(int responseCode, string identifier, string latitude, string longitude) {
        ResponseCode = responseCode;
        Identifier = identifier;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string ToString() => Identifier + ": " + Latitude.Substring(0, 4) + "°, " + Longitude.Substring(0, 4) + "°";
}

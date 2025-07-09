using UnityEngine;

public class SetFloat : MonoBehaviour
{
    public float inspectorFloat;  
    public void GetFloat(float value)
    {
        float aFLoat = value; 
        Debug.Log(aFLoat);
        inspectorFloat = aFLoat;
        
    }
}

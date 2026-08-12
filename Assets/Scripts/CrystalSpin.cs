using UnityEngine;

public class CrystalSpin : MonoBehaviour
{
    private void Update()
    {
      transform.Rotate(0,50 * Time.deltaTime, 0)    ;  
    }
}




using UnityEngine;

public class lockedCursor : MonoBehaviour
{

  
    
    void Start()
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;

}


}

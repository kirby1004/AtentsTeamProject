using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

interface IinterPlay
{
    void SetisObjectNear(bool n);
    void SetisUI(bool n);

    void SetisInterPlay(bool n);
    UnityEvent OpenUi { get; set; }
    UnityEvent CloseUi { get; set; }
    UnityEvent interPlay { get; set; }
}
public class RPGInterPlaySystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

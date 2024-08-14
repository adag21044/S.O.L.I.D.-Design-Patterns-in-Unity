using UnityEngine;

public class ItemLogger : MonoBehaviour
{
    private void Start()
    {
        var item = GetComponent<Item>();

        if(item == null) return;

        item.DisplayText();
        
    }
    
}
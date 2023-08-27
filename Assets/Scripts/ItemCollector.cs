using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import unity package to be able to use the Text as a variable.
using UnityEngine.UI;
using TMPro;



public class ItemCollector : MonoBehaviour
{
  private int apples = 0;
  //private can only be used in this script
  //Void - will still execute function without a return
  //reference to new text to work apples counter.
  [SerializeField] private TextMeshProUGUI applesText;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Apple"))
    {
      Destroy(collision.gameObject);
      apples++;
      //accessing the applesText object. finding the text component. giving the Value "Apples: + the value of apples
      applesText.text = "Apples: " + apples;
    }
  }
    
}

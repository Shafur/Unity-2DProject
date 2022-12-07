using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighting : MonoBehaviour
{
    //private bool ObjectHighlight;
    public Light Light = null;
  //  [SerializeField]
  //  private float HighlightRange = 4;
  //  private bool Player;
  //  [SerializeField]
  //  private bool showGizmos = false;
  //
  //  // Start is called before the first frame update
  //  void Start()
  //  {
  //      Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, HighlightRange);
  //
  //      Gizmos.DrawWireSphere(transform.position, HighlightRange);
  //      if (playerCollider != null && GameObject.FindWithTag("Player"))
  //      {
  //          Light.enabled = true;
  //
  //      }
  //      else
  //      {
  //          Light.enabled = false;
  //      }
  //          
  //
  //  }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

           
            Light.enabled = true;

            //turning on object highlight
            if(Light.enabled = true)
            {
                Light.range = 1;
                Light.color = Color.green;
                Light.intensity = 1;
                
            }
        }

        
    }
    public void OnTriggerExit2D(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Light.enabled = false;
        }
    }


}

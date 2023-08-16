using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    [SerializeField] float torqueMinimum = 1;
    [SerializeField] float torqueMaximum = 5;
    [SerializeField] float throwStrength = 5;
    [SerializeField] TextMeshProUGUI textBox;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.gameObject);
    }

    // Update is called once per frame
    public void RollTheDice()
    {
        rb.AddForce(Vector3.up * throwStrength, ForceMode.Impulse);

        rb.AddTorque(transform.forward * Random.Range(torqueMinimum,torqueMaximum) + transform.up * Random.Range(torqueMinimum,torqueMaximum)
         + transform.right * Random.Range(torqueMinimum,torqueMaximum));


         StartCoroutine(WaitForStop());

    }

    IEnumerator WaitForStop(){
        
        yield return new WaitForFixedUpdate();
        
        while(rb.angularVelocity.sqrMagnitude > 0.05){
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(2);
        CheckRolld12();
    }
    /*
    public void CheckRolld4(){
        Vector3 vec = transform.right;
        int rollValue =0;

        float y = Mathf.Round(vec.y*100);
        
        if(y>=0&&y<=3)rollValue=1;
        else if(y==47)rollValue=2;
        else if(y==45)rollValue=3;
        else if(y==-94)rollValue=4;
        
        
        Debug.Log(y.ToString());
        Debug.Log(vec.ToString());

        textBox.text = rollValue.ToString();
    }

    
    public void CheckRolld6(){
        
        float y,x,z;
        int rollValue =0;

        y = Mathf.Round(Vector3.Dot(transform.up.normalized, Vector3.up));
        x = Mathf.Round(Vector3.Dot(transform.right.normalized, Vector3.up));
        z = Mathf.Round(Vector3.Dot(transform.forward.normalized, Vector3.up));
        switch(y){
            case 1:
                rollValue = 3;
                break;
            case -1:
                rollValue = 4;
                break;
        }
        switch(x){
            case 1:
                rollValue = 2;
                break;
            case -1:
                rollValue = 5;
                break;
        }
        switch(z){
            case 1:
                rollValue = 1;
                break;
            case -1:
                rollValue = 6;
                break;
        }
        
        //textBox.text = rollValue.ToString();
        //textBox.text = transform.right.ToString();
        Debug.Log(transform.right.ToString());
    }
    
    
    public void CheckRolld8(){
        float y,y1,y2;
        Vector3 vec = transform.right;
        Vector3 vec1 = transform.up;
        Vector3 vec2 = transform.forward;
        int rollValue =0;
        
        //x=Mathf.Round(vec.x*100);
        y=Mathf.Round(vec.y*100);
        //z=Mathf.Round(vec.z*100);
        
       // x1=Mathf.Round(vec1.x*100);
        y1=Mathf.Round(vec1.y*100);
       // z1=Mathf.Round(vec1.z*100);

      //  x2=Mathf.Round(vec2.x*100);
        y2=Mathf.Round(vec2.y*100);
       // z2=Mathf.Round(vec2.z*100);

        //Debug.Log("y:"+y.ToString() + " y1:"+y1.ToString() + " y2:"+y2.ToString());
        
        if(y>=55 && y<=60){
            if(y1>=55 && y1<=60){
                if(y2>=55 && y2<=60){
                    rollValue=8;
                }else if(y2<=-55 && y2>=-60){
                    rollValue=3;
                }
            }else if(y1<=-55 && y1>=-60){
                if(y2>=55 && y2<=60){
                    rollValue=5;
                }else if(y2<=-55 && y2>=-60){
                    rollValue=2;
                }
            }
        }else if(y<=-55 && y>=-60){
            if(y1>=55 && y1<=60){
                if(y2>=55 && y2<=60){
                    rollValue=1;
                }else if(y2<=-55 && y2>=-60){
                    rollValue=6;
                }
            }else if(y1<=-55 && y1>=-60){
                if(y2>=55 && y2<=60){
                    rollValue=4;
                }else if(y2<=-55 && y2>=-60){
                    rollValue=7;
                }
            }
        }
        
        textBox.text = rollValue.ToString();
    }
    
    public void CheckRolld10(){
        
        float y,y1,y2;
        Vector3 vec = transform.right;
        Vector3 vec1 = transform.up;
        Vector3 vec2 = transform.forward;
        int rollValue =0;
        
        y=Mathf.Round(vec.y*100);
        y1=Mathf.Round(vec1.y*100);       
        y2=Mathf.Round(vec2.y*100);
        
        //Debug.Log("y:"+y.ToString() + " y1:"+y1.ToString() + " y2:"+y2.ToString());
        
        if(y>=47 && y<=50){
            if(y1>0)rollValue = 2;
            else rollValue = 3;
        }else if(y>=76 && y<=79){
            if(y1>0)rollValue = 5;
            else rollValue = 8;
        }else if(y>=-79 && y<=-76){
            if(y1>0)rollValue = 1;
            else rollValue = 4;
        }else if(y>=-50 && y<=-46){
            if(y1>0)rollValue = 6;
            else rollValue = 7;
        }else if(y>=0 && y<=3){
            if(y1>0)rollValue = 9;
            else rollValue = 10;
        }

        textBox.text = rollValue.ToString();
    }
    */
    public void CheckRolld12(){
        
        float y,y1,y2;
        Vector3 vec = transform.right;
        Vector3 vec1 = transform.up;
        Vector3 vec2 = transform.forward;
        int rollValue =0;
        
        y=Mathf.Round(vec.y*100);
        y1=Mathf.Round(vec1.y*100);       
        y2=Mathf.Round(vec2.y*100);
        
        //Debug.Log("y:"+y.ToString() + " y1:"+y1.ToString() + " y2:"+y2.ToString());

        
        
    }

}
/*tisting za kote kock
//float x,x1,x2;
        float y,y1,y2;
        //float z,z1,z2;
        Vector3 vec = transform.right;
        Vector3 vec1 = transform.up;
        Vector3 vec2 = transform.forward;
        int rollValue =0;
        
        //x=Mathf.Round(vec.x*100);
        y=Mathf.Round(vec.y*100);
        //z=Mathf.Round(vec.z*100);
        
        //x1=Mathf.Round(vec1.x*100);
        y1=Mathf.Round(vec1.y*100);
        //z1=Mathf.Round(vec1.z*100);

        //x2=Mathf.Round(vec2.x*100);
        y2=Mathf.Round(vec2.y*100);
        //z2=Mathf.Round(vec2.z*100);

        //Debug.Log("x:"+x.ToString() + " y1:"+x1.ToString() + " x2:"+x2.ToString());
        Debug.Log("y:"+y.ToString() + " y1:"+y1.ToString() + " y2:"+y2.ToString());
        //Debug.Log("z:"+z.ToString() + " y1:"+z1.ToString() + " y2:"+z2.ToString());
*/

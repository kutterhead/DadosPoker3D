using UnityEngine;

public class dado : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 rayDirection = Vector3.forward;
    public bool[] sides;
    public int valorDado = 0;
    //public int valorAbajo = 0;
    public int[] indicesCorrelacion;
    public char[] indicesCorrelacionChar;

    void Start()
    {
        //rayDirection = Vector3.forward;
       // rayDirection = transform.forward;



    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;

        valorDado = 0;
        for (int i =0; i< sides.Length; i++)
        {
          

            
            switch (i)
            {
                case 0:
                    rayDirection = -transform.forward;
                    //valorDado = 3;

                    break;
                case 1:
                    rayDirection = transform.right;
                    //valorDado = 4;
                    break;
                case 2:
                    rayDirection = transform.forward;
                    //valorDado = 1;
                    break;
                case 3:
                    rayDirection = -transform.right;
                    //valorDado = 2;
                    break;
                case 4:
                    rayDirection = transform.up;
                    //valorDado = 6;
                    break;

                default:
                    rayDirection = -transform.up;

                   
                    break;


            }


            //rayDirection = transform.up;
            
            if (Physics.Raycast(transform.position, rayDirection,out hit,1f,LayerMask.GetMask("Ground")))
            {
                Debug.Log(hit);
                Debug.DrawRay(transform.position, rayDirection, Color.green);
                sides[i] = true;
                valorDado = indicesCorrelacion[i];
            }
            else
            {
                Debug.DrawRay(transform.position, rayDirection, Color.red);

                sides[i]=false;
            }
           
            



        }




    }
}

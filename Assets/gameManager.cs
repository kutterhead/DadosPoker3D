
using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public dado[] dados;
    public int[] valorDados;

    public float torqueMax = 10f;
    public float velocityMax = 10f;
    void Start()
    {
        System.Array.Resize(ref(valorDados),dados.Length);

        //lanzaDados();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void lanzaDados()
    {
        Debug.Log("Dados lanzados");

        foreach (var dado in dados)
        {
            dado.resetPos();
            Vector3 randomAngleEuler = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            dado.gameObject.transform.localEulerAngles = randomAngleEuler;
            dado.gameObject.SetActive(true);
            float velocityY = Random.Range(0,velocityMax);
            float velocityZ = Random.Range(0, velocityMax);
            float velocityX = Random.Range(0, velocityMax);

            dado.gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(velocityX, -velocityY, velocityZ);
            Vector3 randomTorque = new Vector3(Random.Range(-torqueMax, torqueMax), Random.Range(-torqueMax, torqueMax), Random.Range(-torqueMax, torqueMax));

            dado.gameObject.GetComponent<Rigidbody>().angularVelocity = randomTorque;
            //dado.gameObject.GetComponent<Rigidbody>().linearVelocity = -transform.up*100;

        }




        Invoke(nameof(compruebaJugada),5f);
    }

    public void compruebaJugada()
    {
        Debug.Log("Jugada:");
        string jugada = "";
        for (int i=0; i< dados.Length;i++)
        {
            valorDados[i] = dados[i].valorDado;
            jugada += dados[i].valorDado + ",";
        }
        Debug.Log(jugada);
    }

}

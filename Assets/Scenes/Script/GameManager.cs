using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;

[Serializable]

public class TopAlaniTeknikIslemler
{

    public Animator TopAlaniAsansor;
    public TextMeshProUGUI SayiText;
    public int AtilmasiGerekenTop;
    public GameObject[] Toplar;
}




public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ToplayiciObje;
    [SerializeField] private GameObject TopKontrolOBjesi;
    public bool ToplayiciHareketDurumu;

    int AtilanTopSayisi;
    int ToplamCheckPointSayisi;
    int MevcutCheckPointIndex;


    [SerializeField] private List<TopAlaniTeknikIslemler> _TopAlaniTeknikIslemler = new List<TopAlaniTeknikIslemler>();



    void Start()
    {
         ToplayiciHareketDurumu = true;
        _TopAlaniTeknikIslemler[0].SayiText.text = AtilanTopSayisi + "/" + _TopAlaniTeknikIslemler[0].AtilmasiGerekenTop;
       
    }

    void Update()
    {

        if (ToplayiciHareketDurumu)
        {
            ToplayiciObje.transform.position += 5f * Time.deltaTime * ToplayiciObje.transform.forward;

            if (Time.timeScale != 0)
            {

                if (Input.GetKey(KeyCode.A))
                {
                    Debug.Log("Calýstý");
                    ToplayiciObje.transform.position = Vector3.Lerp(ToplayiciObje.transform.position, new Vector3
                   (ToplayiciObje.transform.position.x - .1f, ToplayiciObje.transform.position.y,
                    ToplayiciObje.transform.position.z), 0.4f);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    Debug.Log("Calýstý");
                    ToplayiciObje.transform.position = Vector3.Lerp(ToplayiciObje.transform.position, new Vector3
                   (ToplayiciObje.transform.position.x + .1f, ToplayiciObje.transform.position.y,
                    ToplayiciObje.transform.position.z), 0.4f);

                }



            }
        }

    }

    public void SiniraGelindi()
    {
        ToplayiciHareketDurumu = false;

        Invoke("AsamaKontrol",2f);

        Collider[] HitColl = Physics.OverlapBox(TopKontrolOBjesi.transform.position, TopKontrolOBjesi.transform.localScale /
            2, Quaternion.identity);

        int i = 0;
        while (i < HitColl.Length) 
        {
            // rigidbodye eriþecek ve ona z ekseninde bir güç ver demiþ oluyoruz asagida 

            HitColl[i].GetComponent<Rigidbody>().AddForce(new Vector3(0,0,.8f),ForceMode.Impulse);

            i++;

        }

        Debug.Log(i);

    }


    public void ToplariSay() 
    {

        AtilanTopSayisi++;
        _TopAlaniTeknikIslemler[0].SayiText.text = AtilanTopSayisi + "/" + _TopAlaniTeknikIslemler[0].AtilmasiGerekenTop;

    }


    void AsamaKontrol() 
    {

        if (AtilanTopSayisi >= _TopAlaniTeknikIslemler[0].AtilmasiGerekenTop)
        {
            Debug.Log("KAZANDÝN");

            _TopAlaniTeknikIslemler[0].TopAlaniAsansor.Play("Asansor");


            foreach (var item in _TopAlaniTeknikIslemler[0].Toplar) //bütün toplarý yönetebilirim bu kod sayesinde (gamemanager da elementte 20 topu da yönetebilirim=)
            { // bu komut o platform üzerinde yeterli sayýda topu asansöre ulastýrdýktan sonra kazandý yazýsýný gördükten sonra bütün toplarý yok etme komutu. zaten daha sonra platformu uzatýnca asansörle digerr plaltforma geciyosun gibi düþün.)
                item.SetActive(false);
            }

        }
        else
        {
            Debug.Log("KAYBETTÝN");
        }

        


    }




    /*
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(TopKontrolOBjesi.transform.position, TopKontrolOBjesi.transform.localScale);

    }
    */


}

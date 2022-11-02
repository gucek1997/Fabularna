using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine;


public class ParseXML : MonoBehaviour
{

    public TextAsset xmlRawFile;
    public Text pyta;
    public Text odpy1;
    public Text odpy2;
    public Text odpy3;

    string pytanie1;
    string odpowiedz1;
    string odpowiedz2;
    string odpowiedz3;
    string dobra;
    //inicjalizacja liczby i pierwsza 
    int liczba_wylosowana;
    string pierwsza = "//aarlangdi/odp"; //przypisanie znacznikow gdzie jest pytanie
    public int udzielono_odpowiedzi = 1;
    public int wartosc = 0;
    //kanwasy 
    public Canvas Pytanie;
    public Canvas CanvaDobraodp;
    public Canvas CanvaZlaodp;
 
    //tablica do pamietania pytan
    int[] tablica = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };



    void Start()
    {
        //losowaie liczby
        liczba_wylosowana = Random.Range(1, 3);
        //tworzenie pliku xml
        string data = xmlRawFile.text;
        pierwsza = pierwsza + liczba_wylosowana; //przypisanie wylosowanej liczby do znacznika
        parseXmlFile(data);  //wywolanie funkcji paroswania xml

        
                     
    }



    private void Zlaodpowiedz()
    {
        liczba_wylosowana = Random.Range(1, 3);
        for (int i = 0; i <= 10; i++)
        {
            if (liczba_wylosowana == tablica[i])
            {
                Zlaodpowiedz();
            }
        }
        pierwsza = "//aarlangdi/odp";
        pierwsza = pierwsza + liczba_wylosowana;
        string data = xmlRawFile.text;
        parseXmlFile(data);
    }

    //skrypt to odpowiedzi peirwszej
    public void Pierwszaodp()
    {
        if (odpowiedz1 == dobra)
        {

            udzielono_odpowiedzi++;
            wartosc++;
            Pytanie.enabled = false;
            CanvaDobraodp.enabled = true;
            StartCoroutine(Test());
            if (wartosc == 9)
            {
                CanvaDobraodp.enabled = false;
            }
            tablica[wartosc] = liczba_wylosowana;
            Zlaodpowiedz();


        }
        else
        {
            Zlaodpowiedz();
            CanvaZlaodp.enabled = true;
            StartCoroutine(Test());
        }
    }
    //skrypt do odpowiedzi drugiej
    public void Drugaodp()
    {
        if (odpowiedz2 == dobra)
        {
            udzielono_odpowiedzi++;
            wartosc++;
            Pytanie.enabled = false;
            CanvaDobraodp.enabled = true;
            StartCoroutine(Test());

            if (wartosc == 9)
            {
                CanvaDobraodp.enabled = false;
            }
            tablica[wartosc] = liczba_wylosowana;
            Zlaodpowiedz();
        }
        else
        {
            Zlaodpowiedz();
            CanvaZlaodp.enabled = true;
            StartCoroutine(Test());
        }
    }
    //skrypt do odopowiedzi trzeciej
    public void Trzeciaodp()
    {
        if (odpowiedz3 == dobra)
        {
            udzielono_odpowiedzi++;
            wartosc++;
            Pytanie.enabled = false;
            CanvaDobraodp.enabled = true;
            StartCoroutine(Test());

            if (wartosc == 9)
            {
                CanvaDobraodp.enabled = false;

            }
            tablica[wartosc] = liczba_wylosowana;
            Zlaodpowiedz();
        }
        else
        {
            Zlaodpowiedz();
            CanvaZlaodp.enabled = true;
            StartCoroutine(Test());
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        CanvaDobraodp.enabled = false;
        CanvaZlaodp.enabled = false;
    }

    void parseXmlFile(string xmlData)
    {

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        string xmlPathPattern = pierwsza;  //podstawienie znacznikow  
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach (XmlNode node in myNodeList)
        {
            XmlNode pytanie = node.FirstChild;
            XmlNode odp1 = pytanie.NextSibling;
            XmlNode odp2 = odp1.NextSibling;
            XmlNode odp3 = odp2.NextSibling;
            XmlNode good = odp3.NextSibling;
            //pzypisanie wyciagnietych linijek z xml 
            pytanie1 = pytanie.InnerXml;
            odpowiedz1 = odp1.InnerXml;
            odpowiedz2 = odp2.InnerXml;
            odpowiedz3 = odp3.InnerXml;
            dobra = good.InnerXml;
        }
        //przypisanie do unity zmiennych
        pyta.text = pytanie1;
        odpy1.text = odpowiedz1;
        odpy2.text = odpowiedz2;
        odpy3.text = odpowiedz3;

    }


    



}

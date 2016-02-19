using UnityEngine;
using System.Collections;
using System.Xml;

public class ParseXML : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        TextAsset xmlFile = Resources.Load("productListing") as TextAsset;

        XmlDocument xmlDoc = new XmlDocument();
        //3 types of reading xml docs.
            //XmlDocument - entire document
            //XmlTextReader - doesn't cache, forward moving
            //XmlReader - does cache, forward moving

        xmlDoc.LoadXml(xmlFile.text);

        //Debug.Log(xmlDoc.DocumentElement.Name);
        //Debug.Log(xmlDoc.DocumentElement.GetAttribute("title"));
        //Debug.Log(xmlDoc.DocumentElement.FirstChild.Name);
        //Debug.Log(xmlDoc.DocumentElement.FirstChild.FirstChild.InnerText);

        //Debug.Log(xmlDoc.DocumentElement.FirstChild.ChildNodes);

        foreach(XmlNode node in xmlDoc.DocumentElement.ChildNodes)
        {
            foreach (XmlNode node2 in node.ChildNodes)
            {
                Debug.Log(node.Name +" - "+ node2.Name +" - "+ node2.InnerText);
            }
        }

        /*
        foreach(XmlNode node in xmlDoc.DocumentElement.FirstChild.ChildNodes)
        {
            Debug.Log(node.InnerText);
        }
        */
    }

    // Update is called once per frame
    void Update () {
	
	}
}

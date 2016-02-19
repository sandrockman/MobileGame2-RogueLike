using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public class ParseCDCatalog : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
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

        foreach (XmlNode node in xmlDoc.DocumentElement)
        {
            int cdYear = 0;
            string title = "t", artist = "a", country = "cu", company = "cm";

            //output the information into the debug
            foreach (XmlNode node2 in node.ChildNodes)
            {
                //if year of CD is after 1980, Output the Title/Artist
                //if year of CD is after 1990, Output the Title/Artist/Country/Company
                //Don't output anything if CD year is 2000 or later
                //Debug.Log(node.Name + " - " + node2.Name + " - " + node2.InnerText);
                if (node2.Name == "TITLE")
                {
                    title = node2.InnerText;
                }
                if (node2.Name == "ARTIST")
                {
                    artist = node2.InnerText;
                }
                if (node2.Name == "COUNTRY")
                {
                    country = node2.InnerText;
                }
                if (node2.Name == "COMPANY")
                {
                    company = node2.InnerText;
                }
                if (node2.Name == "YEAR")
                {
                    cdYear = Convert.ToInt32(node.LastChild.InnerText);
                }

            }
            if(cdYear < 2000)
            {
                if(cdYear > 1990)
                {
                    Debug.Log(title + ", " + artist + ", " + country + ", " + company);
                }
                else if(cdYear > 1980)
                {
                    Debug.Log(title + ", " + artist);

                }
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

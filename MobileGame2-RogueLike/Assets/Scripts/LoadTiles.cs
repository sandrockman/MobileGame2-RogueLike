using UnityEngine;
using System.Collections;
using System.Xml;

public class LoadTiles : MonoBehaviour {

    //holds the .xml file
    public TextAsset mapInformation;

    //a temporary tile object
    public GameObject tempCube;

    private Sprite[] sprites;

    // Use this for initialization
    void Start () {
        //Load Sprites into the sprite array
        //sprites = Resources.Load("roguelikeSheet_magenta") as Sprite;
        sprites = Resources.LoadAll<Sprite>("RPGpack_sheet");
        Debug.Log(sprites.Length);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(mapInformation.text);

        //Maneuver the camera
        //Camera.main.transform.position = new Vector3(9.9f, -9.9f, 10f);
        //Camera.main.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        XmlNodeList layerNames = xmlDoc.GetElementsByTagName("layer");
        Debug.Log(layerNames.Count);
        foreach(XmlNode node in layerNames)
        {
            //Debug.Log(node.Attributes[0].InnerText);
            //Debug.Log(node.Attributes.GetNamedItem("name").InnerText);
            //Debug.Log(node.Attributes["name"].Value);
        }

        XmlNode tileSetInfo = xmlDoc.SelectSingleNode("map").SelectSingleNode("tileset");

        float tileWidth = int.Parse(tileSetInfo.Attributes["tilewidth"].Value)/ (float)100;
        float tileHeight = int.Parse(tileSetInfo.Attributes["tileheight"].Value)/ (float)100;
        //Debug.Log(tileWidth);
        //Debug.Log(int.Parse(tileSetInfo.Attributes["tilewidth"].Value));
        //float tileWidth = float.Parse(tileSetInfo.Attributes["tilewidth"].Value);
        //float tileHeight = float.Parse(tileSetInfo.Attributes["tileheight"].Value);

        //for each layer that exists
        foreach (XmlNode layerInfo in layerNames)
        {
            int layerWidth = int.Parse(layerInfo.Attributes["width"].Value);
            int layerHeight = int.Parse(layerInfo.Attributes["height"].Value);

            if (layerInfo.Attributes["name"].Value == "Background")
            {
                //Pull out the data node
                XmlNode tempNode = layerInfo.SelectSingleNode("data");

                int mapLocVert, mapLocHorz;
                mapLocHorz = mapLocVert = 0;

                foreach (XmlNode tile in tempNode.SelectNodes("tile"))
                {
                    int spriteValue = int.Parse(tile.Attributes["gid"].Value);

                    if (spriteValue > 0)
                    {
                        GameObject tempSprite = new GameObject("test");
                        SpriteRenderer renderer = tempSprite.AddComponent<SpriteRenderer>();
                        renderer.sprite = sprites[spriteValue - 1];

                        float locationX = tileWidth * mapLocHorz;
                        float locationY = tileHeight * mapLocVert;
                        Vector3 newLocation = new Vector3(locationX, locationY, 0f);

                        tempSprite.transform.position = new Vector3(locationX, locationY, 0);

                        //renderer.sortingLayerName = layerInfo.Attributes["name"].Value;
                        renderer.sortingLayerName = "Background";

                        //Instantiate(tempCube, newLocation, Quaternion.identity);

                    }
                    //incr. our loc. along the horz.
                    mapLocHorz++;

                    if (mapLocHorz % layerWidth == 0)
                    {
                        //incr. our vertical location.
                        mapLocVert++;
                        //reset our horz. location
                        mapLocHorz = 0;
                    }
                }
            }
            if (layerInfo.Attributes["name"].Value == "Obstacles")
            {
                //Pull out the data node
                XmlNode tempNode = layerInfo.SelectSingleNode("data");

                int mapLocVert, mapLocHorz;
                mapLocHorz = mapLocVert = 0;

                foreach (XmlNode tile in tempNode.SelectNodes("tile"))
                {
                    int spriteValue = int.Parse(tile.Attributes["gid"].Value);

                    if (spriteValue > 0)
                    {
                        GameObject tempSprite = new GameObject("test");
                        SpriteRenderer renderer = tempSprite.AddComponent<SpriteRenderer>();
                        renderer.sprite = sprites[spriteValue - 1];

                        float locationX = tileWidth * mapLocHorz;
                        float locationY = tileHeight * mapLocVert;
                        Vector3 newLocation = new Vector3(locationX, locationY, 0f);

                        tempSprite.transform.position = new Vector3(locationX, locationY, 0);

                        //renderer.sortingLayerName = layerInfo.Attributes["name"].Value;
                        renderer.sortingLayerName = "Obstacles";

                        //Instantiate(tempCube, newLocation, Quaternion.identity);

                    }
                    //incr. our loc. along the horz.
                    mapLocHorz++;

                    if (mapLocHorz % layerWidth == 0)
                    {
                        //incr. our vertical location.
                        mapLocVert++;
                        //reset our horz. location
                        mapLocHorz = 0;
                    }
                }
            }
            if (layerInfo.Attributes["name"].Value == "Accents")
            {
                //Pull out the data node
                XmlNode tempNode = layerInfo.SelectSingleNode("data");

                int mapLocVert, mapLocHorz;
                mapLocHorz = mapLocVert = 0;

                foreach (XmlNode tile in tempNode.SelectNodes("tile"))
                {
                    int spriteValue = int.Parse(tile.Attributes["gid"].Value);

                    if (spriteValue > 0)
                    {
                        GameObject tempSprite = new GameObject("test");
                        SpriteRenderer renderer = tempSprite.AddComponent<SpriteRenderer>();
                        renderer.sprite = sprites[spriteValue - 1];

                        float locationX = tileWidth * mapLocHorz;
                        float locationY = tileHeight * mapLocVert;
                        Vector3 newLocation = new Vector3(locationX, locationY, 0f);

                        tempSprite.transform.position = new Vector3(locationX, locationY, 0);

                        //renderer.sortingLayerName = layerInfo.Attributes["name"].Value;
                        renderer.sortingLayerName = "Accents";

                        //Instantiate(tempCube, newLocation, Quaternion.identity);

                    }
                    //incr. our loc. along the horz.
                    mapLocHorz++;

                    if (mapLocHorz % layerWidth == 0)
                    {
                        //incr. our vertical location.
                        mapLocVert++;
                        //reset our horz. location
                        mapLocHorz = 0;
                    }
                }
            }
            if (layerInfo.Attributes["name"].Value == "Interactive")
            {
                //Pull out the data node
                XmlNode tempNode = layerInfo.SelectSingleNode("data");

                int mapLocVert, mapLocHorz;
                mapLocHorz = mapLocVert = 0;

                foreach (XmlNode tile in tempNode.SelectNodes("tile"))
                {
                    int spriteValue = int.Parse(tile.Attributes["gid"].Value);

                    if (spriteValue > 0)
                    {
                        GameObject tempSprite = new GameObject("test");
                        SpriteRenderer renderer = tempSprite.AddComponent<SpriteRenderer>();
                        renderer.sprite = sprites[spriteValue - 1];

                        float locationX = tileWidth * mapLocHorz;
                        float locationY = tileHeight * mapLocVert;
                        Vector3 newLocation = new Vector3(locationX, locationY, 0f);

                        tempSprite.transform.position = new Vector3(locationX, locationY, 0);

                        //renderer.sortingLayerName = layerInfo.Attributes["name"].Value;
                        renderer.sortingLayerName = "Interactive";

                        //Instantiate(tempCube, newLocation, Quaternion.identity);

                    }
                    //incr. our loc. along the horz.
                    mapLocHorz++;

                    if (mapLocHorz % layerWidth == 0)
                    {
                        //incr. our vertical location.
                        mapLocVert++;
                        //reset our horz. location
                        mapLocHorz = 0;
                    }
                }
            }
            if (layerInfo.Attributes["name"].Value == "Foreground")
            {
                //Pull out the data node
                XmlNode tempNode = layerInfo.SelectSingleNode("data");

                int mapLocVert, mapLocHorz;
                mapLocHorz = mapLocVert = 0;

                foreach (XmlNode tile in tempNode.SelectNodes("tile"))
                {
                    int spriteValue = int.Parse(tile.Attributes["gid"].Value);

                    if (spriteValue > 0)
                    {
                        GameObject tempSprite = new GameObject("test");
                        SpriteRenderer renderer = tempSprite.AddComponent<SpriteRenderer>();
                        renderer.sprite = sprites[spriteValue - 1];

                        float locationX = tileWidth * mapLocHorz;
                        float locationY = tileHeight * mapLocVert;
                        Vector3 newLocation = new Vector3(locationX, locationY, 0f);

                        tempSprite.transform.position = new Vector3(locationX, locationY, 0);

                        //renderer.sortingLayerName = layerInfo.Attributes["name"].Value;
                        renderer.sortingLayerName = "Foreground";

                        //Instantiate(tempCube, newLocation, Quaternion.identity);

                    }
                    //incr. our loc. along the horz.
                    mapLocHorz++;

                    if (mapLocHorz % layerWidth == 0)
                    {
                        //incr. our vertical location.
                        mapLocVert++;
                        //reset our horz. location
                        mapLocHorz = 0;
                    }
                }
            }

        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}

using UnityEngine;
using System.Xml;
using System.IO;

public class SampleMain
{
    private string sanmplestr;
    void Start() {
    }
    public void XmlPerse(string xmlString)
    { // string型で渡ってきたとする

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlString));

        XmlNode root = xmlDoc.FirstChild;

        XmlNodeList talkList = xmlDoc.GetElementsByTagName("talk");

        XmlNode talk0 = talkList[0];
        XmlNode talk1 = talkList[1];

        XmlNodeList speakList0 = talk0.ChildNodes;
        XmlNodeList speakList1 = talk1.ChildNodes;

        Debug.Log(root.Name); // talks

        Debug.Log(talk0.Attributes["person"].Value); // 2
        Debug.Log(talk1.Attributes["person"].Value); // 1

        Debug.Log(speakList0[0].Attributes["content"].Value); // こんにちは
        Debug.Log(speakList0[1].Attributes["content"].Value); // ありがとう
        Debug.Log(speakList0[2].Attributes["content"].Value); // さようなら

        Debug.Log(speakList0[0].Attributes["num"].Value); // 1
        Debug.Log(speakList0[1].Attributes["num"].Value); // 2
        Debug.Log(speakList0[2].Attributes["num"].Value); // 3

        Debug.Log(speakList1[0].Attributes["content"].Value); // あーい
        Debug.Log(speakList1[1].Attributes["content"].Value); // ふーい 
        Debug.Log(speakList1[2].Attributes["content"].Value); // ねむい

        Debug.Log(speakList1[0].Attributes["num"].Value); // 4
        Debug.Log(speakList1[1].Attributes["num"].Value); // 5 
        Debug.Log(speakList1[2].Attributes["num"].Value); // 6
    }
}
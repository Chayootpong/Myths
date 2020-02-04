using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : Photon.MonoBehaviour {

    public Text nameTag;

    void Update()
    {
        if (photonView.isMine)
        {
            StartCoroutine("Delaytime");
        }
    }

    IEnumerator Delaytime()
    {
        yield return new WaitForSeconds(1);
        photonView.RPC("UpdateName", PhotonTargets.All, ConnectAndJoinRandom.charName);
    }

    [PunRPC] //รอรับค่า
    public void UpdateName(string names)
    {
        nameTag.text = names;

        //Debug.Log(nameTag.text);
    }

    

    //อธิบายหลักการคร่าวๆ
    //ตัวแปรของทุกตัวละครจะเหมือนกันหมด แต่ค่าของตัวแปรจะแตกต่างกันออกไปตาม Action ในจอตัวเอง แปลว่าถึงชื่อเหมือนกันแต่ค่าจะไม่เท่ากัน
    //ค่อยเรียกส่งค่าให้คนอื่นเห็นเมื่อตำนวณเสร็จแล้วก็ได้ ไม่ใช่อัพเดทแม้แต่การคำนวณ
    //การเปรียบเทียบค่า คือที่จะลองวันที่ 13/12/60 แหละ คาดว่าเอาตัวแปรฝั่งเราไปเช็ค .All หรือ Other เทียบว่าตรงไหม ถ้าตรงก็ทำ Action
    //แปลว่าเราต้องเขียน Script ของตัวละครแยกกันไว้จะดีกว่า ถึงสุดท้ายต้องเอามารวมทั้งหมดอีกทีก็เถอะ
    //ส่วนที่อัพเดทคือตรงรับค่า เพื่อที่จะ Return ค่าคืน ไม่ใช่ตรงคำสั่ง .NPC
    //นอกเหนือจากนั้น ในส่วนที่ไม่ส่งค่าก็นำไปใช้อะไรตามปกติก็ได้
    //ตัวแปรคร่าวๆที่ต้องใช้ เช็คเทิร์น ทำ DMG ค่า HP DMG Overtime Checkstatus Dead Checkpoint โดยคร่าวๆ
    //การลด CD สามารถทำได้โดยไม่ต้องส่งค่าให้ผู้อืน
    //จริงๆมีอีกงาน ทำให้การเคลื่อที่ Smooth กว่านี้ Transform
    //ระบบ Lobby จะศึกษาก็ได้ ทำได้ก็ดี
}

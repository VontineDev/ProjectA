using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MarchingBytes;

public class TestHUD : MonoBehaviour
{
    public Camera mainCam;
    public UIRoot uiRoot;
    public EasyObjectPool easyObjectPool;
    private void Start()
    {
        easyObjectPool.Init();
        LoadHudText1();
        LoadHudText2();
    }
    public void LoadHudText1()
    {
        var prefab = Resources.Load<GameObject>("UI_HudText1");
        Debug.Log($"{prefab.name}");
        EasyObjectPool.instance.MakePoolInfo("UI_HudText1", prefab, 10);

    }
    public void LoadHudText2()
    {
        var prefab = Resources.Load<GameObject>("UI_HudText2");
        Debug.Log($"{prefab.name}");
        EasyObjectPool.instance.MakePoolInfo("UI_HudText2", prefab, 10);
    }
    private void DisplayHudText(UIRoot uiRoot, Vector3 monsterPos)
    {
        Vector3 v = mainCam.WorldToScreenPoint(monsterPos);
        //Debug.Log(v);

        v.x = (v.x / Screen.width) * 1080;
        v.y = (v.y / Screen.height) * 1920;
        v.z = 0;
        var pos = v - new Vector3(1080 / 2, 1920 / 2, 0);
        //Debug.Log(v);
        //Debug.Log(v - new Vector3(1080 / 2, 1920 / 2, 0));
        var hudTextGo = EasyObjectPool.instance.GetObjectFromPool("UI_HudText1", Vector3.zero, Quaternion.identity);
        var hud = hudTextGo.GetComponent<UI_HudText>();
        hud.Init(uiRoot, pos, 10f);
        hud.OnTweenEndCall = () =>
        {
            EasyObjectPool.instance.ReturnObjectToPool(hud.gameObject);

        };
        hud.Play();
    }
    private void DisplayHudText2(UIRoot uiRoot, Vector3 monsterPos)
    {
        Vector3 v = mainCam.WorldToScreenPoint(monsterPos);
        //Debug.Log(v);

        v.x = (v.x / Screen.width) * 1080;
        v.y = (v.y / Screen.height) * 1920;
        v.z = 0;
        var pos = v - new Vector3(1080 / 2, 1920 / 2, 0);
        //Debug.Log(v);
        //Debug.Log(v - new Vector3(1080 / 2, 1920 / 2, 0));
        var hudTextGo = EasyObjectPool.instance.GetObjectFromPool("UI_HudText1", Vector3.zero, Quaternion.identity);
        var hud = hudTextGo.GetComponent<UI_HudText>();
        hud.Init(uiRoot, pos, 10f);
        hud.OnTweenEndCall = () =>
        {
            EasyObjectPool.instance.ReturnObjectToPool(hud.gameObject);
        };
        hud.Play2();
    }
    private void DisplayHudText3(UIRoot uiRoot, Vector3 monsterPos)
    {
        Vector3 v = mainCam.WorldToScreenPoint(monsterPos);
        //Debug.Log(v);

        v.x = (v.x / Screen.width) * 1080;
        v.y = (v.y / Screen.height) * 1920;
        v.z = 0;
        var pos = v - new Vector3(1080 / 2, 1920 / 2, 0);
        //Debug.Log(v);
        //Debug.Log(v - new Vector3(1080 / 2, 1920 / 2, 0));
        var hudTextGo = EasyObjectPool.instance.GetObjectFromPool("UI_HudText2", Vector3.zero, Quaternion.identity);
        var hud = hudTextGo.GetComponent<UI_HudText2>();
        hud.Init(uiRoot, pos, 10f);
        hud.OnTweenEndCall = () =>
        {
            EasyObjectPool.instance.ReturnObjectToPool(hud.gameObject);
        };
        hud.Play();
    }
    private void DisplayHudText4(UIRoot uiRoot, Vector3 monsterPos)
    {
        Vector3 v = mainCam.WorldToScreenPoint(monsterPos);
        //Debug.Log(v);

        v.x = (v.x / Screen.width) * 1080;
        v.y = (v.y / Screen.height) * 1920;
        v.z = 0;
        var pos = v - new Vector3(1080 / 2, 1920 / 2, 0);
        //Debug.Log(v);
        //Debug.Log(v - new Vector3(1080 / 2, 1920 / 2, 0));
        var hudTextGo = EasyObjectPool.instance.GetObjectFromPool("UI_HudText2", Vector3.zero, Quaternion.identity);
        var hud = hudTextGo.GetComponent<UI_HudText2>();
        hud.Init(uiRoot, pos, 10f);
        hud.OnTweenEndCall = () =>
        {
            EasyObjectPool.instance.ReturnObjectToPool(hud.gameObject);
        };
        hud.Play2();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Plane에 쏘는레이
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.cyan, 1f);
            Vector3 point = Vector3.zero;
            if (Physics.Raycast(ray, out hit, 100))//Plane과 충돌 확인
            {
                point = hit.point;
            }

            var pos = point;

            DisplayHudText(uiRoot, pos);

            var pos2 = pos;
            pos2.x += 10;
            DisplayHudText2(uiRoot, pos2);

            var pos3 = pos;
            pos3.y += 20;
            DisplayHudText3(uiRoot, pos3);
            var pos4 = pos3;
            pos4.x += 10;
            DisplayHudText4(uiRoot, pos4);
            //lbDamage.transform.localPosition = v - new Vector3(1080 / 2, 1920 / 2, 0) - 50 * Vector3.up;
            //lbDamage.transform.position = UICamera.mainCamera.ViewportToScreenPoint(Input.mousePosition);

        }
    }
}
